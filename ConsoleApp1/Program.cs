using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Detail, DetailModel>());
            var mapper = config.CreateMapper();


            Console.WriteLine("Hello World!");

            using(DbContext db = new DbContext())
            {
                var details = db.Details.ToList();
                foreach (var detail in details)
                {
                    Console.WriteLine(detail);
                }

                Console.WriteLine("======old================================");
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
                foreach (var detailModel in target)
                {
                    Console.WriteLine(detailModel);
                }
                Console.WriteLine("=== new 1 ===================================");

                var target2 = new List<DetailModel>();
                foreach (var detail in details)
                {
                    var detailModel = mapper.Map<DetailModel>(detail);
                    target2.Add(detailModel);
                }
                  foreach (var detailModel in target)
                {
                    Console.WriteLine(detailModel);
                }
            }



            Console.ReadLine();
        }
    }
}
