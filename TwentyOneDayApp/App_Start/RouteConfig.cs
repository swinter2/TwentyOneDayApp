using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TwentyOneDayApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Collection Detail",
                url: "{controller}/{action}/{year}/{month}/{day}",
                defaults: new { controller = "Collection", action = "Detail" },
                constraints: new { year= @"\d{4}", month= @"\d{1,2}", day = @"\d{1,2}" }
            );
            routes.MapRoute(
                name: "Today's Collection",
                url: "today",
                defaults: new { controller = "Collection", action = "Today" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Collection", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}