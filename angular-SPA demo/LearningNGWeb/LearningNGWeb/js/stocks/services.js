define(['angular', 'ngResource', 'stocks/config', 'stocks/defs/service-defs'],
    function () {
        var stocksServicesModule =
            angular.module('Aditi.SPA.Modules.Stocks.Services',
                [
                    'ngResource',
                    'Aditi.SPA.Modules.Stocks.Configuration'
                ]);

        stocksServicesModule.factory('companyInfoProvider',
            [
                '$resource',
                'stocksServiceUrls',
                AditiCompanyInfoProvider
            ]);

        stocksServicesModule.factory('stockQuoteProvider',
            [
                'stockQuoteRanges',
                AditiStockQuoteProvider
            ]);

        stocksServicesModule.factory('stockHistoryChartDataProvider',
            [
                AditiStockHistoryChartDataProvider
            ])
    });

