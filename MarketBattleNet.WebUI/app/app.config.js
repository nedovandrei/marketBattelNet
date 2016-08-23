(function () {
    "use strict";

    angular.module("app")
        .config(["$urlRouterProvider", "$stateProvider", function ($urlRouterProvider, $stateProvider) {
            $urlRouterProvider.otherwise("/shop");
            $stateProvider
                .state("shop", {
                    url: "/shop",
                    templateUrl: "app/shop/shop.html",
                    controller: "ShopController"
                })
                .state("game", {
                    url: "/game",
                    templateUrl: "app/game/game.html",
                    controller: "GameController"
                });
                //.state("art", {
                //    url: "/",
                //    templateUrl: "app/art/art.html",
                //    controller: "ArtController"
                //});
            
        }]);
}());