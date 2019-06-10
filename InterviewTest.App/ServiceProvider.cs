using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.App
{
	public partial class ServiceProvider
	{
		public static ServiceProvider Instance { get; }=new ServiceProvider();
		public IProductStore ProductStore { get; }= new ProductStore();

        public string[] ProductTypes = new string[] {"Vegetable","Fruit","Pizza"};

        public IProduct CreateOBject(string type, string name, int qty, int unitprice)
        {
            IProduct p= null;
            switch (type)
            {
                case "Vegetable":
                    p = new Vegetable(name, qty, unitprice);
                    break;

                case "Fruit":
                    p = new Fruit(name, qty, unitprice);

                    break;

                case "Pizza":
                    p = new Pizza(name, qty, unitprice);

                    break;
            }
            return p;
        }
    }
}
