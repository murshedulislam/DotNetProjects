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
    public class ReportingController : Controller
    {
        PurchaseSupplierManager _purchaseSupplierManager = new PurchaseSupplierManager();
        CustomerSaleManager _customerSaleManager = new CustomerSaleManager();
        ProductSaleManager _productSaleManager = new ProductSaleManager();
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        // GET: Reporting
        [HttpGet]
        public ActionResult Show()
        {
            ReportingViewModel reportvm = new ReportingViewModel();
            return View(reportvm);
        }

        [HttpGet]
        public ActionResult Search()
        {
            ReportingViewModel reportvm = new ReportingViewModel();
            return View(reportvm);
        }
        [HttpPost]
        public JsonResult GetSoldProducts(DateTime startDate, DateTime endDate)
        {
            List<dynamic> dynamicList = new List<dynamic>();
            //List<dynamic> dynamicList1 = new List<dynamic>();
            List<dynamic> saleList = new List<dynamic>();
            Product aProduct = new Product();
            Category aCategory = new Category();
            Purchase aPurchase = new Purchase();
            var products = _customerSaleManager.GetSoldProducts(startDate, endDate);
            foreach (var product in products)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList.Add(new { Id = sale.ProductId, Quantity = sale.Quantity, Total = sale.TotalPrice });
                }
            }
            //var productDetails = from p in dynamicList
            //                     group p.Total by p.Id into g
            //                     select new { Id = g.Key, Totals = g.ToList().Sum(x => Convert.ToInt32(x)) };

            var productDetails = from p in dynamicList
                                 group p by p.Id;


            var id = 0;
            foreach (var p in productDetails)
            {
                id = p.Key;
                aProduct.ID = id;

                var product = _productManager.GetById(aProduct);

                aCategory.ID = product.CategoryId;

                var category = _categoryManager.GetById(aCategory);
                aPurchase.ProductId = id;

                var purchase = _purchaseManager.GetProduct(aPurchase);

                var quantity = 0;
                var total = 0;
                foreach (var s in p)
                {
                    quantity = quantity + s.Quantity;
                    total = total + Convert.ToInt32(s.Total);
                }
                saleList.Add(new { Id = id, Codes = product.Code, Names = product.Name, Unit = purchase.UnitPrice, Category = category.Name, Quantity = quantity, Total = total });
            }


            //var boughtBetween = _purchaseSupplierManager.BoughtBetweenDates(startDate, endDate);

            //foreach (var between in boughtBetween)
            //{
            //    var purchases = _purchaseManager.GetByPurchaseSupplierId(between.ID);
            //    foreach (var purchase in purchases)
            //    {
            //        dynamicList1.Add(new { Id = purchase.ProductId, In = purchase.Quantity });
            //    }
            //}

            return Json(saleList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRemainingProducts(DateTime startDate, DateTime endDate)
        {
            List<dynamic> dynamicList = new List<dynamic>();
            List<dynamic> dynamicList1 = new List<dynamic>();
            List<dynamic> saleList = new List<dynamic>();
            List<dynamic> purchaseList = new List<dynamic>();
            Product aProduct = new Product();
            Category aCategory = new Category();
            Purchase aPurchase = new Purchase();
            var products = _customerSaleManager.GetSoldProducts(startDate, endDate);
            foreach (var product in products)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList.Add(new { Id = sale.ProductId, Sold = sale.Quantity });
                }
            }
            var productDetails = from p in dynamicList
                                 group p.Sold by p.Id into g
                                 select new { Id = g.Key, TotalSale = g.ToList().Sum(x => Convert.ToInt32(x)) };

            //var productDetails = from p in dynamicList
            //                     group p by p.Id;
            var boughtBetween = _purchaseSupplierManager.BoughtBetweenDates(startDate, endDate);

            foreach (var between in boughtBetween)
            {
                var purchases = _purchaseManager.GetByPurchaseSupplierId(between.ID);
                foreach (var purchase in purchases)
                {
                    dynamicList1.Add(new { Id = purchase.ProductId, Bought = purchase.Quantity });
                }
            }

            var purchaseDetails = from p in dynamicList1
                                  group p.Bought by p.Id into g
                                  select new { Id = g.Key, TotalPurchase = g.ToList().Sum(x => Convert.ToInt32(x)) };


            var Details = from b in productDetails
                          join s in purchaseDetails on b.Id equals s.Id
                          select new { Id = b.Id, Ins = s.TotalPurchase, Outs = b.TotalSale };




            foreach (var p in Details)
            {
                var available = p.Ins - p.Outs;

                aProduct.ID = p.Id;

                var product = _productManager.GetById(aProduct);

                aCategory.ID = product.CategoryId;

                var category = _categoryManager.GetById(aCategory);
                aPurchase.ProductId = p.Id;

                var purchase = _purchaseManager.GetProduct(aPurchase);
                var purchasePrice = purchase.UnitPrice;
                var sale = _productSaleManager.GetByProductId(p.Id);
                var salePrice = sale.UnitPrice;
                var cp = available * purchasePrice;
                var mrp = available * salePrice;
                var profit = mrp - cp;
                //var quantity = 0;
                //var total = 0;
                //foreach (var s in p)
                //{
                //    quantity = quantity + s.Quantity;
                //    total = total + Convert.ToInt32(s.Total);
                //}
                saleList.Add(new { Id = p.Id, Codes = product.Code, Names = product.Name, Category = category.Name, CostPrice = cp, MRP = mrp, Profit = profit });
            }






            return Json(saleList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProductDetails(int id)
        {
            List<dynamic> dynamicList = new List<dynamic>();
            Product aProduct = new Product();
            Category aCategory = new Category();
            Purchase aPurchase = new Purchase();
            aProduct.ID = id;

            var product = _productManager.GetById(aProduct);

            aCategory.ID = product.CategoryId;

            var category = _categoryManager.GetById(aCategory);
            aPurchase.ProductId = id;

            var purchase = _purchaseManager.GetProduct(aPurchase);

            dynamicList.Add(new { Codes = product.Code, Names = product.Name, Unit = purchase.UnitPrice, Category = category.Name });

            return Json(dynamicList, JsonRequestBehavior.AllowGet);
        }
    }
}