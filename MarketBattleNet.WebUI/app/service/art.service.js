(function () {
    "use strict";

    angular.module("app")
        .factory("artService", ["$timeout", "artResource", function ($timeout, artResource) {
            var _artService = {};

            _artService.getAll = function (callback) {
                return artResource.getAll(function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> GetAll: couldn't get");
                });
            };

            _artService.findById = function (id, callback) {
                return artResource.findById({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> findById: couldnt' get")
                });
            };

            _artService.add = function (artModel, callback) {
                return artResource.add(artModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> add: error");
                });
            };

            _artService.update = function (artModel, callback) {
                return artResource.update(artModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> update: error");
                });
            };

            _artService.delete = function (id, callback) {
                return artResource.delete({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> delete: error");
                });
            };

            _artService.findByGameId = function (id, callback) {
                return artResource.findByGameId({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("artService -> findByGameId: error")
                });
            }

            //_artService.findByGameId = function (id, callback) {
            //    var artMocks = [
            //        {
            //            "Id": 1,
            //            "GameId": 5,
            //            "Name": "Чашка ТЕСТ1",
            //            "Description": "О БОЖЕ ЭТО ЛУЧШЕЕ ЧТО СЛУЧАЛОСЬ С ТВОЕЙ ЖАЛКОЙ ЖИЗНЬЮ СУКА, НЕ СМЕЙ ПРОПУСКАТЬ УРОД",
            //            "ThumbnailFileName": "art1_thumbnail.jpg",
            //            "LargeFileName": "art1_large.png"
            //        },
            //        {
            //            "Id": 2,
            //            "GameId": 5,
            //            "Name": "Чашка ТЕСТ2",
            //            "Description": "ОПЯТЬЖЕ",
            //            "ThumbnailFileName": "art2_thumbnail.jpg",
            //            "LargeFileName": "art2_large.png"
            //        },
            //        {
            //            "Id": 3,
            //            "GameId": 5,
            //            "Name": "Коврик ТЕСТ3",
            //            "Description": "ТЕСТ ОПИСАНИЕ",
            //            "ThumbnailFileName": "art3_thumbnail.jpg",
            //            "LargeFileName": null
            //        }
            //    ]

            //    $timeout(callback(artMocks), 1000);

            //}

            //_artService.getAll = function (callback) {
            //    var artMocks = [
            //        {
            //            "Id": 1,
            //            "GameId": 5,
            //            "Name": "Чашка ТЕСТ1",
            //            "Description": "О БОЖЕ ЭТО ЛУЧШЕЕ ЧТО СЛУЧАЛОСЬ С ТВОЕЙ ЖАЛКОЙ ЖИЗНЬЮ СУКА, НЕ СМЕЙ ПРОПУСКАТЬ УРОД",
            //            "ThumbnailFileName": "art1_thumbnail.jpg",
            //            "LargeFileName": "art1_large.png"
            //        },
            //        {
            //            "Id": 2,
            //            "GameId": 5,
            //            "Name": "Чашка ТЕСТ2",
            //            "Description": "ОПЯТЬЖЕ",
            //            "ThumbnailFileName": "art2_thumbnail.jpg",
            //            "LargeFileName": "art2_large.png"
            //        },
            //        {
            //            "Id": 3,
            //            "GameId": 5,
            //            "Name": "Коврик ТЕСТ3",
            //            "Description": "ТЕСТ ОПИСАНИЕ",
            //            "ThumbnailFileName": "art3_thumbnail.jpg",
            //            "LargeFileName": null
            //        }
            //    ]

            //    $timeout(function () { callback(artMocks) }, 1000);

            //}

            return _artService;
        }]);
})();