using SBMS_Project2.BLL.BLL;
using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMS_Project2.Controllers
{
    public class CategoryController : Controller
    {
        Category aCategory = new Category();
        CategoryManager _categoryManager = new CategoryManager();


        [HttpGet]
        public ActionResult Add()
        {
            aCategory.Categories = _categoryManager.GetAll();
            return View(aCategory);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Add(category);
            }


            aCategory.Categories = _categoryManager.GetAll();
            return View(aCategory);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            aCategory.ID = ID;

            var category = _categoryManager.GetById(aCategory);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Update(category);
                return RedirectToAction(nameof(Add));
            }

            return View(category);
        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            aCategory.ID = ID;
            var category = _categoryManager.GetById(aCategory);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Delete(category);
                return RedirectToAction("Add");
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult Search()
        {
            aCategory.Categories = _categoryManager.GetAll();
            return View(aCategory);
        }

        [HttpPost]
        public ActionResult Search(Category category)
        {
            var categories = _categoryManager.GetAll();
            if (category.Name != null)
            {
                categories = categories.Where(p => p.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }
            category.Categories = categories;
            return View(category);
        }
    }
}