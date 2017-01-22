(function() {
    "use strict";

    angular.module("app")
        .controller("AdminRequestTableController", [
            "$scope",
            "requestService",
            "artService",
            "gameService",
            "userProfileService",
            "appSettings",
            function($scope, requestService, artService, gameService, userProfileService, appSettings) {

                $scope.imagesPath = appSettings.imagesPath;

                $scope.requestList = [];

                $scope.completeRequest = function (id) {
                    appSettings.loader.show();
                    requestService.completeRequest({id: id}, function() {
                        init();
                    });
                }

                $scope.deleteRequest = function(id) {
                    appSettings.loader.show();
                    requestService.delete(id, function() {
                        init();
                    });
                }

                function init() {
                    appSettings.loader.show();

                    requestService.getAll(function(result) {
                        $scope.requestList = result;
                        appSettings.loader.hide();
                    });                   
                }

                init();
            }
        ]);
}());