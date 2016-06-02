using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.DataAccess.Interfaces
{
    public interface ICustomersRepository : IRepository<Customer, int>
    {
        IEnumerable<Customer> GetCustomersByName(string customerName);
    }
}
