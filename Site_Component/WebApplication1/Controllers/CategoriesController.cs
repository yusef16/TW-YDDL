using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Domain.Entities.Categories;
using siteComponente.Domain.Entities.Products;
using siteComponente.Web.ActionAtributes;
using siteComponente.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static siteComponente.BussinessLogic.Core.CategoryApi;

namespace siteComponente.Web.Controllers
{
     public class CategoriesController : BaseController
     {
          private readonly ISession _session;
          private readonly ICategory _category;
          public CategoriesController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
               _category = bl.GetCategoryBL();


          }
          [HttpGet]
          public ActionResult Index()
          {
               return View(_category.GetCategoryList());
          }

          [HttpGet]
          [AdminMod]
          public ActionResult CreatePage()
          {
               ViewBag.Message = "Create Page";
               return View();
          }
          [HttpPost]
          [AdminMod]
          public ActionResult CreatePage(CategoryForm category)
          {
               if (!ModelState.IsValid)
               {
                    return View(category);
               }
               var categoryData = new CategoryData
               {
                    Name = category.Name,
                    Thumbnail = category.Thumbnail
               };
               var response = _category.ValidateCreateCategory(categoryData);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Categories");
               }
               else
               {
                    ModelState.AddModelError("Name category already exists", response.StatusMessage);
                    return View(category);
               }
          }
          [HttpGet]
          [AdminMod]
          public ActionResult Edit(int id)
          {
               var category = _category.GetCategoryById(id);
               if (category == null)
               {
                    return RedirectToAction("Index", "Categories");
               }
               else
               {
                    return View(_category.GetCategoryById(id));
               }

          }
          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Category editCategory)
          {
               var response = _category.ValidateEditCategory(editCategory);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Categories");
               }
               else
               {
                    ModelState.AddModelError("Category already exists", response.StatusMessage);
                    return View(editCategory);
               }
          }


          [AdminMod]
          [HttpGet]
          public ActionResult Delete(int id)
          {
               var category = _category.GetCategoryById(id);
               if (category == null)
               {
                    return RedirectToAction("Index", "Categories");
               }
               else
               {
                    return View(_category.GetCategoryById(id));
               }
          }
          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(Category deleteCategory)
          {
               var response = _category.ValidateDeleteCategory(deleteCategory);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Categories");
               }
               else
               {
                    ModelState.AddModelError("Category already exists", response.StatusMessage);
                    return View(deleteCategory);
               }
          }


     }
}