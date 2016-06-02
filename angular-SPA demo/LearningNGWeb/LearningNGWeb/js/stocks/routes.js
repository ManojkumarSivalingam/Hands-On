define(['angular', 'ngRoute', 'stocks/config', 'stocks/defs/route-defs', 'stocks/controllers'],
    function () {
        var stocksRoutesModule =
            angular.module('Aditi.SPA.Modules.Stocks.Routes',
                [
                    'ngRoute',
                    'Aditi.SPA.Modules.Stocks.Configuration',
                    'Aditi.SPA.Modules.Stocks.Controllers'
                ]);

        stocksRoutesModule.config(
            [
                '$routeProvider',
                'stocksTemplateUrls',
                AditiStocksRouterConfiguration
            ]);
    });