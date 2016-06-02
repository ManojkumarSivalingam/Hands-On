using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Aditi.Libraries.SOA.Proxies.Extensions
{
    public class SecuredCustomerServiceProxy : ICustomerService
    {
        private CustomerServiceProxy customerServiceProxy = default( CustomerServiceProxy );

        public SecuredCustomerServiceProxy()
        {
            var httpApplication = HttpContext.Current.Application;

            if ( httpApplication != default( HttpApplicationState ) )
            {
                string[] credentials = ( string[] ) httpApplication.Get( "ServiceCredentials" );

                customerServiceProxy = new CustomerServiceProxy( credentials[0], credentials[1] );
            }
        }


        #region ICustomerService Members

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.customerServiceProxy.GetAllCustomers();
        }

        public IEnumerable<Customer> GetCustomers(string customerName)
        {
            return this.customerServiceProxy.GetCustomers( customerName );
        }

        public Customer GetCustomerDetails(int customerId)
        {
            return this.customerServiceProxy.GetCustomerDetails( customerId );
        }

        public bool SaveCustomer(Customer customer)
        {
            return this.customerServiceProxy.SaveCustomer( customer );
        }

        #endregion
    }
}
