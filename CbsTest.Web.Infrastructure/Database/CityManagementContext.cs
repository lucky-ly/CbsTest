using CbsTest.Web.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CbsTest.Web.Infrastructure.Database
{
    public class CityManagementContext : DbContext
    {
        public CityManagementContext(DbContextOptions<CityManagementContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>().HasKey(x => x.Id);
        }
    }
}
