using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Web.Extensibility.Interfaces
{
    public interface ICacheService
    {
        object GetCache(string cacheKey);
        void SetCache(string cacheKey, object cacheObject);
    }
}
