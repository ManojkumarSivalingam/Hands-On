using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Aditi.Libraries.SOA.Extensibility
{
    public class AditiInstancingServiceBehavior : IServiceBehavior
    {
        private Type serviceType = default( Type );

        public AditiInstancingServiceBehavior(Type serviceType)
        {
            this.serviceType = serviceType;
        }

        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var instanceProvider = new AditiInstanceProvider( this.serviceType );
            var channelDispatchers = serviceHostBase.ChannelDispatchers;

            foreach ( ChannelDispatcher dispatcher in channelDispatchers )
            {
                var endpoints = dispatcher.Endpoints;

                foreach ( var endpoint in endpoints )
                    endpoint.DispatchRuntime.InstanceProvider = instanceProvider;
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        #endregion
    }
}
