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
    class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public DataTable LoadCategory()
        {
            return _itemRepository.LoadCategory();
        }

        public DataTable LoadCompany()
        {
            return _itemRepository.LoadCompany();
        }

        public int Duplicate(Item item)
        {
            return _itemRepository.Duplicate(item);
        }

        public int InsertItem(Item item)
        {
            return _itemRepository.InsertItem(item);
        }
    }
}
