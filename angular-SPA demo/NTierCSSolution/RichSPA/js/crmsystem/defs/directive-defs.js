function AditiCustomersViewerDirective(templateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.customersViewer;
        },
        scope: {
            customersList: '='
        },
        controller: 'aditiCustomersViewerDirectiveController'
    };

    return directive;
}

function AditiCustomerDetailsViewerDirective(templateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.customerDetailsViewer;
        },
        controller: 'aditiCustomerDetailsViewerDirectiveController'
    };

    return directive;
}

function AditiOrdersViewerDirective(templateUrls) {
    var directiveDefinition = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.ordersViewer;
        },
        controller: 'aditiOrdersViewerDirectiveController'
    };

    return directiveDefinition;
}

function AditiChartRendererDirective() {
    var directive = {
        restrict: 'EA',
        scope: {
            chartData: '=',
            chartType: '@',
            targetElement: '@'
        },
        controller: 'aditiChartRendererDirectiveController'
    };

    return directive;
}

function AditiCreditLimitValidationDirective() {
    var directive = {
        restrict: 'A',
        scope: {
            minCreditLimit: '=',
            maxCreditLimit: '='
        },
        require: 'ngModel',
        link: function (scope, element, attributes, ngModel) {
            if (ngModel) {
                ngModel.$validators.aditiCreditLimitValidation = function (modelValue) {
                    var isValid = false;

                    if (modelValue) {
                        isValid = modelValue >= scope.minCreditLimit &&
                            modelValue <= scope.maxCreditLimit;
                    }

                    return isValid;
                };
            }
        }
    };

    return directive;
}