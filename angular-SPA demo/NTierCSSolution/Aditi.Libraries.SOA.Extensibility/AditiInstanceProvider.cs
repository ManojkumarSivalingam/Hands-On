using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Aditi.Libraries.DI.Interfaces;
using System.Diagnostics;

namespace Aditi.Libraries.SOA.Extensibility
{
    public class AditiInstanceProvider : IInstanceProvider
    {
        private const string INVALID_DI_CONTEXT_ERROR_MESSAGE =
            @"Invalid DI Context Specified!";
        private IObjectBuilder objectBuilder = default( IObjectBuilder );
        private Type serviceType = default( Type );

        public AditiInstanceProvider(Type serviceType)
        {
            this.serviceType = serviceType;
            this.objectBuilder = DIContext.ObjectBuilder;

            if ( this.objectBuilder == default( IObjectBuilder ) )
                throw new FaultException( INVALID_DI_CONTEXT_ERROR_MESSAGE );
        }

        #region IInstanceProvider Members

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance( instanceContext );
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            var serviceObject = default( object );

            try
            {
                serviceObject = this.objectBuilder.Build( serviceType );
            }
            catch { throw; }

            return serviceObject;
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            instance = default( object );
        }

        #endregion
    }
}
