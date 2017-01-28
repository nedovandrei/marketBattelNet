(function () {
    "use strict";

    angular.module("app")
        .controller("AdminContentTableController", [
            "$scope", "artService", "gameService", "appSettings", function ($scope, artService, gameService, appSettings) {

                $scope.imagesPath = appSettings.imagesPath;

                $scope.gameList = [];
                $scope.artList = [];

                $scope.deleteGame = function(id) {
                    appSettings.loader.show();
                    gameService.delete(id, function() {
                        init();

                    });
                }

                function loadArts() {
                    appSettings.loader.show();
                    artService.getAll(function(result) {
                        $scope.artList = result;
                        appSettings.loader.hide();
                    });
                }

                function loadGames() {
                    appSettings.loader.show();
                    gameService.getAll(function (result) {
                        $scope.gameList = result;
                        appSettings.loader.hide();
                    });
                }

                function init() {
                    loadArts();
                    loadGames();
                }



                init();
            }
        ]);
}());