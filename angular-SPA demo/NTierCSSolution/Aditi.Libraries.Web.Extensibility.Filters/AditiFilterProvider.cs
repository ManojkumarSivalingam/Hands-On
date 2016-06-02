using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aditi.Libraries.Web.Extensibility.Filters
{
    public class AditiFilterProvider : IFilterProvider
    {
        #region IFilterProvider Members

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var controllerName = actionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            var actionName = actionDescriptor.ActionName.ToLower();

            if ( controllerName.Equals( "home" ) && actionName.Equals( "index" ) )
            {
                yield return new Filter( new OutputCacheAttribute
                {
                    CacheProfile = "HomeCacheProfile"
                }, FilterScope.Controller, default( int ) );
            }
        }

        #endregion
    }
}
