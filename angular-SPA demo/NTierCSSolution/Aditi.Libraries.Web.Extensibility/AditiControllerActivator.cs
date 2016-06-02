using Aditi.Libraries.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aditi.Libraries.Web.Extensibility
{
    public class AditiControllerActivator : IControllerActivator
    {
        private const string INVALID_DI_CONTEXT_ERROR_MESSGAE = @"Invalid DI Context Specified!";

        private IObjectBuilder objectBuilder = default( IObjectBuilder );

        public AditiControllerActivator()
        {
            this.objectBuilder = DIContext.ObjectBuilder;

            if ( this.objectBuilder == default( IObjectBuilder ) )
                throw new ApplicationException( INVALID_DI_CONTEXT_ERROR_MESSGAE );
        }

        #region IControllerActivator Members

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            var controllerObject = default( IController );

            try
            {
                controllerObject = this.objectBuilder.Build( controllerType ) as IController;
            }
            catch { throw; }

            return controllerObject;
        }

        #endregion
    }
}
