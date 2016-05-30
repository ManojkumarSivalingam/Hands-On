//using HCS.OneTap.Model;
//using HCS.OneTap.Model.Entities;
//using HCS.OneTap.SearchEngine.OneTapNewsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCS.OneTap.SearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Get keywords from DB
            ////Call service to get keywords

            //OneTapNewsServiceClient client = new OneTapNewsServiceClient();
            //List<KeyWord> lstKeyWords = client.GetKeywords().ToList();

            //List<News> Completelist = new List<News>();

            ////Get tweets for all keywords
            ////Call Handler to search for tweets            
            //foreach (KeyWord keyword in lstKeyWords)
            //{
            //    var tweets = OneTapWebRequestHandler.GetTweets(keyword);
            //    if (tweets != null)
            //        Completelist.AddRange(tweets);

            //    var googleNews = OneTapWebRequestHandler.GetGoogleNews(keyword);
            //    if (googleNews != null)
            //        Completelist.AddRange(googleNews);
            //}

            //client.SetNews(Completelist.ToArray());


           
            

       //     ServiceReference1.Service1Client client = new
       //ServiceReference1.Service1Client();
       //     string returnString;

       //     returnString = client.GetData(textBox1.Text);

           // OneTapNewsService.OneTapNewsServiceClient client = new OneTapNewsService.OneTapNewsServiceClient();
           //List<News> list = client.GetNews(0, 10).ToList();
           // List<Logo> logolist = client.GetLogo(3, string).ToList();


            //var key = new KeyWord { NDSName = "India", NDSId = 7 };
            //var tweets = OneTapWebRequestHandler.GetTweets(key);
            //OneTapNewsServiceClient client = new OneTapNewsServiceClient();
            //bool result = client.SetNews(tweets);
        }
    }
}


                
   

                
            
        
