using System;
using System.IO;
using CarbonDioxide.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarbonDioxide.WebApi
{
    public class ConfigurationHelper
    {
        public static DbContextOptions<CarbonDbContext> GetDbContextOptions()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Hello {connectionString}");

            var builder = new DbContextOptionsBuilder<CarbonDbContext>();
            builder
                .UseLazyLoadingProxies()
                .UseSqlite(connectionString);

            return builder.Options;
        }
    }
}