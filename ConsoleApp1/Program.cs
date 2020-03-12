using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using(DbContext db = new DbContext())
            {
                var details = db.Details.ToList();
                foreach (var detail in details)
                {
                    Console.WriteLine(detail);
                }
            }



            Console.ReadLine();
        }
    }
}
