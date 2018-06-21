using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class TransactionItem
    {
        public int TransactionItemId { get; set; }
        public int? TransactionId { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public Transaction Transaction { get; set; }
    }
}
