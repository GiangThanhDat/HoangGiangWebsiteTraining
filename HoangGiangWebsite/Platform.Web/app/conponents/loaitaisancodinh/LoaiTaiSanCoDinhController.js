(function (app) {
    'use strict';

    app.controller('LoaiTaiSanCoDinhController', LoaiTaiSanCoDinhController);

    LoaiTaiSanCoDinhController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function LoaiTaiSanCoDinhController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.Add = {}
        $scope.getAll = function () {
          
            apiService.get('/api/loaitaisancodinh/getall', null, function (result) {

                $scope.AllFormat = result.data;
                $scope.All = result.data;
                if (result.data.length > 0) {
                    $scope.AllFormat = result.data[result.data.length - 1].MaLoaiTSCD

                } else {
                    $scope.AllFormat = 0;

                }

                var maso = parseInt($scope.AllFormat);

                var str = "" + (maso + 1)
                var pad = "000000"
                var ans = pad.substring(0, pad.length - str.length) + str
                $scope.Add.MaLoaiTSCD = ans;
            }, function () {
                console.log('Load  failed.');
            });

        }
        $scope.thuoc = function () {
            
            apiService.get('/api/taikhoanco/getall', null, function (result) {

                $scope.AllTKco = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }
         $scope.thuoc1 = function () {
            
            apiService.get('/api/taikhoanno/getall', null, function (result) {

                $scope.AllTKno = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }

        $scope.XemChiTiet = function (i) {
            $scope.singer = {}
           
            $('.bs-example-modal-lg').modal('show');
            angular.forEach($scope.All, function (item) {
                if (item.MaLoaiTSCD==i) {
                    $scope.singer = item; 
                }
            })

        }
        $scope.luu = function () {

            $ngBootbox.confirm('Bạn chắc muốn lưu  không').then(function () {

                apiService.put('/api/loaitaisancodinh/update', $scope.singer, function (result) {
                    notificationService.displaySuccess("Cập nhật thành công");
                    $('.bs-example-modal-lg').modal('hide');
                    $scope.getAll();
                    $scope.thuoc();
                    $scope.thuoc1();

                }, function () {
                        notificationService.displayWarning("Cập nhật không thành công");
                });


            });
        }


        $scope.showcreate = function () {
            $('.bs-example-modal-lg1').modal('show');
        }



        $scope.create = function () {

            $ngBootbox.confirm('Bạn chắc muốn thêm không').then(function () {
               
                apiService.post('api/loaitaisancodinh/create', $scope.Add, function (result) {
                    notificationService.displaySuccess('Thêm thành công');
                    $('.bs-example-modal-lg1').modal('hide');
                    $scope.Add = {}
                    $scope.getAll();
                    $scope.All();
                    
                    $scope.thuoc();
                    $scope.thuoc1();
                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });
            });

        }





        $scope.getAll();
        $scope.thuoc();
        $scope.thuoc1();
    }
   
    
})(angular.module('platformTH_GV.loaitaisancodinh'));