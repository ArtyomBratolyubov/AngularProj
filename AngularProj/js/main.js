var app = angular.module("main", ["ngRoute"]);

app.controller("GalleryController", [
    "$scope", "galleryService", function ($scope, galleryService) {

        $scope.imageContainer = [];

        galleryService.GetAll().then(function (resp) {
            $scope.curImagesContainer = resp.data;
        });

        $scope.DeleteImage = function (id) {
            galleryService.Remove(id);
        }

    }
]);

app.controller("AddImageController", [
    "$scope", "galleryService", function ($scope, galleryService) {

        $scope.tempUrl = "";

        $scope.tempImageName = "";

        $scope.img= {};

        $scope.tempUrl.change = updateImg();

        function updateImg() {
            img = {
                src: $scope.tempUrl,
                name: $scope.tempImageName,
            };
        }

        $scope.AddImage = function () {
            if (!$scope.tempUrl || !$scope.tempImageName)
                return;

            galleryService.Add($scope.tempUrl, $scope.tempImageName);

            $scope.tempUrl = "";
            $scope.tempImageName = "";
            $scope.tempAlbumId = 0;
        };
    }
]);

app.controller("IndexController", [
    "$scope", function ($scope) {
        $scope.siteDesc = "123";
        $scope.isEdit = false;

        var tempDesc = "";

        $scope.Edit = function () {
            tempDesc = String($scope.siteDesc);
            $scope.isEdit = true;
        }

        $scope.Save = function () {
            $scope.isEdit = false;
        }

        $scope.Cancel = function () {
            $scope.siteDesc = tempDesc;
            $scope.isEdit = false;
        }
    }
]);

app.service("galleryService", ["$http", function ($http) {
    var _resp = {};

    return {
        GetAll: function () {

            var resp = $http({
                url: "/Image/GetImages"
            });
            resp.then(function(r) {
                _resp = r;
            });

            return resp;
        },

        Add: function (src, name) {
            var data = _resp.data;

            var id;
            if (data.length === 0)
                id = 1;
            else
                id = data[data.length - 1].id + 1;
            data.push({
                id: id,
                src: src,
                name: name,
                desc: desc
            });
        },

        Remove: function (id) {
            var data = _resp.data;
            var a = data.filter(function (val) {
                return val.id === id;
            });

            var i = data.indexOf(a[0]);

            data.splice(i, 1);
        }
    }
}]);

app.config(["$locationProvider", "$routeProvider",
    function ($locationProvider, $routeProvider) {
        $routeProvider
            .when("/",
            {
                templateUrl: "Views/Angular/Index.html",
                controller: "IndexController"
            })
            .when("/Home/Layout/",
            {
                templateUrl: "Views/Angular/Index.html",
                controller: "IndexController"
            })
            .when("/Home/Gallery",
            {
                templateUrl: "Views/Angular/Gallery.html",
                controller: "GalleryController"
            })
            .when("/Home/AddImage",
            {
                templateUrl: "Views/Angular/AddImage.html",
                controller: "AddImageController"
            })
            .otherwise({ redirectTo: "/" });

        $locationProvider.html5Mode(true);
    }]);

app.directive("imagePreview",
[
    function () {
        return {
            restrict: "E",
            replace: true,
            templateUrl: "/Views/Angular/Image/ImagePreview.html",
            scope: { img: "=" }
        }
    }
]);