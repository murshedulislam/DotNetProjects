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
    public partial class CategorySetup : Form
    {
        Category category = new Category();
        
        StockManager _stockManager = new StockManager();
        int rowIndex;
        int isExecuted;
        public CategorySetup()
        {
            
            InitializeComponent();
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveButton.Text =="Save")
            {
                category.Name = categoryNameTextBox.Text;
                if (String.IsNullOrEmpty(category.Name))
                {
                    MessageBox.Show("Category name field is blank.");
                    return;
                }
                if (_stockManager.Duplicate(category) > 0)
                {
                    MessageBox.Show("This Category name already exists.");
                    return;
                }
               isExecuted=_stockManager.InsertCategory(category);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Unsuccessful");
                }
                categoryDisplayGridView.DataSource= _stockManager.DisplayGrid();
                categoryNameTextBox.Text = "";
            }

            if (SaveButton.Text == "Update")
            {
                category.Name = categoryNameTextBox.Text;
                if (String.IsNullOrEmpty(category.Name))
                {
                    MessageBox.Show("Category name field is blank.");
                    return;
                }
                if (_stockManager.Duplicate(category) > 0)
                {
                    MessageBox.Show("This Category name already exists");
                    return;
                }
               isExecuted=_stockManager.UpdateCategory(category, rowIndex);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Unsuccessful");
                }
                categoryDisplayGridView.DataSource = _stockManager.DisplayGrid();
                SaveButton.Text = "Save";
                categoryNameTextBox.Text = "";
            }



        }

       

        //private void ShowButton_Click(object sender, EventArgs e)
        //{
        //    categoryDisplayGridView.DataSource= _stockManager.DisplayGrid();
        //}

        private void categoryDisplayGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //districtComboBox.Text = "";
               // rowIndex = e.RowIndex + 1;
                DataGridViewRow selectedRow = categoryDisplayGridView.Rows[e.RowIndex];

                categoryNameTextBox.Text = selectedRow.Cells[1].Value.ToString();
                rowIndex = Convert.ToInt32(selectedRow.Cells[2].Value);

                SaveButton.Text = "Update";


            }
        }

        private void categoryDisplayGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           categoryDisplayGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
