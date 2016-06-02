using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AditiRichWebUI.App_Start
{
    public static class ServerCredentialsConfiguration
    {
        public static void Configure()
        {
            if ( HttpContext.Current.Application != default( HttpApplicationState ) )
            {
                HttpContext.Current.Application.Add( "ServiceCredentials",
                    new string[] { "aditiuser1", "Prestige123$$/?" } );
            }
        }
    }
}