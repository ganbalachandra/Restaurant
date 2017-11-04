
(function () {
    'use strict';


    angular.module('PhoenixKata', ['ngMaterial']).controller('BookingController', ['BookingService', BookingController]);

    function BookingController(BookingService) {
        var vm = this;
 
        init();
      

        function init() {
            vm.createBooking = ceateBooking;
            vm.displayForm = displayForm;
            vm.getBookings = getBookings;
            vm.editBookings = editBookings;
            vm.bookings = [];
            vm.showNewBookingForm = false;
            vm.displayBookingTable = true;
            vm.showBookingButton = true;

            getBookings();

        }

        function displayForm(){
        
            vm.showNewBookingForm = true;
            vm.displayBookingTable = false;
            vm.showBookingButton = false;
        }

        //edit booking
        function editBookings(bookings) {
            BookingService.editBookings(booking);


        }
        // create bookings
        function ceateBooking() {
            console.log("create booking");
          

            vm.booking = {
                BookingId: 0,
                BookingTime: vm.bookingTime,
                ContactNumber: vm.contactNumber,
                ContactName: vm.contactName,
                NumberOfPeople: vm.numberOfPeople,
                TableNumber: vm.tableNumber
            };
            BookingService.createBookings(vm.booking);
 
        }
        // get bookings
        function getBookings() {

            BookingService.getBookings().then(function (result) {

                vm.bookings = result;
            });

        }  
        
    }
})();