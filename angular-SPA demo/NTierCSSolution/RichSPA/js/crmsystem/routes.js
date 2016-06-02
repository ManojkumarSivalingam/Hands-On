var crmSystemRoutesModule =
    angular.module('Aditi.SPA.Modules.CRM.Routes',
        [
            'ngRoute',
            'Aditi.SPA.Modules.CRM.Configuration',
            'Aditi.SPA.Modules.CRM.Controllers'
        ]);

crmSystemRoutesModule.config(
    [
        '$routeProvider',
        'crmSystemTemplateUrls',
        AditiCRMSystemRouterConfiguration
    ]);

