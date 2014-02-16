var app = angular.module("randoHome");

app.controller("game", ["$scope", "gamestate", function ($scope, gamestate) {
    $scope.draw = function() {
        gamestate.get().then(function(e) {
            $scope.state = e.data;
        });
    };       
}]);

