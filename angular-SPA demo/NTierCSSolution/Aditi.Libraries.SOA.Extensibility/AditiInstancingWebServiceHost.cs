using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Extensibility
{
    public class AditiInstancingWebServiceHost : WebServiceHost
    {
        public AditiInstancingWebServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base( serviceType, baseAddresses )
        {
            var serviceBehavior = new AditiInstancingServiceBehavior( serviceType );

            Description.Behaviors.Add( serviceBehavior );
        }
    }
}
