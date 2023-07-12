using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CategoryProductMVC.Models;
using PagedList;
using PagedList.Mvc;

namespace CategoryProductMVC.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult DisplayCategories(int? i)
        {
            CategoryDAL cd = new CategoryDAL();
            return View(cd.GetCategories().ToPagedList(i ?? 1, 5));
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            if (ModelState.IsValid)
            {
                CategoryDAL cd = new CategoryDAL();
                int result = cd.CreateCategory(c);
                if (result > 0)
                {
                    return RedirectToAction("DisplayCategories");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            CategoryDAL cd = new CategoryDAL();
            return View(cd.GetCategoryById(id));
        }

        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            if (ModelState.IsValid)
            {
                CategoryDAL cd = new CategoryDAL();
                int result = cd.EditCategory(c);
                if (result > 0)
                {
                    return RedirectToAction("DisplayCategories");
                }
            }
            return View();
        }

        public ActionResult DetailsCategory(int id)
        {
            CategoryDAL cd = new CategoryDAL();
            return View(cd.GetCategoryById(id));
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            CategoryDAL cd = new CategoryDAL();
            return View(cd.GetCategoryById(id));
        }

        [HttpPost]
        public ActionResult DeleteCategory(Category c)
        {
            if (ModelState.IsValid)
            {
                CategoryDAL cd = new CategoryDAL();
                int result = cd.DeleteCategory(c);
                if (result > 0)
                {
                    return RedirectToAction("DisplayCategories");
                }
            }
            return View();
        }
    }
}