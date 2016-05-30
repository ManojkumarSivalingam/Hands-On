var newsServicesModule =
    angular.module('HCS.OneTapWeb.Modules.OneTap.Services',
        [
            'ngResource',
            'HCS.OneTapWeb.Modules.OneTap.Configuration'
        ]);

newsServicesModule.factory('oneTapNewsService',
    [
        '$resource',
        'onetapSystemServiceUrls',
        OneTapNewsService
    ]);

