using SBMS_Project2.DatabaseContext.DatabaseContext;
using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Repository.Repository
{
    public class SupplierRepository
    {
        SBMSDbContext db = new SBMSDbContext();

        public bool AddSupplier(Supplier supplier)
        {
            int isExecuted = 0;
            db.Suppliers.Add(supplier);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.ID == supplier.ID);
            db.Suppliers.Remove(aSupplier);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;

        }

        public bool UpdateSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            //Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.Code == supplier.Code);
            //if (aSupplier != null)
            //{
            //    aSupplier.Name = supplier.Name;

            //}

            db.Entry(supplier).State = EntityState.Modified;
            isExecuted = db.SaveChanges();


            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public Supplier GetById(Supplier supplier)
        {
            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.ID == supplier.ID);
            return aSupplier;

        }

        public Supplier GetDuplicate(Supplier supplier)
        {
            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.Code == supplier.Code);
            return aSupplier;

        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }
    }
}
