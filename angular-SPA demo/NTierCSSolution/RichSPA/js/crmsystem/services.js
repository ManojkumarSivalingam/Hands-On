var crmServicesModule =
    angular.module('Aditi.SPA.Modules.CRM.Services',
        [
            'ngResource',
            'Aditi.SPA.Modules.CRM.Configuration'
        ]);

crmServicesModule.factory('customerService',
    [
        '$resource',
        'crmSystemServiceUrls',
        AditiCustomerService
    ]);

crmServicesModule.factory('orderService',
    [
        '$resource',
        'crmSystemServiceUrls',
        AditiOrderService
    ]);

crmServicesModule.factory('ordersChartDataProvider',
    [
        AditiOrdersChartDataProvider
    ]);

