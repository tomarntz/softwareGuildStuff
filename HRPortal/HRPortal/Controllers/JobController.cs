using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models.Data;
using HRPortal.Models.Repositories;
using HRPortal.Models.Repositories.JobRepos;

namespace HRPortal.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Jobs()
        {
            var model = JobRepository.GetAllJobs();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult EditJob(int id)
        {
            var job = JobRepository.Get(id);
            return View(job);
        }

        [HttpPost]
        public ActionResult EditJob(Job job)
        {
            JobRepository.Edit(job);
            return RedirectToAction("Jobs");
        }

        public ActionResult AddJob()
        {
            return View(new Job());
        }

        [HttpPost]
        public ActionResult AddJob(string position, string discription)
        {
            JobRepository.Add(position, discription);
            return RedirectToAction("Jobs");
        }

        public ActionResult DeleteJob(int id)
        {
            var job = JobRepository.Get(id);
            return View(job);
        }

        [HttpPost]
        public ActionResult DeleteJob(Job job)
        {
            JobRepository.Delete(job.JobId);
            return RedirectToAction("Jobs");
        }

        public ActionResult Apply(int id)
        {
            var j = JobRepository.Get(id);

            return View(j);
        }

        [HttpPost]
        public ActionResult Apply()
        {
            throw new ArgumentException();
        }
    }
}