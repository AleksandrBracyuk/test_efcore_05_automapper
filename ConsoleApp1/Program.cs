using System;
using System.Collections.Generic;
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

                Console.WriteLine("======================================");

                var target = new List<DetailModel>();
                foreach (var detail in details)
                {
                    var detailModel = new DetailModel
                    {
                        Id = detail.Id,
                        Name = detail.Name,
                        ValueDecimal = detail.ValueDecimal,
                        ValueDateTime = detail.ValueDateTime,
                        ValueInt = detail.ValueInt,
                        ValueString = detail.ValueString,
                        CityId = detail.CityId,
                        City = detail.City,
                        MainId = detail.MainId,
                        Main = detail.Main
                    };
                    target.Add(detailModel);
                }

                Console.WriteLine("======================================");

                foreach (var detailModel in target)
                {
                    Console.WriteLine(detailModel);
                }
                Console.WriteLine("======================================");
            }



            Console.ReadLine();
        }
    }
}
