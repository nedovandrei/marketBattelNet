(function () {
    "use strict";

    angular.module("app")
        .factory("requestService", ["requestResource", function (requestResource) {
            var _requestService = {};

            _requestService.getAll = function (callback) {
                return requestResource.getAll(function (result) {
                    callback(result);
                }, function () {
                    console.log("requestService -> GetAll: couldn't get");
                });
            };

            _requestService.findById = function (id, callback) {
                return requestResource.findById({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("requestService -> findById: couldnt' get")
                });
            };

            _requestService.add = function (requestModel, callback) {
                return requestResource.add(requestModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("requestService -> add: error");
                });
            };

            _requestService.update = function (requestModel, callback) {
                return requestResource.update(requestModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("requestService -> update: error");
                });
            };

            _requestService.delete = function (id, callback) {
                return requestResource.delete({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("requestService -> delete: error");
                });
            };

            return _requestService;
        }]);
})();