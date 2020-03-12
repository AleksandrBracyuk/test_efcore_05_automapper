using System.Collections.Generic;

namespace ConsoleApp1
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CityModel> Cities { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} Name:{Name}";
        }
    }
}
