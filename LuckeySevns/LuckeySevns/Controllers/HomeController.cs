using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckeySevns.Models;
using LuckeySevns.Models.WorkFlows;

namespace LuckeySevns.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LuckeySevensMVC()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LuckeySevensMVC(decimal amount)
        {
            var player = new Player() {StartingBet = amount};

            var gameWF = new GameWorkFlow();
            gameWF.PlayGame(player);

            return View("Results", player);
        }

        public ActionResult LuckySevensJS()
        {
            return View();
        }
    }
}