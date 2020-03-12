using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Main
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Detail> Details { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} Name:{Name} Details:{Details?.Count}";
        }
    }
}
