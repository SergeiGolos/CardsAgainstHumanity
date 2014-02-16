var app = angular.module("randoHome");

app.controller("chrome", ["$scope", "gamestate", "$interval", function ($scope, gamestate, $interval) {
    var timer = 10000;
    var count = 0;
    $interval(function () {
        gamestate.get().then(function(e) {
            $scope.state = e.data;
            count = 0;
        });
    }, timer);
    
    $interval(function () {
        $scope.count = (timer / 1000) - count;
        count++;
    }, 1000);
      
}]);

