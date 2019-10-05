using AutoMapper;
using SBMS_Project2.BLL.BLL;
using SBMS_Project2.Models;
using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMS_Project2.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        CustomerManager _customerManager = new CustomerManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        ProductSaleManager _productSaleManager = new ProductSaleManager();
        CustomerSaleManager _customerSaleManager = new CustomerSaleManager();

        [HttpGet]
        public ActionResult Add()
        {
            SalesViewModel salesvm = new SalesViewModel();
            salesvm.CustomerList = _customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            salesvm.ProductList = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(salesvm);

        }

        [HttpPost]
        public ActionResult Add(SalesViewModel salesvm)
        {
            var sales = new List<ProductSale>();
            //Purchase _purchase = new Purchase();
            CustomerSale _customerSale = new CustomerSale();
            if (ModelState.IsValid)
            {
                Customer _customer = new Customer();
                _customer.ID = salesvm.CustomerId;
                var customer = _customerManager.GetById(_customer);
                customer.LoyaltyPoint = salesvm.LoyaltyPoint;
                _customerManager.UpdateCustomer(customer);
                CustomerSale aCustomer = Mapper.Map<CustomerSale>(salesvm);
                _customerSaleManager.AddCustomerSale(aCustomer);

                ////_customerManager.UpdateCustomer(customer);
                ////_customerSale.Date = salesvm.Date;
                ////_customerSale.CustomerId = salesvm.CustomerId;
                ////_customerSale.LoyaltyPoint = salesvm.LoyaltyPoint;
                ////_customerSale.GrandTotal = salesvm.GrandTotal;
                ////_customerSale.Discount = salesvm.Discount;
                ////_customerSale.DiscountAmount = salesvm.DiscountAmount;
                ////_customerSale.PayableAmount = salesvm.PayableAmount;
                ////_customerSaleManager.AddCustomerSale(_customerSale);
                //var ps = _customerSaleManager.GetByCode(salesvm.InvoiceNumber);
                ////foreach (var sale in salesvm.ProductSales)
                ////{


                ////    sale.CustomerSaleId = 1;

                ////    sales.Add(sale);
                ////}

                ////_productSaleManager.AddProductSale(sales);

            }

            salesvm.CustomerList = _customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            salesvm.ProductList = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(salesvm);
        }

        [HttpPost]
        public JsonResult GetLoyaltyPoint(int customerId)
        {
            Customer _customer = new Customer();
            _customer.ID = customerId;
            var customer = _customerManager.GetById(_customer);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAvailableQuantity(int productId)
        {

            List<dynamic> dynamicList = new List<dynamic>();


            var products = _purchaseManager.GetByProduct(productId);
            var quantity = 0;

            foreach (var product in products)
            {
                quantity = quantity + product.Quantity;
            }

            var sales = _productSaleManager.GetByProduct(productId);
            var saleOut = 0;
            if (sales != null || sales.Count != 0)
            {
                foreach (var sale in sales)
                {
                    saleOut = saleOut + sale.Quantity;
                }
            }

            var available = quantity - saleOut;

            return Json(available, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProductMRP(int productId)
        {


            Purchase aPurchase = new Purchase();
            aPurchase.ProductId = productId;
            var product = _purchaseManager.GetProduct(aPurchase);


            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult GetProductName(int productId)
        {
            Product _product = new Product();
            _product.ID = productId;
            var product = _productManager.GetById(_product);

            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}