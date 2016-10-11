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
                        $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                    } else {
                        $(".m_page").css("background-image", "url('" + appSettings.backgroundDefault + "')");
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