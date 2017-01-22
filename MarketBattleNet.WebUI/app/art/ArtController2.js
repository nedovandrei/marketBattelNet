(function () {
    "use strict";

    angular.module("app")
        .controller("ArtController2", [
            "$stateParams",
            "$scope",
            "artService",
            "shoppingCartService",
            "gameService",
            "$location",
            "appSettings",
            function ($stateParams, $scope, artService, shoppingCartService, gameService, $location, appSettings) {
                $scope.imagesPath = appSettings.imagesPath;

                $scope.art = {
                    TShirtSex: "M",
                    TShirtSize: "M"
                };                

                $scope.isInCart = false;

                $scope.photoInScope = "";

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

                $scope.changeTShirtSize = function(size) {
                    $scope.art.TShirtSize = size;
                    console.log("tshirtSize: " + size);
                }

                $scope.changeTShirtSex = function(sex) {
                    $scope.art.TShirtSex = sex;
                    console.log("tshirtSex: " + sex);
                }

                $scope.changeColour = function(colour) {
                    $scope.art.Colour = colour;
                    console.log("tshirtColour: " + colour);
                }

                $scope.changePhotoInScope = function(fileName) {
                    $scope.photoInScope = fileName;
                }

                function changeBackground(fileName) {
                    if (!!fileName) {
                        $(".m_page").css("background-image", "url('" + appSettings.imagesPath + fileName + "')");
                    } else {
                        $(".m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                    }
                }

                function loadArt() {
                    if (!!$stateParams.artId) {
                        artService.findById($stateParams.artId, function (result) {
                            $scope.art = result;
                            $scope.art.TShirtSex = "M";
                            $scope.art.TShirtSize = "M";
                            $scope.art.Colour = "black";
                            console.log($scope.art);
                            isInCartCheck();
                            $scope.photoInScope = $scope.art.LargeFileName;
                            gameService.findById($scope.art.GameId, function (result) {
                                changeBackground(result.BackgroundFileName);
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
                        if ($scope.art.Id === shoppingCart[i].Id) {
                            $scope.isInCart = true;
                        }
                    }
                }

                function init() {                    
                    console.log("ArtController initialized");
                    loadArt();
                }

                init();
            }]);
}());