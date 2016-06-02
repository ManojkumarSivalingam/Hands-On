using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Web.Api.Interfaces
{
    public interface IOrdersApiController
    {
        IEnumerable<Order> GetOrders(int id);
    }
}
