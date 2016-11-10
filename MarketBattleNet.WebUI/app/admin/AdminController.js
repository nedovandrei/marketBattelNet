(function () {
    "use strict";

    angular.module("app")
        .controller("AdminController", ["$scope", "$rootScope", "$state", "gameService", "appSettings", function ($scope, $rootScope, $state, gameService, appSettings) {
            $scope.gameList = [];


            $scope.showFile = function(e) {
                var files = e.target.files;
                for (var i = 0, f; f = files[i]; i++) {
                    if (!f.type.match('image.*')) continue;
                    var fr = new FileReader();
                    fr.onload = (function (theFile) {
                        return function (e) {
                            var li = document.createElement('li');
                            li.innerHTML = "<img src='" + e.target.result + "' />";
                            document.getElementById('list').insertBefore(li, null);
                        };
                    })(f);

                    fr.readAsDataURL(f);
                }
            }

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
            }

            init();
        }]);
}());