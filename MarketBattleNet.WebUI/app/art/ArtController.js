(function () {
    "use strict";

    angular.module("app")
        .controller("ArtController", ["$scope", function ($scope) {
            

            function changeBackground(fileName) {
                if (fileName) {
                    $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                } else {
                    $(".m_page").css("background-image", "url('" + appSettings.backgroundDefault + "')");
                }
            }
        }]);
}());