var CreateSkillController = function ($scope, $routeParams, $location, SkillFactory) {
    $scope.skill = {
        name: "",
        returnUrl: $routeParams.returnUrl,
        creationFailure: false
    };

    $scope.create = function () {
        var result = SkillFactory($scope.skill.name);
        result.then(function (result) {
            if (result.success) {
                if ($scope.skill.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {

                    $location.path($scope.skill.returnUrl);
                }
            } else {
                $scope.skill.creationFailure = true;
            }
        });
    }
}

CreateSkillController.$inject = ['$scope', '$routeParams', '$location', 'SkillFactory'];