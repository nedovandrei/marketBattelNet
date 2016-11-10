(function() {
    "use strict";

    angular.module("app")
        .factory("loginResource", function($resource, appSettings) {
            return $resource(appSettings.apiPath + "login/", null, {
                'login': { method: "POST" }
            });
        });
}());