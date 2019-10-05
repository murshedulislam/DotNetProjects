using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementSystemApp.BLL.BLL;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.Models;

namespace SmallBusinessManagementSystemApp.Controllers
{
    public class StockController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        PurchaseSupplierManager _purchaseSupplierManager = new PurchaseSupplierManager();
        CustomerSaleManager _customerSaleManager = new CustomerSaleManager();
        ProductSaleManager _productSaleManager = new ProductSaleManager();
        // GET: Stock
        public ActionResult Order()
        {
            StockViewModel stockvm = new StockViewModel();

            return View(stockvm);
        }

        [HttpGet]
        public ActionResult Search()
        {
            StockViewModel stockvm = new StockViewModel();
            stockvm.CategoryList = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            stockvm.ProductList = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });
            return View(stockvm);
        }

        [HttpPost]
        public JsonResult GetProduct(int? productId, int? categoryId, DateTime startDate, DateTime endDate) {
            List<dynamic> dynamicList = new List<dynamic>();
            List<dynamic> dynamicList1 = new List<dynamic>();
            List<dynamic> dynamicList2 = new List<dynamic>();
            List<dynamic> dynamicList3 = new List<dynamic>();
            List<dynamic> resultList = new List<dynamic>();
            var expiredProducts = _purchaseManager.GetExpiredProduct(startDate, endDate);
            //bought before startDate
            var boughtBefore = _purchaseSupplierManager.BoughtBeforeDate(startDate);
            //bought between dates
            var boughtBetween = _purchaseSupplierManager.BoughtBetweenDates(startDate, endDate);

            foreach(var before in boughtBefore)
            {
                var purchases = _purchaseManager.GetByPurchaseSupplierId(before.ID);
                foreach(var purchase in purchases)
                {
                    dynamicList.Add(new { Id = purchase.ProductId, Opening = purchase.Quantity });
                }
            }

            foreach (var between in boughtBetween)
            {
                var purchases = _purchaseManager.GetByPurchaseSupplierId(between.ID);
                foreach (var purchase in purchases)
                {
                    dynamicList1.Add(new { Id = purchase.ProductId, In = purchase.Quantity });
                }
            }
            //products sold between dates
            var soldBetween = _customerSaleManager.GetSoldProducts(startDate, endDate);

            //products sold before start

            var soldBefore = _customerSaleManager.SoldProductsBefore(startDate);

            foreach (var product in soldBetween)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList2.Add(new { Id = sale.ProductId, Out = sale.Quantity});
                }
            }

            foreach (var product in soldBefore)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList3.Add(new { Id = sale.ProductId, Sold = sale.Quantity });
                }
            }
            var openingDetails = from p in dynamicList
                             group p.Opening by p.Id into g
                             select new { Id = g.Key, Openings = g.ToList().Sum(x => Convert.ToInt32(x)) };

            var openingSaleDetails = from p in dynamicList3
                                 group p.Sold by p.Id into g
                                 select new { Id = g.Key, BeforeSales = g.ToList().Sum(x => Convert.ToInt32(x)) };

            var inDetails = from p in dynamicList1
                             group p.In by p.Id into g
                             select new { Id = g.Key, Ins = g.ToList().Sum(x => Convert.ToInt32(x)) };


            var outDetails = from p in dynamicList2
                                 group p.Out by p.Id into g
                                 select new { Id = g.Key, Outs = g.ToList().Sum(x => Convert.ToInt32(x)) };
            


            var results = from b in openingDetails
                          join s in openingSaleDetails on b.Id equals s.Id
                          join i in inDetails on b.Id equals i.Id
                          join o in outDetails on b.Id equals o.Id
                          select new { Id = b.Id, Opening = b.Openings, OpeningSale =s.BeforeSales ,In = i.Ins, Out = o.Outs };

            if (productId > 0)
            {

                results = results.Where(c => c.Id == productId).ToList();
            }
            foreach (var result in results)
            {
                Product aProduct = new Product();
                Category aCategory = new Category();
                aProduct.ID = result.Id;
                var product = _productManager.GetById(aProduct);
                aCategory.ID = product.CategoryId;
                var category = _categoryManager.GetById(aCategory);
                Purchase aPurchase = new Purchase();
                aPurchase.ProductId = result.Id;
                var purchase = _purchaseManager.GetProduct(aPurchase);
                var available = result.Opening - result.OpeningSale;
                var closing = (available + result.In) - result.Out;
                resultList.Add(new { Code= product.Code, Name = product.Name, CategoryId = category.ID ,Category = category.Name, Reorder = product.ReorderLevel, Date = purchase.ExpireDate, OpeningBalance = available, In = result.In, Out = result.Out, ClosingBalance = closing});

            }
            if (categoryId > 0)
            {

                resultList = resultList.Where(c => c.CategoryId == categoryId).ToList();
            }
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetNewProduct(int? productId, int? categoryId, DateTime startDate, DateTime endDate)
        {
            List<dynamic> dynamicList = new List<dynamic>();
            List<dynamic> dynamicList1 = new List<dynamic>();
            List<dynamic> dynamicList2 = new List<dynamic>();
            List<dynamic> dynamicList3 = new List<dynamic>();
            List<dynamic> resultList = new List<dynamic>();
            List<dynamic> finalList = new List<dynamic>();
            var expiredProducts = _purchaseManager.GetExpiredProduct(startDate, endDate);
            //bought before startDate
            var boughtBefore = _purchaseSupplierManager.BoughtBeforeDate(startDate);
            //bought between dates
            var boughtBetween = _purchaseSupplierManager.BoughtBetweenDates(startDate, endDate);

            foreach (var before in boughtBefore)
            {
                var purchases = _purchaseManager.GetByPurchaseSupplierId(before.ID);
                foreach (var purchase in purchases)
                {
                    dynamicList.Add(new { Id = purchase.ProductId, Opening = purchase.Quantity });
                }
            }

            foreach (var between in boughtBetween)
            {
                var purchases = _purchaseManager.GetByPurchaseSupplierId(between.ID);
                foreach (var purchase in purchases)
                {
                    dynamicList1.Add(new { Id = purchase.ProductId, In = purchase.Quantity });
                }
            }
            //products sold between dates
            var soldBetween = _customerSaleManager.GetSoldProducts(startDate, endDate);

            //products sold before start

            var soldBefore = _customerSaleManager.SoldProductsBefore(startDate);

            foreach (var product in soldBetween)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList2.Add(new { Id = sale.ProductId, Out = sale.Quantity });
                }
            }

            foreach (var product in soldBefore)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList3.Add(new { Id = sale.ProductId, Sold = sale.Quantity });
                }
            }
            var openingDetails = from p in dynamicList
                                 group p.Opening by p.Id into g
                                 select new { Id = g.Key, Openings = g.ToList().Sum(x => Convert.ToInt32(x)) };

            var openingSaleDetails = from p in dynamicList3
                                     group p.Sold by p.Id into g
                                     select new { Id = g.Key, BeforeSales = g.ToList().Sum(x => Convert.ToInt32(x)) };

            var inDetails = from p in dynamicList1
                            group p.In by p.Id into g
                            select new { Id = g.Key, Ins = g.ToList().Sum(x => Convert.ToInt32(x)) };


            var outDetails = from p in dynamicList2
                             group p.Out by p.Id into g
                             select new { Id = g.Key, Outs = g.ToList().Sum(x => Convert.ToInt32(x)) };



            var results = from b in openingDetails
                          join s in openingSaleDetails on b.Id equals s.Id
                          join i in inDetails on b.Id equals i.Id
                          join o in outDetails on b.Id equals o.Id
                          select new { Id = b.Id, Opening = b.Openings, OpeningSale = s.BeforeSales, In = i.Ins, Out = o.Outs };

            if (productId > 0)
            {

                results = results.Where(c => c.Id == productId).ToList();
            }
            foreach (var result in results)
            {
                Product aProduct = new Product();
                Category aCategory = new Category();
                aProduct.ID = result.Id;
                var product = _productManager.GetById(aProduct);
                aCategory.ID = product.CategoryId;
                var category = _categoryManager.GetById(aCategory);
                Purchase aPurchase = new Purchase();
                aPurchase.ProductId = result.Id;
                var purchase = _purchaseManager.GetProduct(aPurchase);
                var available = result.Opening - result.OpeningSale;
                var closing = (available + result.In) - result.Out;
                resultList.Add(new { Code = product.Code, Name = product.Name, Category = category.Name, Reorder = product.ReorderLevel, Date = purchase.ExpireDate, OpeningBalance = available, In = result.In, Out = result.Out, ClosingBalance = closing });

            }

            if (categoryId > 0)
            {

                resultList = resultList.Where(c => c.CategoryId == categoryId).ToList();
            }

            //foreach (var result in resultList)
            //{
            //    if (result.Reorder >= result.OpeningBalance)
            //    {
            //        finalList.Add(result);
            //    }
            //}
            resultList = resultList.Where(c => c.Reorder >= c.OpeningBalance).ToList();
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetExpiredProduct(int? productId, int? categoryId, DateTime startDate, DateTime endDate)
        {
            List<dynamic> dynamicList = new List<dynamic>();
            List<dynamic> dynamicList1 = new List<dynamic>();
            List<dynamic> dynamicList2 = new List<dynamic>();
            List<dynamic> dynamicList3 = new List<dynamic>();
            List<dynamic> resultList = new List<dynamic>();
            List<dynamic> finalList = new List<dynamic>();
            var expiredProducts = _purchaseManager.GetExpiredProduct(startDate, endDate);
            //bought before startDate
            var boughtBefore = _purchaseSupplierManager.BoughtBeforeDate(startDate);
            //bought between dates
            var boughtBetween = _purchaseSupplierManager.BoughtBetweenDates(startDate, endDate);

            foreach (var before in boughtBefore)
            {
                var purchases = _purchaseManager.GetByPurchaseSupplierId(before.ID);
                foreach (var purchase in purchases)
                {
                    dynamicList.Add(new { Id = purchase.ProductId, Opening = purchase.Quantity });
                }
            }

            foreach (var between in boughtBetween)
            {
                var purchases = _purchaseManager.GetByPurchaseSupplierId(between.ID);
                foreach (var purchase in purchases)
                {
                    dynamicList1.Add(new { Id = purchase.ProductId, In = purchase.Quantity });
                }
            }
            //products sold between dates
            var soldBetween = _customerSaleManager.GetSoldProducts(startDate, endDate);

            //products sold before start

            var soldBefore = _customerSaleManager.SoldProductsBefore(startDate);

            foreach (var product in soldBetween)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList2.Add(new { Id = sale.ProductId, Out = sale.Quantity });
                }
            }

            foreach (var product in soldBefore)
            {
                var sales = _productSaleManager.GetByProductSaleId(product.ID);
                foreach (var sale in sales)
                {
                    dynamicList3.Add(new { Id = sale.ProductId, Sold = sale.Quantity });
                }
            }
            var openingDetails = from p in dynamicList
                                 group p.Opening by p.Id into g
                                 select new { Id = g.Key, Openings = g.ToList().Sum(x => Convert.ToInt32(x)) };

            var openingSaleDetails = from p in dynamicList3
                                     group p.Sold by p.Id into g
                                     select new { Id = g.Key, BeforeSales = g.ToList().Sum(x => Convert.ToInt32(x)) };

            var inDetails = from p in dynamicList1
                            group p.In by p.Id into g
                            select new { Id = g.Key, Ins = g.ToList().Sum(x => Convert.ToInt32(x)) };


            var outDetails = from p in dynamicList2
                             group p.Out by p.Id into g
                             select new { Id = g.Key, Outs = g.ToList().Sum(x => Convert.ToInt32(x)) };



            var results = from b in openingDetails
                          join s in openingSaleDetails on b.Id equals s.Id
                          join i in inDetails on b.Id equals i.Id
                          join o in outDetails on b.Id equals o.Id
                          select new { Id = b.Id, Opening = b.Openings, OpeningSale = s.BeforeSales, In = i.Ins, Out = o.Outs };

            if (productId > 0)
            {

                results = results.Where(c => c.Id == productId).ToList();
            }
            foreach (var result in results)
            {
                Product aProduct = new Product();
                Category aCategory = new Category();
                aProduct.ID = result.Id;
                var product = _productManager.GetById(aProduct);
                aCategory.ID = product.CategoryId;
                var category = _categoryManager.GetById(aCategory);
                Purchase aPurchase = new Purchase();
                aPurchase.ProductId = result.Id;
                var purchase = _purchaseManager.GetProduct(aPurchase);
                var available = result.Opening - result.OpeningSale;
                var closing = (available + result.In) - result.Out;
                resultList.Add(new { Code = product.Code, Name = product.Name, Category = category.Name, Reorder = product.ReorderLevel, Date = purchase.ExpireDate, OpeningBalance = available, In = result.In, Out = result.Out, ClosingBalance = closing });

            }

            if (categoryId > 0)
            {

                resultList = resultList.Where(c => c.CategoryId == categoryId).ToList();
            }

            foreach (var result in resultList)
            {
                if (result.Date <= startDate)
                {
                    finalList.Add(result);
                }
            }
            //resultList = finalList.Where(c => c.Reorder <= c.OpeningBalance).ToList();
            return Json(finalList, JsonRequestBehavior.AllowGet);
        }
    }
}