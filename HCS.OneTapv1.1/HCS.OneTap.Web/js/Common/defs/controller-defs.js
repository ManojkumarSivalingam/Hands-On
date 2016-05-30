/*function OneTapDownloadsController(viewModel, exceptionHandler) {
    if (viewModel && exceptionHandler) {
        viewModel.Name = "@WhiteLabelName";
    }
}*/

function OneTapDownloadsController(viewModel,globalViewModel, logoService) {
    if (logoService && viewModel) {
        viewModel.id = 3;
        viewModel.getLogo = function () {
            logoService.getLogo(viewModel.id).then(
                function (data) {
                    if (data.length > 0) {
                        viewModel.logoList = data;
                        globalViewModel.$emit('WhiteLabel_Updated', data[0]);
                    }
                },
                function (error) {
                    viewModel.errorMessage = " Error Occurred, Details: " +
                        JSON.stringify(error);

                    throw error;
                });
        }
        viewModel.getLogo();
        globalViewModel.$on('WhiteLabel_Changed', function () {
            viewModel.getLogo();
        });

    }
}


