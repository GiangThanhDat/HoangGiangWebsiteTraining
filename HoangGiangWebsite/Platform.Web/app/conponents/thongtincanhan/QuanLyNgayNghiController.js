(function (app) {
    app.controller('QuanLyNgayNghiController', QuanLyNgayNghiController);

    function QuanLyNgayNghiController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.QuanLyNgayNghi = [];
        $scope.GetQuanLyNgayNghi = GetQuanLyNgayNghi;
        $scope.UpDateQuanLyNgayNghi = UpDateQuanLyNgayNghi;
       
        $scope.hide = true;
        $scope.close = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;
            $scope.close = false;

        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
            $scope.close = true;
        }

        function GetQuanLyNgayNghi() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/quanlyngaynghi/GetquanLyNgayNghi', config, function (result) {

                $scope.QuanLyNgayNghi = result.data;

                angular.forEach($scope.QuanLyNgayNghi, function (item) {
                    var date1 = new Date(item.NgayBatDau);
                    item.NgayBatDau = $filter('date')(date1, "yyyy-MM-dd");
                    var date2 = new Date(item.NgayKetThuc);
                    item.NgayKetThuc = $filter('date')(date2, "yyyy-MM-dd");
                })

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        function UpDateQuanLyNgayNghi() {
            var a = 0;
            angular.forEach($scope.QuanLyNgayNghi, function (item) {
                var b = new Date(item.NgayBatDau).getTime();
                var c = new Date(item.NgayKetThuc).getTime();
                if (b > c || b == c) {

                    a = 1
                }

            })
            if (a === 1) {
                alert("Ngày bắt đầu phải nhỏ hơn ngày kết thúc")
                //$scope.anmobang = false;
            }
            else if (a != 1) {

                $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                    angular.forEach($scope.QuanLyNgayNghi, function (item) {
                        apiService.put('/api/quanlyngaynghi/update', item, function (result) {
                            notificationService.displaySuccess("Sửa thành công");
                            $scope.GetQuanLyNgayNghi();

                            $scope.hide = true;
                            $scope.Edit = false;
                            $scope.save = false;
                            $scope.close = true;

                            console.log('Sửa thành công.');
                        }, function () {
                            console.log('sửa thông tin không thành công.');
                        });
                    });

                });
            }
        }

        $scope.GetQuanLyNgayNghi();

    }
})(angular.module('platformTH_GV.thongtincanhan'));