var crmModule =
    angular.module('HCS.OneTapWeb.Modules.OneTap',
        [
            'HCS.OneTapWeb.Modules.OneTap.Routes',
            'HCS.OneTapWeb.Modules.OneTap.Filters'
        ]);

crmModule.run(
    function ($log) {
        $log.info('OneTap Module Initialized Successfully!');
    });


