
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Carfinance.Phoenix.Kata.Angular.Models;
using Carfinance.Phoenix.Kata.Angular.DAL.Mappings;

namespace Carfinance.Phoenix.Kata.Angular.DAL
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext()
            : base("Name=RestaurantContext")
        {
        }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookingMap());


        }
    }
}