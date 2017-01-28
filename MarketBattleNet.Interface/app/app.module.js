(function () {
    "use strict";

    angular.module('myFilters', [])
    .filter('keys', function () {
        return function (input) {
            if (!input) {
                return [];
            }
            return Object.keys(input);
        }
    });

    angular.module("app", [
        "ui.router",
        "ngResource",
        "ngAnimate",
        "ngSanitize",
        "ngCookies",
        "toaster",
        "myFilters"
    ]);


}());