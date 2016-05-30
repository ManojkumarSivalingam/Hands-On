var newsSystemControllersModule =
    angular.module( 'HCS.OneTapWeb.Modules.OneTap.Controllers',
        [
            'HCS.OneTapWeb.Modules.OneTap.Services'
        ]);

newsSystemControllersModule.controller('newsViewController',
        [
            '$scope',
            '$rootScope',
            'oneTapNewsService',
            'onetapSystemServiceUrls',
            newsViewController
            
        ]);

    