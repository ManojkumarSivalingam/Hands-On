using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Security.Authentication
{
    public class AditiAuthenticationManager : UserNamePasswordValidator
    {
        private static Dictionary<string, string> credentials = default( Dictionary<string, string> );

        static AditiAuthenticationManager()
        {
            credentials = new Dictionary<string, string>
            {
                { "aditiuser1", "Prestige123$$/?" },
                { "aditiuser2", "Prestige123$$/?" },
                { "aditiuser3", "Prestige123$$/?" },
                { "aditiuser4", "Prestige123$$/?" },
                { "aditiuser5", "Prestige123$$/?" }
            };
        }

        public override void Validate(string userName, string password)
        {
            var validation = !string.IsNullOrEmpty( userName ) && !string.IsNullOrEmpty( password ) &&
                credentials.ContainsKey( userName.ToLower() );

            if ( !validation )
                throw new FaultException(
                    new FaultReason( "Invalid Credential Details Specified!" ) );

            var user = userName.ToLower();
            var credential = credentials[user];

            var authenticationStatus = !string.IsNullOrEmpty( credential ) &&
                credential.Equals( password );

            if ( !authenticationStatus )
                throw new FaultException(
                    new FaultReason( "Authentication Failed!" ) );
        }
    }
}
