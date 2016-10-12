(function () {
    "use strict";

    angular.module("app")
        .controller("ArtController", ["$stateParams", "$scope", "artService", function ($stateParams, $scope, artService) {
            
            $scope.art = {};
            $scope.backUrl = $stateParams.fromUrl;
            $scope.back = function () {
                window.history.back();
            }

            function changeBackground(fileName) {
                if (fileName) {
                    $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                } else {
                    $(".m_page").css("background-image", "url('" + appSettings.backgroundDefault + "')");
                }
            }

            function loadArt(){
                artService.findById($stateParams.artId, function (result) {
                    $scope.art = result;
                });
            }

            function init() {
                loadArt();
            }

            init();
        }]);
}());