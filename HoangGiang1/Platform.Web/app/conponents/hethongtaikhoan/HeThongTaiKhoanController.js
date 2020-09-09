(function (app) {
    'use strict';

    app.controller('HeThongTaiKhoanController', HeThongTaiKhoanController);

    HeThongTaiKhoanController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function HeThongTaiKhoanController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.Add = {}
        $scope.singer = {}
        $scope.getAll = function () {

            apiService.get('/api/hethongtaikhoan/getall', null, function (result) {

                $scope.AllView = result.data;
               

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
           
            if ($scope.singer.NgungTheoDoi == true) {
                     document.getElementById("edit").checked = true;
                 }
            else if ($scope.singer.NgungTheoDoi == false) {
                     document.getElementById("edit").checked = false;
            }

            document.getElementById('edit').onclick = function (e) {
                if (this.checked) {
                    $scope.singer.NgungTheoDoi = true

                }
                else {
                    $scope.singer.NgungTheoDoi = false
                }
            };
               
          

        }
        $scope.save = function (i) {
            $ngBootbox.confirm('Bạn chắc muốn sửa không').then(function () {

                apiService.put('api/hethongtaikhoan/update', $scope.singer, function (result) {
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

                apiService.post('api/hethongtaikhoan/create', $scope.Add, function (result) {
                    notificationService.displaySuccess('Thêm thành công');
                    $('.bs-example-modal-lg1').modal('hide');
                    $scope.Add = {}
                    $scope.getAll();

                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });
            });

        }
        document.getElementById('action').onclick = function (e) {
            if (this.checked) {
                $scope.Add.NgungTheoDoi = true

            }
            else {
                $scope.Add.NgungTheoDoi = false
            }
        };

        $scope.huy = function () {
            $scope.getAll();
            $scope.singer = {}
            $scope.Add = {}
           

        }

        $scope.getAll();

    }


})(angular.module('platformTH_GV.hethongtaikhoan'));