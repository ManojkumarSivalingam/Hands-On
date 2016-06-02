using Aditi.Libraries.Web.Extensibility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Aditi.Libraries.Web.Extensibility.Impl
{
    public class AditiCacheService : ICacheService
    {
        #region ICacheService Members

        public object GetCache(string cacheKey)
        {
            var cacheObject = default( object );

            if ( !string.IsNullOrEmpty( cacheKey ) )
            {
                if ( HttpContext.Current.Cache != default( Cache ) )
                {
                    cacheObject = HttpContext.Current.Cache[cacheKey];
                }
            }

            return cacheObject;
        }

        public void SetCache(string cacheKey, object cacheObject)
        {
            var validation = !string.IsNullOrEmpty( cacheKey ) && cacheObject != default( object );

            if ( validation )
                HttpContext.Current.Cache[cacheKey] = cacheObject;
        }

        #endregion

    }
}