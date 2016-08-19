using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryValidation.Models;

namespace JQueryValidation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrationForm()
        {
            var model = new RSVPResponse();
            return View(model);
        }

        public ActionResult RegistrationForm2()
        {
            var model = new RSVPResponse();
            return View(model);
        }



        [HttpPost]
        public ActionResult RegistrationForm(RSVPResponse model)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", model);
            }
            return View(model);
        }
    }
}