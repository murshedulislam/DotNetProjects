using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementSystemApp.BLL.BLL;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.Models;
using AutoMapper;

namespace SmallBusinessManagementSystemApp.Controllers
{
    public class PurchaseController : Controller
    {
        Purchase _purchase = new Purchase();
        SupplierManager _supplierManager = new SupplierManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        PurchaseSupplierManager _purchaseSupplierManager = new PurchaseSupplierManager();
        // GET: Purchase
        [HttpGet]
        public ActionResult Add()
        {
            PurchaseViewModel purchasevm = new PurchaseViewModel();
            purchasevm.SupplierList = _supplierManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(), Text = c.Name
            });

            purchasevm.ProductList = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(purchasevm);
        }
        [HttpPost]
        public ActionResult Add(PurchaseViewModel purchasevm)
        {
            var purchases = new List<Purchase>();
            //Purchase _purchase = new Purchase();
            PurchaseSupplier _purchaseSupplier = new PurchaseSupplier();
            if (ModelState.IsValid)
            {
                _purchaseSupplier.Date = purchasevm.Date;
                _purchaseSupplier.SupplierId = purchasevm.SupplierId;
                _purchaseSupplier.InvoiceNumber = purchasevm.InvoiceNumber;
                _purchaseSupplierManager.AddPurchase(_purchaseSupplier);
                var ps = _purchaseSupplierManager.GetByCode(purchasevm.InvoiceNumber);
                foreach (var purchase in purchasevm.Purchases)
                {
                    //_purchase = Mapper.Map<Purchase>(purchase);

                    purchase.PurchaseSupplierId = ps.ID;

                    purchases.Add(purchase);
                }
               
                _purchaseManager.AddPurchase(purchases);
                
            }

            purchasevm.SupplierList = _supplierManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(), Text= c.Name
            });

            purchasevm.ProductList = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(purchasevm);
        }

        [HttpPost]
        
        public JsonResult GetProductCode(int productId)
        {
            Product _product = new Product();
            _product.ID = productId;
            var product = _productManager.GetById(_product);

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductMRP(int productId)
        {
            Purchase _purchase = new Purchase();
            _purchase.ProductId = productId;
            var purchase = _purchaseManager.GetProduct(_purchase);

            return Json(purchase, JsonRequestBehavior.AllowGet);
        }
    }
}