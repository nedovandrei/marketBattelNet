(function () {
    "use strict";

    angular.module("app")
        .factory("artService", ["$timeout", "artResource", function ($timeout, artResource) {
            var _artService = {};

            _artService.getAll = function (callback) {
                return artResource.getAll(function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> GetAll: couldn't get");
                });
            };

            _artService.getAllExt = function(data, callback) {
                return artResource.getAllExt(data, function(result) {
                    callback(result);
                }, function() {
                    console.log("artService -> getAllExt: error");
                });
            }

            _artService.findById = function (id, callback) {
                return artResource.findById({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> findById: couldnt' get");
                });
            };

            _artService.add = function (artModel, callback) {
                return artResource.add(artModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> add: error");
                });
            };

            _artService.update = function (artModel, callback) {
                return artResource.update(artModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> update: error");
                });
            };

            _artService.delete = function (id, callback) {
                return artResource.delete({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> delete: error");
                });
            };

            _artService.findByGameId = function (id, callback) {
                return artResource.findByGameId({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> findByGameId: error");
                });
            }

            _artService.getCountByGameId = function(id, callback) {
                return artResource.getCountByGameId({ id: id }, function (result) {
                    callback(result);
                }, function() {
                    console.log("artService -> getCountByGameId: error");
                });
            }           
            return _artService;
        }]);
})();