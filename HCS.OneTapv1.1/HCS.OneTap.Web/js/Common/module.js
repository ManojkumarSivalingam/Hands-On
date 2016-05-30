var commonModule = angular.module('HCS.OneTapWeb.Modules.Common',
    [
        'HCS.OneTapWeb.Modules.Common.Directives',
        'HCS.OneTapWeb.Modules.Common.Routes',
        
    ]);

commonModule.run(
    function ($log) {
        $log.info('Common Module Initialized Successfully!');
    });
