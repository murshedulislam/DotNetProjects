using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystemApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void categorySetupLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CategorySetup categorySetup = new CategorySetup();
            categorySetup.Show();
        }

        private void companySetupLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompanySetup companySetup = new CompanySetup();
            companySetup.Show();
        }

        private void itemSetupLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ItemSetup itemSetup = new ItemSetup();
            itemSetup.Show();
        }

        private void stockInLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StockIn stockIn = new StockIn();
            stockIn.Show();
        }

        private void stockOutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StockOut stockOut = new StockOut();
            stockOut.Show();
        }

        private void searchSummaryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchSummary searchSummary = new SearchSummary();
            searchSummary.Show();
        }

        private void searchViewLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchView searchView = new SearchView();
            searchView.Show();
        }
    }
}
