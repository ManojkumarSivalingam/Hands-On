using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Security.Authorization
{
    public class AditiAuthorizationManager : ServiceAuthorizationManager
    {
        private static Dictionary<string, string[]> authorizationDetails =
            default( Dictionary<string, string[]> );

        static AditiAuthorizationManager()
        {
            authorizationDetails = new Dictionary<string, string[]>
            {
                { "aditiuser1", new string[] { "*" } },
                { "aditiuser2", new string[] { "getallcustomers", "getcustomers", "getcustomerdetails" } },
                { "aditiuser3", new string[] { "getcustomers" } }
            };
        }

        public override bool CheckAccess(OperationContext operationContext)
        {
            var authorizationStatus = default( bool );

            try
            {
                if ( operationContext != default( OperationContext ) )
                {
                    var userName = operationContext.ServiceSecurityContext.PrimaryIdentity.Name;
                    var user = userName.ToLower();
                    var action = operationContext.IncomingMessageHeaders.Action.ToLower();
                    var validation = !string.IsNullOrEmpty( user ) && !string.IsNullOrEmpty( action ) &&
                        authorizationDetails.ContainsKey( user );

                    if ( validation )
                    {
                        var allowedActions = authorizationDetails[user];

                        foreach ( var allowedAction in allowedActions )
                        {
                            if ( allowedAction.Equals( "*" ) || action.Contains( allowedAction ) )
                            {
                                authorizationStatus = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch { }

            return authorizationStatus;
        }
    }
}
