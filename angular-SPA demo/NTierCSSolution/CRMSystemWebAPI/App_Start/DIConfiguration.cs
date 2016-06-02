using Aditi.Libraries.DI.Impl;
using Aditi.Libraries.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSystemWebAPI.App_Start
{
    public static class DIConfiguration
    {
        public static void Configure()
        {
            DIContext.ObjectBuilder = AditiObjectBuilder.Instance;
        }
    }
}