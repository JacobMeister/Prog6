﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Prog6_Eindopdracht.ASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tamagotchis", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TamagotchiModel",
                url: "{controller}/{action}/{name}/{id}"
             );
        }
    }
}
