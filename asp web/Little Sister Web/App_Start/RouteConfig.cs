using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Little_Sister_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name:"Main",
                url: "{controller}/{action}/{name}/{lastPosTime}/{url}/{ghost}/{mail}/{lastPos}",
                defaults: new { controller = "Main", action = "Rechercher", name=UrlParameter.Optional, lastPosTime=UrlParameter.Optional, url = UrlParameter.Optional, ghost=UrlParameter.Optional, mail=UrlParameter.Optional, lastPos=UrlParameter.Optional}
            );
        }
    }
}
