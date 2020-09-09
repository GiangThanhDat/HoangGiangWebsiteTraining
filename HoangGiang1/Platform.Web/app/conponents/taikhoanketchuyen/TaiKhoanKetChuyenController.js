(function (app) {
    'use strict';

    app.controller('TaiKhoanKetChuyenController', TaiKhoanKetChuyenController);

    TaiKhoanKetChuyenController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function TaiKhoanKetChuyenController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.Add = {}
        $scope.singer = {}
        $scope.getAll = function () {

            apiService.get('/api/taikhoanketchuyen/getall', null, function (result) {

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
                if ($scope.singer.NgungTheoDoi == true) {
                    document.getElementById("edit").checked = true;
                }
                else if ($scope.singer.NgungTheoDoi == false) {
                    document.getElementById("edit").checked = false;
                }
            })
            document.getElementById('edit').onclick = function () {
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
               
                apiService.put('api/taikhoanketchuyen/update', $scope.singer, function (result) {
                    notificationService.displaySuccess('Sửa thành công');
                    $('.bs-example-modal-lg').modal('hide');

                    $scope.All();
                }, function () {
                    notificationService.displaySuccess('Sửa không thành công');
                });
            });

        }
        //$scope.changeNgungTheoDoi = function (i,index) {
        //    $scope.changedata = {}
        //    alert(index)
        //        angular.forEach($scope.AllView, function (item) {
        //            if (item.Id === i) {
        //                $scope.changedata = item
        //            }
                    
        //        })
        //        document.getElementById('change').onclick = function () {
        //            if (this.checked) {
        //                $scope.changedata.NgungTheoDoi = true

        //            }
        //            else {
        //                $scope.changedata.NgungTheoDoi = false
        //            }
        //        };

        //        apiService.put('api/taikhoanketchuyen/update', $scope.changedata, function (result) {
        //            notificationService.displaySuccess('Sửa thành công');
        //            $scope.All();

                   
        //        }, function () {
        //            notificationService.displaySuccess('Sửa không thành công');
        //        });
          

        //}

       


        $scope.showcreate = function () {
            $('.bs-example-modal-lg1').modal('show');
        }



        $scope.create = function () {

            $ngBootbox.confirm('Bạn chắc muốn thêm không').then(function () {

                apiService.post('api/taikhoanketchuyen/create', $scope.Add, function (result) {
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


})(angular.module('platformTH_GV.taikhoanketchuyen'));