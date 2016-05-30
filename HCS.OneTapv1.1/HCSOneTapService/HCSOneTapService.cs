using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using HCS.OneTap.SearchEngine;

using HCS.OneTap.Model.Entities;
using HCS.OneTap.Model;
using DataAccessLayer;
using System.Threading;

namespace HCSOneTapService
{
    public partial class HCSOneTapWindowService : ServiceBase
    {
        public EventLog eventLog1;

        public HCSOneTapWindowService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            int interval = 15;
            System.Timers.Timer timScheduledTask = new System.Timers.Timer();

            if (args != null && args.Length>0)
                interval = int.Parse(args[0]);
           
            // Timer interval is set in miliseconds,
            // In this case, we'll run a task every 5 minute

            //timScheduledTask.Interval = interval * 60 * 1000;
            //timScheduledTask.Enabled = true;
            //timScheduledTask.Elapsed += new System.Timers.ElapsedEventHandler(timScheduledTask_Elapsed);

          RunJob();
        }

        void timScheduledTask_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Execute some task
            RunJob();
        }

        void RunJob()
        {
            NewsManager newsManager = new NewsManager();
            List<KeyWord> lstKeyWords = newsManager.GetKeywords();
            List<KeyWord> lstCategoryKeywords = newsManager.GetCategoryKeywords();
            List<News> Completelist = new List<News>();

            //Get tweets for all keywords
            //Call Handler to search for tweets            
            foreach (KeyWord keyword in lstKeyWords)
            {
                
                //this is for keyword
                if (keyword.NewsChannelId == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Getting tweets for {0}", keyword.NDSName);
                    var tweets = OneTapWebRequestHandler.GetTweets(keyword);
                    if (tweets != null)
                        Completelist.AddRange(tweets);
                    Console.WriteLine("Finished getting tweets for {0}", keyword.NDSName);
                }
                else if (keyword.NewsChannelId == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Getting google news for {0}", keyword.NDSName);
                    var googleNews = OneTapWebRequestHandler.GetGoogleNews(keyword);
                    if (googleNews != null)
                        Completelist.AddRange(googleNews);
                    Console.WriteLine("Finished getting google news for {0}", keyword.NDSName);
                }

                // Sleep for 2 sec to avoid request blocks.
                Thread.Sleep(2000);
            }

            Console.WriteLine("Running service for categorized keywords.");

            //this is for categories keyword
            foreach (KeyWord keyword in lstCategoryKeywords)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Getting tweets for {0}", keyword.NDSName);
                var tweets = OneTapWebRequestHandler.GetTweets(keyword);
                    if (tweets != null)
                        Completelist.AddRange(tweets);
                Console.WriteLine("Finished getting tweets for {0}", keyword.NDSName);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Getting google news for {0}", keyword.NDSName);
                var googleNews = OneTapWebRequestHandler.GetGoogleNews(keyword);
                if (googleNews != null)
                    Completelist.AddRange(googleNews);
                Console.WriteLine("Finished getting google news for {0}", keyword.NDSName);
                // Sleep for 2 sec to avoid request blocks.
                Thread.Sleep(200);
            }

            newsManager.SetNews(Completelist);
        }

        

        protected override void OnStop()
        {
        }
    }
}
