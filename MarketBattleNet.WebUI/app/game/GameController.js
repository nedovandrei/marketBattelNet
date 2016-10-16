(function () {
    "use strict";

    angular.module("app")
        .controller("GameController", ["$scope", "gameService", "appSettings", function ($scope, gameService, appSettings) {
            $scope.gameList = [];

            function init() {
                changeBackground();
                appSettings.loader.show();
                gameService.getAll(function (result) {
                    $scope.gameList = result;
                    appSettings.loader.hide();
                });
            }

            function changeBackground(fileName) {
                if (fileName) {
                    $("img.background_image").attr("src", "../images/" + fileName);
                } else {
                    $("img.background_image").attr("src", "../images/" + appSettings.backgroundDefault);
                }
            }

            init();
        }]);
}());