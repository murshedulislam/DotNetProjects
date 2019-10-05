using SBMS_Project2.Models.Models;
using SBMS_Project2.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.BLL.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool DeleteCustomer(Customer customer)
        {
            return _customerRepository.DeleteCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public Customer GetById(Customer customer)
        {
            return _customerRepository.GetById(customer);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
    }
}
