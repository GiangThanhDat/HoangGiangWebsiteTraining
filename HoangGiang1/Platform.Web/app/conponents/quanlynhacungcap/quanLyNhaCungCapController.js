(function (app) {
    'use strict';

    app.controller('quanLyNhaCungCapController', quanLyNhaCungCapController);

    quanLyNhaCungCapController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function quanLyNhaCungCapController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.FilterTenNhaCungcap = {};
        $scope.view = true



        $scope.thaydoithongtin = function () {

            $scope.view = false
            $scope.edit = true

        }
        $scope.huy = function () {

            $scope.view = true
            $scope.edit = false
            $scope.getTenNhaCungcap($scope.item)

        }
        $scope.trove = function () {

            $scope.AllTenNhaCungcap = false
            $scope.hideAll = true

        }

        $scope.GetAllNhaCungCap = function () {
         
          
          
            apiService.get('/api/nhacungcap/getall', null, function (result) {

                $scope.NhaCungCapAll = result.data;
                $scope.hideAll = true
                $scope.AllTenNhaCungcap = false
               

              

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.getTenNhaCungcap = function (item) {
            $scope.item = item
             var config = {
                 params: {
                     name: item
                 }
             }
             apiService.get('/api/nhacungcap/getThongTinNhaCungCap', config, function (result) {

                 $scope.FilterTenNhaCungcap = result.data;
                 $scope.AllTenNhaCungcap = true
                 $scope.hideAll = false

                 $scope.view = true

            }, function () {
                console.log('Load Thông tin  failed.');
            });

         }
        $scope.update = function () {

             apiService.put('/api/nhacungcap/update', $scope.FilterTenNhaCungcap, function (result) {

                 alert("Update Thành công")
                 $scope.edit = false
                 $scope.view = true

            }, function () {
                console.log('Load Thông tin  failed.');
            });

         }

        $scope.getbykeyword = function (keyword) {
            $scope.hideAll = true;
            $scope.AllTenNhaCungcap = false;

            $scope.NhaCungCapAll = [];
            var config = {
                params: {
                    name: keyword
                }
            }
            apiService.get('/api/nhacungcap/search', config, function (result) {

                $scope.NhaCungCapAll = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }

      

    }


})(angular.module('platformTH_GV.quanlynhacungcap'));