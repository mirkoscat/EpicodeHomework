using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{//viene deciso il modello di chiamata che dobbiamo gestire.
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //tutte le chiamate vengono scritte nel formato url
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",//action=nomemetodo
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
