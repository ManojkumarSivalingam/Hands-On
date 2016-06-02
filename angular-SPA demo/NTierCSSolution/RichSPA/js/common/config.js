var commonConfigModule =
    angular.module('Aditi.SPA.Modules.Common.Configuration', []);

commonConfigModule.constant('globalTemplateUrls', {
    header: '/js/common/partials/global-header.html',
    navigation: '/js/common/partials/global-navigation.html',
    footer: '/js/common/partials/global-footer.html',
    home: '/js/common/partials/home.html',
    downloads: '/js/common/partials/downloads.html'
});