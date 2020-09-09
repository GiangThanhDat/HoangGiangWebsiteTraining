(function (app) {
    'use strict';

    app.controller('DinhKhoanTuDongController', DinhKhoanTuDongController);

    DinhKhoanTuDongController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function DinhKhoanTuDongController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.Add = {}
        $scope.getAll = function () {

            apiService.get('/api/dinhkhoantudong/getall', null, function (result) {

                $scope.AllView = result.data;


            }, function () {
                console.log('Load  failed.');
            });

        }

        $scope.thuoc = function () {
            //var config = {
            //    params: {
            //        machungtu: index
            //    }
            //}
            apiService.get('/api/taikhoanco/getall', null, function (result) {

                $scope.AllTKco = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }
         $scope.thuoc1 = function () {
            //var config = {
            //    params: {
            //        machungtu: index
            //    }
            //}
            apiService.get('/api/taikhoanno/getall', null, function (result) {

                $scope.AllTKno = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }

        $scope.XemChiTiet = function (i) {
            $scope.singer = {}
            $('.bs-example-modal-lg').modal('show');
            var index = i
            angular.forEach($scope.AllView, function (item) {
                if (item.Id === index) {
                    $scope.singer = item
                }

            })

        }
        $scope.save = function (i) {
            $ngBootbox.confirm('Bạn chắc muốn sửa không').then(function () {

                apiService.put('api/dinhkhoantudong/update', $scope.singer, function (result) {
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

                apiService.post('api/dinhkhoantudong/create', $scope.Add, function (result) {
                    notificationService.displaySuccess('Thêm thành công');
                    $('.bs-example-modal-lg1').modal('hide');
                    $scope.Add = {}
                    $scope.getAll();

                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });
            });

        }
       
        $scope.huy = function (i) {
            $scope.AllView=[]
            $scope.getAll();
            $scope.singer = {}
            $scope.Add = {}
           

        }


        $scope.getAll();
        $scope.thuoc();
        $scope.thuoc1();
    }


})(angular.module('platformTH_GV.dinhkhoantudong'));