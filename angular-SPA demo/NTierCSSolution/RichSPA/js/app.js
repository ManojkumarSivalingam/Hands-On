var appModule = angular.module('Aditi.SPA.App',
    [
        'Aditi.SPA.Modules.Common',
        'Aditi.SPA.Modules.CRM'
    ]);

appModule.run(
    function ($log, $rootScope) {
        $rootScope.isAuthenticated = false;

        $log.info('Aditi SPA Initialized Successfully!');
    });