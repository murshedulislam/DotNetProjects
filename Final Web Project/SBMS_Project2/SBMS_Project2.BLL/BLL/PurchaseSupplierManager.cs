using SBMS_Project2.Models.Models;
using SBMS_Project2.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.BLL.BLL
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

        public PurchaseSupplier GetDuplicate(string code)
        {
            return _purchaseSupplierRepository.GetDuplicate(code);
        }

        public List<PurchaseSupplier> BoughtBeforeDate(DateTime? startDate)
        {
            return _purchaseSupplierRepository.BoughtBeforeDate(startDate);
        }
    }
}
