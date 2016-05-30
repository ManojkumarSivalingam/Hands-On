
var appModule = angular.module('HCS.OneTapWeb.App',
    [
        'HCS.OneTapWeb.Modules.Common',
        'HCS.OneTapWeb.Modules.OneTap',
        'HCS.OneTapWeb.Modules.Admin',
        'HCS.OneTapWeb.Modules.SuperAdmin',
        'ngSanitize',
        'angucomplete-alt',
        'ui.grid',
        'ui.grid.selection',
        'ngTagsInput'
      
    ]);
//var decode = angular.module('HCS.OneTapWeb.App', ['HCS.OneTapWeb.App.filters', 'HCS.OneTapWeb.App.services', 'HCS.OneTapWeb.App.directives', 'ngSanitize'])

appModule.run(
    function ($log, $rootScope) {
        $rootScope.isAuthenticated = false;

        $log.info('HCS OneTapWeb Initialized Successfully!');
    });

appModule.config(function ($httpProvider) {
    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
});


//var app = angular.module('HCS.OneTapWeb.App', ['ui.bootstrap']);

//app.controller('autocompleteController', function ($scope, $http) {
//    UpdateCategory(); // Load all countries with capitals
//    function UpdateCategory() {
//        $http.get("ajax/UpdateCategory.php").success(function (data) {
//            $scope.countries = data;
//        });
//    };
//});