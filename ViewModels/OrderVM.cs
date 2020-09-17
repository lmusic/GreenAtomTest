using System;
using System.Collections.Generic;

namespace TestGreenAtom.ViewModels
{
    public class OrderVM
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
