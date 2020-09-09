(function (app) {
    'use strict';

    app.controller('ThietLapGiaController', ThietLapGiaController);

    ThietLapGiaController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService', '$http'];
    function ThietLapGiaController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http, $mdToast, $log) {

        $scope.TatCaHangHoa = [];
        //$scope.BangThietLap = true;
        $scope.edit_view = true;
        $scope.update_view = false;
        $scope.close_view = false;

        $scope.DuaTatCaHangHoaVaoBangThietLap = function () {
            apiService.get('/api/hangHoa/GetHangHoaForThietLap', null, function (DanhSachHoangHoa) {
                $scope.TatCaHangHoa = DanhSachHoangHoa.data;
                angular.forEach($scope.TatCaHangHoa,function (item) {
                    item.DonViTinh = item.getdvt[0];
                    item.MaDonViTinh = item.getdvt[0].MaDonViTinh;
                });
                console.log($scope.TatCaHangHoa);

            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.DuaTatCaHangHoaVaoBangThietLap();
        $scope.adddvt = function (i, index) {
            $scope.TatCaHangHoa[index].MaDonViTinh = i;
        }

        //$scope.editClick = function () {
        //    $scope.edit_view = false;
        //    $scope.view = false;
        //    $scope.update_view = true;
        //    $scope.close_view = true;
        //    $scope.edit = true;            
        //}

        $scope.thutu;

        $scope.show = function (item) {
            $scope.thutu = item;
            return $scope.thutu;
        }

        $scope.closeClick = function () {
            //$scope.update_view = false;
            //$scope.close_view = false;
            //$scope.edit_view = true;
            //$scope.view = true;
            //$scope.edit = false;
            $scope.thutu = -1;
        }

        $scope.Update = function (item) {
            item.MaDonViTinh = item.DonViTinh.MaDonViTinh;
            item.DonGia = item.DonViTinh.DonGia;
            console.log(item);

            apiService.put('/api/hanghoa_donvitinh/update', item, function () {
                alert("thành công");
                $scope.DuaTatCaHangHoaVaoBangThietLap();

            }, function () {
                    console.log("that bai");
            })
            $scope.closeClick();
        }



        $scope.getnhomHang = function () {
            apiService.get('/api/nhomhanghoa/getall', null, function (result) {
                $scope.getAllNhomHangHoa = result.data;
            }, function () {
                console.log('Load  failed.');
            });


        }
        $scope.gettinhchathanghoa = function () {
            apiService.get('/api/tinhchathanghoa/getall', null, function (result) {
                $scope.getAlltinhchathanghoa = result.data;
            }, function () {
                console.log('Load  failed.');
            });


        }


       
    }

})(angular.module('platformTH_GV.thongkehanghoa'));


