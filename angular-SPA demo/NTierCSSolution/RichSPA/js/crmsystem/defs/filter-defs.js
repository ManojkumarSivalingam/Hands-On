function AditiStatusFilter(symbols) {
    var filterLogic = function (status) {
        return status ? symbols.check : symbols.cross;
    };

    return filterLogic;
}

function AditiCustomerPhotoUrlFilter(photoBaseUrl) {
    var filterLogic = function (customerId) {
        return photoBaseUrl + "/" + customerId + ".jpg";
    };

    return filterLogic;
}