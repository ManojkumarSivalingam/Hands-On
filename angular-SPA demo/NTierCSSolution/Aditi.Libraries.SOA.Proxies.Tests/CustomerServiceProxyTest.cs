using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aditi.Libraries.SOA.Contracts.Services;

namespace Aditi.Libraries.SOA.Proxies.Tests
{
    [TestClass]
    public class CustomerServiceProxyTest
    {
        private ICustomerService customerService = default( ICustomerService );

        [TestInitialize]
        public void Initialize()
        {
            var userName = "aditiuser1";
            var password = "Prestige123$$/?";

            this.customerService = new CustomerServiceProxy(userName, password);
        }

        [TestMethod]
        public void ShouldGetAllCustomers()
        {
            var customers = this.customerService.GetAllCustomers();

            var expectedNoOfCustomerRecords = 9;
            var actualNoOfCustomerRecords = customers.Count();

            Assert.AreEqual<int>( expectedNoOfCustomerRecords, actualNoOfCustomerRecords );
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.customerService = default( ICustomerService );
        }
    }
}
