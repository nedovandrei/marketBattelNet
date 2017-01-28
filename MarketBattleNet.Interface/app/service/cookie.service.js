(function () {
    'use strict';

    angular.module("app")
        .factory("cookieService", ["$cookies", function ($cookies) {
            var _cookieService = {};

            _cookieService.getAll = function (callback) {
                callback($cookies.getAll);
            }

            _cookieService.create = function (key, value) {
                $cookies.put(key, value);
            };

            _cookieService.createObject = function (key, object) {
                $cookies.putObject(key, object);
            };

            _cookieService.get = function (key, callback) {
                callback($cookies.get(key));
            };

            _cookieService.getObject = function (key, callback) {
                callback($cookies.getObject(key));
            };

            _cookieService.removeKey = function (key, callback) {
                $cookies.remove(key);
                if (callback) {
                    callback();
                }
            };

            return _cookieService;
        }]);
}());