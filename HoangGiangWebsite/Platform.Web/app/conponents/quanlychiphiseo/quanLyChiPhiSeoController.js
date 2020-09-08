
(function (app) {
    'use strict';

    app.controller('quanLyChiPhiSeoController', quanLyChiPhiSeoController);

    quanLyChiPhiSeoController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function quanLyChiPhiSeoController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.ChiTietCoSo = {};
        $scope.bangchitiet = false;
        $scope.view = true;
        $scope.edit = false;

        $scope.gettatca = function () {
            $scope.CoSo = [];
            $scope.bangxem = true;
            $scope.bangchitiet = false;
            apiService.get('/api/coso/getall', null, function (result) {
                console.log(result.data);
                $scope.CoSo = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }



        $scope.getbykeyword = function (keyword) {
            $scope.bangxem = true;
            $scope.bangchitiet = false;

            $scope.CoSo = [];
            var config = {
                params: {
                    keyword: keyword
                }
            }

            apiService.get('/api/coso/getbykeyword', config, function (result) {
                console.log(result.data);
                $scope.CoSo = [];
                $scope.CoSo = result.data;

            }, function () {
                console.log('Load  failed.');
            });
        }

        $scope.GetThongTinChiTietCoSo = function (id) {
            $scope.id = id;
            $scope.bangxem = false;
            $scope.bangchitiet = true;
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/coso/getbyid', config, function (result) {
                $scope.ChiTietCoSo = result.data;
                console.log($scope.ChiTietCoSo);
            }, function () {
                console.log('Load  failed.');
            });
        }


        //xử lý cho các nút
        $scope.trove = function () {
            $scope.bangxem = true;
            $scope.bangchitiet = false;
        }


        $scope.thaydoithongtin = function () {
            $scope.view = false;
            $scope.edit = true;
        }


        $scope.huy = function () {
            $scope.view = true;
            $scope.edit = false;
            $scope.GetThongTinChiTietCoSo($scope.id);
        }

        $scope.Update = function () {
            $ngBootbox.confirm('Bạn chắc muốn sửa không').then(function () {
                apiService.put('/api/coso/update', $scope.ChiTietCoSo, function (result) {
                    notificationService.displaySuccess("Sửa thành công");
                    $scope.GetThongTinChiTietCoSo($scope.id);
                    $scope.view = !$scope.view;
                    $scope.edit = !$scope.edit
                }, function () {
                    notificationService.displayWarning("Sửa không thành công");
                });
            });
        }

        $scope.remove() = function () {
            $ngBootbox.confirm('Bạn chắc muốn sửa  không').then(function () {
                apiService.put('/api/coso/update', $scope.ChiTietCoSo, function (result) {
                    notificationService.displaySuccess("Sửa thành công");
                    $scope.GetThongTinChiTietCoSo($scope.id);
                    $scope.view = !$scope.view;
                    $scope.edit = !$scope.edit
                }, function () {
                    notificationService.displayWarning("Sửa không thành công");
                });
            });
        }

    }
})(angular.module('platformTH_GV.quanlychiphiseo'));