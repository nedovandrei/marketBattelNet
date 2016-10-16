(function () {
    "use strict";

    angular.module("app")
        .controller("ShopController", [
            "artService",
            "gameService",
            "$scope",
            "$stateParams",
            "appSettings",
            function (artService, gameService, $scope, $stateParams, appSettings) {
                
                function changeBackground (fileName) {
                    if (fileName) {
                        $("img.background_image").attr("src", "../images/" + fileName);
                    } else {
                        $("img.background_image").attr("src", "../images/" + appSettings.backgroundDefault);
                    }                    
                }

                $scope.artList = [];
                $scope.gameInFocus = {}

                function loadArt() {
                    if ($stateParams.gameId) {
                        gameService.findById($stateParams.gameId, function (result) {
                            $scope.gameInFocus = result;
                            changeBackground($scope.gameInFocus.BackgroundFileName);
                        });
                        artService.findByGameId($stateParams.gameId, function (result) {
                            $scope.artList = result;
                        });
                        
                    } else {
                        artService.getAll(function (result) {
                            $scope.artList = result;
                        })
                    }
                };

                function init() {
                    loadArt();
                };

                init();
            }
        ]);
}());