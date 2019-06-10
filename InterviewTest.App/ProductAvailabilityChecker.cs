using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewTest.App
{
    public class ProductAvailabilityChecker
    {
        public IProduct Product { get; }

        public ProductAvailabilityChecker(IProduct product)
        {
            Product = product;
        }

        public void CheckIfAvailable()
        {
            Thread.Sleep(5000);//Let us to check 
            Result = true;
        }
        public async Task<ProductAvailabilityChecker> CheckIfAvailableAsync()
        {
            return await Task.Run(() =>
            {
                //Let us to check 
                Thread.Sleep(5000);
                this.Result = true;
                return this;
            });

        }
        public bool Result { get; private set; }
    }
}
