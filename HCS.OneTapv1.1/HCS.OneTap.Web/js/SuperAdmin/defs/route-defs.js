function SuperAdminSystemRouterConfiguration(routeProvider, templateUrls) {
    if (routeProvider && templateUrls) {
        routeProvider.when('/superadmin', {
            templateUrl: function () {
                return templateUrls.superadmin;
            },
            controller: 'superadminViewController'
        });
    }
    
}
        
    