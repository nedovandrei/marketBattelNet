(function () {
    "use strict";

    angular.module("app")
        .controller("ArtController", [
            "$stateParams",
            "$scope",
            "artService",
            "shoppingCartService",
            "gameService",
            "$location",            
            "appSettings",
            function ($stateParams, $scope, artService, shoppingCartService, gameService, $location, appSettings) {
            
                $scope.art = {};                

                $scope.isInCart = false;

                $scope.back = function () {
                    if (!!$stateParams.fromUrl) {
                        $location.path($stateParams.fromUrl);
                    } else {
                        $location.path("#/shop");
                    }
                
                }

                $scope.putIntoCart = function () {
                    shoppingCartService.addToCart($scope.art);
                    isInCartCheck();
                }

                function changeBackground(fileName) {
                    if (fileName) {
                        $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                    } else {
                        $(".m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                    }
                }

                function loadArt() {
                    if (!!$stateParams.artId) {
                        artService.findById($stateParams.artId, function (result) {
                            $scope.art = result;
                            isInCartCheck();
                            gameService.findById($scope.art.GameId, function (result) {
                                changeBackground(result.BackgroundFileName)
                            });
                        });
                    }                
                }

                function isInCartCheck() {
                    var shoppingCart = [];
                    shoppingCartService.getAllPurchasedItems(function (result) {
                        shoppingCart = result;
                    });

                    for (var i = 0; i < shoppingCart.length; i++) {
                        if ($scope.art.Id == shoppingCart[i].Id) {
                            $scope.isInCart = true;
                        }
                    }
                }

                function init() {
                    loadArt();
                }

                init();
            }]);
}());