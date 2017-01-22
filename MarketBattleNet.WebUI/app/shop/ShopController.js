(function () {
    "use strict";

    angular.module("app")
        .controller("ShopController", [
            "artService",
            "gameService",
            "$scope",
            "$stateParams",
            "$location",
            "appSettings",
            function (artService, gameService, $scope, $stateParams, $location, appSettings) {
                $scope.imagesPath = appSettings.imagesPath;

                $scope.searchString = "";

                function changeBackground(fileName) {
                    if (fileName) {
                        $(".m_page").css("background-image", "url('" + appSettings.imagesPath + fileName + "')");
                    } else {
                        $(".m_page").css("background-image", "url('../images/" + appSettings.backgroundDefault + "')");
                    }
                }

                $scope.currentUrl = $location.path();

                $scope.artList = [];
                $scope.gameInFocus = {};
                $scope.sortPropertyName = "";
                $scope.sortReverse = false;

                $scope.sortObject = {
                    ByDate: "",
                    ByPrice: "",
                    ByType: [],
                    SearchString: "",
                    GameId: !!$stateParams.gameId ? $stateParams.gameId : null
                }

                $scope.typeSort = {
                    cup: false,
                    mousepad: false,
                    tshirts: false
                }

                $scope.byTypeSort = function (type) {
                    $scope.sortObject.ByType = [];
                    if ($scope.typeSort[type] === true) {
                        $scope.typeSort[type] = false;
                        for (var i in $scope.typeSort) {
                            if ($scope.typeSort.hasOwnProperty(i)) {
                                if ($scope.typeSort[i] === true) {
                                    $scope.sortObject.ByType.push(i);
                                }
                            }
                        }
                    } else {
                        $scope.typeSort[type] = true;
                        for (var j in $scope.typeSort) {
                            if ($scope.typeSort.hasOwnProperty(j)) {
                                if ($scope.typeSort[j] === true) {
                                    $scope.sortObject.ByType.push(j);
                                }
                            }
                        }
                    }

                    $scope.applySortChanges();

                    //for (var i in $scope.typeSort) {
                    //    if ($scope.typeSort.hasOwnProperty(i)) {
                    //        if ($scope.typeSort[i] === true) {
                    //            $scope.ByType.push(type);
                    //        }
                    //    }
                    //}
                }

                $scope.setSortProperties = function(propName, reverse) {
                    if ($scope.sortPropertyName === propName && $scope.sortReverse === reverse) {
                        $scope.sortPropertyName = "";
                        $scope.sortReverse = false;
                        return;
                    }
                    $scope.sortPropertyName = propName;
                    $scope.sortReverse = reverse;
                }

                $scope.applySortChanges = function() {
                    getAllExtended($scope.sortObject);
                }

                function getAllExtended(sortObject) {
                    artService.getAllExt(sortObject, function (result) {
                        $scope.artList = [];
                        $scope.artList = result;
                    });
                }

                //$scope.search = function () {
                //    if ($scope.searchString === "") {
                //        artService.getAll(function(result) {
                //            $scope.artList = result;                            
                //        });
                //    } else {
                //        artService.search($scope.searchString, function (result) {
                //            $scope.artList = result;                            
                //        });
                //    }
                    
                //}

                function loadArt() {
                    appSettings.loader.show();
                    if (!!$stateParams.gameId && $stateParams.gameId !== "") {
                        gameService.findById($stateParams.gameId, function (result) {
                            $scope.gameInFocus = result;
                            changeBackground($scope.gameInFocus.BackgroundFileName);
                        });
                        artService.findByGameId($stateParams.gameId, function (result) {
                            $scope.artList = result;

                            appSettings.loader.hide();
                        });
                        
                    } else {
                        artService.getAll(function (result) {
                            $scope.artList = result;
                            appSettings.loader.hide();
                            changeBackground();                            
                        });
                    }
                };

                function init() {
                    loadArt();
                };

                init();
            }
        ]);
}());