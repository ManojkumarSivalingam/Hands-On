using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Business.Interfaces
{
    public interface ICustomersBusinessComponent : IBusinessComponent
    {
        IEnumerable<Customer> GetCustomers(string customerName = default(string));
        Customer GetCustomer(int customerId);
        bool SaveCustomerRecord(Customer customer);
    }
}
