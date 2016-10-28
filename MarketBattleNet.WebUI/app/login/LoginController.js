(function () {
    "use strict";

    angular.module("app")
        .controller("LoginController", ["$scope", "loginService", "appSettings", function ($scope, loginService, appSettings) {
            $scope.gameList = [];

            function init() {
                changeBackground();
                appSettings.loader.show();
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