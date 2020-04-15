using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ConteoSega",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ConteoSega", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}