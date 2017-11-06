using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Carfinance.Phoenix.Kata.Angular.Services.Interfaces;
using Carfinance.Phoenix.Kata.Angular.Services;
using System.Collections.Generic;
using Moq;
using Carfinance.Phoenix.Kata.Angular.Models;
using Carfinance.Phoenix.Kata.Angular.DAL;
using System.Data.Entity;
using Carfinance.Phoenix.Kata.Angular.Repository;
using System.Data.Entity.Infrastructure;
using System.Data.Common;

namespace Carfinance.Phoenix.Kata.Angular.Tests
{
    [TestClass]
    public class BookingServiceTests
    {
        private IBookingService bookingService;
        private Mock<IDataService> dataServiceMock;
        private IList<Booking> bookings;

        private  RestaurantContext _ctx;
        private BaseRepository<Booking> _bookingRepository;
        private List<Booking> _bookings;

        [TestInitialize]
        public void Initialize()
        {

         
            bookings = new List<Booking>
            {
                new Booking { BookingId = 1 },
                new Booking { BookingId = 19 },
                new Booking { BookingId = 7 },
                new Booking { BookingId = 5 }
            };
            //var mockSet = new Mock<DbSet<Booking>>();
            //var mockContext = new Mock<RestaurantContext>();
            //mockContext.Setup(m => m.Bookings).Returns(mockSet.Object);

            //var mockRepo = new Mock<RestaurantRepository>(mockContext);

            //var bookingService = new BookingService(mockRepo.Object);


            dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(d => d.Initialize()).Returns(bookings);

            bookingService = new BookingService(dataServiceMock.Object);
        }

        [TestCleanup]

        #region Create
      
        [TestMethod]
        public void CreateBooking_NullBooking_ThrowsArgumentNullException()
        {            
            Assert.ThrowsException<ArgumentNullException>(() => bookingService.CreateBooking(null));
        }

        [TestMethod]
        public void CreateBooking_InvalidTableNumber_Zero_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = 0
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookingService.CreateBooking(booking));
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateBooking_InvalidTableNumber_NegativeNumber_ThrowsArgumentOutOfRangeException()
        {
           

                var booking = new Booking
                {
                    TableNumber = -1
                };

                Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookingService.CreateBooking(booking));

        }

        [TestMethod]
        public void CreateBooking_InvalidTableNumber_TooHigh_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = 5
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookingService.CreateBooking(booking));
        }

        [TestMethod]
        public void CreateBooking_InvalidTableNumber_TooHigh_ThrowsArgumentOutOfRangeExceptionWithMessage()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = 5
            };

            ArgumentOutOfRangeException exception = null;

            try
            {
                bookingService.CreateBooking(booking);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Table number 5 does not exist"));
        }

        [TestMethod]
        public void CreateBooking_InvalidTableNumber_TooLow_ThrowsArgumentOutOfRangeExceptionWithMessage()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = -2
            };

            ArgumentOutOfRangeException exception = null;

            // Act
            try
            {
                bookingService.CreateBooking(booking);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Table number -2 does not exist"));
        }

        [TestMethod]
        public void CreateBooking_Valid_BookingAddedToBookings()
        {
            // Arrange
            var booking = new Booking()
            {
                ContactName = "Banana",
                TableNumber = 1,
                BookingTime = DateTime.Parse("2017-06-25 11:30"),
                ContactNumber = "07226374521",
                NumberOfPeople = 10,
               

            };

            var context = new RestaurantContext();
            var repo = new RestaurantRepository();
            var bookingService = new BookingService(repo);

            var count = bookingService.GetAllBookings().Count;
            // Act
            bookingService.CreateBooking(booking);

            // Assert
            //Assert.AreEqual(count+1, bookingService.GetAllBookings().Count);
            Assert.AreEqual(5, bookingService.GetAllBookings().Count);

        }

        [TestMethod]
        public void CreateBooking_Valid_BookingIdIncrementsMaxId()
        {
            // Arrange
            var booking = new Booking()
            {
                ContactName = "Banana",
                TableNumber = 1,
                BookingTime = DateTime.Parse("2017-06-25 11:30"),
                ContactNumber = "07226374521",
                NumberOfPeople = 10,

            };



            var context = new RestaurantContext();
            var repo = new RestaurantRepository();
            var bookingService = new BookingService(repo);

            // Act
            bookingService.CreateBooking(booking);

            // Assert
            Assert.AreEqual(5, bookingService.GetAllBookings().Count);
            Assert.AreEqual(20, bookingService.GetAllBookings()[4].BookingId);
        }

        #endregion Create        
    }
}
