(function (app) {
    app.controller('QuanLyQuaGioController', QuanLyQuaGioController);

    function QuanLyQuaGioController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.QuanLyQuaGio = [];
        $scope.GetQuanLyQuaGio = GetQuanLyQuaGio;
        $scope.UpDateQuanLyQuaGio = UpDateQuanLyQuaGio;
       
        $scope.hide = true;
        $scope.close = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;
            $scope.close = false;

        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
            $scope.close = true;
        }

        function GetQuanLyQuaGio() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/quanlyquagio/GetQuanLyQuaGio', config, function (result) {

                $scope.QuanLyQuaGio = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        function UpDateQuanLyQuaGio() {


            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                angular.forEach($scope.QuanLyQuaGio, function (item) {
                    apiService.put('/api/quanlyquagio/update', item, function (result) {
                        notificationService.displaySuccess("Sửa thành công");
                        $scope.GetQuanLyQuaGio();

                        $scope.hide = !$scope.hide;
                        $scope.Edit = !$scope.Edit
                        console.log('Sửa thành công.');
                    }, function () {
                        console.log('sửa thông tin không thành công.');
                    });
                });

            });

        }

        $scope.GetQuanLyQuaGio();
    }
})(angular.module('platformTH_GV.thongtincanhan'));