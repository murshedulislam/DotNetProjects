using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementSystemApp.BLL.BLL;
using SmallBusinessManagementSystemApp.Models.Models;

namespace SmallBusinessManagementSystemApp.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        Supplier _supplier = new Supplier();
        // GET: Supplier
        [HttpGet]
        public ActionResult Add()
        {
            _supplier.Suppliers = _supplierManager.GetAll();
            return View(_supplier);
        }

        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierManager.AddSupplier(supplier);
                supplier.Suppliers = _supplierManager.GetAll();
                
            }
           
            return View(supplier);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            _supplier.ID = Id;
            var supplier = _supplierManager.GetById(_supplier);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierManager.UpdateSupplier(supplier);
            }
            return View(supplier);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            _supplier.ID = Id;
            var supplier = _supplierManager.GetById(_supplier);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult Delete(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (_supplierManager.UpdateSupplier(supplier))
                {
                    ViewBag.SuccessMsg = "Deleted.";
                }

                else
                {
                    ViewBag.FailMsg = "Delete Failed.";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Failed.";
            }
            return View(supplier);
        }

        [HttpGet]
        public ActionResult Show()
        {
            _supplier.Suppliers = _supplierManager.GetAll();
            return View(_supplier);
        }
        [HttpPost]
        public ActionResult Show(Supplier supplier)
        {
            var suppliers = _supplierManager.GetAll();

            if (supplier.Code != null)
            {

                suppliers = suppliers.Where(c => c.Code.ToLower().Contains(supplier.Code.ToLower())).ToList();
            }

            if (supplier.Name != null)
            {
                //suppliers = suppliers.Where(c => c.Name.Contains(supplier.Name)).ToList();
                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(supplier.Name.ToLower())).ToList();
            }
            if (supplier.Address != null)
            {

                suppliers = suppliers.Where(c => c.Address.ToLower().Contains(supplier.Address.ToLower())).ToList();
            }
            if (supplier.Contact > 0)
            {
                suppliers = suppliers.Where(c => c.Contact == supplier.Contact).ToList();
            }
            if (supplier.Email != null)
            {

                suppliers = suppliers.Where(c => c.Email.ToLower().Contains(supplier.Email.ToLower())).ToList();
            }
            if (supplier.ContactPerson != null)
            {

                suppliers = suppliers.Where(c => c.ContactPerson.ToLower().Contains(supplier.ContactPerson.ToLower())).ToList();
            }

            supplier.Suppliers = suppliers;
            return View(supplier);
        }

        [HttpPost]
        public JsonResult GetSupplier(int id, string code, string name, string address, string email, int contact, string contactPerson)
        {
            Supplier aSupplier = new Supplier();
            aSupplier.ID = id;
            aSupplier.Code = code;
            aSupplier.Name = name;
            aSupplier.Address = address;
            aSupplier.Email = email;

            aSupplier.Contact = contact;
            aSupplier.ContactPerson = contactPerson;
            var supplier = _supplierManager.UpdateSupplier(aSupplier);
            var suppliers = _supplierManager.GetAll();
            return Json(suppliers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SearchSupplier(int? id, string code, string name, string address, string email, int? contact, string contactPerson)
        {
            var suppliers = _supplierManager.GetAll();

            if (code!= null)
            {

                suppliers = suppliers.Where(c => c.Code.ToLower().Contains(code.ToLower())).ToList();
            }

            if (name != null)
            {
                //suppliers = suppliers.Where(c => c.Name.Contains(supplier.Name)).ToList();
                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (address != null)
            {

                suppliers = suppliers.Where(c => c.Address.ToLower().Contains(address.ToLower())).ToList();
            }
            if (contact > 0)
            {
                suppliers = suppliers.Where(c => c.Contact == contact).ToList();
            }
            if (email != null)
            {

                suppliers = suppliers.Where(c => c.Email.ToLower().Contains(email.ToLower())).ToList();
            }
            if (contactPerson != null)
            {

                suppliers = suppliers.Where(c => c.ContactPerson.ToLower().Contains(contactPerson.ToLower())).ToList();
            }


            return Json(suppliers, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteSupplier(int id)
        {
            Supplier aSupplier = new Supplier();
            aSupplier.ID = id;
            
            var supplier = _supplierManager.DeleteSupplier(aSupplier);
            var suppliers = _supplierManager.GetAll();
            return Json(suppliers, JsonRequestBehavior.AllowGet);
        }
    }
}