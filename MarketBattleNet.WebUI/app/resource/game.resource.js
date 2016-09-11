(function () {
    "use strict";

    angular.module("app")
        .factory("gameResource", function ($resource, appSettings) {
            return $resource(appSettings.apiPath + "game/:id", { id: "@id" }, {
                'getAll': { method: "GET", isArray: true },
                'findById': { method: "GET" },
                'add': { method: "POST" },
                'update': { method: "UPDATE" },
                'delete': { method: "DELETE" }
            });
        });
})();