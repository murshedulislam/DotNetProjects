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
    public class StockController : Controller
    {
        StockManager _stockManager = new StockManager();
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        Product _product = new Product();
        

        // GET: Stock
        public ActionResult Search()
        {
            
            return View();
        }



        [HttpPost]
        public ActionResult Search(ProductViewModel productViewModel)
        {


            _product.Name = productViewModel.ProductName;
            _product.CategoryName= productViewModel.CategoryName;
            
            List<ProductViewModel> products = _productManager.GetProducts(_product).Select(c => new ProductViewModel
            {
                ProductName = c.Name,
                CategoryName = c.Category.Name,
                ReorderLevel = c.ReorderLevel,
                Code = c.Code,
            }).ToList();

            foreach(var product in products)
            {
                Product pro = new Product();
                pro.ProductName = product.ProductName;
                var expireDate = _productManager.PurchaseDetails(pro);
                
                foreach(var item in products)
                {
                    if (item.ProductName == pro.ProductName)
                    {
                        item.ExpireDate = expireDate.ExpireDate;
                       

                    }
                }
            }
            ViewBag.Products = products;
            
            return View();
        }









        //[HttpPost]
        //public ActionResult Search()
        //{
        //    var products = _productManager.GetAll();
            

        //    var categories = _categoryManager.GetAll();
        //    foreach (var category in categories)
        //    {

        //        if (category.Products != null && category.Products.Any())
        //        {
        //            foreach (var product in category.Products)
        //            {
                        
        //            }
        //        }
        //    }

            
        //    //stock.Categories = categories;

        //    return View();
        //}
    }
}