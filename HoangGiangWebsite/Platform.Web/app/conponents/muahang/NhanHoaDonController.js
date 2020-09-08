(function (app) {
    'use strict';

    app.controller('NhanHoaDonController', NhanHoaDonController);

    NhanHoaDonController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService','$http'];
    function NhanHoaDonController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http) {
        $scope.openmodal = function () {
            $('.bs-example-modal-lg').modal('show');
            // window.open('https://localhost:44308/admin#/themphieuthu', '_blank', 'width=500, height=400')

        }
        $scope.openmodal();
        //#region
       
        $scope.PhieuThu = {

            NgayHoachToan: new Date(),
            NgayChungTu: new Date(),
            
        }

        //#region
        function getallNCC() {
            apiService.get('/api/nhacungcap/getall', null, function (result) {
                $scope.AllNCC = result.data;
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getallNCC()
        function getPhieuThu() {
            apiService.get('/api/tralaihangmua/getall', null, function (result) {
                if (result.data.length > 0) {
                    $scope.maphieuthu = result.data[result.data.length - 1].MaTraLaiHangMua;
                }
                else {
                    $scope.maphieuthu = 0;
                }


                var maso = parseInt($scope.maphieuthu);

                var str = "" + (maso + 1)
                var pad1 = "0000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                //var pad = "NK"
                //var ans = pad.substring(0) + ans1
                //alert(ans);
                $scope.PhieuThu.MaTraLaiHangMua = ans1

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getPhieuThu();
        //#endregion
       
        $scope.LuuPhieuThu = function () {
            
            $ngBootbox.confirm('Bạn chắc muốn lưu  không').then(function () {

                apiService.post('/api/tralaihangmua/create', $scope.PhieuThu, function (result) {
                    notificationService.displaySuccess("Lưu thành công");
                    apiService.post('/api/chitiettralaihangmua/create', $scope.ChiTietThu, function (result) {
                            notificationService.displaySuccess("Lưu chi tiết thành công");

                        }, function () {
                            notificationService.displayWarning("Lưu chi tiết không thành công");

                        });
                   
                    $scope.PhieuThu = {
                        NgayHoachToan: new Date(),
                        NgayChungTu: new Date(),
                    }
                    
                    $scope.getAllNCC();
                    $scope.ChiTietThu = [];
                    getPhieuThu();

                }, function () {
                    notificationService.displayWarning("Lưu không thành công");
                });


            });
        }
     
    }


})(angular.module('platformTH_GV.muahang'));