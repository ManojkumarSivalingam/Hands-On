using DataAccessLayer;
using HCS.OneTap.Model;
using HCS.OneTap.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HCS.OneTap.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class OneTapNewsService : IOneTapNewsService
    {
        public List<News> GetNews(string pageindex)
        {
            NewsManager _newsManager = new NewsManager();
            int index = 0;
            if (Int32.TryParse(pageindex, out index))
            {
                return _newsManager.GetNews(index);
            }
            return null;
        }

        public List<Logo> GetLogo(int id)
        {
            WhiteLabelManager _whitelabel = new WhiteLabelManager();
            int idno = 0;
            //string wname;
            return _whitelabel.GetLogo(idno);
        }

        public bool SetNews(List<News> NewsList)
        {
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.SetNews(NewsList);
            }
        }

        //public List<KeyWord> GetKeywords()
        //{
        //    using (NewsManager _newsManager = new NewsManager())
        //    {
        //        return _newsManager.GetKeywords();
        //    }
        //}

        public bool SetKeyword(string keyword, string ChannelList)
        {
            KeyWord newkeyword = new KeyWord();
            newkeyword.NDSName = keyword;
            newkeyword.DelimitedChannelIds = ChannelList;
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.SetKeyword(newkeyword);
            }
        }

        public List<NewsChannel> GetNewsChannel()
        {
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.GetNewsChannel();
            }
        }

        //public bool SetWhiteLabel(string name)
        //{
        //    using (NewsManager _newsManager = new NewsManager())
        //    {
        //        return _newsManager.SetWhiteLabel(name);
        //    }
        //}

        public bool UpdateWhitelabel(string WLVID, string WLVName)
        {
            Logo newlogo = new Logo();
            int Id = default(int);
            Int32.TryParse(WLVID, out Id);
            newlogo.WLVID = Id;
            newlogo.WhiteLabelName = WLVName;
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.UpdateWhitelabel(newlogo);
            }
        }

        public List<string> GetHandlers(string keyWord, int newsSource)
        {
            // TODO: 
            // Input keyword, sourceType
            // Check AllHandlers table for existing handlers for keyword
            // if it has rows, fetch handlers from it.
            //      else get handlers from twitter api and save.
            // Return list of handlers
            List<string> handlers = new List<string>();
            handlers.Add("#test1");
            handlers.Add("#test2");
            handlers.Add("#test3");
            return handlers;
        }

        public bool SetCategory(string category, int categoryId)
        {
            Category newcategory = new Category();
            newcategory.CategoryName = category;
            newcategory.CategoryId = categoryId;
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.SetCategory(newcategory);
            }
        }

        public bool UpdateCategory(string CATID, string CATName)
        {
            Category updatedcategory = new Category();
            int Id = default(int);
            Int32.TryParse(CATID, out Id);
            updatedcategory.CategoryId = Id;
            updatedcategory.CategoryName = CATName;
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.UpdateCategory(updatedcategory);
            }
        }

        public List<Category> GetCategory()
        {
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.GetCategory();
            }
        }

        public List<Category> SelectCategory(string searchkeyword)
        {
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.SelectCategory(searchkeyword);
            }
        }
        public List<Category> ViewCategory()
        {
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.ViewCategory();
            }
        }

        public bool DeleteCategory(string categoryids)
        {
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.DeleteCategory(categoryids);
            }
        }

        //https://code.msdn.microsoft.com/windowsdesktop/Support-for-arrays-in-53c276ae

        public bool UpdateCategoryKeyword(string categoryIds, string keywords)
        {
            Dictionary<int, string> categoryKeywords = new Dictionary<int, string>();

            string[] categoryIdArray = categoryIds.Split(',');
            if (keywords.StartsWith("|"))
            {
                keywords = keywords.Substring(1);
            }

            string[] keywordArray = keywords.Split('|');
            keywordArray.ToList().RemoveAll(x => x.Length <= 0);
            using (NewsManager _newsManager = new NewsManager())
            {
                for(int i = 0; i < categoryIdArray.Length; i++)
                {   
                    int catId;
                    if(int.TryParse( categoryIdArray[i], out catId)){
                        _newsManager.UpdateCategoryKeyword(catId, "," + keywordArray[i]);
                    }
                }
             }

            return true;
        }


        public List<News> GetCatNews(int cat_Id, int pageIndex)
        {
            NewsManager manager = new NewsManager();
            return manager.GetCatNews(cat_Id, pageIndex);

        }

        public bool SetNewsChannel(string newschannel)
        {
            NewsChannel newchannel = new NewsChannel();
            newchannel.NewsChannelName = newschannel;
            
            using (NewsManager _newsManager = new NewsManager())
            {
                return _newsManager.SetNewsChannel(newchannel);
            }
        }


    
    }


}



