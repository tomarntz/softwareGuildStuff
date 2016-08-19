using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models.Data;
using HRPortal.Models.Repositories.CategoryRepo;

namespace HRPortal.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult MenuLinks()
        {
            return PartialView("_MenuLinks",CategoryRepository.ReadAll());
        }

        public ActionResult Delete(int id)
        {
            var category = CategoryRepository.Read(id);
            return View(category);
        }

        public ActionResult Add()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            CategoryRepository.Create(category.Name);
            return RedirectToAction("Index","Home");
        }
    }
}