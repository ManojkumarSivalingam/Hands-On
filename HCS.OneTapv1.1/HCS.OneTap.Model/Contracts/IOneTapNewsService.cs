using HCS.OneTap.Model;
using HCS.OneTap.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HCS.OneTap.Model
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
    [ServiceContract]
    public interface IOneTapNewsService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetNews/?pageindex={pageindex}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]        
        List<News> GetNews(string pageindex);

      [OperationContract]
      [WebInvoke(UriTemplate = "GetLogo/?id={id}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
       List<Logo> GetLogo(int id);

      [OperationContract]
      bool SetNews(List<News> NewsList);

      [OperationContract]
      [WebInvoke(UriTemplate = "SetKeyword/?keyWord={keyword}&Channels={ChannelList}",
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          Method = "GET")]
      bool SetKeyword(string keyword,string ChannelList);

        //[OperationContract]
        //List<KeyWord> GetNewsChannel();

        [OperationContract]
        [WebInvoke(UriTemplate = "GetChannel/",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
      List<NewsChannel> GetNewsChannel();

        [OperationContract]
        [WebInvoke(UriTemplate = "updatewhitelabel/?WLVID={WLVID}&WLVName={WLVName}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        bool UpdateWhitelabel(string WLVID,string WLVName);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "SetWhiteLabel/?name={name}",
        //   ResponseFormat = WebMessageFormat.Json,
        //   BodyStyle = WebMessageBodyStyle.Bare,
        //   Method = "GET")]
        //bool SetWhiteLabel(string name);

        // TODO: Add your service operations here
        [OperationContract]
        [WebInvoke(UriTemplate = "GetHandlers/?keyWord={keyword}&newsSource={newsSource}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        List<string> GetHandlers(string keyWord, int newsSource);

        [OperationContract]
        [WebInvoke(UriTemplate = "SetCategory/?Category={category}&categoryId={categoryId}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        bool SetCategory(string category, int categoryId);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateCategory/?CATID={CATID}&CATName={CATName}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        bool UpdateCategory(string CATID, string CATName);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetCategory/",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        List<Category> GetCategory();

        [OperationContract]
        [WebInvoke(UriTemplate = "SelectCategory/?searchkeyword={searchkeyword}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        List<Category> SelectCategory(string searchkeyword);
       
        
        [OperationContract]
        [WebInvoke(UriTemplate = "ViewCategory/",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        List<Category> ViewCategory();

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteCategory/?categoryids={categoryids}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        bool DeleteCategory(string categoryids);


        //[OperationContract]
        //[WebInvoke(UriTemplate = "GetKeywords/",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    Method = "GET")]
        //List<KeyWord> GetKeywords();
        //UriTemplate = "UpdateCategoryKeyword/?categoryIds={categoryIds}&keywords={keywords}"
        [OperationContract]
        [WebInvoke(
            UriTemplate = "UpdateCategoryKeyword/?categoryIds={categoryIds}&keywords={keywords}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        bool UpdateCategoryKeyword(string categoryIds, string keywords);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetCatNews/?cat_Id={cat_Id}&pageIndex={pageIndex}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        List<News> GetCatNews(int cat_Id, int pageIndex);


        [OperationContract]
        [WebInvoke(UriTemplate = "SetNewsChannel/?NewsChannelName={newschannel}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "GET")]
        bool SetNewsChannel(string newschannel);

    }
}
 