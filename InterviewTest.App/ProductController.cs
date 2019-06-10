using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.App
{
    public partial class ServiceProvider
    {
        internal System.Collections.Concurrent.ConcurrentBag<string> messages = new System.Collections.Concurrent.ConcurrentBag<string>();


        public ServiceProvider()
        {
            ProductStore.ProductAdded += _productStore_ProductAdded;
            ProductStore.ProductRemoved += _productStore_ProductRemoved;
        }


        private void _productStore_ProductRemoved(Guid obj)
        {
            //IProduct possibleProduct = _products.FirstOrDefault(p => p.Id == obj);
            //if (possibleProduct != null)
            //{
            //    _products.Remove(possibleProduct);
            //    //RefreshProducts();
            //}
        }
        private void _productStore_ProductAdded(IProduct obj)
        {
            //_products.Add(obj);
            //RefreshProducts();
        }

        public void CheckAvailibilities()
        {
            messages = new System.Collections.Concurrent.ConcurrentBag<string>();
            var tasks = (from p in ProductStore
                         select
    new ProductAvailabilityChecker(p).CheckIfAvailableAsync().ContinueWith((bt) =>
    {
        if (bt.Result.Result == false)
        {
            messages.Add("The product " + bt.Result.Product.Name + " is not available");
        }
    })
 ).ToArray();

            Task.WaitAll(tasks);
        }
    }
}
