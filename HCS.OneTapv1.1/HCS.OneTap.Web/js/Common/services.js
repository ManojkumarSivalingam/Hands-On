var logoServicesModule =
    angular.module('HCS.OneTapWeb.Modules.Common.Services',
        [
            'ngResource',
            'HCS.OneTapWeb.Modules.Common.Configuration'
        ]);

newsServicesModule.factory('oneTapGlobalService',
    [
        '$resource',
        'commonServiceUrls',
        CommonService
    ]);

