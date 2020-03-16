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
        private readonly CarbonDbContext _dbContext;
        
        public CarbonController()
        {
            _dbContext = new CarbonDbContext(ConfigurationHelper.GetDbContextOptions());
        }
        
        [HttpGet]
        public IEnumerable<MeasureItem> Get()
        {
            return _dbContext.MeasureItems.ToList();
        }
    }
}