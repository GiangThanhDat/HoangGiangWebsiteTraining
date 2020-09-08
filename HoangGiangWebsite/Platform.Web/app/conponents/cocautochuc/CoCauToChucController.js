(function (app) {
    'use strict';

    app.controller('CoCauToChucController', CoCauToChucController);

    CoCauToChucController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function CoCauToChucController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.Add = {}
        $scope.getAll = function () {

            apiService.get('/api/cocautochuc/getall', null, function (result) {

                $scope.AllView = result.data;
                $scope.All = result.data;
                if (result.data.length > 0) {
                    $scope.All = result.data[result.data.length - 1].MaDonVi

                } else {
                    $scope.All = 0;

                }

                var maso = parseInt($scope.All);

                var str = "" + (maso + 1)
                var pad = "000000"
                var ans = pad.substring(0, pad.length - str.length) + str
                $scope.Add.MaDonVi = ans;

            }, function () {
                console.log('Load  failed.');
            });

        }
       
        $scope.XemChiTiet = function (i) {
            $scope.singer = {}
            $('.bs-example-modal-lg').modal('show');
            var index = i
            angular.forEach($scope.AllView, function (item) {
                if (item.MaDonVi === index) {
                    $scope.singer = item
                }

            })

        }
        $scope.save = function (i) {
            $ngBootbox.confirm('Bạn chắc muốn sửa không').then(function () {

                apiService.put('api/cocautochuc/update', $scope.singer, function (result) {
                    notificationService.displaySuccess('Sửa thành công');
                    $('.bs-example-modal-lg').modal('hide');

                    $scope.All();
                }, function () {
                    notificationService.displaySuccess('Sửa không thành công');
                });
            });

        }

        $scope.showcreate = function () {
            $('.bs-example-modal-lg1').modal('show');
        }



        $scope.create = function () {

            $ngBootbox.confirm('Bạn chắc muốn thêm không').then(function () {

                apiService.post('api/cocautochuc/create', $scope.Add, function (result) {
                    notificationService.displaySuccess('Thêm thành công');
                    $('.bs-example-modal-lg1').modal('hide');
                    $scope.Add = {}
                    $scope.getAll();
                  
                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });
            });

        }




        $scope.getAll();
      
    }


})(angular.module('platformTH_GV.cocautochuc'));