namespace Carfinance.Phoenix.Kata.Angular.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Carfinance.Phoenix.Kata.Angular.DAL.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Carfinance.Phoenix.Kata.Angular.DAL.RestaurantContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var bookings = new List<Booking>
                {

                    new Booking{ContactName="Nicole Taylor", BookingTime=DateTime.Parse("2017-06-25 11:30"),ContactNumber="07226374521",NumberOfPeople=10,TableNumber=4},
                    new Booking{ContactName= "Mark Quinn", BookingTime=DateTime.Parse("2017-06-25 14:00"),ContactNumber= "07826374821", NumberOfPeople=4,TableNumber=1},
                    new Booking{ContactName="Tom Sykes", BookingTime=DateTime.Parse("2017-06-25 15:00"),ContactNumber="07826374521",NumberOfPeople=3,TableNumber=2},
                    new Booking{ContactName="Callum Evans", BookingTime=DateTime.Parse("2017-06-25 16:00"),ContactNumber="07326372821",NumberOfPeople=1,TableNumber=3},
                    new Booking{ContactName="Henry Ho", BookingTime=DateTime.Parse("2017-06-25 21:00"),ContactNumber="07126124521",NumberOfPeople=7,TableNumber=1},
                    new Booking{ContactName="Stephen Baker", BookingTime=DateTime.Parse("2017-06-25 21:15"),ContactNumber="07826124521",NumberOfPeople=6,TableNumber=3}
                };

            bookings.ForEach(s => context.Bookings.Add(s));
            context.SaveChanges();
        }
    }
}
