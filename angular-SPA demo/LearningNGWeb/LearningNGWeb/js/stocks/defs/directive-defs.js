function AditiCompanyViewerDirective(stocksTemplateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return stocksTemplateUrls.companyDetailViewer;
        },
        scope: {
            companyDetails: '='
        },
        controller: 'aditiCompanyDetailsViewerController'
    };

    return directive;
}

function AditiCompanyStockHistoryViewerDirective(stocksTemplateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return stocksTemplateUrls.companyHistoryViewer
        },
        scope: {
            historyData: '='
        },
        controller: 'aditiCompanyStockHistoryViewerController'
    };

    return directive;
}

function AditiChartRendererDirective() {
    var directive = {
        restrict: 'EA',
        controller: 'aditiChartRendererController',
        scope: {
            chartData: '=',
            chartType: '@',
            targetElement: '@'
        }
    };

    return directive;
}