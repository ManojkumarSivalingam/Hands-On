var newsSystemFiltersModule =
    angular.module('HCS.OneTapWeb.Modules.OneTap.Filters',[]);

newsSystemFiltersModule.filter('startFrom', function () {
    return function (input, start) {
        if (input == null || input.length == 0) return null;
        start = +start; //parse to int
        return input.slice(start);
    }
});