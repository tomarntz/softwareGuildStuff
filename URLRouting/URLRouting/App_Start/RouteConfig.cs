using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace URLRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("CustomerList", "PeopleToKeepHappy",
                new {controller = "Customer", action = "List"});

            routes.MapRoute("AdminPages", "Configuration",
                new {controller = "Admin", action = "Index"});

            routes.MapRoute("ToMuchFun", "Resistance/{name}",
                new {controller = "Home", action = "AnotherVariable"});

            routes.MapRoute("MyRoute", "{Controller}/{Action}/{id}",
                new {controller = "Customer",action = "Index", id = 21});
            
        }
    }
}
