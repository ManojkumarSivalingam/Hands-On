using Aditi.Libraries.Business.Interfaces;
using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Impl
{
    [ServiceBehavior(
        Namespace = NamespaceConstants.BEHAVIORS )]
    public class CustomerService : ICustomerService, IDisposable
    {
        private const string INVALID_BUSINESS_COMPONENT_ERROR_MESSAGE =
            @"Invalid Business Component (or) Parameters Specified!";

        private ICustomersBusinessComponent customersBusinessComponent = default( ICustomersBusinessComponent );

        public CustomerService(ICustomersBusinessComponent customersBusinessComponent)
        {
            this.customersBusinessComponent = customersBusinessComponent;
        }

        #region ICustomerService Members

        [OperationBehavior]
        public IEnumerable<Customer> GetAllCustomers()
        {
            var validation = this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new FaultException( INVALID_BUSINESS_COMPONENT_ERROR_MESSAGE );

            var customersList = default( IEnumerable<Customer> );

            try
            {
                customersList = this.customersBusinessComponent.GetCustomers();
            }
            catch ( Exception exceptionObject )
            {
                exceptionObject.Log();

                throw exceptionObject.Transform( errorId: 101 );
            }

            return customersList;
        }

        [OperationBehavior]
        public IEnumerable<Customer> GetCustomers(string customerName)
        {
            var validation = !string.IsNullOrEmpty( customerName ) &&
                this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new FaultException( INVALID_BUSINESS_COMPONENT_ERROR_MESSAGE );

            var customersList = default( IEnumerable<Customer> );

            try
            {
                customersList = this.customersBusinessComponent.GetCustomers( customerName );
            }
            catch ( Exception exceptionObject )
            {
                exceptionObject.Log();

                throw exceptionObject.Transform( errorId: 102 );
            }

            return customersList;
        }

        [OperationBehavior]
        public Customer GetCustomerDetails(int customerId)
        {
            var validation = customerId != default( int ) &&
                this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new FaultException( INVALID_BUSINESS_COMPONENT_ERROR_MESSAGE );

            var filteredCustomer = default( Customer );

            try
            {
                filteredCustomer = this.customersBusinessComponent.GetCustomer( customerId );
            }
            catch ( Exception exceptionObject )
            {
                exceptionObject.Log();

                throw exceptionObject.Transform( errorId: 103 );
            }

            return filteredCustomer;
        }

        [OperationBehavior]
        public bool SaveCustomer(Customer customer)
        {
            var validation = customer != default( Customer ) &&
                this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new FaultException( INVALID_BUSINESS_COMPONENT_ERROR_MESSAGE );

            var status = default( bool );

            try
            {
                status = this.customersBusinessComponent.SaveCustomerRecord( customer );
            }
            catch ( Exception exceptionObject )
            {
                exceptionObject.Log();

                throw exceptionObject.Transform( errorId: 104 );
            }

            return status;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if ( this.customersBusinessComponent != default( ICustomersBusinessComponent ) )
                this.customersBusinessComponent.Dispose();
        }

        #endregion
    }
}
