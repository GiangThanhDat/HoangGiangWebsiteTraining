(function (app) {
    app.controller('thongBaoController', thongBaoController);

    function thongBaoController($scope, apiService, $stateParams) {
        $scope.thongBao = [];
        $scope.MaSoTB = $stateParams.MaSoTB;


        $scope.getChiTietThongBao = getChiTietThongBao;


        function getChiTietThongBao() {
            var config = {
                params: {
                    MaSoTB: $scope.MaSoTB
                }
            }
            apiService.get('/api/ThongBao/chitietTB/', config, function (result) {
                $scope.thongBao = result.data;
            }, function () {
                console.log('Load thông tin failed.');
            });

        }
        $scope.getChiTietThongBao();

    }
})(angular.module('platformTH_GV.thongbao'));