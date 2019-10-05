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
    class StockInManager
    {
        StockInRepository _stockInRepository = new StockInRepository();

        public List<string> LoadCompany()
        {
            return _stockInRepository.LoadCompany();
        }



        public int ReturnCategoryId(Category category)
        {
            return _stockInRepository.ReturnCategoryId(category);
        }

        public int ReturnCompanyId(Company company)
        {
            return _stockInRepository.ReturnCompanyId(company);
        }

        public List<string> LoadCategory(Company company)
        {
            return _stockInRepository.LoadCategory(company);
        }

        public List<string> LoadItem(Company company, Category category)
        {

            return _stockInRepository.LoadItem(company, category);
        }

        public int GetItemId(Item item)
        {
            return _stockInRepository.GetItemId(item);
        }

        public int ReorderLevel(Item item)
        {
            return _stockInRepository.ReorderLevel(item);
        }

        public int availableQuantity(Item item)
        {
            return _stockInRepository.availableQuantity(item);
        }

        public DataTable ShowItems(Item item)
        {
            return _stockInRepository.ShowItems(item);
        }

        public int insertIntoStockIn(StockIN stockIN)
        {
            return _stockInRepository.insertIntoStockIn(stockIN);
        }

        public string findQuantity(StockIN stockIN)
        {
            return _stockInRepository.findQuantity(stockIN);
        }

        public int updateStockInAmount(StockIN stockIN)
        {
            return _stockInRepository.updateStockInAmount(stockIN);
        }

        public int updateItemAvailableQuantity(Item item)
        {
            return _stockInRepository.updateItemAvailableQuantity(item);
        }
    }
}
