using Carfinance.Phoenix.Kata.Angular.Models;
using Carfinance.Phoenix.Kata.Angular.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carfinance.Phoenix.Kata.Angular.Services
{
    public class BookingService : IBookingService
    {
        private static IList<Booking> bookings;

        public BookingService() : this(new DataService())
        {
        }

        public BookingService(IDataService dataService)
        {
            bookings = dataService.Initialize();
        }

        public IList<Booking> GetAllBookings(){

        
            return bookings;
        }

        public void CreateBooking(Booking booking)
        {


            if (booking == null)
                throw new ArgumentNullException();
        
            else if (booking.TableNumber >= 5 || booking.TableNumber <= 0 )
                    throw new ArgumentOutOfRangeException(string.Format("Table number {0} does not exist", booking.TableNumber));
  
                int Id = bookings.OrderByDescending(x => x.BookingId).Select(x => x.BookingId).FirstOrDefault();
                booking.BookingId = Id + 1;// increment booking ID
                bookings.Add(booking);

        }
    }

   
}