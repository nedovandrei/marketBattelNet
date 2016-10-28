(function () {
    'use strict';

    angular.module("app")
        .controller("ShoppingCartController", ["shoppingCartService", "$scope", "$rootScope", function (shoppingCartService, $scope, $rootScope) {

            //public members
            $scope.purchasedItems = [];           

            $scope.$watch("$rootScope.purchasedItems", function () {
                shoppingCartService.getAllPurchasedItems(function (result) {
                    $scope.purchasedItems = result;
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


            //private members
            //var mocks = [
            //    {
            //        "Id": 1,
            //        "GameId": 5,
            //        "Type": "cup",
            //        "NameRus": "Чашка ТЕСТ1",
            //        "NameEng": "Cup TEST1",
            //        "NameRom": "Ceashka TEST1",
            //        "DescriptionRus": "О БОЖЕ ЭТО ЛУЧШЕЕ ЧТО СЛУЧАЛОСЬ С ТВОЕЙ ЖАЛКОЙ ЖИЗНЬЮ СУКА, НЕ СМЕЙ ПРОПУСКАТЬ УРОД",
            //        "DescriptionEng": "MY FUCKIN' GOD JKJKJAKSJDF;L",
            //        "DescriptionRom": "ESTI CEL MAI BUN ART DIN LUMEA",
            //        "Price": 6.99,
            //        "ThumbnailFileName": "art1_thumbnail.jpg",
            //        "LargeFileName": "art1_large.png"
            //    },
            //    {
            //        "Id": 3,
            //        "GameId": 5,
            //        "Type": "cup",
            //        "NameRus": "Чашка ТЕСТ2",
            //        "NameEng": "CUP TEST2",
            //        "NameRom": "CEASCA TEST2",
            //        "DescriptionRus": "ОПЯТЬЖЭЕ",
            //        "DescriptionEng": "ONCE AGAIN",
            //        "DescriptionRom": "bla blabla ROM",
            //        "Price": 6.99,
            //        "ThumbnailFileName": "art2_thumbnail.jpg",
            //        "LargeFileName": "art2_large.png"
            //    },
            //    {
            //        "Id": 4,
            //        "GameId": 5,
            //        "Type": "mousepad",
            //        "NameRus": "Коврик ТЕСТ3",
            //        "NameEng": "MousePad TEST3",
            //        "NameRom": "Covor TEST3",
            //        "DescriptionRus": "ТЕСТ ОПИСАНИЕ",
            //        "DescriptionEng": "TEST DESCRIPTION",
            //        "DescriptionRom": "DESCRIPTIE DE TEST",
            //        "Price": 7.99,
            //        "ThumbnailFileName": "art3_thumbnail.jpg",
            //        "LargeFileName": null
            //    }
            //]

            function init() {
                //for (var i = 0; i < mocks.length; i++) {
                //    shoppingCartService.addToCart(mocks[i]);
                //}
            };

            init();

        }]);
}());