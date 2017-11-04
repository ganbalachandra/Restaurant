(function () {

    angular.module('PhoenixKata')
        .factory('BookingService', ['$http',BookingService]);

    function BookingService($http) {
        var dataService = $http;

        return {
            getBookings: getBookings,
            createBookings: createBookings,
            editBookings:editBookings
        
        };

        // get bookings
        function getBookings() {

           return dataService.get("http://localhost:52363/booking")
            .then(function (result) {
                return result.data;
            }, function (error) {
                handleException(error);
            });

        }
        function createBookings(booking) {
            dataService.post("http://localhost:52363/booking", booking)
                    .then(function (result) {
                        console.log(result);
                        window.location = "/INDEX.HTML"; // use $location
                    }, function (error) {
                        //handleException(error);
                    });

        }
        function editBookings(booking) {
            dataService.put("http://localhost:52363/booking", booking)
            .then(function (result) {

            }, function (error) {
                //handleException(error);
            });

        }


    }

}());



