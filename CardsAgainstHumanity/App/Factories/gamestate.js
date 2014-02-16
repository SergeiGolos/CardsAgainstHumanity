'use strict'


    var app = angular.module("randoHome");
    app.factory("gamestate", ["$http", function ($http) {
        function _get() {
            return $http.get("/api/Game/GetState");
        }

        return { get: _get };
    }]);