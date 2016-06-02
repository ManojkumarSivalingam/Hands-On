var crmModule =
    angular.module('Aditi.SPA.Modules.CRM',
        [
            'Aditi.SPA.Modules.CRM.Routes',
            'Aditi.SPA.Modules.CRM.Filters',
            'Aditi.SPA.Modules.CRM.Directives'
        ]);

crmModule.run(
    function ($log) {
        $log.info('CRM Module Initialized Successfully!');
    });