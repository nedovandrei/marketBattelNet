(function () {
    "use strict";

    angular.module("app")
        .config(["$urlRouterProvider", "$stateProvider", function ($urlRouterProvider, $stateProvider) {
            $urlRouterProvider.otherwise("/");
            $stateProvider
                .state("Home", {
                    url: "/",
                    templateUrl: "app/home/home.html",
                    controller: "HomeController"
                });
        }]);
}());