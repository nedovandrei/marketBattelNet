(function () {
    "use strict";

    angular.module("app")
        .controller("PurchaseController", [
            "shoppingCartService",
            "requestService",
            "userProfileService",
            "toasterService",
            "$scope",
            "$rootScope",
            "$location",
            "appSettings",
            function (shoppingCartService, requestService, userProfileService, toasterService, $scope, $rootScope, $location, appSettings) {
                $scope.purchases = [];
                $scope.currentUrl = $location.path();
                $scope.totalPrice = 0.00;
                $scope.userData = {
                    FullName: "",
                    PhoneNumber: "",
                    Address: ""
                }

                function changeBackground(fileName) {
                    if (fileName) {
                        $(".m_page").css("background-image", "url('../images/" + fileName + "')");
                    } else {
                        $(".m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                    }
                }

                function calculateTotalPrice() {
                    $scope.totalPrice = 0;
                    for (var i = 0; i < $scope.purchases.length; i++) {
                        $scope.totalPrice += $scope.purchases[i].Price;
                    }
                }


                $scope.removeItem = function (item) {
                    shoppingCartService.removeFromCart(item.Id);
                    $scope.purchases = [];
                    shoppingCartService.getAllPurchasedItems(function(result) {
                        $scope.purchases = result;
                        calculateTotalPrice();
                    });                    
                }

                function validatePhoneNumber(phoneNumber) {
                    var reg = /0(6|7)[0-9]{7}/g;
                    return reg.test(phoneNumber);
                }

                $scope.submitRequest = function () {
                    if (!validatePhoneNumber($scope.userData.PhoneNumber)) {
                        console.log('phone NOT invalid');
                        var message = {
                            title: "",
                            text: ""
                        };
                        if ($rootScope.language === 'ru-RU') {
                            message.title = "Ошибка!";
                            message.text = 'Телефон должен быть формата "079123456"';
                        } else if ($rootScope.language === 'en-US') {
                            message.title = "Error!";
                            message.text = 'The phone number should be in "079123456 format"';
                        } else {
                            message.title = "Eroarea!";
                            message.text = 'Numărul de telefon ar trebui să fie în formatul "079123456"';
                        }
                        toasterService.showErrorToaster(message.title, message.text, 10000, 2);
                        return;
                    } 

                    userProfileService.add($scope.userData, function (addedUser) {
                        var requestArr = [];
                        for (var i = 0; i < $scope.purchases.length; i++) {
                            var request = {
                                UserId: addedUser.Id,
                                ArtId: $scope.purchases[i].Id
                            };
                            requestArr.push(request);
                        }
                        requestService.addRange(requestArr, function (result) {
                            $rootScope.purchasedItems = [];
                            shoppingCartService.removeAllPurchases();
                            toasterService.showSuccessToaster("Запрос Сохранён", "Ваши заказы сохранены. Ожидайте звонка для подтверждения");
                            $location.path('/game');
                        });
                    });
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