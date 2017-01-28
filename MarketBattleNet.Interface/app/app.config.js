(function () {
    "use strict";

    angular.module("app")
        .constant("appSettings", {
            //imagesPath: "http://localhost:7378/Content/loaded_art/",
            imagesPath: "Content/loaded_art/",
            //apiPath: "http://localhost:7378/api/",
            apiPath: "api/",
            //apiPath: "http://hatebreeder666-001-site1.btempurl.com/api/",
            loader: {
                show: function () {
                    $.loader({
                        className: "blue-with-image-2",
                        content: ''
                    });
                },
                hide: function () {
                    $.loader('close');
                }
            },
            backgroundDefault: "../images/dota2.jpg"

        })
        .config(["$urlRouterProvider", "$stateProvider", function ($urlRouterProvider, $stateProvider) {
            $urlRouterProvider.otherwise("/game");

            $stateProvider
                .state("shop", {
                    url: "/shop/{gameId}",
                    templateUrl: "app/shop/shop.html",
                    controller: "ShopController"
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
                    controller: "ArtController2"
                })
                .state("login", {
                    url: "/login",
                    templateUrl: "app/login/login.html",
                    controller: "LoginController"
                })
                .state("support", {
                    url: "/support",
                    templateUrl: "app/support/support.html",
                    controller: "SupportController",
                    params: { section: "" }
                })
				.state("admin", {
				    url: "/admin",
				    templateUrl: "app/admin/admin.html",
				    controller: "AdminController"
				})
                    .state("admin.request-table", {
                        url: "/request-table",
                        templateUrl: "app/admin/request-table/admin.request-table.html",
                        controller: "AdminRequestTableController"
                    })
                    .state("admin.content-table", {
                        url: "/content-table",
                        templateUrl: "app/admin/content-table/admin.content-table.html",
                        controller: "AdminContentTableController"
                    })
                    .state("admin.content-manage", {
                        url: "/content-manage",
                        templateUrl: "app/admin/content-manage/admin.content-manage.html",
                        controller: "AdminContentManageController"
                });
        }]);


    angular.module("app").filter('toHtml', function () {
        return function (item) {
            return item.toUpperCase();
        };
    });
}());