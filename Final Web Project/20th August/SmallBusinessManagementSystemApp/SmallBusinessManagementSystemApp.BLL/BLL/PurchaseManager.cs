using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.Repository.Repository;

namespace SmallBusinessManagementSystemApp.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool AddPurchase(Purchase purchase)
        {
            return _purchaseRepository.AddPurchase(purchase);
        }

        public bool AddPurchase(List<Purchase> purchases)
        {
            return _purchaseRepository.AddPurchase(purchases);
        }

        public bool DeletePurchase(Purchase purchase)
        {
            return _purchaseRepository.DeletePurchase(purchase);
        }

        public bool UpdatePurchase(Purchase purchase)
        {
            return _purchaseRepository.UpdatePurchase(purchase);
        }

        public Purchase GetById(Purchase purchase)
        {
            return _purchaseRepository.GetById(purchase);
        }

        public List<Purchase> GetByProduct(int productId)
        {
            return _purchaseRepository.GetByProduct(productId);
        }

        public List<Purchase> GetByPurchaseSupplierId(int id)
        {
            return _purchaseRepository.GetByPurchaseSupplierId(id);
        }

        public Purchase GetProduct(Purchase purchase)
        {
            return _purchaseRepository.GetProduct(purchase);
        }

        public List<Purchase> GetExpiredProduct(DateTime? StartDate, DateTime? EndDate)
        {
            return _purchaseRepository.GetExpiredProduct(StartDate, EndDate);
        }
        public List<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

       
    }
}
