function OneTapNewsService(restService, serviceUrls) {
    if (restService && serviceUrls) {
        //Construct the service URL to be called
        var customerServiceUrl =
            serviceUrls.baseUrl + "/" + serviceUrls.news;
        //Call the service - $resource(url);
        var newsRestService = restService(customerServiceUrl);
        var service = {
            //returns (handleSuccess,handleFailure);
            getNews: function (pageindex) {
                var newsRestService = restService(customerServiceUrl);
                return newsRestService.query({
                    pageindex: pageindex
                }).$promise;
            },



            getCategory: function () {

                var addcategoryUrl = serviceUrls.baseUrl + "/" + serviceUrls.category;
                var newsRestService = restService(addcategoryUrl);
                return newsRestService.query().$promise;
            },


            getCatnews: function (cat_Id, pageindex) {
                var getCatURl = serviceUrls.baseUrl + "/" + serviceUrls.catnews;
                var newsRestService = restService(getCatURl);
                return newsRestService.query({
                    cat_Id:cat_Id,
                    pageIndex: pageindex
                }).$promise;
            }
        };

        return service;
    }

}