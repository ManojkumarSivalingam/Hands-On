
function newsViewController(viewModel, globalViewModel, newsService, serviceUrls) {
    if (newsService && viewModel) {

        viewModel.pageindex = 0;
        viewModel.NewSet = true;
        viewModel.Callme = function () {

            viewModel.pageindex++;

            newsService.getNews(viewModel.pageindex).then(
            function (data) {
                if (data.length > 0) {
                    viewModel.newsList = (viewModel.newsList).concat(data);
                }
                else
                    viewModel.NewSet = false;

                for (var i = 0; i < data.length; i++) {
                    localStorage.setItem("OneTapNews" + data[i].NewsId,
                    data[i].ImageUrl + "%##%" + data[i].UserName + "%##%" + data[i].ShortMessage + "%##%" + data[i].Message);
                }

            })


        }
        
        globalViewModel.GetNextPage = function () {
            var curScrollHieght = $('#myDiv')[0].offsetHeight + $('#myDiv')[0].scrollTop;
            var totalScrollHeight = $('#myDiv')[0].scrollHeight;

            if (curScrollHieght >= (totalScrollHeight)) {
                viewModel.Callme();
                //viewmodel.pageindex++;
            }
            //callcustom(viewmodel, newsservice, serviceurls);
        }


        newsService.getNews(viewModel.pageindex).then(

                    function (data) {
                        //debugger;
                        if (data.length > 0)
                            viewModel.newsList = data;
                        else
                            viewModel.newsList = data
                        //localStorage.clear();
                        for (var i = 0; i < data.length; i++) {
                            localStorage.setItem("OneTapNews" + data[i].NewsId,
                            data[i].ImageUrl + "%##%" + data[i].UserName + "%##%" + data[i].ShortMessage + "%##%" + data[i].Message);
                        }

                        newsService.getCategory().then(
                                            function (data) {
                                                if (data.length > 0) {
                                                    viewModel.categorylist = data;
                                                }
                                            },
                                            function (err) {
                                                console.log(err);
                                            }
                                        );

                    },

                    function (error) {
                        var OneTapKeys = [];
                        var keyregex = /(^OneTapNews)/;
                        var data = [];
                        for (var key in localStorage) {
                            if (keyregex.test(key))
                                OneTapKeys.push(key);
                        }
                        if (OneTapKeys.length > 0) {
                            for (var i = 0; i < OneTapKeys.length; i++) {
                                var news = localStorage.getItem(OneTapKeys[i]);
                                var newsarray = news.split("%##%");
                                var jsonobj = {};
                                jsonobj.NewsId = OneTapKeys[i].replace("OneTapNews", "");
                                jsonobj.ImageUrl = newsarray[0];
                                jsonobj.UserName = newsarray[1];
                                jsonobj.ShortMessage = newsarray[2];
                                jsonobj.Message = newsarray[3];
                                data.push(jsonobj);
                            }
                            viewModel.newsList = data;
                        }
                        else {
                            viewModel.errorMessage = " Error Occurred, Details: " +
                                JSON.stringify(error);
                            throw error;
                        }
                    }),





        viewModel.pageindex = 0;
        //viewModel.cat_Id = CategoryId;
        viewModel.NewSet = true;
        viewModel.getCatnews = function (categoryId, pageIndex) {

            //viewModel.pageindex++;

            newsService.getCatnews(categoryId, 1).then(
            function (data) {
                viewModel.CurrentPage = 0;
                if (data.length > 0) {
                    //viewModel.catNewsList = (viewModel.catNewsList).concat(data);
                    viewModel.catNewsList = data;
                    viewModel.ShowSlider = true;
                }
                else {
                    viewModel.catNewsList = null;
                    viewModel.ShowSlider = false;
                }

                for (var i = 0; i < data.length; i++) {
                    localstorage.setitem("onetapcatnews" + data[i].newsid,
                    data[i].imageurl + "%##%" + data[i].username + "%##%" + data[i].shortmessage + "%##%" + data[i].message);
                }
            })
        }

        globalViewModel.GetNextPage = function () {
            var curScrollHieght = $('#myDiv')[0].offsetHeight + $('#myDiv')[0].scrollTop;
            var totalScrollHeight = $('#myDiv')[0].scrollHeight;

            if (curScrollHieght >= (totalScrollHeight)) {
                viewModel.getCatnews();
                //viewmodel.pageindex++;
            }
            //callcustom(viewmodel, newsservice, serviceurls);
        }

        viewModel.ShowSlider = false;
        viewModel.CurrentPage = 0;
        viewModel.PageSize = 4;
        viewModel.numberOfPages = function () {
            if (viewModel.catNewsList == null || viewModel.catNewsList.length ==0)
                return 0;
            return Math.ceil(viewModel.catNewsList.length / viewModel.PageSize);
        }
        newsService.getCatnews(viewModel.pageindex, viewModel.cat_Id).then(
                    function (data) {
                        //debugger;
                        if (data.length > 0) {
                            viewModel.catnewsList = data;
                        }
                        else
                            viewModel.catnewsList = data;
                        //localStorage.clear();
                        for (var i = 0; i < data.length; i++) {
                            localStorage.setItem("OneTapNews" + data[i].NewsId,
                            data[i].ImageUrl + "%##%" + data[i].UserName + "%##%" + data[i].ShortMessage + "%##%" + data[i].Message);
                        }
                    },
                    function (error) {
                        var OneTapKeys = [];
                        var keyregex = /(^OneTapNews)/;
                        var data = [];
                        for (var key in localStorage) {
                            if (keyregex.test(key))
                                OneTapKeys.push(key);
                        }
                        if (OneTapKeys.length > 0) {
                            for (var i = 0; i < OneTapKeys.length; i++) {
                                var news = localStorage.getItem(OneTapKeys[i]);
                                var newsarray = news.split("%##%");
                                var jsonobj = {};
                                jsonobj.NewsId = OneTapKeys[i].replace("OneTapNews", "");
                                jsonobj.ImageUrl = newsarray[0];
                                jsonobj.UserName = newsarray[1];
                                jsonobj.ShortMessage = newsarray[2];
                                jsonobj.Message = newsarray[3];
                                data.push(jsonobj);
                            }
                            viewModel.catnewsList = data;
                        }
                        else {
                            viewModel.errorMessage = " Error Occurred, Details: " +
                                JSON.stringify(error);
                            throw error;
                        }
                    })
    }
}

    function callcustom(viewmodel, newsservice, serviceurls) {
        if (newsservice && viewmodel) {

            if ($('#mydiv')[0].offsetheight + $('#mydiv')[0].scrolltop == $('#mydiv')[0].scrollheight) {
                alert("end");
                //viewmodel.pageindex++;
            }
            newsservice.getnews(viewmodel.pageindex).then(
             function (data) {
                 if (data.length > 0)
                 {
                     viewmodel.newslist = (viewmodel.newslist).concat(data);
                 }
                 //localstorage.clear();
                 for (var i = 0; i < data.length; i++) {
                     localstorage.setitem("onetapnews" + data[i].newsid,
                     data[i].imageurl + "%##%" + data[i].username + "%##%" + data[i].shortmessage + "%##%" + data[i].message);
                 }

             },

             function (error) {
                 var onetapkeys = [];
                 var keyregex = /(^onetapnews)/;
                 var data = [];
                 for (var key in localstorage) {
                     if (keyregex.test(key))
                         onetapkeys.push(key);
                 }
                 if (onetapkeys.length > 0) {
                     for (var i = 0; i < onetapkeys.length; i++) {
                         var news = localstorage.getitem(onetapkeys[i]);
                         var newsarray = news.split("%##%");
                         var jsonobj = {};
                         jsonobj.newsid = onetapkeys[i].replace("onetapnews", "");
                         jsonobj.imageurl = newsarray[0];
                         jsonobj.username = newsarray[1];
                         jsonobj.shortmessage = newsarray[2];
                         jsonobj.message = newsarray[3];
                         data.push(jsonobj);
                     }
                     viewmodel.newslist = data;
                 }
                 else {
                     viewmodel.errormessage = " error occurred, details: " +
                         json.stringify(error);
                     throw error;
                 }
             }),
             
                 newsservice.getCatnews(viewmodel.pageindex, viewModel.cat_Id).then(
                  function (data) {
                      if (data.length > 0)
                      {
                          viewmodel.catnewsList = (viewmodel.catnewsList).concat(data);
                      }
                      //localstorage.clear();
                      for (var i = 0; i < data.length; i++) {
                          localstorage.setitem("onetapnews" + data[i].newsid,
                          data[i].imageurl + "%##%" + data[i].username + "%##%" + data[i].shortmessage + "%##%" + data[i].message);
                      }

                  },

                  function (error) {
                      var onetapkeys = [];
                      var keyregex = /(^onetapnews)/;
                      var data = [];
                      for (var key in localstorage) {
                          if (keyregex.test(key))
                              onetapkeys.push(key);
                      }
                      if (onetapkeys.length > 0) {
                          for (var i = 0; i < onetapkeys.length; i++) {
                              var news = localstorage.getitem(onetapkeys[i]);
                              var newsarray = news.split("%##%");
                              var jsonobj = {};
                              jsonobj.newsid = onetapkeys[i].replace("onetapnews", "");
                              jsonobj.imageurl = newsarray[0];
                              jsonobj.username = newsarray[1];
                              jsonobj.shortmessage = newsarray[2];
                              jsonobj.message = newsarray[3];
                              data.push(jsonobj);
                          }
                          viewmodel.catnewsList = data;
                      }
                      else {
                          viewmodel.errormessage = " error occurred, details: " +
                              json.stringify(error);
                          throw error;
                      }
                  });


             }
        }

    




