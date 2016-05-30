function CommonService(restService, serviceUrls) {
    if (restService && serviceUrls) {
        var ServiceUrl =
            serviceUrls.baseUrl + "/" + serviceUrls.logo;
        var service = {
            getLogo: function (id) {
                var logoRestService = restService(ServiceUrl);
                return logoRestService.query({
                    id:id
                }).$promise;
            }
        };

        return service;
    }
}
