using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListADO.Data;

namespace TaskListADO.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DBRepository repo = new DBRepository();
            
            return View(repo.GetAll());
        }

    }
}