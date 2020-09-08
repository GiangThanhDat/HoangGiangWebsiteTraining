(function (app) {
    'use strict';

    app.controller('themQuanLyNhaCungCapController', themQuanLyNhaCungCapController);

    themQuanLyNhaCungCapController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function themQuanLyNhaCungCapController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.AddNhaCungCap = {};
       
        $scope.getId = function (item) {
            $scope.AddNhaCungCap.NhomKH_NCC = item;


        };
       
        $scope.huy = function () {
            $scope.AddNhaCungCap = {};
            $scope.getId();
            $scope.getAll();
            $scope.getNhomKH_NCC()
            $scope.IdNhomKH = [];


        };
       


        $scope.getAll = function () {
           
            apiService.get('/api/nhacungcap/getall', null, function (result) {
              

                if (result.data.length > 0) {
                    $scope.AllNhaCungCap = result.data[result.data.length - 1].MaNhaCungCap

                } else {
                    $scope.AllNhaCungCap = 0;

                }

                var maso = parseInt($scope.AllNhaCungCap);

                var str = "" + (maso + 1)
                var pad = "0000"
                var ans = pad.substring(0, pad.length - str.length) + str
                $scope.AddNhaCungCap.MaNhaCungCap = ans;
                $scope.getNhomKH_NCC();


            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }

        $scope.getAll();
        
       
       
       
        $scope.getNhomKH_NCC = function () {

            apiService.get('/api/nhomkh_ncc/getall', null, function (result) {
                $scope.NhomKH_NCC = result.data;
                
              

            }, function () {
                console.log('Load Thông tin  failed.');
            });

         }
       
        $scope.update = function () {

            apiService.post('/api/nhacungcap/create', $scope.AddNhaCungCap, function (result) {
                $scope.AddNhaCungCap = {};
                $scope.getId();
                $scope.getAll();
                $scope.getNhomKH_NCC()
                $scope.IdNhomKH = [];
                alert("Thêm Thành công")

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
      
      

    }


})(angular.module('platformTH_GV.themquanlynhacungcap'));