using Aditi.Libraries.Web.Extensibility.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AditiRichWebUI.App_Start
{
    public static class FilterProvidersConfiguration
    {
        public static void Configure()
        {
            FilterProviders.Providers.Add( new AditiFilterProvider() );
        }
    }
}