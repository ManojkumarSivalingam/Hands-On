using Aditi.Libraries.Business.Interfaces;
using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.Web.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CRMSystemWebAPI.Controllers
{
    [EnableCors( "*", "*", "*" )]
    public class CustomersController : ApiController, ICustomersApiController
    {
        private ICustomersBusinessComponent customersBusinessComponent = default( ICustomersBusinessComponent );

        public CustomersController(ICustomersBusinessComponent customersBusinessComponent)
        {
            this.customersBusinessComponent = customersBusinessComponent;
        }

        #region ICustomersApiController Members

        public IEnumerable<Customer> GetAllCustomers()
        {
            var validation = this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new ApplicationException( "Invalid Customer Component Context Specified!" );

            var customers = this.customersBusinessComponent.GetCustomers();

            return customers;
        }

        public IEnumerable<Customer> GetFilteredCustomers(string customerName)
        {
            var validation = !string.IsNullOrEmpty( customerName ) &&
                this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new ApplicationException( "Invalid Parameters or Customers Component Context Specified!" );

            var customers = this.customersBusinessComponent.GetCustomers( customerName );

            return customers;
        }

        public Customer GetCustomerDetails(int id)
        {
            var validation = id != default( int ) &&
                   this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new ApplicationException( "Invalid Parameters or Customers Component Context Specified!" );

            var filteredCustomer = this.customersBusinessComponent.GetCustomer( id );

            return filteredCustomer;
        }

        public bool PostCustomer(Customer customer)
        {
            var validation = customer != default( Customer ) &&
                    this.customersBusinessComponent != default( ICustomersBusinessComponent );

            if ( !validation )
                throw new ApplicationException( "Invalid Parameters or Customers Component Context Specified!" );

            var status = this.customersBusinessComponent.SaveCustomerRecord( customer );

            return status;
        }

        #endregion
    }
}
