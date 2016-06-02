define(['angular', 'ngRoute', 'common/config', 'common/defs/route-defs'], function () {
    var commonRoutesModule =
        angular.module('Aditi.SPA.Modules.Common.Routes',
            [
                'ngRoute',
                'Aditi.SPA.Modules.Common.Configuration'
            ]);

    commonRoutesModule.config(
        [
            '$routeProvider',
            'commonRouteUrls',
            AditiCommonRouterConfiguration
        ]);
});