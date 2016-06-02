using Aditi.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Services.Orders
{
    public static class OrdersDataProvider
    {
        public static IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>();
            var random = new Random();

            foreach ( var index in Enumerable.Range( 1, 100 ) )
            {
                var order = new Order
                {
                    OrderId = index,
                    OrderDate = DateTime.Now.AddDays( -random.Next( 10 ) ),
                    CustomerId = random.Next( 1, 15 ),
                    BillingAddress = "Bangalore",
                    Units = random.Next( 20, 50 ),
                    Amount = random.Next( 100, 1000 )
                };

                orders.Add( order );
            }

            return orders;
        }
    }
}
