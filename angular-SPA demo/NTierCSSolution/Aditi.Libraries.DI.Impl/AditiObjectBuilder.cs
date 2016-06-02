using Aditi.Libraries.DI.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.DI.Impl
{
    public class AditiObjectBuilder : IObjectBuilder
    {
        private IUnityContainer container = default( IUnityContainer );

        private AditiObjectBuilder(IUnityContainer container = default(IUnityContainer))
        {
            if ( container == default( IUnityContainer ) )
                this.container = new UnityContainer();
            else this.container = container;

            this.container.LoadConfiguration();
        }

        #region IObjectBuilder Members

        public T Build<T>()
        {
            return this.container.Resolve<T>();
        }

        public object Build(Type serviceType)
        {
            return this.container.Resolve( serviceType );
        }

        public IEnumerable<T> BuildAll<T>()
        {
            return this.container.ResolveAll<T>();
        }

        public IEnumerable<object> BuildAll(Type serviceType)
        {
            return this.container.ResolveAll( serviceType );
        }

        #endregion

        #region Singleton Implementation

        private static IObjectBuilder objectBuilder = default( IObjectBuilder );

        static AditiObjectBuilder()
        {
            objectBuilder = new AditiObjectBuilder();
        }

        public static IObjectBuilder Instance
        {
            get
            {
                return objectBuilder;
            }
        }

        #endregion

        #region IObjectBuilder Members

        public IObjectBuilder ChildInstance
        {
            get
            {
                return new AditiObjectBuilder( new UnityContainer() );
            }
        }

        #endregion
    }
}
