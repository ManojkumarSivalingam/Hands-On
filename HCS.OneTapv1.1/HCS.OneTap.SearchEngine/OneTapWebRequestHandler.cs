
using HCS.OneTap.Model;
using HCS.OneTap.Model.Entities;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;

namespace HCS.OneTap.SearchEngine
{
    public static class OneTapWebRequestHandler
    {

        public static List<News> GetTweets(KeyWord key)
        {
            var newsList = new List<News>();
            TwitterCredentials creds = new TwitterCredentials("4U65lcJsuuwo8uXYneToJJecv", "vME3VAdFtXEDOynf5PXy2Z7JXPNCDNjYtcc3zJOW4NYIb3uNFG", "4872881234-3ES80SoG82QO7t3foe8FmFEhF03lMwNLuVfndvt", "rmEoT7IFW9DvCa7ZHxrzu2nzepwrWWEeDRA9VaqTTr94B");
            Auth.SetCredentials(creds);
            
            List<ITweet> tweets=new List<ITweet>();
            if (!key.IsWLVC)
            {
                 tweets= Search.SearchTweets(key.NDSName).ToList();
            }
            else
            {
                List<string> keywordList = key.NDSName.Split(',').ToList();
                foreach(string keyCat in keywordList)
                {
                    var keywordTweets = Search.SearchTweets(keyCat);
                    tweets.AddRange(keywordTweets.ToList());
                }               
            }

            
            if (tweets != null)
            {
                foreach (var tweet in tweets)
                {
                    News news = new News();

                    news.Message = ReplaceUrl(tweet.Text);
                    news.UserName = tweet.CreatedBy.Name;
                    news.Imageurl = tweet.CreatedBy.ProfileImageUrl;
                    news.Source = "Tweet";
                    if (key.IsWLVC)
                    {
                        news.Wlvcid = key.WLVC_Id;
                        news.Wlvid = key.WLV_ID;
                        news.NDSId = null;
                    }
                    else
                    {
                        news.Wlvcid = null;
                        news.Wlvid = null;
                        news.NDSId = key.NDSId;
                    }

                    newsList.Add(news);
                }                
            }
            
            return newsList;
        }

        public static string ReplaceUrl(string message)
        {

            var outputString = message;
            Regex regx = new Regex(@"https?://([-\w\.]+)+(:\d+)?(/([\w/_\.]*(\?\S+)?)?)?", RegexOptions.IgnoreCase);
            MatchCollection mactches = regx.Matches(message);
            foreach (Match match in mactches)
            {
                outputString = outputString.Replace(match.Value, String.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", match.Value));
            }

            return outputString;

        }

        public static List<News> GetGoogleNews(KeyWord key)
        {
            
            List<News> Details = new List<News>();
            try
            {
                // httpWebRequest with API url
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://news.google.com/news?q=" + key.NDSName + "&output=rss&num=100");
                //request.ContentType = "application/json";
                //Method GET
                request.Method = "GET";

                /* Sart browser signature */
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
                /* Sart browser signature */

                //HttpWebResponse for result
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                //Mapping of status code
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    System.IO.Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == "")
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    //Get news data in json string

                    string data = readStream.ReadToEnd();

                    //var news = JsonConvert.DeserializeObject<FeedApiResult>(data);
                    ////Declare DataSet for put data in it.

                    //foreach (Entry entry in news.responseData.entries)
                    //{
                    //    Details.Add(new News
                    //    {
                    //        NDSId = key.NDSId,

                    //        Message = entry.contentSnippet + "<a href='"+ entry.link.ToString() + "'>" + entry.link.ToString() + "</a>" ,
                    //        UserName = entry.title.ToString(),
                    //        Imageurl = entry.link.ToString(),
                    //        Source = "Google"

                    //    });
                    //}

                    //}



                    DataSet ds = new DataSet();
                    StringReader reader = new StringReader(data);
                    ds.ReadXml(reader);
                    DataTable dtGetNews = new DataTable();
                    DataTable dtImages = new DataTable();
                    if (ds.Tables.Count > 3)
                    {
                        dtGetNews = ds.Tables["item"];

                        dtImages = ds.Tables["image"];
                        foreach (DataRow dtRow in dtGetNews.Rows)
                        {
                            News news = new News();
                            //news.NDSId = key.NDSId;
                            news.UserName = dtRow["title"].ToString();
                            // DataObj.Imageurl = dtRow["link"].ToString();
                            // DataObj.NDSId = dtRow["item_id"].ToString();
                            // DataObj.CreatedDate = dtRow["pubDate"].ToString();
                            ParseDescription(dtRow["description"].ToString(), news);
                            news.Source = "Google";
                            //DataObj.Message = dtRow["description"].ToString();
                            if (news.Imageurl != null)
                                Details.Add(news);

                            if(key.IsWLVC)
                            {
                                news.Wlvid = key.WLV_ID;
                                news.Wlvcid = key.WLVC_Id;
                                news.NDSId = null;
                            }
                            else
                            {
                                news.Wlvid = null;
                                news.Wlvcid = null;
                                news.NDSId = key.NDSId;
                            }
                            
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Details;
            
        }

        public static void ParseDescription(string description, News dataObj)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(description);

            var imgTags = document.DocumentNode.SelectNodes("//img");

            if (imgTags != null)
            {
                if (imgTags[0].Attributes["src"] != null)
                {
                    dataObj.Imageurl =  imgTags[0].Attributes["src"].Value;
                }
            }

            var descriptionTags = document.DocumentNode.SelectNodes("//font");
            if (descriptionTags != null)
            {
                if (descriptionTags != null && descriptionTags.Count >= 3)
                {
                    dataObj.Message = descriptionTags[2].SelectNodes("//font")[5].InnerHtml;
                }
            }

            var linkTags = document.DocumentNode.SelectNodes("//a");
            if(linkTags!=null)
            {
                if(linkTags[0].Attributes["href"]!=null)
                {
                    string link=linkTags[0].Attributes["href"].Value;
                    int startindex=link.IndexOf("url=")+4;
                    link=link.Substring(startindex);

                    link = string.Format("<a href='{0}'>{0}</a>", link);

                    dataObj.Message = string.Format("{0} - {1}", dataObj.Message,link );
                }
            }

        }
    }



    public class FeedApiResult
    {
        public ResponseData responseData { get; set; }
        public string responseDetails { get; set; }
        public string responseStatus { get; set; }
    }

    public class ResponseData
    {
        public List<Entry> entries { get; set; }
    }

    public class Feed
    {
        public string title { get; set; }
        public string link { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class Entry
    {
        public string title { get; set; }
        public string link { get; set; }
        public string url { get; set; }
        //public string author { get; set; }
        //public string publishedDate { get; set; }
        public string contentSnippet { get; set; }
        //public string content { get; set; }

    }

}