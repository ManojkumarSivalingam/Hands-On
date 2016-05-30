function OneTapAdminService(restService, serviceUrls) {
    if (restService && serviceUrls) {
        var AdminServiceUrl = serviceUrls.baseUrl + "/" + serviceUrls.admin;
        var adminRestService = restService(AdminServiceUrl);

        var service = {
            setKeyword: function (keyword,channelList) {
                addkeywordUrl = AdminServiceUrl + "?KeyWord=" + keyword + "&Channels=" + channelList;
                var adminRestService = restService(addkeywordUrl);
                return adminRestService.get().$promise;
            },
            getHandlers: function(keyword, newsSource){
                addkeywordUrl = AdminServiceUrl + "?KeyWord=" + keyword + "&newsSource=" + channelList;
                var adminRestService = restService(addkeywordUrl);
                return adminRestService.get().$promise;
            },
            getChannel: function () {

                var addchannelUrl = serviceUrls.baseUrl + "/" + serviceUrls.channel;
                var adminRestService = restService(addchannelUrl);
                return adminRestService.query().$promise;
            },
            updateWhiteLabel: function (WLVID, WLVName) {
                addNameUrl = serviceUrls.baseUrl + "/" + serviceUrls.whiteLabel + "?WLVID=" + WLVID + "&WLVName=" + WLVName;
                var adminRestService = restService(addNameUrl);
                return adminRestService.get().$promise;
            },
            getCategory: function () {

            var addcategoryUrl = serviceUrls.baseUrl + "/" + serviceUrls.category;
            var adminRestService = restService(addcategoryUrl);
            return adminRestService.query().$promise;
            },
            //SetWhiteLabel: function (name) {
            //    addwhitelabelUrl = AdminServiceUrl + "?name=" + name;
            //    var adminRestService = restService(addwhitelabelUrl);
            //    return adminRestService.get().$promise;
            //}

            saveCategoryKeyword: function (categoryId, keywords) {
                savecategoryURL = serviceUrls.baseUrl + "/" + serviceUrls.saveCategoryKeyword + "?categoryIds=" + categoryId + "&keywords=" + keywords;
                var adminRestService = restService(savecategoryURL);
                return adminRestService.get().$promise;
            },       
        };

        return service;
    }
}
