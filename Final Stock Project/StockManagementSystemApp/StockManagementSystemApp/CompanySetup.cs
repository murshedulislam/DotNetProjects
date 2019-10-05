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
    public partial class CompanySetup : Form
    {
        Company company = new Company();

        CompanyManager _companyManager = new CompanyManager();
        int rowIndex;
        int isExecuted;
        public CompanySetup()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveButton.Text == "Save")
            {
                company.Name = companyNameTextBox.Text;
                if (String.IsNullOrEmpty(company.Name))
                {
                    MessageBox.Show("Company name field is blank.");
                    return;
                }
                if (_companyManager.Duplicate(company) > 0)
                {
                    MessageBox.Show("This Company name already exists");
                    return;
                }
                isExecuted = _companyManager.InsertCompany(company);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Unsuccessful");
                }
                companyDisplayGridView.DataSource = _companyManager.DisplayGrid();
                companyNameTextBox.Text = "";
            }

            if (SaveButton.Text == "Update")
            {
                company.Name = companyNameTextBox.Text;
                if (String.IsNullOrEmpty(company.Name))
                {
                    MessageBox.Show("Company name field is blank.");
                    return;
                }
                if (_companyManager.Duplicate(company) > 0)
                {
                    MessageBox.Show("This Company name already exists");
                    return;
                }
                isExecuted = _companyManager.UpdateCompany(company, rowIndex);
                if (isExecuted > 0)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Unsuccessful");
                }
                companyDisplayGridView.DataSource = _companyManager.DisplayGrid();
                companyNameTextBox.Text = "";
                SaveButton.Text = "Save";
            }
        }

        //private void ShowButton_Click(object sender, EventArgs e)
        //{
        //    companyDisplayGridView.DataSource = _companyManager.DisplayGrid();
        //}

        private void companyDisplayGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //districtComboBox.Text = "";
                
                DataGridViewRow selectedRow = companyDisplayGridView.Rows[e.RowIndex];

                companyNameTextBox.Text = selectedRow.Cells[1].Value.ToString();
                rowIndex =Convert.ToInt32(selectedRow.Cells[2].Value);

                SaveButton.Text = "Update";


            }
        }

        private void companyDisplayGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            companyDisplayGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
