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
    public class CustomerSaleRepository
    {
        StockDbContext db = new StockDbContext();

        public bool AddCustomerSale(CustomerSale customerSale)
        {
            int isExecuted = 0;
            db.CustomerSales.Add(customerSale);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool AddCustomerSale(List<CustomerSale> customerSales)
        {
            int isExecuted = 0;
            db.CustomerSales.AddRange(customerSales);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteCustomerSale(CustomerSale customerSale)
        {
            int isExecuted = 0;

            CustomerSale aCustomerSale = db.CustomerSales.FirstOrDefault(c => c.ID == customerSale.ID);
            db.CustomerSales.Remove(aCustomerSale);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;

        }

        public bool UpdateCustomerSale(CustomerSale customerSale)
        {
            int isExecuted = 0;

            //CustomerSale aCustomerSale = db.CustomerSales.FirstOrDefault(c => c.Code == customerSale.Code);
            //if (aCustomerSale != null)
            //{
            //    aCustomerSale.Name = customerSale.Name;

            //}

            db.Entry(customerSale).State = EntityState.Modified;
            isExecuted = db.SaveChanges();


            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public CustomerSale GetById(CustomerSale customerSale)
        {
            CustomerSale aCustomerSale = db.CustomerSales.FirstOrDefault(c => c.ID == customerSale.ID);
            return aCustomerSale;

        }

        public List<CustomerSale> GetSoldProducts(DateTime startDate, DateTime endDate)
        {
            List<CustomerSale> aCustomerSale = db.CustomerSales.Where(c => (c.Date >= startDate && c.Date <= endDate)).ToList();

            return aCustomerSale;

        }
        public List<CustomerSale> SoldProductsBefore(DateTime startDate)
        {
            List<CustomerSale> aCustomerSale = db.CustomerSales.Where(c => (c.Date < startDate)).ToList();

            return aCustomerSale;

        }

        public List<CustomerSale> GetAll()
        {
            return db.CustomerSales.ToList();
        }
    }
}
