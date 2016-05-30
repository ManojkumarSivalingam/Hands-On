var commonDirectivesModule =
    angular.module('HCS.OneTapWeb.Modules.Common.Directives',
        [
            'HCS.OneTapWeb.Modules.Common.Configuration',
        ]);

commonDirectivesModule.directive('oneTapGlobalHeader',
    [
        'globalTemplateUrls',
        OneTapGlobalHeaderDirective
    ]);

commonDirectivesModule.directive('oneTapGlobalFooter',
    [
        'globalTemplateUrls',
        OneTapGlobalFooterDirective
    ]);
