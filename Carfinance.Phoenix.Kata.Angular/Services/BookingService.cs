using Carfinance.Phoenix.Kata.Angular.Models;
using Carfinance.Phoenix.Kata.Angular.Repository;
using Carfinance.Phoenix.Kata.Angular.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carfinance.Phoenix.Kata.Angular.Services
{

    /// <summary>
    /// some code is there not break the tests
    /// </summary>
    public class BookingService : IBookingService
    {
        private static IList<Booking> bookings;
        private readonly RestaurantRepository _context;

        public BookingService(RestaurantRepository context)
        {
            _context = context;
        }

        public BookingService():this(new RestaurantRepository())
        {
            
        }
        public BookingService(IDataService dataService)
        {
            _context = new RestaurantRepository();
            bookings = dataService.Initialize();
        }

        public IList<Booking> GetAllBookings(){

            bookings=_context.All().ToList();
            return bookings;
        }

        public void CreateBooking(Booking booking)
        {


            if (booking == null)
                throw new ArgumentNullException();
        
            else if (booking.TableNumber >= 5 || booking.TableNumber <= 0 )
                    throw new ArgumentOutOfRangeException(string.Format("Table number {0} does not exist", booking.TableNumber));
            if (booking.BookingId > 0)
            {
               
                _context.Update(booking);

            }
            else
            {
                
                _context.Insert(booking);
            }
       

        }
    }

   
}