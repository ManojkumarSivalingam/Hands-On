using Aditi.Libraries.SOA.Contracts.Data;
using Aditi.Libraries.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.Storage.Impl.SqlServer
{
    public class CustomersContext : BaseSystemContext, ICustomersContext
    {
        private static string CONNECTION_STRING =
            ConfigurationManager.ConnectionStrings["AditiTrainingDB"].ConnectionString;

        public CustomersContext() : base( CONNECTION_STRING ) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Configurations.Add<Customer>( new CustomerEntityTypeConfiguration() );
        }

        #region ICustomersContext Members

        public IDbSet<Customer> Customers { get; set; }

        #endregion
    }
}
