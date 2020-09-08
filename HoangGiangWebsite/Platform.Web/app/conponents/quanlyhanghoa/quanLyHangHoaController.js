(function (app) {
    'use strict';

    app.controller('quanLyHangHoaController', quanLyHangHoaController);

    quanLyHangHoaController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function quanLyHangHoaController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.Add = {}
        $('.bs-example-modal-lg1').modal('show');
        $scope.getAll = function () {

            apiService.get('/api/hanghoa/getall', null, function (result) {

                
                $scope.All = result.data;
                if (result.data.length > 0) {
                    $scope.All = result.data[result.data.length - 1].MaHang

                } else {
                    $scope.All = 0;

                }

                var maso = parseInt($scope.All);

                var str = "" + (maso + 1)
                var pad = "000000000000"
                var ans = pad.substring(0, pad.length - str.length) + str
                $scope.Add.MaHang = ans;

            }, function () {
                console.log('Load  failed.');
            });

        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.Add.HinhAnh = fileUrl;
            }
            finder.popup();
          


        }


        $scope.getnhomHang = function () {
            apiService.get('/api/nhomhanghoa/getall', null, function (result) {
                $scope.getAllNhomHangHoa = result.data;
            }, function () {
                console.log('Load  failed.');
            });


        }
        $scope.gettinhchathanghoa = function () {
            apiService.get('/api/tinhchathanghoa/getall', null, function (result) {
                $scope.getAlltinhchathanghoa = result.data;
            }, function () {
                console.log('Load  failed.');
            });


        }
        $scope.addHangHoa = function () {
            $ngBootbox.confirm('Bạn chắc muốn thêm không').then(function () {

                apiService.post('api/hanghoa/create', $scope.Add, function (result) {
                    notificationService.displaySuccess('Thêm thành công');
                    $('.bs-example-modal-lg1').modal('hide');
                    $scope.Add = {}
                    $scope.getAll();

                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });
            });



        }
        $scope.huy = function () {
            $scope.Add = {}
            $scope.getAll();
            $('.bs-example-modal-lg1').modal('hide');
        }
        $scope.getAll();
        $scope.getnhomHang()
        $scope.gettinhchathanghoa()
    }
   
    
})(angular.module('platformTH_GV.quanlyhanghoa'));