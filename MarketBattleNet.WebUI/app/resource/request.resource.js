(function () {
    "use strict";

    angular.module("app")
        .factory("requestResource", function ($resource, appSettings) {
            return $resource(appSettings.apiPath + "request/:id", { id: "@id" }, {
                'getAll': { method: "GET", isArray: true },
                'findById': { method: "GET" },
                'add': { method: "POST" },
                'update': { method: "UPDATE" },
                'delete': { method: "DELETE" },
                'addRange': { method: "POST" , url: appSettings.apiPath + "request/AddRange" }
            });
        });
})();