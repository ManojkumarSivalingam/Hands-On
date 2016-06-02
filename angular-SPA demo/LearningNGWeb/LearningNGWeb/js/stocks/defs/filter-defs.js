function AditiStockSymbolFilter(stockSymbols) {
    var filterLogic = function (bindingValue) {
        return bindingValue ? stockSymbols.check : stockSymbols.cross;
    };

    return filterLogic;
}

function AditiFindStockTypeFilter() {
    var filterLogic = function (bindingValue, threshold) {
        return bindingValue >= threshold;
    };

    return filterLogic;
}