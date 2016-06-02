using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.DI.Interfaces
{
    public interface IObjectBuilder
    {
        T Build<T>();
        object Build(Type serviceType);

        IEnumerable<T> BuildAll<T>();
        IEnumerable<object> BuildAll(Type serviceType);

        IObjectBuilder ChildInstance { get; }
    }
}
