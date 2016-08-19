using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using StabBlog.Models.ViewModels;

namespace StabBlog.Controllers
{
    public class ExhibitController : Controller
    {
        private PostManagement pm = new PostManagement();
        // GET: Exhibit
        public ActionResult ExhibitHome()
        {
            ExhibitHomeVM AllExhibitsAndWeapons = new ExhibitHomeVM();
            return View(AllExhibitsAndWeapons);
        }

        public ActionResult SingleExhibit(int id)
        {
            var SingleExhibit = new SingleExhibitVM();

            SingleExhibit.Exhibit = pm.GetExhibitById(id);
            SingleExhibit.WeaponsInExhibit = pm.GetAllWeapons();

            return View(SingleExhibit);
        }

        public ActionResult WeaponPage(int id)
        {
            var weapon = pm.GetWeaponById(id);

            return View(weapon);
        }

    }
}