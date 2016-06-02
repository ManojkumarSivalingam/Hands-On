var commonDecoratorsModule =
    angular.module('Aditi.SPA.Modules.Common.Decorators', []);

commonDecoratorsModule.factory('$log',
    [
        '$window',
        AditiLogService
    ]);

commonDecoratorsModule.factory('$exceptionHandler',
    [
        '$log',
        AditiExceptionHandlerService
    ]);