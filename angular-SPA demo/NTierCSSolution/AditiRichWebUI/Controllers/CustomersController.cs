using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.SOA.Contracts.Faults;
using Aditi.Libraries.SOA.Contracts.Services;
using Aditi.Libraries.Web.Controller.Interfaces;
using Aditi.Libraries.Web.Extensibility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AditiRichWebUI.Controllers
{
    public class CustomersController : Controller, ICustomersController
    {
        private const string INVALID_CUSTOMER_SERVICE_MESSAGE =
            @"Invalid Customer Service Context (or) Details Specified!";

        private ICacheService cacheService = default( ICacheService );
        private ICustomerService customerService = default( ICustomerService );

        public CustomersController(ICustomerService customerService, ICacheService cacheService)
        {
            this.customerService = customerService;
            this.cacheService = cacheService;
        }

        #region ICustomersController Members

        [ActionName( "Index" )]
        public ActionResult GetIndexContents()
        {
            var validation = this.customerService != default( ICustomerService ) &&
                this.cacheService != default( ICacheService );

            if ( !validation )
                throw new ApplicationException( INVALID_CUSTOMER_SERVICE_MESSAGE );

            var customers = this.cacheService.GetCache( "customers" )
                as IEnumerable<Customer>;

            if ( customers == default( IEnumerable<Customer> ) )
            {
                customers = this.customerService.GetAllCustomers();

                this.cacheService.SetCache( "customers", customers );
            }

            return View( model: customers );
        }

        [ActionName( "Search" )]
        public ActionResult GetSearchCustomerResults(string searchString)
        {
            var validation = this.customerService != default( ICustomerService );

            if ( !validation )
                throw new ApplicationException( INVALID_CUSTOMER_SERVICE_MESSAGE );

            var customersList = default( IEnumerable<Customer> );

            if ( string.IsNullOrEmpty( searchString ) || searchString.Equals( "*" ) )
                customersList = this.customerService.GetAllCustomers();
            else customersList = this.customerService.GetCustomers( searchString );

            return View( viewName: "Index", model: customersList );
        }

        [ActionName( "Details" )]
        public ActionResult GetCustomerDetails(int customerId)
        {
            var validation = this.customerService != default( ICustomerService ) &&
                customerId != default( int );

            if ( !validation )
                throw new ApplicationException( INVALID_CUSTOMER_SERVICE_MESSAGE );

            var filteredCustomer = this.customerService.GetCustomerDetails( customerId );

            return View( model: filteredCustomer );
        }

        [ActionName( "NewCustomer" )]
        public ActionResult InitializeNewForm()
        {
            var customer = new Customer
            {
                CustomerId = new Random().Next( 200000 ),
                ActiveStatus = true
            };

            return View( model: customer );
        }

        [ActionName( "NewCustomer" )]
        [HttpPost]
        public ActionResult SaveCustomerForm(Customer customer)
        {
            var validation = customer != default( Customer ) &&
                this.customerService != default( ICustomerService );

            if ( !validation )
                throw new ApplicationException( INVALID_CUSTOMER_SERVICE_MESSAGE );

            if ( !ModelState.IsValid )
                return View( model: customer );

            var addStatus = this.customerService.SaveCustomer( customer );

            return View( viewName: "SaveCustomerResult", model: addStatus );
        }

        #endregion
    }
}