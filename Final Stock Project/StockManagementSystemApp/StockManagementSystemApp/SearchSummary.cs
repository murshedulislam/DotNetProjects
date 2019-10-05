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
    public partial class SearchSummary : Form
    {
        Company company = new Company();
        Category category = new Category();
        Item item = new Item();
        StockOUT stockOUT = new StockOUT();
        SearchManager _searchManager = new SearchManager();
        int com;


        List<string> categories = new List<string>();
        List<string> companies = new List<string>();
        List<string> items = new List<string>();
        public SearchSummary()
        {
            InitializeComponent();
            companies = _searchManager.LoadCompany();
            foreach (string comp in companies)
            {
                companyComboBox.Items.Add(comp);
            }
            companyComboBox.Text = "--Select--";
            categories = _searchManager.LoadCategory();
            foreach (string catg in categories)
            {
                categoryComboBox.Items.Add(catg);
            }
            categoryComboBox.Text = "--Select--";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            
            if(String.IsNullOrEmpty(companyComboBox.Text) & String.IsNullOrEmpty(categoryComboBox.Text))
            {
                MessageBox.Show("Select a company or a category.");
            }

            if ((companyComboBox.Text != "--Select--") & (categoryComboBox.Text != "--Select--"))
            {
                company.Name = companyComboBox.Text;
                category.Name = categoryComboBox.Text;
                if (_searchManager.DisplayGrid(company, category).Rows.Count > 0)
                {
                    

                    searchDataGridView.DataSource = _searchManager.DisplayGrid(company, category);
                }
                else
                {
                    
                    searchDataGridView.DataSource = "";
                    MessageBox.Show("Did not find any matching item");
                }
                
            }

            if((companyComboBox.Text == "--Select--") & (categoryComboBox.Text != "--Select--"))
            {
                // MessageBox.Show("Company Empty");
                category.Name = categoryComboBox.Text;
                searchDataGridView.DataSource = _searchManager.DisplayCategoryGrid(category);
            }

            if ((companyComboBox.Text != "--Select--") & (categoryComboBox.Text == "--Select--"))
            {
                company.Name = companyComboBox.Text;
                //MessageBox.Show("Category Empty");
                searchDataGridView.DataSource = _searchManager.DisplayCompanyGrid(company);
            }
        }

        private void searchDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            searchDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
