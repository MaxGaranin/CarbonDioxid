using System;

namespace CarbonDioxide.Model.Entities
{
    public class MeasureItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double CO2 { get; set; }
    }
}