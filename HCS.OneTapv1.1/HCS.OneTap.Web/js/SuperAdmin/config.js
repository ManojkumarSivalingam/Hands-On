var superAdminConfigurationModule =
    angular.module('HCS.OneTapWeb.Modules.SuperAdmin.Configuration', []);

superAdminConfigurationModule.constant('onetapSuperAdminServiceUrls', {
    baseUrl: 'http://localhost:52522',
    setCategory: 'OneTapNewsService.svc/SetCategory/',
    selectcategory: 'OneTapNewsService.svc/SelectCategory/',
    deletecategory: 'OneTapNewsService.svc/DeleteCategory/',
    addNewsChannel: 'OneTapNewsService.svc/SetNewsChannel/',

});
superAdminConfigurationModule.constant('onetapSuperAdminTemplateUrls', {
    superadmin: '/js/SuperAdmin/partials/MasterCategory.html',

});