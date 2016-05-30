var adminSystemRoutesModule =
    angular.module('HCS.OneTapWeb.Modules.Admin.Routes',
        [
            'ngRoute',
            'HCS.OneTapWeb.Modules.Admin.Configuration',
            'HCS.OneTapWeb.Modules.Admin.Controllers'
        ]);

adminSystemRoutesModule.config(
    [
        '$routeProvider',
        'onetapAdminTemplateUrls',
        AdminSystemRouterConfiguration
    ]);

