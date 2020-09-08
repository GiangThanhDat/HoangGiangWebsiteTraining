(function (app) {
    'use strict';

    app.controller('LoaiCongCuDungCuController', LoaiCongCuDungCuController);

    LoaiCongCuDungCuController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function LoaiCongCuDungCuController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.Add = {}
        $scope.getAll = function () {
          
            apiService.get('/api/loaicongcudungcu/getall', null, function (result) {

                $scope.AllView = result.data;
                $scope.All = result.data;
                if (result.data.length > 0) {
                    $scope.All = result.data[result.data.length - 1].MaLoaiCCDC

                } else {
                    $scope.All = 0;

                }

                var maso = parseInt($scope.All);

                var str = "" + (maso + 1)
                var pad = "000000"
                var ans = pad.substring(0, pad.length - str.length) + str
                $scope.Add.MaLoaiCCDC = ans;
            
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

        $scope.XemChiTiet = function (i) {
            $scope.singer = {}
            $('.bs-example-modal-lg').modal('show');
          var  index=i
            angular.forEach($scope.AllView, function (item) {
                if (item.MaLoaiCCDC === index) {
                    $scope.singer=item
                }

            })

        }
         $scope.save = function (i) {
             $ngBootbox.confirm('Bạn chắc muốn sửa không').then(function () {
              
                 apiService.put('api/loaicongcudungcu/update', $scope.singer, function (result) {
                     notificationService.displaySuccess('Sửa thành công');
                     $('.bs-example-modal-lg').modal('hide');
                    
                     $scope.All();
                     }, function () {
                         notificationService.displaySuccess('Xóa không thành công');
                     });
                 });
            
         }

        $scope.showcreate = function () {
            $('.bs-example-modal-lg1').modal('show');
        }



        $scope.create = function () {
          
             $ngBootbox.confirm('Bạn chắc muốn thêm không').then(function () {

                 apiService.post('api/loaicongcudungcu/create', $scope.Add, function (result) {
                     notificationService.displaySuccess('Thêm thành công');
                     $('.bs-example-modal-lg1').modal('hide');
                     $scope.getAll();
                     $scope.All();
                     }, function () {
                         notificationService.displaySuccess('Thêm không thành công');
                     });
                 });
            
         }




        $scope.getAll();
        $scope.thuoc();
    }


})(angular.module('platformTH_GV.loaicongcudungcu'));