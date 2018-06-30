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
using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class Dashboard : Form
    {

        private BindingSource productBindingSource = new BindingSource();
        private Models.CoffeeShopContext context = new CoffeeShopContext();
       
        public Dashboard()
        {
            InitializeComponent();
            context.Product.Load();
            productBindingSource.DataSource = context.Product.Local.ToBindingList();
            
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            var addProduct = new AddProduct();
            addProduct.Show();
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            var viewProduct = new ProductGrid(productBindingSource);
            viewProduct.Show();

        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            var order = new Order(productBindingSource);
            order.Show();
        }
    }
}
