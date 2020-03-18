using System;
using System.Collections.Generic;
using System.Linq;
using CarbonDioxide.DataAccess;
using CarbonDioxide.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarbonDioxide.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarbonController : ControllerBase
    {
        private const int MaxItemsCount = 200;

        static CarbonController()
        {
            using (var dbContext = GetDbContext())
            {
                dbContext.Database.Migrate();
            }
        }
        
        [HttpGet]
        public IEnumerable<MeasureItem> Get()
        {
            using (var dbContext = GetDbContext())
            {
                var count = dbContext.MeasureItems.Count();
                if (count <= MaxItemsCount)
                {
                    return dbContext.MeasureItems.ToList();
                }
                else
                {
                    var step = (int) Math.Ceiling((double) count / MaxItemsCount);
                    return dbContext.MeasureItems
                        .ToList()
                        .Select((x, i) => new { Item = x, Index = i})
                        .Where(x => x.Index % step == 0)
                        .Select(x => x.Item)
                        .ToList();
                }
            }
        }

        [HttpPost]
        public void Post([FromBody] MeasureItem measureItem)
        {
            using (var dbContext = GetDbContext())
            {
                dbContext.MeasureItems.Add(measureItem);
                dbContext.SaveChanges();
            }
        }

        private static CarbonDbContext GetDbContext()
        {
            var dbContext = new CarbonDbContext(ConfigurationHelper.GetDbContextOptions());
            return dbContext;
        }
    }
}