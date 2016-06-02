using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Proxies
{
    public class CustomerServiceProxy : ICustomerService, IDisposable
    {
        private const string ENDPOINT_CONFIG_NAME = @"CustomerServiceEndpoint";

        private ICustomerService customerService = default( ICustomerService );
        private ChannelFactory<ICustomerService> customerServiceChannelFactory =
            default( ChannelFactory<ICustomerService> );

        public CustomerServiceProxy(string userName = default(string), string password = default(string))
        {
            this.customerServiceChannelFactory = new ChannelFactory<ICustomerService>(
                endpointConfigurationName: ENDPOINT_CONFIG_NAME );

            this.customerServiceChannelFactory.Credentials.UserName.UserName = userName;
            this.customerServiceChannelFactory.Credentials.UserName.Password = password;

            this.customerService = this.customerServiceChannelFactory.CreateChannel();
        }


        #region ICustomerService Members

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.customerService.GetAllCustomers();
        }

        public IEnumerable<Customer> GetCustomers(string customerName)
        {
            return this.customerService.GetCustomers( customerName );
        }

        public Customer GetCustomerDetails(int customerId)
        {
            return this.customerService.GetCustomerDetails( customerId );
        }

        public bool SaveCustomer(Customer customer)
        {
            return this.customerService.SaveCustomer( customer );
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if ( this.customerServiceChannelFactory != default( ChannelFactory<ICustomerService> ) )
                this.customerServiceChannelFactory.Close();
        }

        #endregion
    }
}
