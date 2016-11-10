(function () {
    "use strict";

    angular.module("app")
        .constant("appSettings", {
            apiPath: "http://localhost:7378/api/",
            loader: {
                show: function () {
                    $.loader({
                        className: "blue-with-image-2",
                        content: ''
                    });
                    console.log("loader started");
                },
                hide: function () {
                    $.loader('close');
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
                .state("purchase", {
                    url: "/purchase",
                    templateUrl: "app/purchase/purchase.html",
                    controller: "PurchaseController"
                })
                .state("art", {
                    url: "/art?artId&fromUrl",
                    templateUrl: "app/art/art.html",
                    controller: "ArtController"
                })
                .state("login", {
                    url: "/login",
                    templateUrl: "app/login/login.html",
                    controller: "LoginController"
                })
				.state("admin", {
                    url: "/admin",
				    templateUrl: "app/admin/admin.html",
                    controller: "AdminController"
				});            
        }]);
}());