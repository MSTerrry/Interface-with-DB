﻿using System;
using DeliveryWizard;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DW.UI
{
    public partial class WayPointF : Form
    {
        public WayPoint wp { get; set; }
        string type;
        string state;        
        public WayPointF(WayPoint wp)
        {
            this.wp = wp;
            InitializeComponent();

        }
        public bool CheckEnable()
        {
            return !(state == "закрыт" || (type != "admin" && state != "принят к обработке"));            
        }
        public WayPointF(WayPoint wp, string type, string state)
        {
            this.wp = wp;
            InitializeComponent();
            this.state = state;
            this.type = type;
            Add.Enabled = CheckEnable();
            Save.Enabled = CheckEnable();
        }
                
        private void Save_Click(object sender, EventArgs e)
        {
            wp.Address = AdressBox.Text;
            if (DroppedBox1.SelectedIndex != -1) wp.ShopType = DroppedBox1.SelectedItem.ToString();
            else wp.ShopType = "Другое";            
            wp.PlaceTitle = TitleBox.Text;
            wp.ProductsList = ProductList.Items.OfType<Product>().ToList();
            wp.TotalCost = CostUD.Value;
        }

        private void WayPointF_Load(object sender, EventArgs e)
        {
            AdressBox.Text = wp.Address;
            DroppedBox1.SelectedItem = wp.ShopType;
            TitleBox.Text = wp.PlaceTitle;
            CostUD.Value = wp.TotalCost;
            if (wp.ProductsList != null)
            {
                foreach (var r in wp.ProductsList)
                {
                    ProductList.Items.Add(r);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var product = new ProductForm(new Product());            
            var res = product.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                ProductList.Items.Add(product.Prod);
            }
            CostUD.Value += (decimal)product.Prod.Amount* (decimal)product.Prod.Cost;
            Save.Enabled = true;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var prod = (Product)ProductList.SelectedItem;
            CostUD.Value -= (decimal)prod.Cost;
            ProductList.Items.Remove(ProductList.SelectedItem);
            if (ProductList.Items.Count == 0 && CheckEnable()) Save.Enabled = false;
        }

        private void ProductList_DoubleClick(object sender, EventArgs e)
        {
            var prod = ProductList.SelectedItem as Product;
            if (prod == null)
                return;                          
            CostUD.Value -= (decimal)prod.Amount* (decimal)prod.Cost;
            var form = new ProductForm(prod.Clone());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var si = ProductList.SelectedIndex;
                ProductList.Items.Remove(ProductList.SelectedItem);
                ProductList.Items.Insert(si,form.Prod);
            }            
            CostUD.Value += (decimal)form.Prod.Amount* (decimal)form.Prod.Cost;
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductList.SelectedIndex != -1 && CheckEnable())
                Delete.Enabled = true;
            else
                Delete.Enabled = false;
        }        
    }
}
