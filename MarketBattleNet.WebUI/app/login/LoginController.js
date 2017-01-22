(function () {
    "use strict";

    angular.module("app")
        .controller("LoginController", ["$scope", "$rootScope", "$state", "loginService", "toasterService", "appSettings", function ($scope, $rootScope, $state, loginService, toasterService, appSettings) {

            $scope.loginObject = {
                UserName: "",
                Password: ""
            };

            $scope.login = function() {
                loginService.login($scope.loginObject, function (result) {
                    
                    var message = {
                        title: "",
                        message: ""
                    };
                    if (result) {
                        $rootScope.adminAuthorized = true;
                        if ($rootScope.language === 'ru-RU') {
                            message.title = "Чтобы заблокировать доступ к секции администрации, обновите страницу";
                        } else if ($rootScope.language === 'en-US') {
                            message.title = "Refresh the page to lock down the Admin section";
                        } else {
                            message.title = "Actualizeaza pagina pentru a bloca secțiunea Administrare";
                        }
                        toasterService.showInfoToaster(message.title, message.message, 10000, 2);

                        $state.go("admin.request-table");
                    } else {                        
                        if ($rootScope.language === 'ru-RU') {
                            message.title = "Ошибка!";
                            message.title = "Имя пользователя либо пароль не верны";
                        } else if ($rootScope.language === 'en-US') {
                            message.title = "Error!";
                            message.title = "User name or Password are incorrect";
                        } else {
                            message.title = "Eroare!";
                            message.title = "Numele de Utilizator sau parola nu este corect";
                        }
                        toasterService.showErrorToaster(message.title, message.message, 5000);
                    }
                });
            };

            function changeBackground(fileName) {
                if (fileName) {
                    $("img.background_image").attr("src", "../images/" + fileName);
                } else {
                    $("img.background_image").attr("src", "../images/" + appSettings.backgroundDefault);
                }
            }

            function init() {
                changeBackground();
            }

            init();
        }]);
}());