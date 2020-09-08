(function (app) {
    app.controller('QuanLyCongTacController', QuanLyCongTacController);

    function QuanLyCongTacController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.QuanLyCongTac = [];
        $scope.QuanLyCongTacAdd = { MaSoNhanVien: $scope.msvc };
        $scope.AddQuanLYCongTac = AddQuanLYCongTac;
        $scope.GetQuanLyCongTac = GetQuanLyCongTac;
        $scope.UpDateQuanLyCongTac = UpDateQuanLyCongTac;
        $scope.hide = true;
        $scope.anmobang = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;
            $scope.anmobang = false;



        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
            $scope.anmobang = true;
        }

        function AddQuanLYCongTac() {
            if ($scope.QuanLyCongTacAdd.NgayBatDau >= $scope.QuanLyCongTacAdd.NgayKetThuc) {
                alert("Thêm ngày bắt đầu phải lớn hơn ngày kết thúc");
            }
            else if ($scope.QuanLyCongTacAdd.NgayBatDau == null || $scope.QuanLyCongTacAdd.NgayKetThuc == null) {
                alert("Ngày bắt đầu và năm kết thúc không được bỏ trống");

            }
            else if ($scope.QuanLyCongTacAdd.GioBatDau == null || $scope.QuanLyCongTacAdd.GioKetThuc == null) {
                alert("Giờ bắt đầu và Giờ kết thúc không được bỏ trống");

            }
            else {

            apiService.post('/api/quanlycongtac/create', $scope.QuanLyCongTacAdd, function (result) {
                notificationService.displaySuccess("Thêm thành công");
                $scope.GetQuanLyCongTac();
                $scope.QuanLyCongTacAdd = { MaSoNhanVien: $scope.msvc };

            }, function () {
                notificationService.displaySuccess('Thêm không thành công');
            });
            }
        }


        function GetQuanLyCongTac() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/quanlycongtac/GetquanLyCongTac', config, function (result) {

               
                if (result.data.length > 0) {
                    $scope.QuanLyCongTac = result.data;
                    $scope.anmobang = true;
                }
                else {
                    $scope.anmobang = false;
                }


                angular.forEach($scope.QuanLyCongTac, function (item) {
                    var date1 = new Date(item.NgayBatDau);
                    item.NgayBatDau = $filter('date')(date1, "yyyy-MM-dd");
                    var date2 = new Date(item.NgayKetThuc);
                    item.NgayKetThuc = $filter('date')(date2, "yyyy-MM-dd");
                })

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        function UpDateQuanLyCongTac() {
            var a = 0;
            angular.forEach($scope.QuanLyCongTac, function (item) {
                var b = new Date(item.NgayBatDau).getTime();
                var c = new Date(item.NgayKetThuc).getTime();
                if (b>c||b==c) {
                  
                    a=1
                }
                
            })
            if (a === 1) {
                alert("Ngày bắt đầu phải nhỏ hơn ngày kết thúc")
                $scope.anmobang = false;
            }
            else if (a != 1) { 
            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                angular.forEach($scope.QuanLyCongTac, function (item) {
                    apiService.put('/api/quanlycongtac/update', item, function (result) {
                        notificationService.displaySuccess("Sửa thành công");
                        $scope.GetQuanLyCongTac();
                        $scope.anmobang = true;
                        $scope.save = false;
                        $scope.hide = !$scope.hide;
                        $scope.Edit = !$scope.Edit
                        console.log('Sửa thành công.');
                    }, function () {
                        console.log('sửa thông tin không thành công.');
                    });
                });

            });
            }

        }

        $scope.GetQuanLyCongTac();

    }
})(angular.module('platformTH_GV.thongtincanhan'));