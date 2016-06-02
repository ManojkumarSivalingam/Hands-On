function AditiCRMSystemRouterConfiguration(routeProvider, templateUrls) {
    if (routeProvider && templateUrls) {
        routeProvider.when('/crmsystem', {
            templateUrl: function () {
                return templateUrls.customersHome;
            },
            controller: 'aditiCRMDashboardViewController'
        });

        routeProvider.when('/newcustomer', {
            templateUrl: function () {
                return templateUrls.newCustomerHome;
            },
            controller: 'aditiNewCustomerHomeController'
        });
    }
}