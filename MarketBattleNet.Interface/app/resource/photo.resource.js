(function() {
    "use strict";

    angular.module("app")
        .factory("photoResource", function($resource, appSettings) {
            return $resource(appSettings.apiPath + "Photo",{
                'save': { method: "POST" },            
            });
        });
}());