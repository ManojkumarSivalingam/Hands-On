using Aditi.Libraries.DI.Impl;
using Aditi.Libraries.DI.Interfaces;
using Aditi.Libraries.Web.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AditiRichWebUI.App_Start
{
    public static class DIConfiguration
    {
        public static void Configure()
        {
            DIContext.ObjectBuilder = AditiObjectBuilder.Instance;
            DependencyResolver.SetResolver( new AditiDependencyResolver() );
        }
    }
}