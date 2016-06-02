define(['angular'], function () {
    var commonConfigurationModule =
        angular.module('Aditi.SPA.Modules.Common.Configuration', []);

    commonConfigurationModule.constant('globalTemplateUrls', {
        header: '/js/common/partials/global-header.html',
        navigation: '/js/common/partials/global-navigation.html',
        loginPanel: '/js/common/partials/global-login-panel.html',
        footer: '/js/common/partials/global-footer.html'
    });

    commonConfigurationModule.constant('commonRouteUrls', {
        home: '/js/common/partials/home.html',
        contacts: '/js/common/partials/contacts.html'
    });
});