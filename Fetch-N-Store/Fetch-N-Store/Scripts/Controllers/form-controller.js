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
            console.log(response);
            console.log($scope.returnedResponse);
            var responseTime = queryTime - Date.now();
                $scope.returnedResponse.status = response.status,
                $scope.returnedResponse.url = $scope.url,
                $scope.returnedResponse.method = $scope.httpMethod,
                $scope.returnedResponse.time = responseTime
                console.log($scope.returnedResponse);

            }, function error(response) {
                console.log("Error", response);
            }
        )
    };

    $scope.store = function () {
        $http({
            method: 'POST',
            url: $scope.url
        }).then(function success(post) {
            console.log("Posted Successfully", post);
        })
    }
    });