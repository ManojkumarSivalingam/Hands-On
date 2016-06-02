using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Storage.Interfaces
{
    public interface ISystemContext : IDisposable
    {
        IEnumerable<T> ExecuteRoutine<T>(string routineName,
            IDictionary<string, object> parameters = default(IDictionary<string,object>)) where T : class;

        void CommitChanges();
    }
}
