function OneTapNewsSystemRouterConfiguration(routeProvider, templateUrls) {
    if (routeProvider && templateUrls) {
        routeProvider.when('/news', {
            templateUrl: function () {
                return templateUrls.admin;
            },
            controller: 'newsViewController'
        })
        .when('/news', {
        templateUrl: function () {
            return templateUrls.newsHome;
        },
        controller: 'newsViewController'
        })
        .when('/', {
        templateUrl: function () {
            return templateUrls.newsHome;
        },
        controller: 'newsViewController'
        });
    }
    
}
        
    