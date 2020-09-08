(function (app) {
    'use strict';

    app.controller('quanLyKhachhangController', quanLyKhachhangController);

    quanLyKhachhangController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function quanLyKhachhangController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.bangxem = false;
        $scope.bangchitiet = false;
        $scope.TTCN = {};


        $scope.gettatca = function () {
            $scope.KhachHang = [];
            $scope.bangxem = true;
            $scope.bangchitiet = false;

            apiService.get('/api/khachhang/getall', null, function (result) {

                $scope.KhachHang = result.data;
                
            }, function () {
                console.log('Load  failed.');
            });

        }

        $scope.getbykeyword = function (keyword) {
            $scope.bangxem = true;
            $scope.bangchitiet = false;

            $scope.KhachHang = [];
            var config = {
                params: {
                    keyword: keyword
                }
            }
            apiService.get('/api/khachhang/getbykeyword', config, function (result) {

                $scope.KhachHang = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }


        $scope.getTTCN = function (id) {
            $scope.id = id;
            $scope.bangxem = false;
            $scope.bangchitiet = true;
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/khachhang/getbyid', config, function (result) {

                $scope.TTCN = result.data;

            }, function () {
                console.log('Load  failed.');
            });
        }


        $scope.trove = function () {
            $scope.bangxem = true;
            $scope.bangchitiet = false;
        }


        $scope.view = true;
        $scope.edit = false;

        $scope.thaydoithongtin = function () {
            $scope.view = false;
            $scope.edit = true;
        }
        $scope.huy = function () {
            $scope.view = true;
            $scope.edit = false;
            $scope.getTTCN($scope.id);
        }


        $scope.updateTTCN=function () {

            $ngBootbox.confirm('Bạn chắc muốn sửa  không').then(function () {
                if ($scope.TTCN.NhomKH_NCC=="") {
                    $scope.TTCN.NhomKH_NCC = null;
                }
                apiService.put('/api/khachhang/update', $scope.TTCN, function (result) {
                    notificationService.displaySuccess("Sửa thành công");
                    $scope.getTTCN($scope.id);
                    $scope.view = !$scope.view;
                    $scope.edit = !$scope.edit
                }, function () {
                   notificationService.displayWarning("Sửa không thành công");
                });


            });

        }
        function getNhomKH() {
            apiService.get('/api/nhomkh_ncc/getall', null, function (result) {
                $scope.NhomKH = result.data;
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        getNhomKH();

    }
   
    
})(angular.module('platformTH_GV.quanlykhachhang'));