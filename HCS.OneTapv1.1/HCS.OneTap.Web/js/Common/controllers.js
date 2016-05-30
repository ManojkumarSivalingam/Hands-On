var commonControllersModule =
    angular.module('HCS.OneTapWeb.Modules.Common.Controllers', 
    [
            'HCS.OneTapWeb.Modules.Common.Services'
    ]);

commonControllersModule.controller('oneTapDownloadsController',
    [
        '$scope',
        '$rootScope',
        'oneTapGlobalService',
        OneTapDownloadsController
    ]);



//function OneTapDownloads(viewModel, logoService) {
//    if (logoService && viewModel) {
//        viewModel.id = 3;
//        logoService.getLogo(viewModel.id).then(
//            function (data) {
//                if (data.length > 0)
//                    viewModel.logoList = data;
//            },
//            function (error) {
//                viewModel.errorMessage = " Error Occurred, Details: " +
//                    JSON.stringify(error);

//                throw error;
//            });
//    }
//}

    
