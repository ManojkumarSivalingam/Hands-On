var dependencies =
    [
        'angular',
        'common/config',
        'common/defs/directive-defs'
    ];

define(dependencies, function () {

    var commonDirectivesModule =
        angular.module('Aditi.SPA.Modules.Common.Directives',
            [
                'Aditi.SPA.Modules.Common.Configuration'
            ]);

    commonDirectivesModule.directive('aditiGlobalHeader',
        [
            'globalTemplateUrls',
            AditiGlobalHeaderDirective
        ]);

    commonDirectivesModule.directive('aditiGlobalNavigation',
        [
            'globalTemplateUrls',
            AditiGlobalNavigationDirective
        ]);

    commonDirectivesModule.directive('aditiGlobalLoginPanel',
        [
            'globalTemplateUrls',
            AditiGlobalLoginPanelDirective
        ]);

    commonDirectivesModule.directive('aditiGlobalFooter',
        [
            'globalTemplateUrls',
            AditiGlobalFooterDirective
        ]);
});