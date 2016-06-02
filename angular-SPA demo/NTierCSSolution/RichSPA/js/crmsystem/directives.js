var crmSystemDirectivesModule =
    angular.module('Aditi.SPA.Modules.CRM.Directives',
        [
            'Aditi.SPA.Modules.CRM.Configuration'
        ]);

crmSystemDirectivesModule.directive('aditiCustomersViewer',
    [
        'crmSystemTemplateUrls',
        AditiCustomersViewerDirective
    ]);

crmSystemDirectivesModule.directive('aditiCustomerDetailsViewer',
    [
        'crmSystemTemplateUrls',
        AditiCustomerDetailsViewerDirective
    ]);

crmSystemDirectivesModule.directive('aditiOrdersViewer',
    [
        'crmSystemTemplateUrls',
        AditiOrdersViewerDirective
    ]);


crmSystemDirectivesModule.directive('aditiChartRenderer',
    [
        AditiChartRendererDirective
    ]);

crmSystemDirectivesModule.directive('aditiCreditLimitValidation',
    [
        AditiCreditLimitValidationDirective
    ]);

