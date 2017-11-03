
(function () {
    'use strict';

    angular.module('PhoenixKata').controller('BookingController', BookingController);
    //$.Inject = ["BookingService"];
    function BookingController($http) {
        var vm = this;
        var dataService = $http;

        // Hook up public events

        vm.getBookings = getBookings;
        vm.bookings = [];
        vm.booking = {
            BookingId: 0,
            BookingTime: '',
            ContactNumber: '',
            ContactName: '',
            NumberOfPeople: '',
            TableNumber: 0

        };
        vm.createBooking = ceateBooking;
        vm.editBooking = editBooking;
        vm.showNewBookingForm = false;
        vm.displayBookingTable = true;

        function editBooking(Booking){

            // no need to implement it

        }

        function ceateBooking() {
            vm.showNewBookingForm = true;
            vm.displayBookingTable = false;

        }


        getBookings();
        
        //BookingService.getBookings();
        // get bookings
        function getBookings() {

            dataService.get("http://localhost:52363/booking")
            .then(function (result) {
                vm.bookings = result.data;
                }, function (error) {
                    handleException(error);
                });

        }

        
        
    }
})();