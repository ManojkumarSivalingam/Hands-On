using Aditi.Libraries.Business.Impl.Validations;
using Aditi.Libraries.Business.Interfaces;
using Aditi.Libraries.DataAccess.Interfaces;
using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.SOA.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Business.Impl
{
    public class CustomersBusinessComponent : ICustomersBusinessComponent
    {
        private const string SAVE_ERROR_MESSGAE = @"Invalid Customer Details (or) Repository Specified!";
        private const string INVALID_CONTEXT_ERROR_MESSAGE = "Invalid Customer Repository Specified!";
        private const string INVALID_SEARCH_STRING_MESSAGE = "Invalid Customer Search String Specified!";

        private ICustomersRepository customersRepository = default( ICustomersRepository );
        private ICustomerValidator customerValidator = default( ICustomerValidator );

        public CustomersBusinessComponent(
            ICustomersRepository customersRepository, ICustomerValidator customerValidator)
        {
            this.customersRepository = customersRepository;
            this.customerValidator = customerValidator;
        }

        #region ICustomersBusinessComponent Members

        public IEnumerable<Customer> GetCustomers(string customerName = default(string))
        {
            var validation = this.customersRepository != default( ICustomersRepository ) &&
                this.customerValidator != default( ICustomerValidator );

            if ( !validation )
                throw new ApplicationError( INVALID_CONTEXT_ERROR_MESSAGE ) { ErrorId = 3 };

            var customersList = default( IEnumerable<Customer> );

            if ( string.IsNullOrEmpty( customerName ) )
                customersList = this.customersRepository.GetAllEntities();
            else
            {
                validation = this.customerValidator.Validate( customerName );

                if ( !validation )
                    throw new ApplicationError( INVALID_SEARCH_STRING_MESSAGE ) { ErrorId = 4 };

                customersList = this.customersRepository.GetCustomersByName( customerName );
            }

            return customersList;
        }

        public bool SaveCustomerRecord(Customer customer)
        {
            var validation = customer != default( Customer ) &&
                this.customersRepository != default( ICustomersRepository ) &&
                this.customerValidator != default( ICustomerValidator ) &&
                this.customerValidator.Validate( customer );

            if ( !validation )
                throw new ApplicationError( SAVE_ERROR_MESSGAE ) { ErrorId = 2 };

            var status = this.customersRepository.AddNewEntity( customer );

            return status;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if ( this.customersRepository != default( ICustomersRepository ) )
                this.customersRepository.Dispose();
        }

        #endregion

        #region ICustomersBusinessComponent Members


        public Customer GetCustomer(int customerId)
        {
            var validation = customerId != default( int ) &&
                this.customersRepository != default( ICustomersRepository );

            if ( !validation )
                throw new ApplicationError { ErrorId = 2 };

            var filteredCustomer = this.customersRepository.GetEntityByKey( customerId );

            return filteredCustomer;
        }

        #endregion
    }
}
