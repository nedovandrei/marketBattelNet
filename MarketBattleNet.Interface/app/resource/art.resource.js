(function () {
    "use strict";

    angular.module("app")
        .factory("artResource", function ($resource, appSettings) {
            return $resource(appSettings.apiPath + "art/:id", { id: "@id" }, {
                'getAll': { method: "GET", isArray: true },
                'getAllExt': { method: "POST", url: appSettings.apiPath + "art/getAllExt", isArray: true },
                'findById': { method: "GET" },
                'add': { method: "POST" },
                'update': { method: "UPDATE" },
                'delete': { method: "DELETE" },
                'findByGameId': { method: "GET", url: appSettings.apiPath + "art/findByGameId/:id", isArray: true },
                'getCountByGameId': { method: "GET", url: appSettings.apiPath + "art/getCountByGameId/:id" }                                           
            });
        });
})();