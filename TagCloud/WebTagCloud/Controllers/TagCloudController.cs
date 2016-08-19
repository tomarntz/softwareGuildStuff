using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sparc.TagCloud;

namespace WebTagCloud.Controllers
{
    public class TagCloudController : Controller
    {
        // GET: TagCloud
        public ActionResult Index()
        {
            var tags = new string[] {"Tom","Tom" ,"Tom" ,"Tom" ,"Tom",
                                    "Andy","Andy","Andy","Andy",
                                    "Sam","Sam","Sam",
                                    "Brendan"};
            var model =new TagCloudAnalyzer()
                .ComputeTagCloud(tags);
            return View(model);
        }
    }
}