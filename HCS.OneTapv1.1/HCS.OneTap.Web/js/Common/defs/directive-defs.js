function OneTapGlobalHeaderDirective(templateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.header;
        },
        controller: 'oneTapDownloadsController'
    };

    return directive;
}

function OneTapGlobalFooterDirective(templateUrls) {
    var directive = {
        restrict: 'EA',
        templateUrl: function () {
            return templateUrls.footer;
        },
        controller: 'oneTapDownloadsController'
    };

    return directive;
}

