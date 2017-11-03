
(function () {
    'use strict';


    angular.module('PhoenixKata', ['ngMaterial']).controller('BookingController', BookingController);
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
        vm.displayForm = displayForm;
        vm.showNewBookingForm = false;
        vm.displayBookingTable = true;
        vm.showBookingButton = true;


        function editBooking(Booking){
            dataService.post("http://localhost:52363/booking")
         .then(function (result) {
            
         }, function (error) {
             //handleException(error);
         });


        }

        function displayForm(){
        
            vm.showNewBookingForm = true;
            vm.displayBookingTable = false;
            vm.showBookingButton = false;
        }

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
            dataService.post("http://localhost:52363/booking", vm.booking)
                    .then(function (result) {
                        console.log(result);
                        window.location = "/INDEX.HTML"; // use $location
                        }, function (error) {
                                //handleException(error);
                        });
        }


        getBookings();
        
        //BookingService.getBookings();
        // get bookings
        function getBookings() {

            dataService.get("http://localhost:52363/booking")
            .then(function (result) {
                vm.bookings = result.data;
                }, function (error) {
                    //handleException(error);
                });

        }  
        
    }
})();