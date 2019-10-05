using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.DatabaseContext.DatabaseContext;

namespace SmallBusinessManagementSystemApp.Repository.Repository
{
    public class PurchaseRepository
    {
        StockDbContext db = new StockDbContext();

        public bool AddPurchase(Purchase purchase)
        {
            int isExecuted = 0;
            db.Purchases.Add(purchase);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool AddPurchase(List<Purchase> purchases)
        {
            int isExecuted = 0;
            db.Purchases.AddRange(purchases);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeletePurchase(Purchase purchase)
        {
            int isExecuted = 0;

            Purchase aPurchase = db.Purchases.FirstOrDefault(c => c.ID == purchase.ID);
            db.Purchases.Remove(aPurchase);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;

        }

        public bool UpdatePurchase(Purchase purchase)
        {
            int isExecuted = 0;

            //Purchase aPurchase = db.Purchases.FirstOrDefault(c => c.Code == purchase.Code);
            //if (aPurchase != null)
            //{
            //    aPurchase.Name = purchase.Name;

            //}

            db.Entry(purchase).State = EntityState.Modified;
            isExecuted = db.SaveChanges();


            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public Purchase GetById(Purchase purchase)
        {
            Purchase aPurchase = db.Purchases.FirstOrDefault(c => c.ID == purchase.ID);
            
            return aPurchase;

        }

        public Purchase GetProduct(Purchase purchase)
        {
            Purchase aPurchase = db.Purchases.FirstOrDefault(c => c.ProductId == purchase.ProductId);

            return aPurchase;

        }

        public List<Purchase> GetByProduct(int productId)
        {
            List<Purchase> aPurchase = db.Purchases.Where(c => c.ProductId == productId).ToList();

            return aPurchase;

        }
        public List<Purchase> GetByPurchaseSupplierId(int id)
        {
            List<Purchase> aPurchase = db.Purchases.Where(c => c.PurchaseSupplierId == id).ToList();

            return aPurchase;

        }
       
        public List<Purchase> GetExpiredProduct(DateTime? StartDate, DateTime? EndDate)
        {
            List<Purchase> aPurchase = db.Purchases.Where(c => (c.ExpireDate >= StartDate && c.ExpireDate <= EndDate)).ToList();

            return aPurchase;

        }
        public List<Purchase> GetAll()
        {
            return db.Purchases.ToList();
        }

        
    }
}
