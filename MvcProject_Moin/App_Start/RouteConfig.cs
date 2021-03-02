using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcProject_Moin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable Attribute Routing
            routes.MapMvcAttributeRoutes();

            // Specific Route - StuffController
            routes.MapRoute(
                name: "Route02",
                url: "Stuff/{action}/{id}",
                defaults: new { controller = "Stuff", action = "Details", id = UrlParameter.Optional }
             );


            // Specific Route - StuffController
            routes.MapRoute(
                name: "Route01",
                url: "Stuff/{action}",
                defaults: new { controller = "Stuff", action = "Index" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
