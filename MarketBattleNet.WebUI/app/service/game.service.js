(function () {
    "use strict";

    angular.module("app")
        .factory("gameService", ["$timeout", "gameResource", function ($timeout, gameResource) {
            var _gameService = {};

            //_gameService.getAll = function (callback) {
            //    return gameResource.getAll(function (result) {
            //        callback(result);
            //    }, function () {
            //        console.log("gameService -> GetAll: couldn't get");
            //    });
            //};

            _gameService.findById = function (id, callback) {
                return gameResource.findById({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> findById: couldnt' get")
                });
            };

            _gameService.add = function (gameModel, callback) {
                return gameResource.add(gameModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> add: error");
                });
            };

            _gameService.update = function (gameModel, callback) {
                return gameResource.update(gameModel, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> update: error");
                });
            };

            _gameService.delete = function (id, callback) {
                return gameResource.delete({ id: id }, function (result) {
                    callback(result);
                }, function () {
                    console.log("gameService -> delete: error");
                });
            };


            //mocks for Andrew
            //uncomment this method and comment the one above
            _gameService.getAll = function (callback) {
                var gameMocks = [
                    {
                        "Id": 1,
                        "Name": "Half Life",
                        "LogoFileName": "half_life_logo.png",
                        "BackgroundFileName": "half_life_background.png"
                    },
                    {
                        "Id": 2,
                        "Name": "Lineage 2",
                        "LogoFileName": "lineage_2_logo.png",
                        "BackgroundFileName": "lineage_2_background.png"
                    },
                    {
                        "Id": 3,
                        "Name": "Hearthstone",
                        "LogoFileName": "hearthstone_logo.png",
                        "BackgroundFileName": "hearthstone_background.png"
                    },
                    {
                        "Id": 4,
                        "Name": "Wolrd of Warcraft",
                        "LogoFileName": "wow_logo.png",
                        "BackgroundFileName": "wow_background.png"
                    },
                    {
                        "Id": 5,
                        "Name": "Dota 2",
                        "LogoFileName": "dota_2_logo.png",
                        "BackgroundFileName": "dota_2_background.jpg"
                    },
                    {
                        "Id": 6,
                        "Name": "League of Legends",
                        "LogoFileName": "league_of_legends_logo.png",
                        "BackgroundFileName": "league_of_legends_background.png"
                    }
                ]

                return $timeout(function () { callback(gameMocks);}, 1000)
            }

            return _gameService;
        }]);
})();