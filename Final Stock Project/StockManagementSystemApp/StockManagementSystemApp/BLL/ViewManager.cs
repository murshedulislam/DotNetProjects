using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;

namespace StockManagementSystemApp.BLL
{
    class ViewManager
    {
        ViewRepository _viewRepository = new ViewRepository();
        public DataTable ShowItems(string fromDate, string toDate, StockOUT stockOUT)
        {
           return _viewRepository.ShowItems(fromDate, toDate, stockOUT);
        }

        public int DateDifference(string fromDate, string toDate)
        {
            return _viewRepository.DateDifference(fromDate, toDate);
        }
    }
}
