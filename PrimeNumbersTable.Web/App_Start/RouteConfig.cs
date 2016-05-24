﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PrimeNumbersTable.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                MVC.PrimeNumbersTable.Name,
                "primenumberstable/generate/{totalOfPrimeNumbers}",
                new
                {
                    controller = MVC.PrimeNumbersTable.Name,
                    action = MVC.PrimeNumbersTable.ActionNames.Generate,
                    totalOfPrimeNumbers = 10
                }
                //,new { totalOfPrimeNumbers = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
