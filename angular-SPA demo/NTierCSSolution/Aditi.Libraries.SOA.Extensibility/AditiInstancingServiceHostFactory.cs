using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Extensibility
{
    public class AditiInstancingServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var serviceHost = new AditiInstancingServiceHost( serviceType, baseAddresses );

            return serviceHost;
        }
    }
}
