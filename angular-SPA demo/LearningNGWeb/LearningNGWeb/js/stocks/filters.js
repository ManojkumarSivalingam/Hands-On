define(['angular', 'stocks/config', 'stocks/defs/filter-defs'],
    function () {
        var stocksFilterModule =
            angular.module('Aditi.SPA.Modules.Stocks.Filters',
                [
                    'Aditi.SPA.Modules.Stocks.Configuration'
                ]);

        stocksFilterModule.filter('aditiFindStockType',
            [
                AditiFindStockTypeFilter
            ]);

        stocksFilterModule.filter('aditiStockSymbol',
            [
                'stockSymbols',
                AditiStockSymbolFilter
            ]);
    });
