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
    public partial class StockOut : Form
    {
        Company company = new Company();
        Category category = new Category();
        Item item = new Item();
        StockOUT stockOUT = new StockOUT();
        StockOutManager _stockOutManager = new StockOutManager();
        int com;


        List<string> categories = new List<string>();
        List<string> companies = new List<string>();
        List<string> items = new List<string>();
        public StockOut()
        {
            InitializeComponent();
        }

        

        private void StockOut_Load(object sender, EventArgs e)
        {
            
            
            companies = _stockOutManager.LoadCompany();
            foreach(string comp in companies)
            {
                companyComboBox.Items.Add(comp);
            }
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            categories.Clear();
            categories.TrimExcess();
            categoryComboBox.Items.Clear();
            company.Name = companyComboBox.Text;
            company.SL = _stockOutManager.ReturnCompanyId(company);
            categories = _stockOutManager.LoadCategory(company);
            foreach (string catg in categories)
            {
                categoryComboBox.Items.Add(catg);
            }

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            items.Clear();
            items.TrimExcess();
            itemComboBox.Items.Clear();
            category.Name = categoryComboBox.Text;
            category.SL = _stockOutManager.ReturnCategoryId(category);
            items = _stockOutManager.LoadItem(company, category);
            foreach (string itm in items)
            {
                itemComboBox.Items.Add(itm);
            }
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.Name = itemComboBox.Text;
            stockOUT.ItemID = _stockOutManager.GetItemId(item);
            item.ReorderLevel =_stockOutManager.ReorderLevel(item);
            reorderLevelTextBox.Text = item.ReorderLevel.ToString();
            item.AvailableQuantity= _stockOutManager.availableQuantity(item);
            availableQuantityTextBox.Text = item.AvailableQuantity.ToString();

        }

        private void stockOutDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            stockOutDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            item.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
            stockOUT.Amount = Convert.ToInt32(stockOutTextBox.Text);
            item.AvailableQuantity = item.AvailableQuantity - stockOUT.Amount;
            
            if(item.ReorderLevel > item.AvailableQuantity)
            {
                MessageBox.Show("Available Quantity has fallen below Reorder Level");
            }

            if (item.AvailableQuantity >= 0)
            {
                int n = stockOutDataGridView.Rows.Add();

                stockOutDataGridView.Rows[n].Cells[1].Value = itemComboBox.Text;
                stockOutDataGridView.Rows[n].Cells[2].Value = companyComboBox.Text;
                stockOutDataGridView.Rows[n].Cells[3].Value = stockOutTextBox.Text;
            }
            if (item.AvailableQuantity < 0)
            {
                MessageBox.Show("Cannot remove item below available quantity");
            }

        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            
            for (int i=0;i< stockOutDataGridView.Rows.Count; i++)
            {
              item.Name= stockOutDataGridView.Rows[i].Cells[1].Value.ToString();
              stockOUT.Amount = Convert.ToInt32(stockOutDataGridView.Rows[i].Cells[3].Value);
                stockOUT.ItemID = _stockOutManager.GetItemId(item);
                stockOUT.StockCondition = SellButton.Text;
                
                item.AvailableQuantity = _stockOutManager.availableQuantity(item);
                item.AvailableQuantity = item.AvailableQuantity - stockOUT.Amount;
                //if (item.ReorderLevel > item.AvailableQuantity)
                //{
                //    MessageBox.Show("Available Quantity has fallen below Reorder Level");
                //}

                if (item.AvailableQuantity >= 0)
                {
                    int isExecuted = _stockOutManager.insertIntoStockOut(stockOUT);
                    if (isExecuted > 0)
                    {
                        MessageBox.Show("Successful");
                    }
                    int qExecuted = _stockOutManager.UpdateAvailableQuantity(item);
                    if (qExecuted > 0)
                    {
                        MessageBox.Show("Update Quantity Successful");
                    }
                }
                    

                if (item.AvailableQuantity < 0)
                {
                    MessageBox.Show("Cannot remove item below available quantity");
                }
            }

            stockOutDataGridView.Rows.Clear();

        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < stockOutDataGridView.Rows.Count; i++)
            {
                item.Name = stockOutDataGridView.Rows[i].Cells[1].Value.ToString();
                stockOUT.Amount = Convert.ToInt32(stockOutDataGridView.Rows[i].Cells[3].Value);
                stockOUT.ItemID = _stockOutManager.GetItemId(item);
                stockOUT.StockCondition = LostButton.Text;
                
                item.AvailableQuantity = _stockOutManager.availableQuantity(item);
                item.AvailableQuantity = item.AvailableQuantity - stockOUT.Amount;
                //if (item.ReorderLevel > item.AvailableQuantity)
                //{
                //    MessageBox.Show("Available Quantity has fallen below Reorder Level");
                //}
                if (item.AvailableQuantity >= 0)
                {
                    int isExecuted = _stockOutManager.insertIntoStockOut(stockOUT);
                    if (isExecuted > 0)
                    {
                        MessageBox.Show("Successful Insert Into StockOUT");
                    }
                    int qExecuted = _stockOutManager.UpdateAvailableQuantity(item);
                    if (qExecuted > 0)
                    {
                        MessageBox.Show("Update Quantity Successful");
                    }
                }
                    

                if (item.AvailableQuantity < 0)
                {
                    MessageBox.Show("Cannot remove item below available quantity");
                }
            }

            stockOutDataGridView.Rows.Clear();
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < stockOutDataGridView.Rows.Count; i++)
            {
                item.Name = stockOutDataGridView.Rows[i].Cells[1].Value.ToString();
                stockOUT.Amount = Convert.ToInt32(stockOutDataGridView.Rows[i].Cells[3].Value);
                stockOUT.ItemID = _stockOutManager.GetItemId(item);
                stockOUT.StockCondition = DamageButton.Text;
                
                item.AvailableQuantity = _stockOutManager.availableQuantity(item);
                item.AvailableQuantity = item.AvailableQuantity - stockOUT.Amount;
                //if(item.ReorderLevel > item.AvailableQuantity)
                //{
                //    MessageBox.Show("Available Quantity has fallen below Reorder Level");
                //}
                if(item.AvailableQuantity >= 0)
                {
                    int isExecuted = _stockOutManager.insertIntoStockOut(stockOUT);
                    if (isExecuted > 0)
                    {
                        MessageBox.Show("Successful");
                    }
                    int qExecuted = _stockOutManager.UpdateAvailableQuantity(item);
                    if (qExecuted > 0)
                    {
                        MessageBox.Show("Update Quantity Successful");
                    }
                }
                
                if(item.AvailableQuantity < 0)
                {
                    MessageBox.Show("Cannot remove item below available quantity");
                }
            }

            stockOutDataGridView.Rows.Clear();
        }
    }
}
