
function AditiCommonRouterConfiguration(routeProvider, templateUrls) {
    if (routeProvider && templateUrls) {
        routeProvider.when('/home', {
            templateUrl: function () {
                return templateUrls.home;
            }
        });

        routeProvider.when('/downloads', {
            templateUrl: function () {
                return templateUrls.downloads;
            },
            controller: 'aditiDownloadsController'
        });

        routeProvider.otherwise({
            redirectTo: '/home'
        });
    }
}