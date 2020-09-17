using System;

namespace TestGreenAtom.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }

        public int Price { get; private set; }

        public Guid? OrderId { get; private set; }

        public Order Order { get; private set; }

        protected Product()
        {

        }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangePrice(int price)
        {
            Price = price;
        }
    }
}
