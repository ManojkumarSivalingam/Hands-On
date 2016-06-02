function AditiStockViewerController(viewModel, companyInfoProvider) {
    if (companyInfoProvider && viewModel) {
        companyInfoProvider.getCompanies().then(
            function (data) {
                viewModel.companies = data;
            },
            function (error) {
                viewModel.errorMessage = "Errro Occurred, Details : " +
                    JSON.stringify(error);

                throw error;
            });

    }
}

function AditiCompanyDetailsViewerController(viewModel, interval, stockQuoteProvider, refreshDetails) {
    var DEFAULT_INTERVAL = 4000;
    var GAUGE_VALUE_DIVIDER = 180;
    var timer = null;

    viewModel.stockHistory = [];
    viewModel.gaugeData = {
        value: 0,
        lowerLimit: 0,
        upperLimit: 6,
        valueUnit: '$ ',
        precision: 2,
        ranges: [
                    {
                        min: 0,
                        max: 1.5,
                        color: '#DEDEDE'
                    },
                    {
                        min: 1.5,
                        max: 2.5,
                        color: '#8DCA2F'
                    },
                    {
                        min: 2.5,
                        max: 3.5,
                        color: '#FDC702'
                    },
                    {
                        min: 3.5,
                        max: 4.5,
                        color: '#FF7700'
                    },
                    {
                        min: 4.5,
                        max: 6.0,
                        color: '#C50200'
                    }]
    };

    var refreshQuotation = function () {
        var quotation = stockQuoteProvider.getQuote(
            viewModel.companyDetails.name);

        viewModel.stockQuotation = quotation;

        var history = {
            time: new Date(),
            quotation: quotation
        };

        viewModel.stockHistory.unshift(history);
        viewModel.gaugeData.value = quotation / GAUGE_VALUE_DIVIDER;
    };


    viewModel.refreshInterval = refreshDetails.interval || DEFAULT_INTERVAL;
    viewModel.$watch('refreshInterval', function (newValue) {
        if (newValue) {
            if (timer) {
                clearInterval(timer.$$intervalId);
            }

            timer = interval(function () {
                refreshQuotation();
            }, viewModel.refreshInterval);
        }
    });
}

function AditiChartRendererController(viewModel) {
    require(['c3'], function (c3) {
        viewModel.$watch('chartData', function (newValue) {
            if (newValue) {
                //console.log(newValue);
                //console.log(viewModel.targetElement);
                //console.log(viewModel.chartType);
                //console.log(viewModel.chartData);
                c3.generate({
                    bindto: viewModel.targetElement,
                    type: viewModel.chartType,
                    data: {
                        columns: viewModel.chartData
                    }
                });
            }
        });
    });
}

function AditiCompanyStockHistoryViewerController(viewModel, stockHistoryChartDataProvider) {
    viewModel.$watchCollection('historyData',
        function (newValue) {
            if (newValue && stockHistoryChartDataProvider) {
                viewModel.stockHistoryChartData =
                    stockHistoryChartDataProvider.getChartData(viewModel.historyData);
            }
        });
}