

function SuperAdminViewController(viewModel, globalViewModel, filterFilter, adminService, serviceUrls) {
    if (viewModel && adminService) {

        viewModel.CategoryName = "";
        viewModel.NewsChannelName = "";
        viewModel.addCategory = function () {

            // TODO: For inserting/updating both newsCateogory and NewsChannel, we shouldnt call the service parallely
            // so we need to run it sequently

            CategoryUpdateSuccess = false;

            // For Insert/Update category
            if (viewModel.SelectedCategory && viewModel.SelectedCategory.CategoryName && viewModel.SelectedCategory.CategoryName.length > 0 && viewModel.SelectedCategory.CategoryId)
                adminService.setCategory(viewModel.NewCategoryName, viewModel.SelectedCategory.CategoryId).then(function () {
                    //   alert('Update');
                    viewModel.GetCategories();
                },
                    function (error) {
                        viewModel.errorMessage = " Error Occurred, Details: " +
                            JSON.stringify(error);
                    })
            else {
                // alert('insert');
                if (viewModel.NewCategoryName.length > 0)
                    adminService.setCategory(viewModel.NewCategoryName, 0).then(function () {
                        //alert('category inserted');
                        CategoryUpdateSuccess = true;
                        //viewModel.GetCategories();
                    },
                    function (error) {
                        viewModel.errorMessage = " Error Occurred, Details: " +
                            JSON.stringify(error);
                        CategoryUpdateSuccess = false;
                    });
            }

            // For Insert NewsChannel TODO: Update
            if (viewModel.NewsChannelName.length > 0) {
                alert('entered')
                adminService.addNewsChannel(viewModel.NewsChannelName).then(function () {
                    //alert('category inserted');
                    //dono what to do here

                    alert('inserted')
                },
                function (error) {
                    // We are silently ignoring the error here, because we are not paid !
                    //viewModel.errorMessage = " Error Occurred, Details: " +
                      //  JSON.stringify(error);
                });
            }
            if(CategoryUpdateSuccess)
                viewModel.GetCategories();
        }

        viewModel.deleteCategory = function () {

            if (viewModel.SelectedCategory && viewModel.SelectedCategory.CategoryName && viewModel.SelectedCategory.CategoryName.length > 0 && viewModel.SelectedCategory.CategoryId)
                adminService.deleteCategory(viewModel.SelectedCategory.CategoryId).then(function () {
                    //   alert('Update');
                    viewModel.GetCategories();
                },
                    function (error) {
                        viewModel.errorMessage = " Error Occurred, Details: " +
                            JSON.stringify(error);
                    });
        }
        viewModel.GetCategories = function () {
            adminService.selectcategory("").then(
            function (data) {
                var CategoryList = [];
                data.forEach(function (cat) {
                    var obj = {};
                    obj.CategoryName = cat.CategoryName;
                    obj.CategoryId = cat.CategoryId;
                    CategoryList.push(obj);
                });
                viewModel.Categories = CategoryList;

            }, function (error) {
                viewModel.errorMessage = " Error Occurred, Details: " +
                    JSON.stringify(error);
            });
        }
        viewModel.GetCategories();
        viewModel.SelectedCategory = {};
        //Getting Newschannel
        viewModel.GetNewsChannel = function () {
            adminService.selectcategory("").then(
            function (data) {
                var CategoryList = [];
                data.forEach(function (cat) {
                    var obj = {};
                    obj.CategoryName = cat.CategoryName;
                    obj.CategoryId = cat.CategoryId;
                    CategoryList.push(obj);
                });
                viewModel.Categories = CategoryList;

            }, function (error) {
                viewModel.errorMessage = " Error Occurred, Details: " +
                    JSON.stringify(error);
            });
        }
        viewModel.GetCategories();
        viewModel.SelectedCategory = {};

      
        ////Category
        viewModel.Onchange = function (selected) {

            if (selected) {
                viewModel.SelectedCategory.CategoryName = selected.title;
                viewModel.SelectedCategory.CategoryId = selected.description;
            } else {
                console.log('cleared');
            }
        };
        viewModel.NewCategoryName = "";
        viewModel.onTextChange = function (text) {

            if (typeof text != 'undefined' && text.length == 0)
                viewModel.SelectedCategory = {};
            else if (typeof text != 'undefined' && text.length > 0)
                viewModel.NewCategoryName = text;
        }

        var columnDefs1 = [
          { name: 'CategoryName', width: 200, displayName: 'Category Name' },
          { name: 'CategoryId', width: 90, displayName: 'Category Id' }
        ];
        viewModel.gridOptions = {
            enableRowSelection: true,
            enableSelectAll: true,
            selectionRowHeaderWidth: 35,
            columnDefs: columnDefs1,
            data: 'Categories'
        };

        viewModel.gridOptions.multiSelect = true;

        viewModel.info = {};

        viewModel.toggleMultiSelect = function () {
            viewModel.gridApi.selection.setMultiSelect(!viewModel.gridApi.grid.options.multiSelect);
        };

        viewModel.toggleModifierKeysToMultiSelect = function () {
            viewModel.gridApi.selection.setModifierKeysToMultiSelect(!viewModel.gridApi.grid.options.modifierKeysToMultiSelect);
        };

        viewModel.selectAll = function () {
            viewModel.gridApi.selection.selectAllRows();
        };

        viewModel.clearAll = function () {
            viewModel.gridApi.selection.clearSelectedRows();
        };

        viewModel.toggleRow1 = function () {
            viewModel.gridApi.selection.toggleRowSelection(viewModel.gridOptions.data[0]);
        };

        viewModel.deleteSelected = function () {
            
            var selectedIds = viewModel.gridApi.selection.getSelectedRows();
            var commaSeperatedIds = selectedIds.map(function (data) {
                return data.CategoryId;
            }).join(",");

            adminService.deleteCategory(commaSeperatedIds).then(function () {
                adminService.selectcategory("").then(
                    function (data) {
                        var CategoryList = [];
                        data.forEach(function (cat) {
                            var obj = {};
                            obj.CategoryName = cat.CategoryName;
                            obj.CategoryId = cat.CategoryId;
                            CategoryList.push(obj);
                        });
                        viewModel.Categories = CategoryList;

                    }, function (error) {
                        viewModel.errorMessage = " Error Occurred, Details: " +
                            JSON.stringify(error);
                    });
            })
        }

        viewModel.gridOptions.onRegisterApi = function (gridApi) {
            //set gridApi on scope
            viewModel.gridApi = gridApi;
            gridApi.selection.on.rowSelectionChanged(viewModel, function (row) {
                var msg = 'row selected ' + row.isSelected;
                $log.log(msg);
            });

            gridApi.selection.on.rowSelectionChangedBatch(viewModel, function (rows) {
                var msg = 'rows changed ' + rows.length;
                $log.log(msg);
            });
        };

    }
}
