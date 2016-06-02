var crmSystemControllersModule =
    angular.module('Aditi.SPA.Modules.CRM.Controllers',
        [
            'Aditi.SPA.Modules.CRM.Services'
        ]);

crmSystemControllersModule.controller('aditiCRMDashboardViewController',
        [
            '$scope',
            'customerService',
            AditiCRMDashboardViewController
        ]);

crmSystemControllersModule.controller('aditiCustomersViewerDirectiveController',
    [
        '$scope',
        'crmSystemEvents',
        AditiCustomersViewerDirectiveController
    ]);

crmSystemControllersModule.controller('aditiCustomerDetailsViewerDirectiveController',
    [
        '$scope',
        '$rootScope',
        'customerService',
        'crmSystemEvents',
        AditiCustomerDetailsViewerDirectiveController
    ]);

crmSystemControllersModule.controller('aditiOrdersViewerDirectiveController',
    [
        '$scope',
        '$rootScope',
        'orderService',
        'ordersChartDataProvider',
        'crmSystemEvents',
        AditiOrdersViewerDirectiveController
    ]);

crmSystemControllersModule.controller('aditiChartRendererDirectiveController',
    [
        '$scope',
        AditiChartRendererDirectiveController
    ]);

crmSystemControllersModule.controller('aditiNewCustomerHomeController',
    [
        '$scope',
        '$timeout',
        '$location',
        'customerService',
        'newCustomerRedirectDetails',
        AditiNewCustomerHomeController
    ]);