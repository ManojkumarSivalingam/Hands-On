var commonControllersModule =
    angular.module('Aditi.SPA.Modules.Common.Controllers', []);

commonControllersModule.controller('aditiDownloadsController',
    [
        '$scope',
        '$exceptionHandler',
        AditiDownloadsController
    ]);

