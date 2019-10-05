using SBMS_Project2.BLL.BLL;
using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMS_Project2.Controllers
{
    public class CustomerController : Controller
    {
        Customer aCustomer = new Customer();
        CustomerManager _customerManager = new CustomerManager();

        // GET: Customer
        [HttpGet]
        public ActionResult Add()
        {
            aCustomer.Customers = _customerManager.GetAll();
            return View(aCustomer);
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            _customerManager.AddCustomer(customer);

            aCustomer.Customers = _customerManager.GetAll();
            return View(aCustomer);
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            aCustomer.ID = ID;

            var customer = _customerManager.GetById(aCustomer);
            
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerManager.UpdateCustomer(customer);
                return RedirectToAction(nameof(Add));
            }

            return View(customer);
        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            aCustomer.ID = ID;
            var customer = _customerManager.GetById(aCustomer);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerManager.DeleteCustomer(customer);
                return RedirectToAction("Add");
            }

            return View(customer);
        }

        [HttpGet]
        public ActionResult Search()
        {
            aCustomer.Customers = _customerManager.GetAll();
            return View(aCustomer);
        }

        [HttpPost]
        public ActionResult Search(Customer customer)
        {
            var customers = _customerManager.GetAll();
            if (customer.Name != null)
            {
                customers = customers.Where(p => p.Name.ToLower().Contains(customer.Name.ToLower())).ToList();
            }
            customer.Customers = customers;
            return View(customer);
        }
    }
}