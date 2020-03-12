using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Main> Mains { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DetailChild> DetailChilds { get; set; }

        public DbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=automapper;Username=test1;Password=test1;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country[]{
                    new Country{Id=1,Name="Ukraine"},
                    new Country{Id=2,Name="Russia"},
                    new Country{Id=3,Name="USA"} }
                    );

            modelBuilder.Entity<City>().HasData(
                new City[]{
                    new City(){CountryId=1, Id = 1, Name = "Kyiv"},
                    new City(){CountryId=1, Id = 2, Name = "Charkov"},
                    new City(){CountryId=1, Id = 3, Name = "Odessa"},
                    new City(){CountryId=2, Id = 4, Name = "Moscow"},
                    new City(){CountryId=2, Id = 5, Name = "StPetersburg"},
                    new City(){CountryId=3, Id = 6, Name = "Washington"},
                    new City(){CountryId=3, Id = 7, Name = "Los-Angeles"},
                    new City(){CountryId=3, Id = 8, Name = "New York"},
                });

            modelBuilder.Entity<Main>().HasData(
                new Main[] { 
                new Main(){Id=1, Name="Main-1"},
                new Main(){Id=2, Name="Main-2"},
                new Main(){Id=3, Name="Main-3"},
                });
            modelBuilder.Entity<Detail>().HasData(
                new Detail[]{
                    new Detail(){
                        MainId=1,
                        Id=1,
                        Name="Detail-1", 
                        ValueDecimal=10.12m, 
                        ValueDateTime=new DateTime(2000,1,1,0,0,0),
                        ValueInt=12,
                        ValueString="В лесу родилась ёлочка в лесу она росла",
                        CityId = 4
                    },
                    new Detail(){
                        MainId=1,
                        Id=2,
                        Name="Detail-2",
                        ValueDecimal=34.56m,
                        ValueDateTime=new DateTime(2010,1,1,0,0,0),
                        ValueInt=14,
                        ValueString="Зимой и летом стройная",
                        CityId = 4
                    },
                    new Detail(){
                        MainId=1,
                        Id=3,
                        Name="Detail-3",
                        ValueDecimal=78.9m,
                        ValueDateTime=new DateTime(2020,1,1,0,0,0),
                        ValueInt=16,
                        ValueString="Зеленая была",
                        CityId = 4
                    }
                });
            modelBuilder.Entity<DetailChild>().HasData(
                new DetailChild[] { 
                new DetailChild(){MainId=2,
                        Id=4,
                        Name="DetailChild-1",
                        ValueDecimal=11.2m,
                        ValueDateTime=new DateTime(2020,1,2,10,0,0),
                        ValueInt=18,
                        ValueString="Крокодилы-бегемоты и зеленый попугай",
                        CityId = 1,
                        ValueChildInt = 1
                        }
                });
        }
    }


}
