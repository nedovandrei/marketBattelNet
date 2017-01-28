(function () {
    "use strict";

    angular.module("app")
        .controller("AdminContentManageController", ["$scope", "photoService", "artService", "gameService", "appSettings", "toasterService", function ($scope, photoService, artService, gameService, appSettings, toasterService) {

            $scope.gamesList = [];

            $scope.imagesPath = appSettings.imagesPath;

            $scope.gameLogo = { ds:[], fileName: "" };
            $scope.gameBackground = { ds: [], fileName: "" };
            $scope.artSmallPhoto = { ds: [], fileName: "" };
            $scope.artBigPhoto1 = { ds: [], fileName: "" };
            $scope.artBigPhoto2 = { ds: [], fileName: "" };
            $scope.artBigPhoto3 = { ds: [], fileName: "" };
            $scope.artBigPhoto4 = { ds: [], fileName: "" };

            $scope.testFileInputChange = function () {
                console.log($scope.testFileInputModel);
            }

            $scope.gameModel = {
                NameEng: "",
                BackgroundFileName: "",
                LogoFileName: ""
            };

            $scope.artModel = {
                NameRus: "",
                NameEng: "",
                NameRom: "",
                Type: "",
                GameId: "",
                DescriptionRus: "",
                DescriptionEng: "",
                DescriptionRom: "",
                Price: "",
                ThumbnailFileName: "",
                LargeFileName: "",
                LargeFileName2: "",
                LargeFileName3: "",
                LargeFileName4: ""
            };


            $scope.getFileDetails = function (e) {
                appSettings.loader.show();
                if (e.id === "gameLogo") {
                    $scope.$apply(function () {
                        // STORE THE FILE OBJECT IN AN ARRAY.
                        for (var i = 0; i < e.files.length; i++) {
                            $scope.gameLogo.ds.push(e.files[i]);
                        }
                        $scope.uploadFiles("gameLogo");
                    });
                } else if (e.id === "gameBackground") {
                    $scope.$apply(function () {
                        // STORE THE FILE OBJECT IN AN ARRAY.
                        for (var i = 0; i < e.files.length; i++) {
                            $scope.gameBackground.ds.push(e.files[i]);
                        }
                        $scope.uploadFiles("gameBackground");
                    });
                } else if (e.id === "artSmallPhoto") {
                    $scope.$apply(function () {
                        // STORE THE FILE OBJECT IN AN ARRAY.
                        for (var i = 0; i < e.files.length; i++) {
                            $scope.artSmallPhoto.ds.push(e.files[i]);
                        }
                        $scope.uploadFiles("artSmallPhoto");
                    });
                } else if (e.id === "artBigPhoto1") {
                    $scope.$apply(function () {
                        // STORE THE FILE OBJECT IN AN ARRAY.
                        for (var i = 0; i < e.files.length; i++) {
                            $scope.artBigPhoto1.ds.push(e.files[i]);
                        }
                        $scope.uploadFiles("artBigPhoto1");
                    });
                } else if (e.id === "artBigPhoto2") {
                    $scope.$apply(function () {
                        // STORE THE FILE OBJECT IN AN ARRAY.
                        for (var i = 0; i < e.files.length; i++) {
                            $scope.artBigPhoto2.ds.push(e.files[i]);
                        }
                        $scope.uploadFiles("artBigPhoto2");
                    });
                } else if (e.id === "artBigPhoto3") {
                    $scope.$apply(function () {
                        // STORE THE FILE OBJECT IN AN ARRAY.
                        for (var i = 0; i < e.files.length; i++) {
                            $scope.artBigPhoto3.ds.push(e.files[i]);
                        }
                        $scope.uploadFiles("artBigPhoto3");
                    });
                } else if (e.id === "artBigPhoto4") {
                    $scope.$apply(function () {
                        // STORE THE FILE OBJECT IN AN ARRAY.
                        for (var i = 0; i < e.files.length; i++) {
                            $scope.artBigPhoto4.ds.push(e.files[i]);
                        }
                        $scope.uploadFiles("artBigPhoto4");
                    });
                }
            };

            $scope.uploadFiles = function (input) {
                appSettings.loader.show();
                switch (input) {
                    case "gameLogo":
                        photoService.uploadFiles($scope.gameLogo.ds, function (result) {
                            $scope.gameLogo.fileName = result.slice(1, result.length - 1);
                            $scope.gameModel.LogoFileName = result.slice(1, result.length - 1);
                            appSettings.loader.hide();
                        });
                        break;

                    case "gameBackground":
                        photoService.uploadFiles($scope.gameBackground.ds, function (result) {
                            $scope.gameBackground.fileName = result.slice(1, result.length - 1);
                            $scope.gameModel.BackgroundFileName = result.slice(1, result.length - 1);
                            appSettings.loader.hide();
                        });
                        break;

                    case "artSmallPhoto":
                        photoService.uploadFiles($scope.artSmallPhoto.ds, function (result) {
                            $scope.artSmallPhoto.fileName = result.slice(1, result.length - 1);
                            $scope.artModel.ThumbnailFileName = result.slice(1, result.length - 1);
                            appSettings.loader.hide();
                        });
                        break;

                    case "artBigPhoto1":
                        photoService.uploadFiles($scope.artBigPhoto1.ds, function (result) {
                            $scope.artBigPhoto1.fileName = result.slice(1, result.length - 1);
                            $scope.artModel.LargeFileName = result.slice(1, result.length - 1);
                            appSettings.loader.hide();
                        });
                        break;

                    case "artBigPhoto2":
                        photoService.uploadFiles($scope.artBigPhoto2.ds, function (result) {
                            $scope.artBigPhoto2.fileName = result.slice(1, result.length - 1);
                            $scope.artModel.LargeFileName2 = result.slice(1, result.length - 1);
                            appSettings.loader.hide();
                        });
                        break;

                    case "artBigPhoto3":
                        photoService.uploadFiles($scope.artBigPhoto3.ds, function (result) {
                            $scope.artBigPhoto3.fileName = result.slice(1, result.length - 1);
                            $scope.artModel.LargeFileName3 = result.slice(1, result.length - 1);
                            appSettings.loader.hide();
                        });
                        break;

                    case "artBigPhoto4":
                        photoService.uploadFiles($scope.artBigPhoto4.ds, function (result) {
                            $scope.artBigPhoto4.fileName = result.slice(1, result.length - 1);
                            $scope.artModel.LargeFileName4 = result.slice(1, result.length - 1);
                            appSettings.loader.hide();
                        });
                        break;
                }
            };

            $scope.submitGame = function () {
                if ($scope.gameModel.BackgroundFileName === "" || $scope.gameModel.LogoFileName === "") {
                    toasterService.showErrorToaster("Ошибка", "Нет загруженных фотографий для этой игры");
                    return;
                }
                appSettings.loader.show();
                gameService.add($scope.gameModel, function () {
                    appSettings.loader.hide();
                    toasterService.showSuccessToaster($scope.gameModel.NameEng, "Сохранено");
                    $scope.gameModel.BackgroundFileName = "";
                    $scope.gameModel.NameEng = "";
                    $scope.gameModel.LogoFileName = "";
                    $scope.gameBackground.ds = [];
                    $scope.gameBackground.fileName = "";
                    $scope.gameLogo.ds = [];
                    $scope.gameLogo.fileName = "";
                    
                });
            };

            $scope.submitArt = function () {
                if ($scope.artModel.ThumbnailFileName === "" || $scope.artModel.LargeFileName === "") {
                    toasterService.showErrorToaster("Ошибка", "Нет загруженных фотографий для этого товара");
                    return;
                }
                appSettings.loader.show();
                artService.add($scope.artModel, function () {
                    toasterService.showSuccessToaster($scope.artModel.NameRus, "Сохранено");
                    $scope.artModel = {
                        NameRus: "",
                        NameEng: "",
                        NameRom: "",
                        Type: "",
                        GameId: "",
                        DescriptionRus: "",
                        DescriptionEng: "",
                        DescriptionRom: "",
                        Price: "",
                        ThumbnailFileName: "",
                        LargeFileName: ""
                    };
                    $scope.artSmallPhoto.ds = [];
                    $scope.artSmallPhoto.fileName = "";
                    $scope.artBigPhoto1.ds = [];
                    $scope.artBigPhoto1.fileName = "";
                    $scope.artBigPhoto2.ds = [];
                    $scope.artBigPhoto2.fileName = "";
                    $scope.artBigPhoto3.ds = [];
                    $scope.artBigPhoto3.fileName = "";
                    $scope.artBigPhoto4.ds = [];
                    $scope.artBigPhoto4.fileName = "";
                    appSettings.loader.hide();                    
                });
            };

            function init() {
                appSettings.loader.show();
                gameService.getAll(function(result) {
                    $scope.gamesList = result;
                    appSettings.loader.hide();
                });
            }

            init();
        }]);
}());