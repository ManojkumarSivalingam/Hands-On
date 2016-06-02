using Aditi.Libraries.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Aditi.Libraries.WebAPI.Extensibility.DI
{
    public class AditiApiDependencyResolver : IDependencyResolver
    {
        private IObjectBuilder objectBuilder = default( IObjectBuilder );

        public AditiApiDependencyResolver()
        {
            this.objectBuilder = DIContext.ObjectBuilder;
        }

        public AditiApiDependencyResolver(IObjectBuilder objectBuilder)
        {
            this.objectBuilder = objectBuilder;
        }

        #region IDependencyResolver Members

        public IDependencyScope BeginScope()
        {
            return new AditiApiDependencyResolver(
                DIContext.ObjectBuilder.ChildInstance );
        }

        #endregion

        #region IDependencyScope Members

        public object GetService(Type serviceType)
        {
            var service = default( object );

            try
            {
                service = this.objectBuilder.Build( serviceType );
            }
            catch { }

            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var services = default( IEnumerable<object> );

            try
            {
                services = this.objectBuilder.BuildAll( serviceType );
            }
            catch { }

            return services;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.objectBuilder = default( IObjectBuilder );
        }

        #endregion
    }
}
