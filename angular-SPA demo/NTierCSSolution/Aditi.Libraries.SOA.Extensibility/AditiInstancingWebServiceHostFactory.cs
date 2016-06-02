using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Extensibility
{
    public class AditiInstancingWebServiceHostFactory : WebServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var serviceHost = new AditiInstancingWebServiceHost( serviceType, baseAddresses );

            return serviceHost;
        }
    }
}
