﻿using System;
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
    public partial class Dashboard : Form
    {
        
        
       
        public Dashboard()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            var addProduct = new AddProduct();
            addProduct.Show();
        }
    }
}
