using System;
using System.Collections.Generic;

namespace TestGreenAtom.Models
{
    public class Order : BaseEntity
    {
        public DateTime CreationDate { get; }
        public string Description { get; private set; }

        public List<Product> Products { get; private set; }

        protected Order()
        {

        }

        public Order(string description, List<Product> products)
        {
            Description = description;
            CreationDate = DateTime.Now;
            Products = products;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void ChangeProductList(List<Product> products)
        {
            Products = products;
        }
    }
}
