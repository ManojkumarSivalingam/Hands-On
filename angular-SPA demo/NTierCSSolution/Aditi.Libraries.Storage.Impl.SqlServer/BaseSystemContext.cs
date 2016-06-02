using Aditi.Libraries.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Storage.Impl.SqlServer
{
    public abstract class BaseSystemContext : DbContext, ISystemContext
    {
        public BaseSystemContext(string connectionString) : base( connectionString ) { }

        #region ISystemContext Members

        public virtual IEnumerable<T> ExecuteRoutine<T>(
            string routineName, IDictionary<string, object> parameters = default(IDictionary<string,object>))
            where T : class
        {
            var tList = default( IEnumerable<T> );

            if ( !string.IsNullOrEmpty( routineName ) )
            {
                var sqlParameters = new List<SqlParameter>();

                foreach ( var key in parameters.Keys )
                    sqlParameters.Add(
                        new SqlParameter( key, parameters[key] ) );

                tList = Database.SqlQuery<T>( routineName, sqlParameters.ToArray() ).ToList();
            }

            return tList;
        }

        public void CommitChanges()
        {
            this.SaveChanges();
        }

        #endregion
    }
}
