using SBMS_Project2.Models.Models;
using SBMS_Project2.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.BLL.BLL
{
    public class CustomerSaleManager
    {
        CustomerSaleRepository _customerSaleRepository = new CustomerSaleRepository();

        public bool AddCustomerSale(CustomerSale customerSale)
        {
            return _customerSaleRepository.AddCustomerSale(customerSale);
        }

        public bool DeleteCustomerSale(CustomerSale customerSale)
        {
            return _customerSaleRepository.DeleteCustomerSale(customerSale);
        }

        public bool UpdateCustomerSale(CustomerSale customerSale)
        {
            return _customerSaleRepository.UpdateCustomerSale(customerSale);
        }

        public CustomerSale GetById(CustomerSale customerSale)
        {
            return _customerSaleRepository.GetById(customerSale);
        }

        public List<CustomerSale> GetSoldProducts(DateTime startDate, DateTime endDate)
        {
            return _customerSaleRepository.GetSoldProducts(startDate, endDate);
        }

        public List<CustomerSale> GetAll()
        {
            return _customerSaleRepository.GetAll();
        }

        public List<CustomerSale> SoldProductsBefore(DateTime startDate)
        {
            return _customerSaleRepository.SoldProductsBefore(startDate);
        }

    }
}
