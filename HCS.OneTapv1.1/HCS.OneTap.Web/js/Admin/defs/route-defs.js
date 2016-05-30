function AdminSystemRouterConfiguration(routeProvider, templateUrls) {
    if (routeProvider && templateUrls) {
        routeProvider.when('/admin', {
            templateUrl: function () {
                return templateUrls.admin;
            },
            controller: 'adminViewController'
        });
    }
    
}
        
    