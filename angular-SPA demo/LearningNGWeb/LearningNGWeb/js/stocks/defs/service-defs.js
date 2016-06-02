function AditiCompanyInfoProvider(restService, stocksServiceUrls) {
    if (restService && stocksServiceUrls) {
        var companyServiceUrl = stocksServiceUrls.baseUrl + '/' + stocksServiceUrls.companies;
        var companyRestService = restService(companyServiceUrl);

        var serviceDefinition = {
            getCompanies: function () {
                return companyRestService.query().$promise;
            }
        };

        return serviceDefinition;
    }
}

function AditiStockQuoteProvider(stockQuoteRanges) {
    var isCompanyFortune500 = function (name) {
        var isValid = false;

        var fortune500Companies = ["Hewlett Packard Enterprise", "PGE Corporation", "CapitalIT Systems"];

        for (var index in fortune500Companies) {
            if (fortune500Companies[index] === name) {
                isValid = true;
                break;
            }
        }

        return isValid;
    };

    var serviceDefinition = {
        getQuote: function (companyName) {
            var EXTRA_BONUS_POINTS = 50;
            var quote = Math.floor(
                Math.random() * (stockQuoteRanges.maximum - stockQuoteRanges.minimum) +
                    stockQuoteRanges.minimum);

            if (isCompanyFortune500(companyName))
                quote += EXTRA_BONUS_POINTS;

            return quote;
        }
    };

    return serviceDefinition;
}

function AditiStockHistoryChartDataProvider() {
    var serviceDefinition = {
        getChartData: function (stockHistory) {
            var times = ['Time'];
            var quotes = ['Quote'];

            for (var index in stockHistory) {
                var historyItem = stockHistory[index];

                if (historyItem) {
                    times.push(historyItem.time.toString());
                    quotes.push(historyItem.quotation);
                }
            }

            return [times, quotes];
        }
    };

    return serviceDefinition;
}