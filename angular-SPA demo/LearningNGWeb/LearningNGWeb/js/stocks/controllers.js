define(['angular', 'stocks/services', 'stocks/defs/controller-defs'],
    function () {
        var stocksControllersModule =
            angular.module('Aditi.SPA.Modules.Stocks.Controllers',
                [
                    'Aditi.SPA.Modules.Stocks.Services'
                ]);

        stocksControllersModule.controller('aditiStockViewerController',
            [
                '$scope',
                'companyInfoProvider',
                AditiStockViewerController
            ]);

        stocksControllersModule.controller('aditiCompanyDetailsViewerController',
            [
                '$scope',
                '$interval',
                'stockQuoteProvider',
                'refreshDetails',
                AditiCompanyDetailsViewerController
            ]);

        stocksControllersModule.controller('aditiCompanyStockHistoryViewerController',
            [
                '$scope',
                'stockHistoryChartDataProvider',
                AditiCompanyStockHistoryViewerController
            ]);

        stocksControllersModule.controller('aditiChartRendererController',
            [
                '$scope',
                AditiChartRendererController
            ]);
    });