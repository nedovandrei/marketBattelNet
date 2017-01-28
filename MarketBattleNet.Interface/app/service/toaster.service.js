(function() {
    "use strict";

    angular.module("app")
        .factory("toasterService", ["toaster", function (toaster) {
            var _toasterService = {};

            _toasterService.showSuccessToaster = function(title, text, timeout, containerId) {
                var toasterTime = 5000;
                var toastContainerId = 1;
                if (timeout) {
                    toasterTime = timeout;
                }
                if (containerId) {
                    toastContainerId = containerId;
                }
                toaster.pop({
                    toasterId: toastContainerId,
                    type: 'success',
                    title: title,
                    body: text,
                    timeout: toasterTime
                });
            };

            _toasterService.showErrorToaster = function(title, text, timeout, containerId) {
                var toasterTime = 0;
                var toastContainerId = 2;
                if (containerId) {
                    toastContainerId = containerId;
                }
                if (timeout) {
                    toasterTime = timeout;
                }
                toaster.pop({
                    toasterId: toastContainerId,
                    type: 'error',
                    title: title,
                    body: text,
                    timeout: toasterTime
                });
            }

            _toasterService.showWarningToaster = function(title, text, timeout, containerId) {
                var toasterTime = 5000;
                var toastContainerId = 1;
                if (timeout) {
                    toasterTime = timeout;
                }
                if (containerId) {
                    toastContainerId = containerId;
                }
                toaster.pop({
                    toasterId: toastContainerId,
                    type: 'warning',
                    title: title,
                    body: text,
                    timeout: toasterTime
                });
            };

            _toasterService.showInfoToaster = function(title, text, timeout, containerId) {
                var toasterTime = 5000;
                var toastContainerId = 1;
                if (timeout) {
                    toasterTime = timeout;
                }
                if (containerId) {
                    toastContainerId = containerId;
                }
                toaster.pop({
                    toasterId: toastContainerId,
                    type: 'info',
                    title: title,
                    body: text,
                    timeout: toasterTime
                });
            };

            return _toasterService;
        }]);
}());