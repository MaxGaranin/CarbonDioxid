using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarbonDioxide.DataAccess
{
    public class CarbonDbContextFactory : IDesignTimeDbContextFactory<CarbonDbContext>
    {
        public CarbonDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarbonDbContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite(@"Data Source=Carbon.db");

            return new CarbonDbContext(optionsBuilder.Options);
        }
    }
}