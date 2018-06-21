using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionItem = new HashSet<TransactionItem>();
        }

        public int TransactionId { get; set; }
        public DateTime? Date { get; set; }

        public ICollection<TransactionItem> TransactionItem { get; set; }
    }
}
