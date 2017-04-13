var UpdateController = function ($scope, $routeParams, $location, UpdateFactory) {
    $scope.element = {
        name: "",
        parent: "",
        returnUrl: $routeParams.returnUrl,
        updatingFailure: false
    };

    $scope.update = function () {
        var result = UpdateFactory($scope.element.name, $scope.element.parent);
        result.then(function (result) {
            if (result.success) {
                if ($scope.element.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {
                    $location.path($scope.element.returnUrl);
                }
            } else {
                $scope.element.updatingFailure = true;
            }
        });
    }
}

UpdateController.$inject = ['$scope', '$routeParams', '$location', 'UpdateFactory'];