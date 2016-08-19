using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;
using HRPortal.Models.Repositories;
using HRPortal.Models.Repositories.JobRepos;
using HRPortal.Models.Repositories.Personrepo;

namespace HRPortal.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListApplicantts()
        {
            var vm = PersonRepository.GetAll();


            return View(vm);
        }

        public ActionResult ListApplicantsByJob(int jobId)
        {
            var model = PersonRepository.GetPersonByJob(jobId);
            return View();
        }
    }
}