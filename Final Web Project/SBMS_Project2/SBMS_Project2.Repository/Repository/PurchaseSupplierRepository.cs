﻿using SBMS_Project2.DatabaseContext.DatabaseContext;
using SBMS_Project2.Models.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Repository.Repository
{
    public class PurchaseSupplierRepository
    {
        SBMSDbContext db = new SBMSDbContext();

        public bool AddPurchase(PurchaseSupplier purchase)
        {
            int isExecuted = 0;
            db.PurchaseSuppliers.Add(purchase);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public PurchaseSupplier GetByCode(string code)
        {
            PurchaseSupplier aPurchase = db.PurchaseSuppliers.FirstOrDefault(c => c.InvoiceNumber == code);
            return aPurchase;

        }

        public PurchaseSupplier GetDuplicate(string code)
        {
            PurchaseSupplier aPurchase = db.PurchaseSuppliers.FirstOrDefault(c => c.InvoiceNumber == code);
            return aPurchase;

        }


        public List<PurchaseSupplier> BoughtBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            List<PurchaseSupplier> aPurchaseSupplier = db.PurchaseSuppliers.Where(c => (c.Date >= startDate && c.Date <= endDate)).ToList();

            return aPurchaseSupplier;

        }

        public List<PurchaseSupplier> BoughtBeforeDate(DateTime? startDate)
        {
            List<PurchaseSupplier> aPurchaseSupplier = db.PurchaseSuppliers.Where(c => (c.Date < startDate)).ToList();

            return aPurchaseSupplier;

        }
        public List<PurchaseSupplier> GetProducts(DateTime startDate, DateTime endDate)
        {
            List<PurchaseSupplier> aPurchaseSupplier = db.PurchaseSuppliers.Where(c => (c.Date >= startDate && c.Date <= endDate)).ToList();

            return aPurchaseSupplier;

        }
    }
}