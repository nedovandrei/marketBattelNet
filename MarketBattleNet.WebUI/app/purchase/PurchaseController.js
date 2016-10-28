(function () {
    "use strict";

    angular.module("app")
        .controller("PurchaseController", [
            "shoppingCartService",
            "requestService",
            "$scope",
            "$location",
            "appSettings",
            function (shoppingCartService, requestService, $scope, $location, appSettings) {
                $scope.purchases = [];
                $scope.currentUrl = $location.path();
                $scope.totalPrice = 0.00;

                function changeBackground(fileName) {
                    if (fileName) {
                        $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                    } else {
                        $(".m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                    }
                }

                function calculateTotalPrice() {
                    for (var i = 0; i < $scope.purchases.length; i++) {
                        $scope.totalPrice += $scope.purchases[i].Price;
                    }
                }

                function init() {
                    

                    shoppingCartService.getAllPurchasedItems(function (result) {
                        $scope.purchases = result;
                        calculateTotalPrice();
                        changeBackground();
                    });
                }

                init();
            }]);
}());