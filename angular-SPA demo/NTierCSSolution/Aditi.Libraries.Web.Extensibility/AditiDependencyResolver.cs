using Aditi.Libraries.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aditi.Libraries.Web.Extensibility
{
    public class AditiDependencyResolver : IDependencyResolver
    {
        private const string INVALID_DI_CONTEXT_ERROR_MESSGAE = @"Invalid DI Context Specified!";
        
        private IObjectBuilder objectBuilder = default( IObjectBuilder );

        public AditiDependencyResolver()
        {
            this.objectBuilder = DIContext.ObjectBuilder;

            if ( this.objectBuilder == default( IObjectBuilder ) )
                throw new ApplicationException( INVALID_DI_CONTEXT_ERROR_MESSGAE );
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            var serviceObject = default( object );

            if ( serviceType == typeof( IControllerActivator ) )
                serviceObject = new AditiControllerActivator();
            
            return serviceObject;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var serviceObjects = default( IEnumerable<object> );

            try
            {
                serviceObjects = this.objectBuilder.BuildAll( serviceType );
            }
            catch { throw; }

            return serviceObjects;
        }

        #endregion
    }
}
