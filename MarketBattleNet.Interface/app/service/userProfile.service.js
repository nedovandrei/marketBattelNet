(function () {
    "use strict";

    angular.module("app")
        .factory("userProfileService", ["userProfileResource", function (userProfileResource) {
            var _userProfileService = {};

            _userProfileService.getAll = function (callback) {
                return userProfileResource.getAll(function (result) {
                    callback(result);
                }, function () {
                    console.log("userProfileService -> GetAll: couldn't get");
                });
            };

            _userProfileService.findById = function (id, callback) {
                return userProfileResource.findById({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("userProfileService -> findById: couldnt' get")
                });
            };

            _userProfileService.add = function (userProfileModel, callback) {
                return userProfileResource.add(userProfileModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("userProfileService -> add: error");
                });
            };

            _userProfileService.update = function (userProfileModel, callback) {
                return userProfileResource.update(userProfileModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("userProfileService -> update: error");
                });
            };

            _userProfileService.delete = function (id, callback) {
                return userProfileResource.delete({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("userProfileService -> delete: error");
                });
            };

            return _userProfileService;
        }]);
})();