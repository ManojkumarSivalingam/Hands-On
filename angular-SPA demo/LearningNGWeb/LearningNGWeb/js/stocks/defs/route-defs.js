function AditiStocksRouterConfiguration(routeProvider, stocksTemplateUrls) {
    if (routeProvider && stocksTemplateUrls) {
        routeProvider.when('/stocks', {
            templateUrl: function () {
                return stocksTemplateUrls.stocksHome;
            },
            controller: 'aditiStockViewerController'
        });
    }
}