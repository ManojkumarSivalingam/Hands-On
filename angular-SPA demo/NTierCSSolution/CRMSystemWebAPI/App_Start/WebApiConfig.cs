using Aditi.Libraries.WebAPI.Extensibility.DI;
using CRMSystemWebAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CRMSystemWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.EnableCors();

            DIConfiguration.Configure();

            config.DependencyResolver = new AditiApiDependencyResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
