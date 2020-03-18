using System;
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
        private const int MaxItemsCount = 200;
        private readonly CarbonDbContext _dbContext;

        public CarbonController(CarbonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<MeasureItem> Get()
        {
            var count = _dbContext.MeasureItems.Count();
            if (count <= MaxItemsCount)
            {
                return _dbContext.MeasureItems.ToList();
            }
            else
            {
                var step = (int) Math.Ceiling((double) count / MaxItemsCount);
                return _dbContext.MeasureItems
                    .ToList()
                    .Select((x, i) => new {Item = x, Index = i})
                    .Where(x => x.Index % step == 0)
                    .Select(x => x.Item)
                    .ToList();
            }
        }

        [HttpPost]
        public void Post([FromBody] MeasureItem measureItem)
        {
            _dbContext.MeasureItems.Add(measureItem);
            _dbContext.SaveChanges();
        }
    }
}