(function (app) {
    app.controller('ThongTinTuyenDungController', ThongTinTuyenDungController);

    function ThongTinTuyenDungController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.ThongTinTuyenDung = [];
        $scope.GetThongTinTuyenDung = GetThongTinTuyenDung;
        $scope.UpDateThongTinTuyenDung = UpDateThongTinTuyenDung;
        $scope.hide = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;

        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
        }


        function GetThongTinTuyenDung() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/thongtintuyendung/GetthongTinTuyenDung', config, function (result) {

                $scope.ThongTinTuyenDung = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }


        function UpDateThongTinTuyenDung() {


            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                angular.forEach($scope.ThongTinTuyenDung, function (item) {
                    apiService.put('/api/thongtintuyendung/update', item, function (result) {
                        notificationService.displaySuccess("Sửa thành công");
                        $scope.GetThongTinTuyenDung();

                        $scope.hide = !$scope.hide;
                        $scope.Edit = !$scope.Edit
                        console.log('Sửa thành công.');
                    }, function () {
                        console.log('sửa thông tin không thành công.');
                    });
                });

            });

        }

        $scope.GetThongTinTuyenDung();
    }
})(angular.module('platformTH_GV.thongtincanhan'));