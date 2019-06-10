using System;

namespace InterviewTest.App
{
    internal class Pizza : IProduct
    {
        private int qty;
        public Guid Id { get; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice
        {
            get { return UnitPrice * Count; }
        }
        public HealthIndex HealthIndex { get; }

        public Pizza(string name, int qty, int unitprice)
        {
            this.Name = name;
            this.qty = qty;
            this.UnitPrice = unitprice;
        }
    }
}