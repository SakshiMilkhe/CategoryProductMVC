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
    public class ProductController : Controller
    {
        public ActionResult DisplayProducts(int? i)
        {
            ProductDAL pd = new ProductDAL();
            return View(pd.GetProducts().ToPagedList(i ?? 1, 5));
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            CategoryDAL cd = new CategoryDAL();
            ViewBag.Categories = cd.GetCategories().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                var c = new CategoryDAL();
                p.CategoryName = c.GetCategoryById(p.CategoryId).CategoryName;
                ProductDAL pd = new ProductDAL();
                int result = pd.CreateProduct(p);
                if (result > 0)
                {
                    return RedirectToAction("DisplayProducts");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ProductDAL pd = new ProductDAL();
            return View(pd.GetProductById(id));
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                var c = new CategoryDAL();
                p.CategoryName = c.GetCategoryById(p.CategoryId).CategoryName;
                ProductDAL pd = new ProductDAL();
                int result = pd.EditProduct(p);
                if (result > 0)
                {
                    return RedirectToAction("DisplayProducts");
                }
            }
            return View();
        }

        public ActionResult DetailsProduct(int id)
        {
            ProductDAL pd = new ProductDAL();
            return View(pd.GetProductById(id));
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            ProductDAL pd = new ProductDAL();
            return View(pd.GetProductById(id));
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                var c = new CategoryDAL();
                p.CategoryName = c.GetCategoryById(p.CategoryId).CategoryName;
                ProductDAL pd = new ProductDAL();
                int result = pd.DeleteProduct(p);
                if (result > 0)
                {
                    return RedirectToAction("DisplayProducts");
                }
            }
            return View();
        }
    }
}