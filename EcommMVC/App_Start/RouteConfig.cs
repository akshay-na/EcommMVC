﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EcommMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(

                name: "Home",
                url: "",
                defaults: new { Controller = "ProductDetails", action = "Index", id = UrlParameter.Optional }

            );

            routes.MapRoute(

                name: "Products",
                url: "products/{action}/{id}",
                defaults: new { Controller = "ProductDetails", action = "Index", id = UrlParameter.Optional }

            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
