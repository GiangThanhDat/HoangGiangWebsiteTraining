(function (app) {
    'use strict';

    app.controller('nhapTaiSanController', nhapTaiSanController);

    nhapTaiSanController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function nhapTaiSanController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.msnv = "";
        $scope.newDate = new Date();
        $scope.QuanLyTaiSan = {};
        $scope.getmasocoso = function (item) {
            $scope.NhapTaiSan.MaCoSo =item;

        }
        $scope.getMaSoNhanVien = function (item) {
            $scope.QuanLyTaiSan.MaSoNhanVien = item;
         

        }


       
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.maNhanVien = $scope.authentication.userName;
        $scope.getALLCoSo = [];
       
        $scope.GetAllNhanVien = GetAllNhanVien;
        $scope.GetAllTaiSan = GetAllTaiSan;
        $scope.getAddTaiSan = getAddTaiSan;
        $scope.GetCoSo = GetCoSo;



        function GetCoSo() {

            apiService.get('/api/coso/getall', null, function (result) {

                $scope.getALLCoSo = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
       
        function GetAllNhanVien() {

            apiService.get('/api/nhanvien/getnhanvien', null, function (result) {

                $scope.LyLichNhanVien = result.data;
              

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        $scope.NhapTaiSan = { NguoiNhap: $scope.maNhanVien };

        function GetAllTaiSan() {

            apiService.get('/api/taisan/getall', null, function (result) {

                $scope.AlllTaiSan = result.data;
                if (result.data.length > 0) {
                    $scope.AlllTaiSan = result.data[result.data.length - 1].MaTaiSan
                   
                } else {
                    $scope.AlllTaiSan = 0;

                }

                var maso = parseInt($scope.AlllTaiSan);

                var str = "" + (maso + 1)
                var pad = "000000"
                var ans = pad.substring(0, pad.length - str.length) + str
                $scope.NhapTaiSan.MaTaiSan = ans;
                $scope.QuanLyTaiSan.MaTaiSan = ans;
               

               

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }


        function getAddTaiSan() {

            $ngBootbox.confirm('Bạn chắc muốn thêm  không').then(function () {
                apiService.post('/api/taisan/create', $scope.NhapTaiSan, function (result) {
                    $scope.GetAllTaiSan()
                    $scope.getmasocoso();
                    $scope.GetCoSo();
                    $scope.MaSoCoSo = [];
                    $scope.NhapTaiSan = { NguoiNhap: $scope.maNhanVien };
                    alert("Thêm tài sản thành công ")

                    apiService.post('/api/quanlytaisan/create', $scope.QuanLyTaiSan, function (result) {

                        $scope.GetAllTaiSan()
                        $scope.getMaSoNhanVien()
                        $scope.saveMaSoNhanVien = [];
                        notificationService.displaySuccess("thêm quản lý tài sản thành công");


                    }, function () {
                        console.log('thêm quản lý tài sản không thành công.');
                    });
                 
                }, function () {
                    console.log('Thêm tài sản không thành công.');
                });
               

            });
        }
       
        $scope.huy = function () {
            $scope.GetAllTaiSan()
            $scope.getmasocoso();
            $scope.GetCoSo();
            $scope.MaSoCoSo = [];
            $scope.NhapTaiSan = { NguoiNhap: $scope.maNhanVien };
            $scope.getMaSoNhanVien()
            $scope.saveMaSoNhanVien = [];
        }


        $scope.GetAllTaiSan()
        $scope.GetCoSo()
        $scope.GetAllNhanVien()
    }


})(angular.module('platformTH_GV.quanlytaisan'));