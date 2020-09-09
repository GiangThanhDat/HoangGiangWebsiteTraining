(function (app) {
    'use strict';

    app.controller('themKhachHangController', themKhachHangController);

    themKhachHangController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function themKhachHangController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.TTCN = {};
        function getall() {
            apiService.get('/api/khachhang/getall', null, function (result) {
                if (result.data.length>0) {
                    $scope.allNhanVien = result.data[result.data.length - 1].MaKhachHang.split('KH')[1];;
                }
                else {
                    $scope.allNhanVien = 0;
                }
             
                var maso = parseInt($scope.allNhanVien);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "KH"
                var ans = pad.substring(0) + ans1
                

                

                $scope.TTCN = {
                    MaKhachHang: ans
                }
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        function getNhomKH() {
            apiService.get('/api/nhomkh_ncc/getall', null, function (result) {
                $scope.NhomKH = result.data;
                
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getall();
        getNhomKH();
        $scope.addKhachHang= function () {
            $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
                apiService.post('/api/khachhang/create', $scope.TTCN, function (result) {
                    notificationService.displaySuccess("Thêm thành công");
                    getall();
                    }, function () {
                        notificationService.displayWarning('Thêm thất bại');
                    });
                });
        }
        $scope.huy = function () {
            getall();
        }

        
    }

   
    
})(angular.module('platformTH_GV.quanlykhachhang'));