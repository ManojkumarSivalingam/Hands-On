using Aditi.Libraries.DI.Impl;
using Aditi.Libraries.DI.Interfaces;
using Aditi.Libraries.Web.Extensibility;
using AditiRichWebUI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AditiRichWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ServerCredentialsConfiguration.Configure();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            DIConfiguration.Configure();
            MetadataProvidersConfiguration.Configure();
            FilterProvidersConfiguration.Configure();
        }
    }
}
