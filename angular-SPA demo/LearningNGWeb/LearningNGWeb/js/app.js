define(['angular', 'common/module', 'stocks/module'], function () {
    var appModule = angular.module('Aditi.SPA.App',
        [
            'Aditi.SPA.Modules.Common',
            'Aditi.SPA.Modules.Stocks'
        ]);

    appModule.run(
        function ($log) {
            $log.info('Aditi SPA Application Initialized Successfully!');
        });
});