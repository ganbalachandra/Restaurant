
(function () {
    'use strict';


    angular.module('PhoenixKata', ['ngMaterial', 'ui.bootstrap.datetimepicker']).controller('BookingController', ['BookingService', BookingController]);

    function BookingController(BookingService) {
        var vm = this;
 
        init();
      
        // init prop
        function init() {
            vm.createBooking = ceateBooking;
            vm.displayForm = displayForm;
            vm.getBookings = getBookings;
            vm.editBookingDisplay = editBookingDisplay;
            vm.bookings = [];
            vm.showNewBookingForm = false;
            vm.displayBookingTable = true;
            vm.showBookingButton = true;

            getBookings();

        }

        function displayForm(){
            vm.formTitle = "Create Booking";
            vm.showNewBookingForm = true;
            vm.displayBookingTable = false;
            vm.showBookingButton = false;
        }

        //edit booking
        function editBookingDisplay(booking) {
            displayForm();
            vm.formTitle = "Edit Booking";
            vm.bookingId = booking.bookingId;
            vm.bookingTime= booking.bookingTime;
            vm.contactNumber = booking.contactNumber;
            vm.contactName = booking.contactName;
            vm.numberOfPeople = booking.numberOfPeople;
            vm.tableNumber = booking.tableNumber;

        }


        // create bookings
        function ceateBooking() {
           
            
            var bookingId = 0;
            if (vm.bookingId > 0)
                bookingId = vm.bookingId;
        
            vm.booking = {
                BookingId: bookingId,
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