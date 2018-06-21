using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Product
    {
        public Product()
        {
            TransactionItem = new HashSet<TransactionItem>();
        }

        public int ProductId { get; set; }
        public int ProductType { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public byte[] Image { get; set; }

        public ProductType ProductTypeNavigation { get; set; }
        public ICollection<TransactionItem> TransactionItem { get; set; }
    }
}
