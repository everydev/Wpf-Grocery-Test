using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewTest.App
{
	public class ProductStore: ObservableCollection<IProduct>, IProductStore
	{
        public event Action<IProduct> ProductAdded;
        public event Action<Guid> ProductRemoved;

        //private readonly List<IProduct> _products = new List<IProduct>();
        public IEnumerable<IProduct> LoadProducts()
		{
            //return _products.ToList();
            return this.ToList();
		}

		public ProductStore():base()
		{
            //NOTE: NO NEED TO CHANGE THIS; 
            //_products.AddRange(new IProduct[]
            //{
            //	new Fruit("Orange", 5,3),
            //	new Vegetable("Salad", 3,6)
            //});
            this.Add(new Fruit("Orange", 5, 3));
            this.Add(new Fruit("Apple", 15, 2));
            this.Add(new Vegetable("Salad", 3, 6));
            this.Add(new Pizza("Vegan Pizza", 3, 6));

        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    ProductAdded?.Invoke((IProduct)e.NewItems[0]);

                    Thread.Sleep(5000);//DO NOT REMOVE; TO SIMULATE A BUGGY/SLOW SERVICE
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Thread.Sleep(5000);
                    break;
            }
         
        }

		public void Remove(Guid productId)
		{
			IProduct product = this.FirstOrDefault(p => p.Id.Equals(productId));
			if (product != null)
			{
                base.Remove(product);
			}
		}	
	}
}
