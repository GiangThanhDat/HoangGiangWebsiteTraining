(function (app) {
    'use strict';

    app.controller('NhomKH_NCCController', NhomKH_NCCController);

    NhomKH_NCCController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function NhomKH_NCCController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.bangxem = false;
        $scope.bangchitiet = false;
        $scope.TTCN = {};
        $scope.gettatca = function () {
            $scope.KhachHang = [];
            $scope.NhomKH_NCC ="";
            $scope.PhanLoai ="";
            $scope.bangxem = true;
            $scope.bangchitiet = false;

            apiService.get('/api/nhomkh_ncc/getall', null, function (result) {

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
            apiService.get('/api/nhomkh_ncc/getbykeyword', config, function (result) {

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
            apiService.get('/api/nhomkh_ncc/getbyid', config, function (result) {

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
               
                apiService.put('/api/nhomkh_ncc/update', $scope.TTCN, function (result) {
                    notificationService.displaySuccess("Sửa thành công");
                    $scope.getTTCN($scope.id);
                    $scope.view = !$scope.view;
                    $scope.edit = !$scope.edit
                    $scope.gettatca()
                }, function () {
                   notificationService.displayWarning("Sửa không thành công");
                });


            });

        }
      
        $scope.addKhachHang = function () {


            $ngBootbox.confirm('Bạn chắc muốn sửa  không').then(function () {

                apiService.post('/api/nhomkh_ncc/create', $scope.addKH, function (result) {
                    notificationService.displaySuccess("Thêm thành công");
                    $scope.gettatca();
                    $scope.addKH = {}
                   
                }, function () {
                        notificationService.displayWarning("Thêm không thành công");
                });


            });

        }
    }
   
    
})(angular.module('platformTH_GV.doituong'));