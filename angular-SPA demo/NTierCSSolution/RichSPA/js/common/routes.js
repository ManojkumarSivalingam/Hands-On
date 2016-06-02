var commonRoutesModule =
    angular.module('Aditi.SPA.Modules.Common.Routes',
        [
            'ngRoute',
            'Aditi.SPA.Modules.Common.Configuration',
            'Aditi.SPA.Modules.Common.Controllers'
        ]);

commonRoutesModule.config(
    [
        '$routeProvider',
        'globalTemplateUrls',
        AditiCommonRouterConfiguration
    ]);
