var crmSystemRoutesModule =
    angular.module('HCS.OneTapWeb.Modules.OneTap.Routes',
        [
            'ngRoute',
            'HCS.OneTapWeb.Modules.OneTap.Configuration',
            'HCS.OneTapWeb.Modules.OneTap.Controllers'
        ]);

crmSystemRoutesModule.config(
    [
        '$routeProvider',
        'onetapSystemTemplateUrls',
        OneTapNewsSystemRouterConfiguration
    ]);

