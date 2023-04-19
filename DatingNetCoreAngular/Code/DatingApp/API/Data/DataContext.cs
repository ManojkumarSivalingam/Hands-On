using API.Data.Converters;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                   .HaveConversion<DateOnlyConverter>()
                   .HaveColumnType("date");
        }
        public DbSet<AppUser> Users { get; set; }
    }
}
