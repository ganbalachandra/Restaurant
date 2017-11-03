(function () {
    'use strict';

    angular.module('PhoenixKata').factory('BookingService',

    function BookingService($http) {
        var vm = this;
        var dataService = $http;


        // get bookings
        function getBookings() {

            return dataService.get("http://localhost:52363/booking")
            .then(function (result) {
                vm.bookings = result.data;
            }, function (error) {
                handleException(error);
            });

        }



    });
})();

