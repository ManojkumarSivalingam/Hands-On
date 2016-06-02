using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Web.Api.Interfaces
{
    public interface ICustomersApiController
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> GetFilteredCustomers(string customerName);
        Customer GetCustomerDetails(int customerId);
        bool PostCustomer(Customer customer);
    }
}
