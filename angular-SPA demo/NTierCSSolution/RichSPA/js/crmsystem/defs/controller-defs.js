function AditiCRMDashboardViewController(viewModel, customerService) {
    if (customerService && viewModel) {
        customerService.getCustomers().then(
            function (data) {
                viewModel.customers = data;
            },
            function (error) {
                viewModel.errorMessage = "Error Occurred, Details : " +
                    JSON.stringify(error);

                throw error;
            });
    }
}

function AditiCustomersViewerDirectiveController(viewModel, crmSystemEvents) {
    viewModel.selectCustomer = function (selectedCustomerId) {
        if (selectedCustomerId) {
            viewModel.$emit(crmSystemEvents.CUSTOMER_SELECTED, selectedCustomerId);
        }
    };
}

function AditiCustomerDetailsViewerDirectiveController(viewModel, globalViewModel, customerService, crmSystemEvents) {
    if (globalViewModel && crmSystemEvents) {
        globalViewModel.$on(crmSystemEvents.CUSTOMER_SELECTED,
            function (eventInfo, args) {
                var selectedCustomerId = parseInt(args);

                customerService.getCustomer(selectedCustomerId).then(
                    function (data) {
                        viewModel.details = data;
                    },
                    function (error) {
                        viewModel.errorMessage = "Error Occurred, Details : " +
                            JSON.stringify(error);

                        throw error;
                    });
            });
    }
}

function AditiOrdersViewerDirectiveController(
    viewModel, globalViewModel, orderService, ordersChartDataProvider, crmSystemEvents) {

    if (globalViewModel && crmSystemEvents) {
        globalViewModel.$on(crmSystemEvents.CUSTOMER_SELECTED,
            function (eventInfo, eventArgs) {
                var selectedCustomerId = parseInt(eventArgs);

                viewModel.selectedCustomerId = selectedCustomerId;

                if (orderService) {
                    orderService.getOrders(selectedCustomerId).then(
                        function (data) {
                            viewModel.orders = data;

                            if (ordersChartDataProvider) {
                                viewModel.ordersChartData =
                                    ordersChartDataProvider.getChartData(viewModel.orders);

                                console.log(viewModel.ordersChartData);
                            }
                        },
                        function (error) {
                            viewModel.errorMessage = "Error Occurred, Details : " +
                                JSON.stringify(error);

                            throw error;
                        });
                }
            });
    }
}

function AditiChartRendererDirectiveController(viewModel) {
    if (viewModel) {
        viewModel.$watch('chartData',
            function (newValue) {
                if (newValue && c3) {
                    console.log(viewModel.targetElement);
                    console.log(viewModel.chartType);
                    console.log(viewModel.chartData);
                    c3.generate({
                        bindto: viewModel.targetElement,
                        data: {
                            columns: viewModel.chartData,
                            type: viewModel.chartType
                        }
                    });
                }
            });
    }
}

function AditiNewCustomerHomeController(viewModel, timeout, locationService, customerService, redirectDetails) {
    var generateCustomerId = function () {
        var MIN_ID = 10;
        var MAX_ID = 100000;

        return Math.floor(
            Math.random() * (MAX_ID - MIN_ID) + MIN_ID);
    };

    if (viewModel && customerService) {
        viewModel.phoneNumberPattern = /^\d{3,5}-\d{6,8}$/;
        viewModel.creditLimits = {
            minimum: 1000,
            maximum: 10000
        };
        viewModel.newCustomer = {
            CustomerId: generateCustomerId()
        };

        viewModel.saveCustomerData = function (customerRecord) {
            if (customerRecord && customerRecord.$valid && viewModel.newCustomer) {
                customerService.newCustomer(viewModel.newCustomer).then(
                    function (data) {
                        if (data) {
                            viewModel.message = "Customer Information Processed Successfully!";

                            var timeoutReference = timeout(function () {
                                locationService.path(redirectDetails.redirectUrl);

                                clearTimeout(timeoutReference.$$timeoutId);
                            }, redirectDetails.timeout);
                        }
                    },
                    function (error) {
                        viewModel.errorMessage = "Error Occurred, Details : " +
                            JSON.stringify(error);

                        throw error;
                    });
            }
        }
    }
}