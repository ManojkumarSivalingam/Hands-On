using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static class OneTapConnection
    {
        private static string connectionstring = "Data Source=.;Initial Catalog=OneTapDb;Integrated Security=SSPI;";
        private static SqlConnection _connection;
        public static SqlConnection GetConnection
        {
            get {
                if (_connection == null){
                    _connection = new SqlConnection(connectionstring);
                }
                return _connection;
            }
        }
    }
}
