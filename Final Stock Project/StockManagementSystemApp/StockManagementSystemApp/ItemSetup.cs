using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApp.Models;
using StockManagementSystemApp.BLL;

namespace StockManagementSystemApp
{
    public partial class ItemSetup : Form
    {
        ItemManager _itemManager = new ItemManager();

        Item item = new Item();
        int isExecuted;
        public ItemSetup()
        {
            InitializeComponent();
        }

        private void ItemSetup_Load(object sender, EventArgs e)
        {
           categoryComboBox.DataSource = _itemManager.LoadCategory();
            companyComboBox.DataSource = _itemManager.LoadCompany();
            categoryComboBox.Text = "";
            companyComboBox.Text = "";
            reorderTextBox.Text = "0";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            item.Name = itemTextBox.Text;
            if (String.IsNullOrEmpty(item.Name))
            {
                MessageBox.Show("Item name field is blank.");
                return;
            }
            if (_itemManager.Duplicate(item) > 0)
            {
                MessageBox.Show("This Item name already exists");
                return;
            }
            item.CategorySL = Convert.ToInt32(categoryComboBox.SelectedValue);
            item.CompanySL = Convert.ToInt32(companyComboBox.SelectedValue);
            item.ReorderLevel = Convert.ToInt32(reorderTextBox.Text);
            isExecuted = _itemManager.InsertItem(item);
            if (isExecuted > 0)
            {
                MessageBox.Show("Successful");
                categoryComboBox.Text = "";
                companyComboBox.Text = "";
                reorderTextBox.Text = "0";
                itemTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Unsuccessful");
            }

        }

        
    }
}
