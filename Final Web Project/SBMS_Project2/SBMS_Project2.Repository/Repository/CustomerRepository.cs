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
    public class CustomerRepository
    {
        SBMSDbContext db = new SBMSDbContext();

        public bool AddCustomer(Customer customer)
        {
            int isExecuted = 0;
            db.Customers.Add(customer);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteCustomer(Customer customer)
        {
            int isExecuted = 0;

            Customer aCustomer = db.Customers.FirstOrDefault(c => c.ID == customer.ID);
            db.Customers.Remove(aCustomer);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;

        }

        public bool UpdateCustomer(Customer customer)
        {
            int isExecuted = 0;
            db.Entry(customer).State = EntityState.Modified;
            isExecuted = db.SaveChanges();


            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public Customer GetById(Customer customer)
        {
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.ID == customer.ID);
            return aCustomer;

        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }
    }
}
