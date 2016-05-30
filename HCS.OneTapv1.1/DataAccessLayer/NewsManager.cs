using HCS.OneTap.Model;
using HCS.OneTap.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NewsManager:IDisposable
    {
        public List<News> GetNews(int pageindex = 0)
        {
            List<News> newslist = new List<News>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try{
         
                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.GetNews");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pPageIndex", pageindex));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newslist.Add(new News
                    {
                        NewsId = Convert.ToInt32(reader["MsgId"].ToString()),
                        UserName = reader["MsgName"].ToString(),
                        Message =reader["Message"].ToString(),
                        ShortMessage = (reader["Message"].ToString().Length > 250) ? reader["Message"].ToString().Substring(0, 250) + "....." : reader["MsgName"].ToString()+reader["Message"].ToString(),
                       // newsurl=reader["ShortMessage"].ToString().Substring('http',' '),
                        Latitude = (reader["Latitude"].ToString().Equals(string.Empty))?0.00:Convert.ToDouble(reader["Latitude"].ToString()),
                        Longitude = (reader["Longitude"].ToString().Equals(string.Empty)) ? 0.00 : Convert.ToDouble(reader["Longitude"].ToString()),
                        Radius = (reader["Radius"].ToString().Equals(string.Empty)) ? 0.00 : Convert.ToDouble(reader["Radius"].ToString()),
                        
                        Imageurl = WebUtility.UrlDecode(reader["Imageurl"].ToString())
                    });
                   
                }
                

                _connection.Close();
                
            }
            catch(Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
               // throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return newslist;
        }


        public bool SetKeyword(KeyWord keyword)
        {
            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false ;
            try
            {
                string result = "";

                var sb = new StringBuilder();
                sb.Append("<ChannelList>");
                foreach (var channel in keyword.AvailableChannels)
                {
                    sb.Append("<Channel><NDSId>"+channel.NewsChannelId.ToString()+"</NDSId></Channel>");
                }

                sb.Append("</ChannelList>");
                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_Insert_Keyword");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@vkeyword";
                param.Value = keyword.NDSName;
                command.Parameters.Add(param);

                var ChannelList = new SqlParameter();
                ChannelList.Direction = ParameterDirection.Input;
                ChannelList.ParameterName = "@vChannelList";
                ChannelList.Value = sb.ToString();
                ChannelList.SqlDbType = SqlDbType.Xml;
                command.Parameters.Add(ChannelList);

                var outparam = new SqlParameter();
                outparam.Direction = ParameterDirection.Output;
                outparam.ParameterName = "@retValue";
                outparam.SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam);

                command.ExecuteNonQuery();

                result = (string)outparam.Value;
                status = result.ToLower().Equals("success");
                }
            
            catch (Exception)
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
                 //throw;
                status = false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return status;
       }

        public string ReplaceUrl(string message)
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

        public bool SetNews(List<News> newslist)
        {
            SqlConnection _connection = OneTapConnection.GetConnection;
           
            try
            {
                string result = "";
                var sb = new StringBuilder();
                sb.Append("<NewsList>");
                foreach (var news in newslist)
                {
                    sb.Append(news.XML);
                }
                sb.Append("</NewsList>");
                _connection.Open();

                if (newslist.Count > 0)
                {
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM NewsTable", _connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }
                }

                SqlCommand command = new SqlCommand("PROC_OneTap_SaveNews");
                command.Connection = _connection;
                
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@NewsList";
                param.Value = sb.ToString();
                param.SqlDbType = SqlDbType.Xml;
                command.Parameters.Add(param);
                var outparam = new SqlParameter();
                outparam .Direction = ParameterDirection.Output;
                outparam .ParameterName = "@retValue";
                outparam .SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam );

                command.ExecuteNonQuery();

                result = (string)outparam.Value;
                return (result.ToLower().Equals("success"))?true:false;

            }
            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
        }

        public void Dispose()
        {
            
        }

        public List<KeyWord> GetCategoryKeywords()
        {

            List<KeyWord> keywordlist = new List<KeyWord>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {

                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.GetCategoryKeywords");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    keywordlist.Add(new KeyWord()
                    {

                        //NDSId = Convert.ToInt32(reader["NDSId"].ToString()),
                        NDSName = reader["C_Keyword"].ToString(),
                        Category_Id = Convert.ToInt32(reader["Category_Id"].ToString()),
                        WLV_ID = Convert.ToInt32(reader["WLVId"].ToString()),
                        WLVC_Id = Convert.ToInt32(reader["WLVC_Id"].ToString()),
                        IsWLVC = true

                    }
                    );

                }


                _connection.Close();
                return keywordlist;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }


        }

        public List<KeyWord> GetKeywords()
        {

            List<KeyWord> keywordlist = new List<KeyWord>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {

                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.GetKeywords");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    keywordlist.Add(new KeyWord()
                    {

                        NDSId = Convert.ToInt32(reader["NDSId"].ToString()),
                        NDSName = reader["NewsDataSourceName"].ToString(),
                        NewsChannelId= Convert.ToInt32(reader["NewsChannelId"].ToString())

                    }

                    );

                }


                _connection.Close();
                return keywordlist;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }


        }
        public List<NewsChannel> GetNewsChannel()
        {
            List<NewsChannel> channellist = new List<NewsChannel>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {

                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.[PROC_OneTap_Channel]");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                var outparam = new SqlParameter();
                outparam.Direction = ParameterDirection.Output;
                outparam.ParameterName = "@retValue";
                outparam.SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    channellist.Add(new NewsChannel
                    {
                        NewsChannelId = Convert.ToInt32(reader["NewsChannelId"].ToString()),
                        NewsChannelName = reader["NewsChannelName"].ToString(),
                    });
                }


                _connection.Close();

            }
            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                // throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
            return channellist;

        }
        public bool SetWhiteLabel(string name)
        {
            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false;
            string result = "";
            try
            {

                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_WhiteLabel2");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@vwhitelabelname";
                //param.ParameterName="@vwhitelabellogo";
                param.Value = name;
                // param.Value=logo;
                command.Parameters.Add(param);
                var outparam = new SqlParameter();
                outparam.Direction = ParameterDirection.Output;
                outparam.ParameterName = "@retValue";
                outparam.SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam);

                command.ExecuteNonQuery();

                result = (string)outparam.Value;
                status = result.ToLower().Equals("success");
            }


            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                //throw;
                status = false;

            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return status;
        }
        public string NDSName { get; set; }

        public bool UpdateWhitelabel(Logo newlogo)
        {
            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false;
            try
            {
                string result = "";
                
                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_UpdateOrSaveWhiteLabel");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@pwhitelabelname";
                param.Value = newlogo.WhiteLabelName;
                param.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(param);

                var ChannelList = new SqlParameter();
                ChannelList.Direction = ParameterDirection.Input;
                ChannelList.ParameterName = "@pwhitelabelid";
                ChannelList.Value = newlogo.WLVID;
                ChannelList.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(ChannelList);

                var outparam = new SqlParameter();
                outparam.Direction = ParameterDirection.Output;
                outparam.ParameterName = "@retValue";
                outparam.SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam);

                command.ExecuteNonQuery();

                result = (string)outparam.Value;
                status = result.ToLower().Equals("success");


                _connection.Close();
            }

            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                //throw;
                status = false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return status;
        }
        public bool SetCategory(Category category)
        {
            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false;
            try
            {
                string result = "";

                
                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_InsertCategory1");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@catname";
                  param.Value = category.CategoryName;
                command.Parameters.Add(param);

                var paramId = new SqlParameter();
                paramId.Direction = ParameterDirection.Input;
                paramId.ParameterName = "@catid";
                paramId.Value = category.CategoryId;
                command.Parameters.Add(paramId);


                var outparam = new SqlParameter();
                outparam.Direction = ParameterDirection.Output;
                outparam.ParameterName = "@retValue";
                outparam.SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam);

                command.ExecuteNonQuery();

                result = (string)outparam.Value;
                status = result.ToLower().Equals("success");
            }

            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                //throw;
                status = false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
         
            return status;
        }
                //_connection.Close();
                //return keywordlist;
        
        public bool UpdateCategory(Category updatedcategory)
        {
            List<Category> categorylist = new List<Category>();

            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false;
            try
            {
                string result = "";

                _connection.Open();
    
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (_connection.State != ConnectionState.Closed)
        //            _connection.Close();
        //    }


        //}
                SqlCommand command = new SqlCommand("PROC_OneTap_InsertCategory1");
                command.Connection = _connection;
        
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var outparam = new SqlParameter();
                outparam.Direction = ParameterDirection.Output;
                outparam.ParameterName = "@retValue";
                outparam.SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categorylist.Add(new Category
                    {
                        CategoryId = Convert.ToInt32(reader["Category_Id"].ToString()),
                        CategoryName = reader["Category_name"].ToString(),
                    });
                }


                
                //var param = new SqlParameter();
                //param.Direction = ParameterDirection.Input;
                //param.ParameterName = "@catname";
                //param.Value = updatedcategory.CategoryName;
                //param.SqlDbType = SqlDbType.VarChar;
                //command.Parameters.Add(param);

                //var CategoryList = new SqlParameter();
                //CategoryList.Direction = ParameterDirection.Input;
                //CategoryList.ParameterName = "@catid";
                //CategoryList.Value = updatedcategory.CategoryId;
                //CategoryList.SqlDbType = SqlDbType.Int;
                //command.Parameters.Add(CategoryList);

                //var outparam1 = new SqlParameter();
                //outparam1.Direction = ParameterDirection.Output;
                //outparam1.ParameterName = "@retValue";
                //outparam1.SqlDbType = SqlDbType.VarChar;
                //outparam1.Size = 20;
                //command.Parameters.Add(outparam1);

                //command.ExecuteNonQuery();

                result = (string)outparam.Value;
                status = result.ToLower().Equals("success");


                _connection.Close();
            }

            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                //throw;
                status = false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return status;
        }

        public List<Category> GetCategory()
        {
            List<Category> categorylist = new List<Category>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {

                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.[PROC_OneTap_GetCategory]");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                //var outparam = new SqlParameter();
                //outparam.Direction = ParameterDirection.Output;
                //outparam.ParameterName = "@retValue";
                //outparam.SqlDbType = SqlDbType.VarChar;
                //outparam.Size = 20;
                //command.Parameters.Add(outparam);
               
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categorylist.Add(new Category
                    {
                        CategoryId = Convert.ToInt32(reader["Category_Id"].ToString()),
                        CategoryName = reader["Category_name"].ToString(),
                        KeywordList = reader["C_Keyword"].ToString()

                    });
                }


                _connection.Close();

            }
            catch (Exception ex)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                 throw ex;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
            return categorylist;

        }

        public List<Category> SelectCategory(string searchkeyword)
        {
            List<Category> categorylist = new List<Category>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {

                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.[PROC_OneTap_GetCategory]");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                //var outparam = new SqlParameter();
                //outparam.Direction = ParameterDirection.Output;
                //outparam.ParameterName = "@retValue";
                //outparam.SqlDbType = SqlDbType.VarChar;
                //outparam.Size = 20;
                //command.Parameters.Add(outparam);

                var catparam = new SqlParameter();
                catparam.ParameterName = "@catname";
                catparam.SqlDbType = SqlDbType.VarChar;
                catparam.SqlValue = searchkeyword+"%";
                command.Parameters.Add(catparam);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categorylist.Add(new Category
                    {CategoryName = reader["Category_name"].ToString(),
                        CategoryId = Convert.ToInt32(reader["Category_Id"].ToString()),
                        
                    });
                }


                _connection.Close();

            }
            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                // throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
            return categorylist;

        }

        public List<Category> ViewCategory()
        {
            List<Category> categorylist = new List<Category>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {

                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.[PROC_OneTap_GetCategory]");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                //var outparam = new SqlParameter();
                //outparam.Direction = ParameterDirection.Output;
                //outparam.ParameterName = "@retValue";
                //outparam.SqlDbType = SqlDbType.VarChar;
                //outparam.Size = 20;
                //command.Parameters.Add(outparam);

                var catparam = new SqlParameter();
                catparam.ParameterName = "@catname";
                catparam.SqlDbType = SqlDbType.VarChar;
                catparam.SqlValue = "";
                command.Parameters.Add(catparam);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categorylist.Add(new Category
                    {
                        CategoryName = reader["Category_name"].ToString()
                        

                    });
                }


                _connection.Close();

            }
            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                // throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
            return categorylist;

        }

        public bool DeleteCategory(string categoryids)
        {
            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false;
            try
            {
                string result = "";

                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_DeleteCategory");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;

                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@catids";
                param.Value = categoryids;
                command.Parameters.Add(param);
                command.ExecuteNonQuery();

                status = result.ToLower().Equals("success");
            }

            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                //throw;
                status = false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return status;
        }

        public bool UpdateCategoryKeyword(int categoryId, string keywords)
        {
            // updates WhiteLabelVersionCategory keywords using the category id
            // This is called multiple times for each category id selected from the UI
            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false;
            try
            {
                string result = "";

                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_Insert_catKeyword");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;

                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@vcategoryId";
                param.Value = categoryId;
                command.Parameters.Add(param);
                
                var param1 = new SqlParameter();
                param1.Direction = ParameterDirection.Input;
                param1.ParameterName = "@vkeyword";
                param1.Value = keywords;
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();

                status = result.ToLower().Equals("success");
            }

            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                //throw;
                status = false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return status;
        }

        public List<News> GetCatNews(int cat_Id, int pageIndex)
        {
            List<News> cat_newslist = new List<News>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {

                //int @pPageIndex =null ;  
                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_GetCatNews");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pcat_id", cat_Id));

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pPageIndex", pageIndex));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cat_newslist.Add(new News
                    {
                        NewsId = Convert.ToInt32(reader["MsgId"].ToString()),
                        UserName = reader["MsgName"].ToString(),
                        Message = reader["Message"].ToString(),
                        ShortMessage = (reader["Message"].ToString().Length > 250) ? reader["Message"].ToString().Substring(0, 250) + "....." : reader["MsgName"].ToString() + reader["Message"].ToString(),
                        // newsurl=reader["ShortMessage"].ToString().Substring('http',' '),
                        Latitude = (reader["Latitude"].ToString().Equals(string.Empty)) ? 0.00 : Convert.ToDouble(reader["Latitude"].ToString()),
                        Longitude = (reader["Longitude"].ToString().Equals(string.Empty)) ? 0.00 : Convert.ToDouble(reader["Longitude"].ToString()),
                        Radius = (reader["Radius"].ToString().Equals(string.Empty)) ? 0.00 : Convert.ToDouble(reader["Radius"].ToString()),

                        Imageurl = WebUtility.UrlDecode(reader["Imageurl"].ToString())
                    });

                }


                _connection.Close();

            }
            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                // throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return cat_newslist;
        }


        public bool SetNewsChannel(NewsChannel newschannel)
        {
            SqlConnection _connection = OneTapConnection.GetConnection;
            bool status = false;
            try
            {
                string result = "";


                _connection.Open();

                SqlCommand command = new SqlCommand("PROC_OneTap_Insert_NewsChannel");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                var param = new SqlParameter();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "@pnewschannel";
                param.Value = newschannel.NewsChannelName;
                command.Parameters.Add(param);

                
                var outparam = new SqlParameter();
                outparam.Direction = ParameterDirection.Output;
                outparam.ParameterName = "@retValue";
                outparam.SqlDbType = SqlDbType.VarChar;
                outparam.Size = 20;
                command.Parameters.Add(outparam);

                command.ExecuteNonQuery();

                result = (string)outparam.Value;
                status = result.ToLower().Equals("success");
            }

            catch (Exception)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                //throw;
                status = false;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }

            return status;
        }

        
    }
}
