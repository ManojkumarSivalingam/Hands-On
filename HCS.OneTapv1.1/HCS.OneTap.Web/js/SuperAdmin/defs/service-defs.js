function OneTapSuperAdminService(restService, serviceUrls) {
    if (restService && serviceUrls) {
        //Construct the service URL to be called
        var customerServiceUrl =
            serviceUrls.baseUrl + "/" + serviceUrls.setCategory;
        //Call the service - $resource(url);
        var newsRestService = restService(customerServiceUrl);
        var service = {
            //returns (handleSuccess,handleFailure);
            setCategory: function (category, catId) {
                var newsRestService = restService(customerServiceUrl);
                return newsRestService.get({
                    category: category,
                    categoryId: catId
                }).$promise;
            },
            selectcategory: function (searchkeyword) {

                var selectcategoryUrl = serviceUrls.baseUrl + "/" + serviceUrls.selectcategory + "?searchkeyword=" + searchkeyword;
                var adminRestService = restService(selectcategoryUrl);
                return adminRestService.query().$promise;
            },
            deleteCategory: function (catIds) {
                var deleteCategoryURL = serviceUrls.baseUrl + "/" + serviceUrls.deletecategory + "?categoryids=" + catIds;
                var adminRestService = restService(deleteCategoryURL);
                return adminRestService.query().$promise;
            },
            addNewsChannel: function (newsChannelName) {
                var addCategoryURl = serviceUrls.baseUrl + "/" + serviceUrls.addNewsChannel + "?NewsChannelName=" + newsChannelName;
                var newsRestService = restService(addCategoryURl);
                return newsRestService.get().$promise;
            },
        };

        return service;
    }
}
