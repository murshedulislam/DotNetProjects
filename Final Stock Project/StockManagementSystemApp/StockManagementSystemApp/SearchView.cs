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
    public partial class SearchView : Form
    {
        StockOUT stockOUT = new StockOUT();
        ViewManager _viewManager = new ViewManager();
        string fromDate, toDate;

        public SearchView()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            if(soldRadioButton.Checked == true)
            {
                fromDate = fromDateTimePicker.Text;
                toDate = toDateTimePicker.Text;
                if(_viewManager.DateDifference(fromDate, toDate) < 0)
                {
                    MessageBox.Show("From Date must be equal to or smaller than To Date");
                    return;
                }
                stockOUT.StockCondition = "Sell";
                fromDate = fromDateTimePicker.Text;
                toDate = toDateTimePicker.Text;
                if (_viewManager.ShowItems(fromDate, toDate, stockOUT).Rows.Count > 0)
                {
                    viewDataGridView.DataSource = _viewManager.ShowItems(fromDate, toDate, stockOUT);
                }

                else
                {
                    MessageBox.Show("No match found");
                }
            }

            if (damagedRadioButton.Checked == true)
            {
                stockOUT.StockCondition = "Damage";
                fromDate = fromDateTimePicker.Text;
                toDate = toDateTimePicker.Text;
                if (_viewManager.ShowItems(fromDate, toDate, stockOUT).Rows.Count > 0)
                {
                    viewDataGridView.DataSource = _viewManager.ShowItems(fromDate, toDate, stockOUT);
                }

                else
                {
                    MessageBox.Show("No match found");
                }
            }

            if (lostRadioButton.Checked == true)
            {
                stockOUT.StockCondition = lostRadioButton.Text;
                fromDate = fromDateTimePicker.Text;
                toDate = toDateTimePicker.Text;
                if (_viewManager.ShowItems(fromDate, toDate, stockOUT).Rows.Count > 0)
                {
                    viewDataGridView.DataSource = _viewManager.ShowItems(fromDate, toDate, stockOUT);
                }

                else
                {
                    MessageBox.Show("No match found");
                }
            }
        }

        private void viewDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            viewDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
