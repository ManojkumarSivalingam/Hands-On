define(['angular', 'ngRadialGauge', 'c3', 'stocks/routes', 'stocks/filters', 'stocks/directives'], function () {
    var stocksModule = angular.module('Aditi.SPA.Modules.Stocks',
            [
                'ngRadialGauge',

                'Aditi.SPA.Modules.Stocks.Routes',
                'Aditi.SPA.Modules.Stocks.Filters',
                'Aditi.SPA.Modules.Stocks.Directives'
            ]);

    stocksModule.run(
        function ($log, $rootScope) {
            $rootScope.stockModuleLoadTime = new Date();

            $log.info('Stock Module Loaded Successfully!');
        });
});