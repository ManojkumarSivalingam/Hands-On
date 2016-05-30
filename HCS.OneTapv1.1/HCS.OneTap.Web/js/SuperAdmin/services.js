var superAdminServicesModule =
    angular.module('HCS.OneTapWeb.Modules.SuperAdmin.Services',
        [
            'ngResource',
            'HCS.OneTapWeb.Modules.SuperAdmin.Configuration'
        ]);

superAdminServicesModule.factory('oneTapSuperAdminService',
    [
        '$resource',
        'onetapSuperAdminServiceUrls',
        OneTapSuperAdminService
    ]);

