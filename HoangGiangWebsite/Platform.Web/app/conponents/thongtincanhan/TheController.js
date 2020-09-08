(function (app) {
    app.controller('TheController', TheController);

    function TheController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.The = [];
        $scope.GetThe = GetThe;
        $scope.UpDateThe = UpDateThe;
        $scope.hide = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;

        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
        }

        function GetThe() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/the/Getthe', config, function (result) {

                $scope.The = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        function UpDateThe() {


            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                angular.forEach($scope.The, function (item) {
                    apiService.put('/api/the/update', item, function (result) {
                        notificationService.displaySuccess("Sửa thành công");
                        $scope.GetThe();

                        $scope.hide = !$scope.hide;
                        $scope.Edit = !$scope.Edit
                        console.log('Sửa thành công.');
                    }, function () {
                        console.log('sửa thông tin không thành công.');
                    });
                });

            });

        }
        $scope.GetThe();
    }
})(angular.module('platformTH_GV.thongtincanhan'));