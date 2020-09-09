(function (app) {
    'use strict';

    app.controller('quanLyNgayNghiAdminController', quanLyNgayNghiAdminController);

    quanLyNgayNghiAdminController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'dateFilter'];
    function quanLyNgayNghiAdminController($scope, apiService, notificationService, $ngBootbox, $filter, dateFilter) {

        $scope.Ngay = false;
        $scope.Nhanvien = false;
        $scope.bangtheongay = false;
        $scope.bangtheomsnv = false;
        $scope.bangtheotennv = false;
        $scope.Tuan = false;
        $scope.Thang = false;
        $scope.chonthang = false;

        $scope.Xemtheongay = function () {
            $scope.Ngay = true;
            $scope.Nhanvien = false;
            $scope.bangtheomsnv = false;
            $scope.bangtheotennv = false;
            $scope.Tuan = false;
            $scope.Thang = false;
            $scope.chonthang = false;

        }
        $scope.Xemtheonhanvien = function () {
            $scope.Ngay = false;
            $scope.Nhanvien = true;
            $scope.bangtheongay = false;
            $scope.Tuan = false;
            $scope.Thang = false;
            $scope.chonthang = false;


        }
        $scope.Xemtheotuan = function () {
            $scope.Ngay = false;
            $scope.Nhanvien = false;
            $scope.bangtheongay = false;
            $scope.Tuan = true;
            $scope.Thang = false;
            $scope.bangtheongay = false;
            $scope.bangtheomsnv = false;
            $scope.bangtheotennv = false;
            $scope.chonthang = false;

            

        }
        $scope.Xemtheothang = function () {
            $scope.Ngay = false;
            $scope.Nhanvien = false;
            $scope.bangtheongay = false;
            $scope.Tuan = false;
            $scope.bangtheongay = false;
            $scope.bangtheomsnv = false;
            $scope.bangtheotennv = false;
            $scope.chonthang = true;

        }

        $scope.DanhSachTheoNgay = [];
        $scope.DanhSachMSNV = [];
        $scope.DanhSachTenNV = [];
        $scope.getbyngay = function () {
            $scope.MaSoCoSo = "";
            $scope.TenNhanVien = "";

            $scope.bangtheongay = true;
            $scope.bangtheomsnv = false;
            $scope.bangtheotennv = false;

            $scope.dateString = dateFilter($scope.ngayxem, 'yyyy-MM-dd');
            var config = {
                params: {
                    ngay: $scope.dateString
                }
            }
            apiService.get('/api/quanlyngaynghi/xemtheongay', config, function (result) {

                $scope.DanhSachTheoNgay = result.data;

            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.getbymsnv = function () {
            $scope.MaSoCoSo = "";
            $scope.TenNhanVien = "";

            $scope.bangtheongay = false;
            $scope.bangtheomsnv = true;
            $scope.bangtheotennv = false;

          
            var config = {
                params: {
                    msnv: $scope.msnv
                }
            }
            apiService.get('/api/quanlyngaynghi/xemtheomsnv', config, function (result) {

                $scope.DanhSachMSNV = result.data;
                if (result.data.length==0) {
                    var config = {
                        params: {
                            msnv: $scope.msnv
                        }
                    }
                    apiService.get('/api/nhanvien/getbymsnv', config, function (result) {

                        $scope.NhanVienKhongCo = result.data;
                       

                    }, function () {
                        console.log('Load  failed.');
                    });
                }

            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.getbytennv = function () {
            $scope.MaSoCoSo = "";
            $scope.TenNhanVien = "";

            $scope.bangtheongay = false;
            $scope.bangtheomsnv = false;
            $scope.bangtheotennv = true;


            var config = {
                params: {
                    tennv: $scope.tennv
                }
            }
            apiService.get('/api/quanlyngaynghi/xemtheotennv', config, function (result) {

                $scope.DanhSachTenNV = result.data;

            }, function () {
                console.log('Load  failed.');
            });
        }


        function GetCoSo() {

            apiService.get('/api/coso/getall', null, function (result) {

                $scope.getALLCoSo = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetCoSo();
        function getTenCoSo() {
            var config = {
                params: {
                    msnv: $scope.authentication.userName
                }
            }
            apiService.get('/api/nhanvien/getbymsnv', config, function (result) {

                $scope.TenCoSo = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        getTenCoSo();
        var currentDate = moment();

        var fnWeekDays = function (dt) {

            var currentDate = dt;
            var weekStart = currentDate.clone().startOf('week');
            var weekEnd = currentDate.clone().endOf('week');

            var days = [];
            for (var i = 0; i <= 6; i++) {

                days.push(moment(weekStart).add(i, 'days').format("DD/MM"));

            };
            return days;
        }
        $scope.weekDays = fnWeekDays(currentDate);


        var nam = new Date().getFullYear();
        var thu2 = function thu2() {
            var split1 = $scope.weekDays[1].split("/");
            var tachchuoi1 = split1[1] + "/" + split1[0]
            var thu2 = new Date(tachchuoi1 + "/" + nam);
            return thu2
        }
        

        var ngayhientai = new Date();
       
        $scope.getAll = [];
        $scope.getbytuan = function () {
            $scope.MaSoCoSo = "";
            $scope.TenNhanVien = "";

            apiService.get('/api/quanlyngaynghi/getall', null, function (result) {

                
                angular.forEach(result.data, function (item) {
                    item.NgayBatDau = new Date(item.NgayBatDau);
                    if (ngayhientai >= item.NgayBatDau && item.NgayBatDau>=thu2()) {
                        $scope.getAll.push(item);
                    }
                })

            }, function () {
                console.log('Load  failed.');
            });
        }
       
       
     
        $scope.getbythang = function () {
            $scope.MaSoCoSo = "";
            $scope.TenNhanVien = "";

            $scope.getAllThang = [];
            $scope.Thang = true;
            var cuoithang = moment($scope.thangxem).endOf('month').format("MM/DD/YYYY");
            var newcuoithang = new Date(cuoithang);
           // alert($scope.thangxem + "  " + newcuoithang);
            apiService.get('/api/quanlyngaynghi/getall', null, function (result) {


                angular.forEach(result.data, function (item) {
                    item.NgayBatDau = new Date(item.NgayBatDau);
                    if (newcuoithang >= item.NgayBatDau && item.NgayBatDau >= $scope.thangxem) {
                        $scope.getAllThang.push(item);
                    }
                })

            }, function () {
                console.log('Load  failed.');
            });
        }


        $scope.xoaTenNhanVien = function () {
            $scope.TenNhanVien = "";

        }
    }    
})(angular.module('platformTH_GV.quanlynhansu'));