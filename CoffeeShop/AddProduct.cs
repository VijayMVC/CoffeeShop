using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CoffeeShop
{

    public partial class AddProduct : Form
    {
        private CoffeeShopContext _context = new CoffeeShopContext();
        private byte[] buffer;
        



        public AddProduct()
        {
            InitializeComponent();
            string[] typeList = _context.ProductType.Select(p=> p.Description).ToArray<string>();
            cbCategory.Items.AddRange(typeList);

        }

        private void Upload_Click(object sender, EventArgs e)
        {
            DialogResult result = openImageDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(openImageDialog.FileName, FileMode.Open, FileAccess.Read);
                buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                fileStream.Close();
                MemoryStream memoryStream = new MemoryStream(buffer);
                pbImage.Image = Image.FromStream(memoryStream);
            }
            

        }

        private void Save_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product()
            {
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                Image = buffer,

                //TODO: set selectedValue property for items in combo box
                ProductType = (int)cbCategory.SelectedIndex+1,

            };
            _context.Product.Add(newProduct);
            _context.SaveChanges();
            MessageBox.Show("Product Saved");
            ActiveForm.Close();
        }
    }

}
