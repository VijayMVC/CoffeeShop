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
using System.Data.Entity;

namespace CoffeeShop
{
    public partial class ProductGrid : Form
    {
        //private CoffeeShopContext _context = new CoffeeShopContext();
        private BindingSource productBindingSource;
        public ProductGrid(BindingSource bs)
        {
            InitializeComponent();
            productBindingSource = bs;
            

            dgProductGrid.DataSource = productBindingSource;
            dgProductGrid.Columns["ProductType"].Visible = false;
            dgProductGrid.Columns["ProductTypeNavigation"].Visible = false;
            dgProductGrid.Columns["TransactionItem"].Visible = false;

        }
    }
}
