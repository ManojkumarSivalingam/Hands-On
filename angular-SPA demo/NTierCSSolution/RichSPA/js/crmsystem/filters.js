var crmSystemFiltersModule =
    angular.module('Aditi.SPA.Modules.CRM.Filters',
        [
            'Aditi.SPA.Modules.CRM.Configuration'
        ]);

crmSystemFiltersModule.filter('aditiStatus',
    [
        'aditiSymbols',
        AditiStatusFilter
    ]);

crmSystemFiltersModule.filter('aditiCustomerPhotoUrl',
    [
        'photoBaseUrl',
        AditiCustomerPhotoUrlFilter
    ]);

