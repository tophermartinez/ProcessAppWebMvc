using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProcessAppWebMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
              
                defaults: new { controller = "Usuario2", action = "Read", id = UrlParameter.Optional }
              
            );

            //routes.MapRoute(
            //    name: "listar",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Mantenedor", action = "Read", id = UrlParameter.Optional }
            //);
        }
    }
}
