(function() {
    "use strict";

    angular.module("app")
        .factory("photoService", ["appSettings", function (appSettings) {
            var _photoService = {};

            _photoService.uploadFiles = function (dataToSend, callback) {

                //function updateProgress(e) {
                //    if (e.lengthComputable) {
                //        document.getElementById('pro').setAttribute('value', e.loaded);
                //        document.getElementById('pro').setAttribute('max', e.total);
                //    }
                //}

                // CONFIRMATION.
                //function transferComplete(e) {
                //    alert("Files uploaded successfully.");
                //}

                var data = new FormData();

                for (var i in dataToSend) {
                    data.append("uploadedFile", dataToSend[i]);
                }

                // ADD LISTENERS.
                var objXhr = new XMLHttpRequest();
                //objXhr.addEventListener("progress", updateProgress, false);
                //objXhr.addEventListener("load", transferComplete, false);

                // SEND FILE DETAILS TO THE API.
                objXhr.open("POST", appSettings.apiPath + "Photo/UploadPhoto", false);
                //objXhr.send(data).then(function() {
                //    callback(objXhr.response);
                //});
                objXhr.send(data);
                callback(objXhr.response);
                console.log(objXhr);

            };

            return _photoService;
        }]);
}());