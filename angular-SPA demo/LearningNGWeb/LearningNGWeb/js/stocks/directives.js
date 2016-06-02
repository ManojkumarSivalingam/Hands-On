define(['angular', 'stocks/config', 'stocks/controllers', 'stocks/defs/directive-defs'],
    function () {
        var stocksDirectivesModule =
             angular.module('Aditi.SPA.Modules.Stocks.Directives',
                [
                    'Aditi.SPA.Modules.Stocks.Configuration',
                    'Aditi.SPA.Modules.Stocks.Controllers'
                ]);

        stocksDirectivesModule.directive('aditiCompanyViewer',
            [
                'stocksTemplateUrls',
                AditiCompanyViewerDirective
            ]);

        stocksDirectivesModule.directive('aditiCompanyStockHistoryViewer',
            [
                'stocksTemplateUrls',
                AditiCompanyStockHistoryViewerDirective
            ]);

        stocksDirectivesModule.directive('aditiChartRenderer',
            [
                AditiChartRendererDirective
            ]);
    });
