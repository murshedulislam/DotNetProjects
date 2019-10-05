using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.Repository.Repository;

namespace SmallBusinessManagementSystemApp.BLL.BLL
{
    public class PurchaseSupplierManager
    {
        PurchaseSupplierRepository _purchaseSupplierRepository = new PurchaseSupplierRepository();
        public bool AddPurchase(PurchaseSupplier purchase)
        {
            return _purchaseSupplierRepository.AddPurchase(purchase);
        }
        public PurchaseSupplier GetByCode(string code)
        {
            return _purchaseSupplierRepository.GetByCode(code);
        }

        public List<PurchaseSupplier> GetProducts(DateTime startDate, DateTime endDate)
        {
            return _purchaseSupplierRepository.GetProducts(startDate, endDate);
        }

        public List<PurchaseSupplier> BoughtBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            return _purchaseSupplierRepository.BoughtBetweenDates(startDate, endDate);
        }

        public List<PurchaseSupplier> BoughtBeforeDate(DateTime? startDate)
        {
            return _purchaseSupplierRepository.BoughtBeforeDate(startDate);
        }
    }
}
