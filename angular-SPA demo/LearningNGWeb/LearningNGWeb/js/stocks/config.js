define(['angular'], function () {
    var stocksConfigurationModule =
        angular.module('Aditi.SPA.Modules.Stocks.Configuration', []);

    stocksConfigurationModule.constant('stocksServiceUrls', {
        baseUrl: '/data',
        companies: 'companies.json'
    });

    stocksConfigurationModule.constant('stocksTemplateUrls', {
        stocksHome: '/js/stocks/partials/stocks-home.html',
        companyDetailViewer: '/js/stocks/partials/company-detail-viewer.html',
        companyHistoryViewer: '/js/stocks/partials/company-history-viewer.html'
    });

    stocksConfigurationModule.constant('refreshDetails', {
        interval: 4000
    });

    stocksConfigurationModule.constant('stockQuoteRanges', {
        minimum: 100,
        maximum: 1000
    });

    stocksConfigurationModule.constant('stockSymbols', {
        check: '\u2713',
        cross: '\u2718'
    });
});