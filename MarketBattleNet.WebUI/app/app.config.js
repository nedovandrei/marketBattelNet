(function () {
    "use strict";

    angular.module("app")
        .constant("appSettings", {
            "apiPath": "http://localhost:7378/api/"
        })
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
                })
                .state("market", {
                    url: "/market",
                    templateUrl: "app/market/market.html",
                    controller: "MarketController"
                })
                .state("art", {
                    url: "/art",
                    templateUrl: "app/art/art.html",
                    controller: "ArtController"
                });
            
        }]);
}());