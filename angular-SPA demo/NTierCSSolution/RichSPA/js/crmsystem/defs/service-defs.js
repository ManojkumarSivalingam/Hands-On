function AditiCustomerService(restService, serviceUrls) {
    if (restService && serviceUrls) {
        var customerServiceUrl =
            serviceUrls.baseUrl + "/" + serviceUrls.customers;
        var customerRestService = restService(customerServiceUrl);
        var service = {
            getCustomers: function () {
                return customerRestService.query().$promise;
            },
            getCustomer: function (customerId) {
                return customerRestService.get({
                    id: customerId
                }).$promise;
            },
            newCustomer: function (customer) {
                if (customer) {
                    return customerRestService.save(customer).$promise;
                }
            }
        };

        return service;
    }
}

function AditiOrderService(restService, serviceUrls) {
    var orderServiceUrl = serviceUrls.baseUrl + "/" + serviceUrls.orders;
    var ordersRestService = restService(orderServiceUrl);
    var serviceDefinition = {
        getOrders: function (customerId) {
            return ordersRestService.query({
                id: customerId
            }).$promise;
        }
    };

    return serviceDefinition;
}

function AditiOrdersChartDataProvider() {
    var serviceDefinition = {
        getChartData: function (orders) {
            var ordersChartData = [];

            if (orders) {
                for (var index in orders) {
                    var order = orders[index];
                    var orderData = [];

                    if (order && order.OrderId && order.Amount) {
                        orderData.push(order.OrderId.toString());
                        orderData.push(order.Amount);

                        ordersChartData.push(orderData);
                    }
                }
            }

            return ordersChartData;
        }
    };

    return serviceDefinition;
}