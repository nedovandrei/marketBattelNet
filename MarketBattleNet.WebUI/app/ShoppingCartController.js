(function () {
    'use strict';

    angular.module("app")
        .controller("ShoppingCartController", ["shoppingCartService", "cookieService", "$scope", "$rootScope", "appSettings", function (shoppingCartService, cookieService, $scope, $rootScope, appSettings) {

            //public members
            $scope.purchasedItemsLocal = [];

            $scope.imagesPath = appSettings.imagesPath;

            $rootScope.$watch("purchasedItems", function () {
                shoppingCartService.getAllPurchasedItems(function (result) {
                    $scope.purchasedItemsLocal = result;
                });
            });

            //pure js code by Andrew
            $scope.showDropdown = function () {
                document.getElementById("myDropdown").classList.toggle("show");
            }

            // Close the dropdown menu if the user clicks outside of it
            window.onclick = function (event) {
                if (!event.target.matches('.dropbtn')) {

                    var dropdowns = document.getElementsByClassName("dropdown-content");
                    var i;
                    for (i = 0; i < dropdowns.length; i++) {
                        var openDropdown = dropdowns[i];
                        if (openDropdown.classList.contains('show')) {
                            openDropdown.classList.remove('show');
                        }
                    }
                }
            }

            $scope.removeItem = function (item) {
                shoppingCartService.removeFromCart(item.Id);
            }

            $scope.changeLanguage = function (language) {
                cookieService.removeKey('language');
                $rootScope.language = language;
                cookieService.create('language', language);
                console.log(language);
            }


            //private members


            function init() {
                var language = null;
                cookieService.get('language', function(result) {
                    if (!angular.isUndefined(result)) {
                        language = result;
                    } else {
                        language = window.navigator.userLanguage || window.navigator.language;
                    }
                });
                
                
                switch(language) {
                    case "en-US":
                    case "en-UK":
                        $scope.changeLanguage("en-US");
                        break;

                    case "ru-RU":
                        $scope.changeLanguage("ru-RU");
                        break;

                    case "ro-MD":
                    case "ro-RO":
                        $scope.changeLanguage("ro-MD");
                        break;

                    default:
                        $scope.changeLanguage("en-US");
                        break;
                }
                console.log($rootScope.language);
            };

            init();

        }]);
}());