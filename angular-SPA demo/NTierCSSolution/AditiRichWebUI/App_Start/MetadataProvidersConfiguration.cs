using Aditi.Libraries.Web.Models.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AditiRichWebUI.App_Start
{
    public static class MetadataProvidersConfiguration
    {
        public static void Configure()
        {
            ModelMetadataProviders.Current = new AditiModelMetadataProvider();

            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add( new AditiModelValidatorProvider() );
        }
    }
}