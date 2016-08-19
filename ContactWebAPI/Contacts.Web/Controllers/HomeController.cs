using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Data;
using Contacts.Models;

namespace Contacts.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var repo = Factory.CreateContactRepository();
            var contacts = repo.GetAll();

            return View(contacts);
        }

        [HttpPost]
        public ActionResult DeleteContact()
        {
            int contactId = int.Parse(Request.Form["ContactID"]);

            var repo = Factory.CreateContactRepository();
            repo.Delete(contactId);

            return View("Index", repo.GetAll());
        }

        public ActionResult AddContact()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            var repo = Factory.CreateContactRepository();
            repo.Add(contact);

            return RedirectToAction("Index");
        }

        public ActionResult EditContact(int id)
        {
            var repo = Factory.CreateContactRepository();
            var contact = repo.GetById(id);

            return View(contact);
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            var repo = Factory.CreateContactRepository();
            repo.Edit(contact);

            return RedirectToAction("Index");
        }
    }
}