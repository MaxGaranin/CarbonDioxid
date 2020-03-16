using CarbonDioxide.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarbonDioxide.DataAccess
{
    public class CarbonDbContext : DbContext
    {
        public CarbonDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MeasureItem> MeasureItems { get; set; }
    }
}