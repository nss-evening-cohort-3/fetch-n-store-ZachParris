app.controller("FormController", function ($scope, $http) {
    $scope.httpMethod;
    $scope.url;
    $scope.returnedResponse = {};
    

    $scope.fetch = function () {
        var queryTime = Date.now();

        $http({
            method: $scope.httpMethod,
            url: $scope.url
        }).then(function success(response) {
            var responseTime = Date.now() - queryTime;
            $scope.returnedResponse.status = response.status,
            $scope.returnedResponse.url = $scope.url,
            $scope.returnedResponse.method = $scope.httpMethod,
            $scope.returnedResponse.time = responseTime
        }, function error(response) {
            console.log("Error", response);
        }
        )
    };

    $scope.showAll = function () {
        console.log("get");
        $http.get('/api/Response')
            .success(function (data) {
                $scope.returnedResponses = data;
                console.log(data);
        })
    }


    $scope.store = function () {
        var jsonData = JSON.stringify($scope.returnedResponse)
        $http.post('/api/Response', jsonData)
        .success(function () {
            console.log("works");
            $scope.showAll();
        })
    }

    $scope.DeleteResponse = function (id) {
        $http({
            url: `/api/response/${id}`,
            method: 'DELETE',

        }).success(response => {
            $scope.showAll();
        })
    }

    });