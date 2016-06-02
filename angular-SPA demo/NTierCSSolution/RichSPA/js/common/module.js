var commonModule = angular.module('Aditi.SPA.Modules.Common',
    [
        'Aditi.SPA.Modules.Common.Directives',
        'Aditi.SPA.Modules.Common.Routes',
        'Aditi.SPA.Modules.Common.Decorators'
    ]);

commonModule.run(
    function ($log) {
        $log.info('Common Module Initialized Successfully!');
    });