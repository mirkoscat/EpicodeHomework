using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{//come se fosse il main
    //creo istanza mvca e faccio app-start così configuro app

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {//dentro cartella app start
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
