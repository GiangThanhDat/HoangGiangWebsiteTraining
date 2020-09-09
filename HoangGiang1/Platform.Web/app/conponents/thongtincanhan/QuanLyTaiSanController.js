
    (function (app) {
        app.controller('QuanLyTaiSanController', QuanLyTaiSanController);

        function QuanLyTaiSanController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
            
            $scope.maNhanVien = $scope.authentication.userName;
            $scope.getQuanLyTaiSanCaNhan = function () {

                var config = {
                    params: {
                        msnv: $scope.maNhanVien
                    }
                }

                apiService.get('/api/quanlytaisan/getQuanLyTaiSanCaNhan', config, function (result) {

                    $scope.ThongKeTaiSan = result.data;
                   

                }, function () {
                    console.log('Load Thông tin  failed.');
                });

            }


            $scope.GetCoSo = function () {
                var config = {
                    params: {
                        msnv: $scope.maNhanVien
                    }
                }
                apiService.get('/api/coso/getTenCoSo', config, function (result) {

                    $scope.CoSo = result.data;


                }, function () {
                    console.log('Load Thông tin  failed.');
                });

            }


            $scope.getQuanLyTaiSanCaNhan();
            $scope.GetCoSo();
          





        }
    })(angular.module('platformTH_GV.thongtincanhan'));