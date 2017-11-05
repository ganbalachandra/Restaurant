(function () {

    angular.module('PhoenixKata')
        .factory('BookingService', ['$http', '$location', BookingService]);

    function BookingService($http, $location) {
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
        // create bookings
        function createBookings(booking) {
            dataService.post("http://localhost:52363/booking", booking)
                    .then(function (result) {
                        console.log(result);
                        window.location= "/INDEX.HTML"; 
                    }, function (error) {
                        //handleException(error);
                    });

        }
        //edit bookings
        function editBookings(booking) {
            dataService.put("http://localhost:52363/booking", booking)
            .then(function (result) {

            }, function (error) {
                //handleException(error);
            });

        }

    }

}());



