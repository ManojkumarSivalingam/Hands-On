

function adminViewController(viewModel, globalViewModel, filterFilter, adminService, serviceUrls) {
    if (viewModel && adminService) {

        viewModel.keyword = "";
        //viewModel.WLVID = globalViewModel.WLVID;
        viewModel.WLVName = "";
        globalViewModel.$on('WhiteLabel_Updated', function (eventInfo, args) {
            viewModel.WLVName = args.WhiteLabelName;
            viewModel.WLVID = args.WLVID;
        });
        viewModel.saveKeyWord = function () {
            channelsselection = viewModel.selection.join('|');
            if (viewModel.keyword.length > 0 && channelsselection.length > 0)
                adminService.setKeyword(viewModel.keyword, channelsselection).then(function () {
                    alert('keyword inserted');
                },
                function (error) {
                    viewModel.errorMessage = " Error Occurred, Details: " +
                        JSON.stringify(error);
                });
            if (viewModel.WLVName.length > 0)
                adminService.updateWhiteLabel(viewModel.WLVID, viewModel.WLVName).then(function () {

                    viewModel.$emit('WhiteLabel_Changed');
                },
                function (error) {
                    viewModel.errorMessage = " Error Occurred, Details: " +
                        JSON.stringify(error);
                })
        }

        viewModel.getHandlers = function () {

            //alert(viewModel.selection.join('|'));



            //var file = $scope.myFile;
            //console.log('file is ');
            //console.dir(file);
            //var uploadUrl = "/fileUpload";
            //fileUpload.uploadFileToUrl(file, uploadUrl);

            adminService.getHandlers(viewModel.keyword, 3).then(function () {
                // popup div with the list of handlers.
            },
            function (error) {
                viewModel.errorMessage = " Error Occurred, Details: " +
                    JSON.stringify(error);
            });

            //adminService.updateWhiteLabel(globalViewModel.WLVID, viewModel.WLVName).then(function () {
            //    alert('keyword inserted');
            //    viewModel.$emit('WhiteLabel_Changed');
            //},
            //function (error) {
            //    viewModel.errorMessage = " Error Occurred, Details: " +
            //        JSON.stringify(error);
            //})
        }


        //viewModel.channellist = [{ NewsChannelName: 'twitter' }, { NewsChannelName: 'Google' }, { NewsChannelName: 'Bing' }]
        viewModel.getChannel = function () {
            adminService.getChannel().then(
            function (data) {
                //debugger;
                if (data.length > 0)
                    viewModel.channellist = data;
                else
                    viewModel.channellist = "";

            }, function (error) {
                viewModel.errorMessage = " Error Occurred, Details: " +
                    JSON.stringify(error);
            });
            //viewModel.addwhitelabel = function () {
            //    adminService.SetWhiteLabel(viewModel.name).then(function () {
            //        alert('whitelabel inserted');
            //    },
            //     function (error) {
            //         viewModel.errorMessage = " Error Occurred, Details: " +
            //             JSON.stringify(error);
            //     });

        }

        viewModel.getChannel();



        viewModel.selection = [];

        
        viewModel.selectedChannels = function selectedChannels() {
             return filterFilter(viewModel.channellist, { IsSelected: true });
        };


        viewModel.$watch('channellist|filter:{IsSelected:true}', function (nv) {
            viewModel.selection = nv.map(function (channel) {
                return channel.NewsChannelId;
            });
        }, true);

        //viewModel.$emit('WhiteLabel_Changed');

        viewModel.getCategory = function () {
            adminService.getCategory().then(
            function (data) {
                //debugger;
                if (data.length > 0)
                    viewModel.categorylist = data;
                else
                    viewModel.categorylist = "";

            }, function (error) {
                viewModel.errorMessage = " Error Occurred, Details: " +
                    JSON.stringify(error);
            });
        }


        viewModel.getCategory();

        viewModel.selectioncategory = [];

        viewModel.selectedCategory = function selectedCategory() {
            return filterFilter(viewModel.CategoryID, { IsSelected: true });
        };


        viewModel.$watch('categorylist|filter:{IsSelected:true}', function (nv) {
            viewModel.categorySelection = nv.map(function (categoryname) {
                return categoryname.CategoryId;
            });
        }, true);

        //viewModel.keywordcategory = "";
        // buggy code ahead!
        viewModel.saveKeyWordcategory = function () {

            categoryselection = "";
            var selectedCategories=[];
            var keywordListCombined = "";
            for (var j = 0; j < viewModel.categorylist.length; j++) {

                if(viewModel.categorylist[j].Keywords &&
                   viewModel.categorylist[j].Keywords.length>0 &&
                 $.inArray(viewModel.categorylist[j].CategoryId,viewModel.categorySelection)>=0)
                {
                    selectedCategories.push(viewModel.categorylist[j].CategoryId);
                    var keywordList = "";
                    for(var k=0;k<viewModel.categorylist[j].Keywords.length;k++){
                        keywordList = keywordList+viewModel.categorylist[j].Keywords[k].text
                        if(k!=(viewModel.categorylist[j].Keywords.length-1))
                           keywordList = keywordList +",";
                    }
                    keywordListCombined += ("|" + keywordList);
                }
            }
            
categoryselection=selectedCategories.join(',');
            if (keywordListCombined.length > 0 && categoryselection.length > 0)
                adminService.saveCategoryKeyword(categoryselection, keywordListCombined).then(function () {
                    alert(' category keyword inserted');
                },
                function (error) {
                    viewModel.errorMessage = " Error Occurred, Details: " +
                        JSON.stringify(error);
                });
        };

       
    }
}



