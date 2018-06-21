using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Product = new HashSet<Product>();
        }

        public int ProductType1 { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
