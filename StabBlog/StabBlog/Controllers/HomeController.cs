using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StabBlog.Models.ViewModels;

namespace StabBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeVM latestHomeVm = new HomeVM();
            return View(latestHomeVm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}