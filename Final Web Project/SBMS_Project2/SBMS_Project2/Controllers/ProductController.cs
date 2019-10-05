using SBMS_Project2.BLL.BLL;
using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMS_Project2.Controllers
{
    public class ProductController : Controller
    {
        Product aProduct = new Product();
        ProductManager _productManager = new ProductManager();
        private CategoryManager _categoryManager = new CategoryManager();

        

        [HttpGet]
        public ActionResult Add()
        {
            aProduct.Products = _productManager.GetAll();
            aProduct.Categories = _categoryManager.GetAll();
            
            return View(aProduct);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            _productManager.Add(product);

            aProduct.Products = _productManager.GetAll();
            aProduct.Categories = _categoryManager.GetAll();

            return View(aProduct);
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            aProduct.ID = ID;
            
            var product = _productManager.GetById(aProduct);
            var categories = _categoryManager.GetAll();
            ViewBag.Categories = new SelectList(categories, "ID", "Name");
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var categories = _categoryManager.GetAll();
            ViewBag.Categories = new SelectList(categories, "ID", "Name");
            if (ModelState.IsValid)
            {
                _productManager.Update(product);
                return RedirectToAction(nameof(Search));
            }
            
            return View(product);
        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            aProduct.ID = ID;
            var product = _productManager.GetById(aProduct);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                _productManager.Delete(product);
                return RedirectToAction("Search");
            }

            return View(product);
        }


        [HttpGet]
        public ActionResult Search()
        {
            aProduct.Products = _productManager.GetAll();
            return View(aProduct);
        }

        [HttpPost]
        public ActionResult Search(Product product)
        {
            var products = _productManager.GetAll();
            if (product.Name != null)
            {
                products = products.Where(p => p.Name.ToLower().Contains(product.Name.ToLower())).ToList();
            }
            product.Products = products;
            return View(product);
        }
    }
}