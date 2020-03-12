namespace ConsoleApp1
{
    public class DetailChild:Detail{
        public int? ValueChildInt { get; set; }

        public override string ToString()
        {
            var b = base.ToString();
            return b + $" ValueChildInt:{ValueChildInt}";
        }
    }
}
