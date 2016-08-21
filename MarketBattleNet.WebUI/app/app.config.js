(function () {
    "use strict";

    angular.module("app")
        .config(["$urlRouterProvider", "$stateProvider", function ($urlRouterProvider, $stateProvider) {
            $urlRouterProvider.otherwise("/");
            $stateProvider
                .state("Shop", {
                    url: "/",
                    templateUrl: "app/shop/game.html",
                    controller: "ShopController"
                })
                .state("Game", {
                    url: "/",
                    templateUrl: "app/game/game.html",
                    controller: "GameController"
                })
                .state("Art", {
                    url: "/",
                    templateUrl: "app/art/art.html",
                    controller: "ArtController"
                })
            ;
        }]);
}());