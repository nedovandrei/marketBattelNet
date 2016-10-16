(function () {
    "use strict";

    angular.module("app")
        .constant("appSettings", {
            apiPath: "http://localhost:7378/api/",
            loader: {
                show: function () {
                    //kinda like loader
                    console.log("loader started");
                },
                hide: function () {
                    //there will once be a hideLoader here
                    console.log("loader ended");
                }
            },
            backgroundDefault: "../images/41101825-game-wallpapers.jpg"
            
        })
        .config(["$urlRouterProvider", "$stateProvider", function ($urlRouterProvider, $stateProvider) {
            $urlRouterProvider.otherwise("/game");
            $stateProvider
                .state("shop", {
                    url: "/shop/{gameId}",
                    templateUrl: "app/shop/shop.html",
                    controller: "ShopController",
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
                    url: "/art?artId",
                    templateUrl: "app/art/art.html",
                    controller: "ArtController"
                });
            
        }]);
}());