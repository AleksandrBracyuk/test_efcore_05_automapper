using System;

namespace ConsoleApp1
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal? ValueDecimal { get; set; }
        public DateTime? ValueDateTime { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int MainId { get; set; }
        public Main Main { get; set; }

        public override string ToString()
        {
            return $"MainId:{MainId} CityId:{CityId} Id:{Id} Name:{Name} ValueDecimal:{ValueDecimal} ValueDateTime:{ValueDateTime} ValueInt:{ValueInt} ValueString:{ValueString}";
        }
    }
}
