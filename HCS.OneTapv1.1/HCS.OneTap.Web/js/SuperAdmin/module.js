var superadminModule =
    angular.module('HCS.OneTapWeb.Modules.SuperAdmin',
        [
            'HCS.OneTapWeb.Modules.SuperAdmin.Routes',
        ]);

superadminModule.run(
    function ($log) {
        $log.info('OneTap Module Initialized Successfully!');
    });


