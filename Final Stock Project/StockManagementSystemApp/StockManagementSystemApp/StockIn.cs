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
    public partial class StockIn : Form
    {
        Company company = new Company();
        Category category = new Category();
        Item item = new Item();
        StockInManager _stockInManager = new StockInManager();
        int quantity;
        StockIN stockIN = new StockIN();

        List<string> categories = new List<string>();
        List<string> companies = new List<string>();
        List<string> items = new List<string>();
        public StockIn()
        {

            InitializeComponent();
            companies = _stockInManager.LoadCompany();
            foreach (string comp in companies)
            {
                companyComboBox.Items.Add(comp);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            if (SaveButton.Text == "Save")
            {
                stockIN.Amount = Convert.ToInt32(stockQuantityTextBox.Text);
                int isExecuted = _stockInManager.insertIntoStockIn(stockIN);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successfully inserted to stockIn");
                }
                item.AvailableQuantity = item.AvailableQuantity + stockIN.Amount;
                isExecuted = _stockInManager.updateItemAvailableQuantity(item);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successfully updated Available Quantity in Item.");
                }
                stockInDataGridView.DataSource = _stockInManager.ShowItems(item);
                availableQuantityTextBox.Text = item.AvailableQuantity.ToString();
            }
            if (SaveButton.Text == "Update")
            {
                stockIN.Amount = Convert.ToInt32(stockQuantityTextBox.Text);
                item.AvailableQuantity = item.AvailableQuantity - quantity;
                item.AvailableQuantity = item.AvailableQuantity + stockIN.Amount;
                int isExecuted = _stockInManager.updateStockInAmount(stockIN);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successfully Updated Amount in stockIn");
                }

                isExecuted = _stockInManager.updateItemAvailableQuantity(item);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successfully updated Available Quantity in Item.");
                }
                stockInDataGridView.DataSource = _stockInManager.ShowItems(item);
                SaveButton.Text = "Save";
                availableQuantityTextBox.Text = item.AvailableQuantity.ToString();
            }
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categories.Clear();
            categories.TrimExcess();
            categoryComboBox.Items.Clear();
            SaveButton.Text = "Save";
            company.Name = companyComboBox.Text;
            company.SL = _stockInManager.ReturnCompanyId(company);
            categories = _stockInManager.LoadCategory(company);
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
            SaveButton.Text = "Save";
            category.Name = categoryComboBox.Text;
            category.SL = _stockInManager.ReturnCategoryId(category);
            items = _stockInManager.LoadItem(company, category);
            foreach (string itm in items)
            {
                itemComboBox.Items.Add(itm);
            }
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveButton.Text = "Save";
            item.Name = itemComboBox.Text;
            stockIN.ItemID = _stockInManager.GetItemId(item);
            item.ReorderLevel = _stockInManager.ReorderLevel(item);
            reorderLevelTextBox.Text = item.ReorderLevel.ToString();
            item.AvailableQuantity = _stockInManager.availableQuantity(item);
            availableQuantityTextBox.Text = item.AvailableQuantity.ToString();
            stockInDataGridView.DataSource = _stockInManager.ShowItems(item);
            CreateUnboundButtonColumn();
        }

        private void stockInDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            stockInDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void CreateUnboundButtonColumn()
        {
            // Initialize the button column.
            DataGridViewButtonColumn buttonColumn =
                new DataGridViewButtonColumn();
            buttonColumn.Name = "Action";
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Edit";

            // Use the Text property for the button text for all cells rather
            // than using each cell's value as the text for its own button.
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the button column to the control.
            stockInDataGridView.Columns.Insert(6, buttonColumn);
        }

        private void stockInDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = stockInDataGridView.Rows[e.RowIndex];

            stockIN.ID = Convert.ToInt32(selectedRow.Cells[1].Value);
            stockQuantityTextBox.Text = _stockInManager.findQuantity(stockIN);
            //item.AvailableQuantity = item.AvailableQuantity - Convert.ToInt32(_stockInManager.findQuantity(stockIN));
            quantity = Convert.ToInt32(_stockInManager.findQuantity(stockIN));

            SaveButton.Text = "Update";
        }
    }
}
