using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    
    public partial class Payment : Form
    {
        private decimal? _changeDue;
        private decimal? _amtReceived;
        private CoffeeShopContext _context = new CoffeeShopContext();
        private decimal? _subtotal;
        private BindingList<Product> _orderItems;
        public Payment(BindingList<Product> bs, decimal? st)
        {
            InitializeComponent();
            _orderItems = bs;
            _subtotal = st;
            tbAmtDue.Text = String.Format("{0:C}",_subtotal);

        
        }

        private void btnTender_Click(object sender, EventArgs e)
        {
            _amtReceived = Convert.ToDecimal(tbAmtReceived.Text);
            if(_amtReceived < _subtotal)
            {
                MessageBox.Show("Insufficient Payment. Please Try Again");
            }
            else
            {
                TenderPayment(_amtReceived);
                processTransaction();
            }
            
        }
        private void TenderPayment(decimal? amtReceived)
        {
            _changeDue = _amtReceived - _subtotal;
            //TODO: event...REGISTER DOOR UNLOCKS
            MessageBox.Show("Change Due: " + _changeDue);
        }
        private void processTransaction()
        {
            var transaction = new Transaction { Date = DateTime.Now };
            _context.Transaction.Add(transaction);
            foreach(var item in _orderItems)
            {
                var transItem = new TransactionItem
                {
                    TransactionId = transaction.TransactionId,
                    ProductId = item.ProductId
                };
                _context.TransactionItem.Add(transItem);
            }
            _context.SaveChanges();
            //PRINT RECEIPT

            
            Console.WriteLine(transaction.TransactionId);
            Console.WriteLine(transaction.Date);
            Console.WriteLine();
            foreach(var item in _orderItems)
            {
                Console.WriteLine(item.Description + " " + item.Price);
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL: " + _subtotal);
            Console.WriteLine("Amount Received: " + _amtReceived);
            Console.WriteLine("Change: " + String.Format("{0:c}",_changeDue));
            Console.WriteLine();
            Console.WriteLine("THANK YOU FOR YOUR ORDER!!");
        }
    }
}
