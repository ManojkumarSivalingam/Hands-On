var adminModule =
    angular.module('HCS.OneTapWeb.Modules.Admin',
        [
            'HCS.OneTapWeb.Modules.Admin.Routes',
        ]);

adminModule.run(
    function ($log) {
        $log.info('OneTap Module Initialized Successfully!');
    });


