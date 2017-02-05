(function () {
    "use strict";

    angular.module("app")
        .controller("GameController", ["$scope", "gameService", "appSettings", "artService", "$location", function ($scope, gameService, appSettings, artService, $location) {
            $scope.gameList = [];
            $scope.artList = [];
            $scope.imagesPath = appSettings.imagesPath;

            $scope.currentUrl = $location.path();

            function init() {
                changeBackground();
                appSettings.loader.show();
                gameService.getAll(function (result) {
                    $scope.gameList = result;
                    artService.getAll(function(result) {
                        $scope.artList = result;
                        appSettings.loader.hide();
                    });
                });
                $(".center").slick({
                    autoplay: true,
                    autoplaySpeed: 5000,
                    infinite: true,
                    arrows: false
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