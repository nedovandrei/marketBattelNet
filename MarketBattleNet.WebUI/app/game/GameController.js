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
                    $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                } else {
                    $(".m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                }
            }

            init();
        }]);
}());