using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class Order : Form
    {
        private BindingSource productBindingSource;
        private BindingList<Product> lineItems = new BindingList<Product>();
        private CoffeeShopContext context = new CoffeeShopContext();

   
        private decimal? _subtotal = 0;

        public decimal? Subtotal
        {
            get => _subtotal;
            set
            {
                _subtotal = value;
                tbSubtotal.Text = String.Format("{0:C}", _subtotal);
            }
        }
        public Order(BindingSource bs)
        {
            InitializeComponent();
            productBindingSource = bs;
            CreateTabPanel();
            CreateTabProductPages();
            lstOrderItems.DataSource = lineItems;
            lstOrderItems.DisplayMember = "Description";
        }
        private void CreateTabPanel()
        {

            foreach (var type in context.ProductType)
            {
                tabProducts1.TabPages.Add(type.ProductType1.ToString(), type.Description);

            }
        }

        private void CreateTabProductPages()
        {
            foreach (TabPage tp in tabProducts1.TabPages)
            {

                var list = productBindingSource.List.Cast<Product>();
                var pgProducts = list.Where(p => p.ProductType == Convert.ToInt32(tp.Name));
                var flowPanel = new FlowLayoutPanel();
                flowPanel.Dock = DockStyle.Fill;
                foreach (var p in pgProducts)
                {
                    var b = new Button();
                    var buffer = new MemoryStream(p.Image);
                    b.Image = Image.FromStream(buffer);
                    b.ImageAlign = ContentAlignment.MiddleCenter;
                    
                    b.Size = new Size(150, 150);
                    //b.TextImageRelation = TextImageRelation.ImageAboveText;

                    b.Text = p.Description;
                    flowPanel.Controls.Add(b);
                    b.Tag = p;
                    
                    b.Click += new EventHandler(Add_To_Order);
                }
                tp.Controls.Add(flowPanel);
            }
        }

        private void Add_To_Order(object sender, EventArgs e)
        {
            var lineItem = ((Button)sender).Tag as Product;
            lineItems.Add(lineItem);
            lstOrderItems.SelectedIndex = lstOrderItems.Items.Count - 1;
            Subtotal += lineItem.Price;
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void FormatListItem(object sender, ListControlConvertEventArgs e)
        {
            string currentDescription = ((Product)e.ListItem).Description;
            string currentPrice = String.Format("{0:C}", ((Product)e.ListItem).Price);
            string currentDescPadded = currentDescription.PadRight(25);
            e.Value = currentDescPadded + currentPrice;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Item(object sender, EventArgs e)
        {
            if (lineItems.Count > 0)
            {
                var selectedItem = (Product)lstOrderItems.SelectedItem;
                lineItems.Remove(selectedItem);
                Subtotal -= selectedItem.Price;
            }
            else
            {
                MessageBox.Show("There are no items in order to delete!");
                
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            Order.ActiveForm.Dispose();
            
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            btnCheckout.Tag = lineItems;
            var processPayment = new Payment(lineItems, Subtotal);
            processPayment.Show();
        }
    }
}
