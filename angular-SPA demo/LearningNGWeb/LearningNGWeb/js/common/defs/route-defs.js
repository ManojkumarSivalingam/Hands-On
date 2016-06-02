function AditiCommonRouterConfiguration(routeProvider, commonRouteUrls) {
    if (routeProvider && commonRouteUrls) {
        routeProvider.when('/home', {
            templateUrl: function () {
                return commonRouteUrls.home;
            }
        });

        routeProvider.when('/contacts', {
            templateUrl: function () {
                return commonRouteUrls.contacts;
            }
        });

        routeProvider.otherwise({
            redirectTo: '/home'
        });
    }
}