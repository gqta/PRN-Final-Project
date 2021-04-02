﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PRN_Final_Project
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "QuizAPI",
                routeTemplate: "api/quiz/{id}",
                defaults: new { controller="QuizAPI", action="Get", id = RouteParameter.Optional }
            );
        }
    }
}
