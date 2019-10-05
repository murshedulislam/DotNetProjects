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
    class StockManager
    {
        StockRepository _stockRepository = new StockRepository();

        public DataTable DisplayGrid()
        {
            return _stockRepository.DisplayGrid();
        }

        public int InsertCategory(Category category)
        {
            return _stockRepository.InsertCategory(category);
        }

        public int UpdateCategory(Category category, int rowIndex)
        {
            return _stockRepository.UpdateCategory(category, rowIndex);
        }

        public int Duplicate(Category category)
        {
            return _stockRepository.Duplicate(category);
        }

    }
}
