using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCS.OneTap.Model;

namespace DataAccessLayer
{
    public class WhiteLabelManager
    {
        public List<Logo> GetLogo(int id)
        {
            List<Logo> logolist = new List<Logo>();
            SqlConnection _connection = OneTapConnection.GetConnection;
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("dbo.GetLogo");
                command.Connection = _connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pWLVId", id));
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    logolist.Add(new Logo
                    {
                        WLVID = Convert.ToInt32(reader["WLVId"]),
                        WhiteLabelName = reader["WhiteLabelVersionName"].ToString(),
                        WhiteLabelLogo = reader["Logo"].ToString()

                    });


                }
                _connection.Close();
                return logolist;
            }
            catch (Exception )
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
    }
}



