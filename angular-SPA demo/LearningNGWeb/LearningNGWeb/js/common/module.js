define(['angular', 'common/directives', 'common/routes'], function () {
    var commonModule = angular.module('Aditi.SPA.Modules.Common',
        [
            'Aditi.SPA.Modules.Common.Directives',
            'Aditi.SPA.Modules.Common.Routes'
        ]);

    commonModule.run(
        function ($log) {
            $log.info('Common Module Initialized!');
        });
});