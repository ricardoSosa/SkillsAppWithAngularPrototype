var DeleteController = function ($scope, $routeParams, $location, DeletionFactory) {
    $scope.element = {
        name: "",
        returnUrl: $routeParams.returnUrl,
        deletionFailure: false
    };

    $scope.delete = function () {
        var result = DeletionFactory($scope.element.name);
        result.then(function (result) {
            if (result.success) {
                if ($scope.element.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {
                    $location.path($scope.element.returnUrl);
                }
            } else {
                $scope.element.deletionFailure = true;
            }
        });
    }
}

DeleteController.$inject = ['$scope', '$routeParams', '$location', 'DeletionFactory'];