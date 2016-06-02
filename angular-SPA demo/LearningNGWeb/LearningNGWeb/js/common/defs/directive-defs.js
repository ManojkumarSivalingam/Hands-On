var createDirective = function (url) {
    var directive = {
        restrict: 'AE',
        templateUrl: function () {
            return url;
        }
    };

    return directive;

};

function AditiGlobalHeaderDirective(globalTemplateUrls) {
    return createDirective(globalTemplateUrls.header);
}

function AditiGlobalNavigationDirective(globalTemplateUrls) {
    return createDirective(globalTemplateUrls.navigation);
}

function AditiGlobalFooterDirective(globalTemplateUrls) {
    return createDirective(globalTemplateUrls.footer);
}

function AditiGlobalLoginPanelDirective(globalTemplateUrls) {
    return createDirective(globalTemplateUrls.loginPanel);
}