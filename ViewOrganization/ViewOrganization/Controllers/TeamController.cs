using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewOrganization.Models;

namespace ViewOrganization.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            var players = new List<Player>()
            {
                new Player()
                {
                    Name = "Fransisco Lindor",
                    Number = 12,
                    Position = "SS"
                },
                new Player()
                {
                    Name = "John Kipnis",
                    Number = 22,
                    Position = "2B"
                }
            };

            return View(players);
        }
    }
}