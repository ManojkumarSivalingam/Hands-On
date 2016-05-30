var commonConfigModule =
    angular.module('HCS.OneTapWeb.Modules.Common.Configuration', []);

commonConfigModule.constant('commonServiceUrls', {
    baseUrl: 'http://localhost:52522',
    logo: 'OneTapNewsService.svc/GetLogo/',

});
commonConfigModule.constant('globalTemplateUrls', {
    header: '/js/common/partials/Globalheader.html',
    footer: '/js/common/partials/GlobalFooter.html'   
});




