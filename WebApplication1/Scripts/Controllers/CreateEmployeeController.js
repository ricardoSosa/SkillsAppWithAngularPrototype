var CreateEmployeeController = function ($scope, $routeParams, $location, EmployeeFactory) {
    $scope.employee = {
        name: "",
        returnUrl: $routeParams.returnUrl,
        creationFailure: false
    };

    $scope.create = function () {
        var result = EmployeeFactory($scope.employee.name);
        result.then(function (result) {
            if (result.success) {
                if ($scope.employee.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {

                    $location.path($scope.employee.returnUrl);
                }
            } else {
                $scope.employee.creationFailure = true;
            }
        });
    }
}

CreateEmployeeController.$inject = ['$scope', '$routeParams', '$location', 'EmployeeFactory'];