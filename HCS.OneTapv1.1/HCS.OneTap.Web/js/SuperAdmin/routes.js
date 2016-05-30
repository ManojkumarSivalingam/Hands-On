var superAdminSystemRoutesModule =
    angular.module('HCS.OneTapWeb.Modules.SuperAdmin.Routes',
        [
            'ngRoute',
            'HCS.OneTapWeb.Modules.SuperAdmin.Configuration',
            'HCS.OneTapWeb.Modules.SuperAdmin.Controllers'
        ]);

superAdminSystemRoutesModule.config(
    [
        '$routeProvider',
        'onetapSuperAdminTemplateUrls',
        SuperAdminSystemRouterConfiguration
    ]);

