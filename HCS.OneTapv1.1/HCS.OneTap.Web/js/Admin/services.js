var adminServicesModule =
    angular.module('HCS.OneTapWeb.Modules.Admin.Services',
        [
            'ngResource',
            'HCS.OneTapWeb.Modules.Admin.Configuration'
        ]);

adminServicesModule.factory('oneTapAdminService',
    [
        '$resource',
        'onetapAdminServiceUrls',
        OneTapAdminService
    ]);

