(function () {
    "use strict";

    angular.module("app")
        .factory("gameService", ["gameResource", function (gameResource) {
            var _gameService = {};

            _gameService.getAll = function (callback) {
                return gameResource.getAll(function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> GetAll: couldn't get");
                });
            };

            _gameService.findById = function (id, callback) {
                return gameResource.findById({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> findById: couldnt' get")
                });
            };

            _gameService.add = function (gameModel, callback) {
                return gameResource.add(gameModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> add: error");
                });
            };

            _gameService.update = function (gameModel, callback) {
                return gameResource.update(gameModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> update: error");
                });
            };

            _gameService.delete = function (id, callback) {
                return gameResource.delete({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> delete: error");
                });
            };

            return _gameService;
        }]);
})();