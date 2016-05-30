var newsConfigurationModule =
    angular.module('HCS.OneTapWeb.Modules.OneTap.Configuration', []);

newsConfigurationModule.constant('onetapSystemServiceUrls', {
    baseUrl: 'http://localhost:52522',
    news: 'OneTapNewsService.svc/GetNews/',
    category: 'OneTapNewsService.svc/GetCategory/',
    catnews: 'OneTapNewsService.svc/GetCatNews/',

});
newsConfigurationModule.constant('onetapSystemTemplateUrls', {
    newsHome: '/js/OneTapSearch/partials/news-home.html',
    
});