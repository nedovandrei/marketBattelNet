(function() {
    "use strict";

    angular.module("app")
        .factory("loginService", ["loginResource", function(loginResource) {
            var _loginService = {};

            _loginService.login = function(loginObject, callback) {
                return loginResource.login(loginObject, function(result) {
                    callback(true);
                }, function () {
                    console.log("loginService -> login; error");
                    callback(false);
                });
            };

            return _loginService;
        }]);
}());