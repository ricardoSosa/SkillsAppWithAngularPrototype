var ReadController = function ($scope, $routeParams, $location) {
    $scope.project = {
        name: ""
    };

    $scope.employee = {
        name: ""
    };

    $scope.skill = {
        name: ""
    };
}

ReadController.$inject = ['$scope', '$routeParams', '$location'];