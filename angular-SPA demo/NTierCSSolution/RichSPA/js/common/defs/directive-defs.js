function AditiGlobalHeaderDirective(templateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.header;
        }
    };

    return directive;
}

function AditiGlobalNavigationDirective(templateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.navigation;
        }
    };

    return directive;
}

function AditiGlobalFooterDirective(templateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.footer;
        }
    };

    return directive;
}