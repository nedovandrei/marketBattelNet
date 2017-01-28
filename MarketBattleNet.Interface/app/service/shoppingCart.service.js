(function () {
    'use strict';

    angular.module("app")
        .factory("shoppingCartService", ["$rootScope", "cookieService", function ($rootScope, cookieService) {
            var _shoppingCartService = {};

            $rootScope.purchasedItems = [];

            function init() {
                cookieService.getObject("purchases", function (result) {
                    if (!!result) {
                        $rootScope.purchasedItems = result;
                    } else {
                        cookieService.createObject('purchases', []);
                        $rootScope.purchasedItems = [];
                    }        
                });
            }

            init();

            _shoppingCartService.addToCart = function (artItem, callback) {
                $rootScope.purchasedItems.push(artItem);
                cookieService.removeKey('purchases');
                cookieService.createObject('purchases', $rootScope.purchasedItems);
                if (callback) {
                    callback();
                }
            };

            _shoppingCartService.removeFromCart = function (artItemId, callback) {
                for (var i = 0; i < $rootScope.purchasedItems.length; i++) {
                    if ($rootScope.purchasedItems[i].Id === artItemId) {
                        $rootScope.purchasedItems.splice(i, 1);
                        cookieService.removeKey('purchases');
                        cookieService.createObject('purchases', $rootScope.purchasedItems);
                    }
                }
                if (callback) {
                    callback();
                }
            };

            _shoppingCartService.getAllPurchasedItems = function (callback) {               
                cookieService.getObject("purchases", function (result) {                    
                    callback($rootScope.purchasedItems);
                });
            };

            _shoppingCartService.removeAllPurchases = function (callback) {               
                cookieService.removeKey("purchases");
                $rootScope.purchasedItems = [];
            }

            return _shoppingCartService;
        }]);
}());