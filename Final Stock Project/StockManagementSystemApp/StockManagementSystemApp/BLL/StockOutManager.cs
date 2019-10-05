using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;

namespace StockManagementSystemApp.BLL
{
    class StockOutManager
    {
        StockOutRepository _stockOutRepository = new StockOutRepository();

        public List<string> LoadCompany()
        {
            return _stockOutRepository.LoadCompany();
        }



        public int ReturnCategoryId(Category category)
        {
            return _stockOutRepository.ReturnCategoryId(category);
        }

        public int ReturnCompanyId(Company company)
        {
            return _stockOutRepository.ReturnCompanyId(company);
        }

        public List<string> LoadCategory(Company company)
        {
            return _stockOutRepository.LoadCategory(company);
        }

        public List<string> LoadItem(Company company, Category category)
        {

            return _stockOutRepository.LoadItem(company, category);
        }

        public int GetItemId(Item item)
        {
            return _stockOutRepository.GetItemId(item);
        }

        public int ReorderLevel(Item item)
        {
            return _stockOutRepository.ReorderLevel(item);
        }

        public int availableQuantity(Item item)
        {
            return _stockOutRepository.availableQuantity(item);
        }

        public int insertIntoStockOut(StockOUT stockOUT)
        {
            return _stockOutRepository.insertIntoStockOut(stockOUT);
        }

        public int UpdateAvailableQuantity(Item item)
        {
            return _stockOutRepository.UpdateAvailableQuantity(item);
        }
    }
}