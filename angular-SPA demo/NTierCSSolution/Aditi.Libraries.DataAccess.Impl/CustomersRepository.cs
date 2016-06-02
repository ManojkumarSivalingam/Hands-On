using Aditi.Libraries.DataAccess.Interfaces;
using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.SOA.Contracts.Faults;
using Aditi.Libraries.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.DataAccess.Impl
{
    public class CustomersRepository : ICustomersRepository
    {
        private ICustomersContext customersContext = default( ICustomersContext );

        public CustomersRepository(ICustomersContext customersContext)
        {
            this.customersContext = customersContext;
        }

        #region ICustomersRepository Members

        public IEnumerable<Customer> GetCustomersByName(string customerName)
        {
            var validation = !string.IsNullOrEmpty( customerName ) &&
                customersContext != default( ICustomersContext );

            if ( !validation )
                throw new ApplicationError { ErrorId = 1 };

            var routineName = @"dbo.uspGetCustomers @customerName";
            var parameters = new Dictionary<string, object>
            {
                { "@customerName", customerName }
            };

            var customersList = this.customersContext.ExecuteRoutine<Customer>(
                routineName, parameters );

            return customersList;
        }

        #endregion

        #region IRepository<Customer,int> Members

        public IEnumerable<Customer> GetAllEntities()
        {
            var validation = this.customersContext != default( ICustomersContext );

            if ( !validation )
                throw new ApplicationError { ErrorId = 1 };

            var customersList = this.customersContext.Customers.ToList();

            return customersList;
        }

        public Customer GetEntityByKey(int entityKey)
        {
            var validation = entityKey != default( int ) &&
                this.customersContext != default( ICustomersContext );

            if ( !validation )
                throw new ApplicationError { ErrorId = 1 };

            var filteredCustomer = this.customersContext.Customers.Where(
                customer => customer.CustomerId == entityKey ).FirstOrDefault();

            return filteredCustomer;
        }

        public bool AddNewEntity(Customer entity)
        {
            var validation = entity != default( Customer ) &&
                this.customersContext != default( ICustomersContext );

            if ( !validation )
                throw new ApplicationError { ErrorId = 1 };

            var status = default( bool );
            var addedRecord = this.customersContext.Customers.Add( entity );
            this.customersContext.CommitChanges();

            status = addedRecord != default( Customer );

            return status;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if ( this.customersContext != default( ICustomersContext ) )
                this.customersContext.Dispose();
        }

        #endregion
    }
}
