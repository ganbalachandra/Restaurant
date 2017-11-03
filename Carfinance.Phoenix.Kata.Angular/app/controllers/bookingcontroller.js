
(function () {
    'use strict';

    angular.module('PhoenixKata').controller('BookingController', BookingController);

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
        getBookings();
        vm.orderByDate = new Date().getDate();
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