using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public override string ToString()
        {
            var cities = string.Join<City>(",", Cities);
            return $"Id:{Id} Name:{Name} Cities:{cities}";
        }
    }
}
