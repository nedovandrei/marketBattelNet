(function () {
    "use strict";

    angular.module("app")
        .controller("AdminController", ["$scope", "$rootScope", "$state", "gameService", "appSettings", function ($scope, $rootScope, $state, gameService, appSettings) {            


            

            //document.getElementById('files').addEventListener('change', showFile, false);

            function changeBackground(fileName) {
                if (fileName) {
                    $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                } else {
                    $("m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                }
            }

            function init() {
                if (!$rootScope.adminAuthorized) {
                    $state.go("login");
                }
                changeBackground();
            }

            init();
        }]);
}());