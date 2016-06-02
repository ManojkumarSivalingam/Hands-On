using Aditi.Libraries.Services.Orders;
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
    public class OrdersController : ApiController, IOrdersApiController
    {
        #region IOrdersApiController Members

        public IEnumerable<Order> GetOrders(int id)
        {
            var orders = OrdersDataProvider.GetOrders();
            var filteredOrders = orders.Where(
                order => order.CustomerId == id ).ToList();

            return filteredOrders;
        }

        #endregion
    }
}
