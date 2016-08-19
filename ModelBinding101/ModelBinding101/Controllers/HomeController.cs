using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBinding101.Models;

namespace ModelBinding101.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestFormPost()
        {
            var person = new Person();
            person.PersonId = int.Parse(Request.Form["PersonId"]);
            person.FirstName = Request.Form["FirstName"];
            person.LastName = Request.Form["LastName"];
            return View("Result", person);
        }

        public ActionResult SimpleBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SimpleBinding(int personId, string firstName, string lastName)
        {
            var person = new Person();
            person.PersonId = personId;
            person.FirstName = firstName;
            person.LastName = lastName;
            return View("Result", person);
        }

        public ActionResult ObjectBinding()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult ObjectBinding(Person person)
        {
            return View("Result", person);
        }

        public ActionResult ComplexTypeBinding()
        {
            return View(new Person() {HomeAddress = new Address()});
        }

        [HttpPost]
        public ActionResult ComplexTypeBinding(Person person)
        {
            return View("Result2", person);
        }

        public ActionResult MultipleObjectsBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultipleObjectsBinding(List<Address> addresses )
        {
            return View("Result3", addresses);
        }

        public ActionResult ViewModelBinding()
        {
            return View(new PersonVM());
        }

        [HttpPost]
        public ActionResult ViewModelBinding(PersonVM personVM)
        {
            return View("Result2", personVM.Person);
        }
    }
}