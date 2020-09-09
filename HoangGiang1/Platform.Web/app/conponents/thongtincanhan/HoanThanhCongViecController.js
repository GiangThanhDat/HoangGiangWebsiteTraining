(function (app) {
    app.controller('HoanThanhCongViecController', HoanThanhCongViecController);
  
    HoanThanhCongViecController.$inject = ['$scope', 'apiService', '$stateParams', '$window', 'notificationService', '$ngBootbox', '$filter'];

    function HoanThanhCongViecController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tenNhanVien = $scope.authentication.fullName;
        $scope.HoanThanhCongViec = [];
        $scope.GetHoanThanhCongViec = GetHoanThanhCongViec;
        $scope.UpDateHoanThanhCongViec = UpDateHoanThanhCongViec;   

        function GetHoanThanhCongViec() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/hoanthanhcongviec/GetHoanThanhCongViec', config, function (result) {

                $scope.HoanThanhCongViec = result.data;
                angular.forEach($scope.HoanThanhCongViec, function (item) {
                    var date1 = new Date(item.NgayBatDau);
                    item.NgayBatDau = $filter('date')(date1, "yyyy-MM-dd");
                    var date2 = new Date(item.NgayKetThuc);
                    item.NgayKetThuc = $filter('date')(date2, "yyyy-MM-dd");
                })

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        function UpDateHoanThanhCongViec() {
            var a = 0;
            angular.forEach($scope.HoanThanhCongViec, function (item) {
                var b = new Date(item.NgayBatDau).getTime();
                var c = new Date(item.NgayKetThuc).getTime();
                if (b > c || b == c) {

                    a = 1
                }

            })
            if (a === 1) {
                alert("Ngày bắt đầu phải nhỏ hơn ngày kết thúc")
              
            }
            else if (a != 1) {

                $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                    angular.forEach($scope.HoanThanhCongViec, function (item) {
                        apiService.put('/api/hoanthanhcongviec/update', item, function (result) {
                            notificationService.displaySuccess("Sửa thành công");
                            $scope.GetHoanThanhCongViec();
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
            $scope.GetHoanThanhCongViec()
        }


        $scope.GetHoanThanhCongViec();
    }
})(angular.module('platformTH_GV.thongtincanhan'));