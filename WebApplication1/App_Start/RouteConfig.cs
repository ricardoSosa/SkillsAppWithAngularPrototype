﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "routeOne",
               url: "routesDemo/One",
               defaults: new { controller = "RoutesDemo", action = "One" });

            routes.MapRoute(
                name: "routeTwo",
                url: "routesDemo/Two/{donuts}",
                defaults: new { controller = "RoutesDemo", action = "Two", donuts = UrlParameter.Optional });

            routes.MapRoute(
                name: "routeThree",
                url: "routesDemo/Three",
                defaults: new { controller = "RoutesDemo", action = "Three" });

            routes.MapRoute(
                name: "routeFour",
                url: "routesDemo/Four",
                defaults: new { controller = "RoutesDemo", action = "Four" });

            routes.MapRoute(
                name: "login",
                url: "Account/Login",
                defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "register",
                url: "Account/Register",
                defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
                name: "createProject",
                url: "routesDemo/CreateProject",
                defaults: new { controller = "RoutesDemo", action = "CreateProject" });

            routes.MapRoute(
                name: "projectResult",
                url: "routesDemo/ProjectResult",
                defaults: new { controller = "RoutesDemo", action = "ProjectResult" });

            routes.MapRoute(
                name: "createEmployee",
                url: "RoutesDemo/CreateEmployee",
                defaults: new { controller = "RoutesDemo", action = "CreateEmployee" });

            routes.MapRoute(
                name: "createSkill",
                url: "RoutesDemo/CreateSkill",
                defaults: new { controller = "RoutesDemo", action = "CreateSkill" });

            routes.MapRoute(
                name: "read",
                url: "RoutesDemo/Read",
                defaults: new { controller = "RoutesDemo", action = "Read" });

            routes.MapRoute(
                name: "update",
                url: "RoutesDemo/Update",
                defaults: new { controller = "RoutesDemo", action = "Update" });

            routes.MapRoute(
                name: "delete",
                url: "RoutesDemo/Delete",
                defaults: new { controller = "RoutesDemo", action = "Delete" });

            routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}
