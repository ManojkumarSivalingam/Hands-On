var adminConfigurationModule =
    angular.module('HCS.OneTapWeb.Modules.Admin.Configuration', []);

adminConfigurationModule.constant('onetapAdminServiceUrls', {
    baseUrl: 'http://localhost:52522',
    admin: 'OneTapNewsService.svc/SetKeyword/',
    channel: 'OneTapNewsService.svc/GetChannel/',
    whiteLabel: 'OneTapNewsService.svc/updatewhitelabel/',
    category: 'OneTapNewsService.svc/GetCategory/',
    saveCategoryKeyword: 'OneTapNewsService.svc/UpdateCategoryKeyword/',
});
adminConfigurationModule.constant('onetapAdminTemplateUrls', {
    admin: '/js/Admin/partials/Admin.html'
});