using System.Collections.Generic;
using System.Linq;
using CarbonDioxide.DataAccess;
using CarbonDioxide.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarbonDioxide.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarbonController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MeasureItem> Get()
        {
            using (var dbContext = GetDbContext())
            {
                return dbContext.MeasureItems.ToList();                
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