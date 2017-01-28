(function () {
    "use strict";

    angular.module("app")
        .controller("SupportController", [
            "$scope",
            "appSettings",
            "$stateParams",
            function ($scope, appSettings, $stateParams) {

                $scope.accordeonValue = "";

                $scope.$watch("accordeonValue", function (newValue) {
                    console.log(newValue);
                    $stateParams.section = newValue;
                });

                function changeBackground(fileName) {
                    if (fileName) {
                        $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                    } else {
                        $(".m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                    }
                }

                function openAccordion(param) {
                    $scope.accordeonValue = param;                    
                }

                function init() {
                    changeBackground();
                    console.log("state param - section - ", $stateParams.section);
                    if ($stateParams.section !== "") {
                        openAccordion($stateParams.section);
                    }
                }

                init();
            }]);
}());