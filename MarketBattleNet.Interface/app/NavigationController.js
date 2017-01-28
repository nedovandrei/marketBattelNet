(function () {
    "use strict";

    angular.module("app")
        .run(function ($rootScope, $state, $stateParams) {
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;
        });

    angular.module("app")
        .controller("NavigationController", [
            "$scope",
            "$state",
            "$rootScope",
            "gameService",
            "artService",
            "appSettings",
            function ($scope, $state, $rootScope, gameService, artService, appSettings) {
                $scope.$watch("$state.current", function () {
                    $scope.navigationArray = [];

                    $scope.state = $rootScope.$state;
                    $scope.params = $rootScope.$stateParams;
                    console.log("state changed", $scope.state);
                    console.log("state changed params", $scope.params);


                    if ($scope.state.current.name === "game") {
                        $scope.navigationArray = [
                            {
                                nameRus: "Домой",
                                nameEng: "Home",
                                nameRom: "Pagina Principala",
                                href: "game"
                            },
                        ];
                    } else if ($scope.state.current.name === "shop" && ($scope.params.gameId === "" || $scope.params.gameId === "/")) {
                        $scope.navigationArray = [
                            {
                                nameRus: "Домой",
                                nameEng: "Home",
                                nameRom: "Pagina Principala",
                                href: "game"
                            },
                            {
                                nameEng: "Shop",
                                nameRom: "Magazin",
                                nameRus: "Магазин",
                                href: "shop",
                                params: ""
                            }
                        ];
                    } else if ($scope.state.current.name === "shop" && $scope.params.gameId !== "") {
                        appSettings.loader.show();
                        gameService.findById($scope.params.gameId, function (result) {
                            $scope.navigationArray = [
                                //{
                                //    nameEng: "Shop",
                                //    nameRom: "Magazin",
                                //    nameRus: "Магазин",
                                //    href: "shop({gameId: ''})",
                                //    params: ""
                                //},
                                {
                                    nameRus: "Домой",
                                    nameEng: "Home",
                                    nameRom: "Pagina Principala",
                                    href: "game"
                                },
                                {
                                    nameRom: result.NameEng,
                                    nameEng: result.NameEng,
                                    nameRus: result.NameEng,
                                    href: "shop/" + result.Id
                                }
                            ];
                            appSettings.loader.hide();
                        });
                    } else if ($scope.state.current.name === "art") {
                        appSettings.loader.show();
                        artService.findById($scope.params.artId, function (result) {
                            gameService.findById(result.GameId, function (innerResult) {
                                $scope.navigationArray = [
                                    //{
                                    //    nameEng: "Shop",
                                    //    nameRom: "Magazin",
                                    //    nameRus: "Магазин",
                                    //    href: "shop({gameId: ''})",
                                    //    params: ""
                                    //},
                                    {
                                        nameRus: "Домой",
                                        nameEng: "Home",
                                        nameRom: "Pagina Principala",
                                        href: "game"
                                    },
                                    {
                                        nameRom: innerResult.NameEng,
                                        nameEng: innerResult.NameEng,
                                        nameRus: innerResult.NameEng,
                                        href: "shop({gameId:" + innerResult.Id + "})"
                                    },
                                    {
                                        nameRus: result.NameRus,
                                        nameEng: result.NameEng,
                                        nameRom: result.NameRom,
                                        href: "art({artId:" + result.Id + "})"
                                    }
                                ];
                                appSettings.loader.hide();
                            });
                        });
                    } else if ($scope.state.current.name === "login") {
                        $scope.navigationArray = [
                            {
                                nameRus: "Домой",
                                nameEng: "Home",
                                nameRom: "Pagina Principala",
                                href: "game"
                            },
                            {
                                nameRus: "Вход в Админку",
                                nameEng: "Admin Section Entry",
                                nameRom: "Întrare în secția de Administrație",
                                href: "login"
                            }
                        ];
                    } else if ($scope.state.current.name.includes("admin")) {
                        $scope.navigationArray = [
                            {
                                nameRus: "Домой",
                                nameEng: "Home",
                                nameRom: "Pagina Principala",
                                href: "game"
                            },
                            {
                                nameRus: "Админка",
                                nameEng: "Admin Section",
                                nameRom: "Secția de Administrație",
                                href: "admin"
                            }
                        ];
                    } else if ($scope.state.current.name === "purchase") {
                        $scope.navigationArray = [
                            {
                                nameRus: "Домой",
                                nameEng: "Home",
                                nameRom: "Pagina Principala",
                                href: "game"
                            },
                            {
                                nameRus: "Оформить Заказ",
                                nameEng: "Place an Order",
                                nameRom: "Plasare de Comanda",
                                href: "purchase"
                            }
                        ];
                    } else if ($scope.state.current.name === "support") {
                        $scope.navigationArray = [
                            {
                                nameRus: "Домой",
                                nameEng: "Home",
                                nameRom: "Pagina Principala",
                                href: "game"
                            },
                            {
                                nameRus: "Помощь",
                                nameEng: "Support",
                                nameRom: "Ajutor",
                                href: "support"
                            }
                        ];
                    }


                    console.log("navigation Array: ", $scope.navigationArray);
                });

            }]);
}());