namespace ConsoleApp1
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public CountryModel Country { get; set; }

        public override string ToString()
        {
            return $"CountryId:{CountryId} Id:{Id} Name:{Name}";
        }
    }
}
