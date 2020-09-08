
(function (app) {
    'use strict';

    app.controller('themcosoController', themcosoController);

    themcosoController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function themcosoController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.coSoObj = {}
        $('.bs-example-modal-lg1').modal('show');
        
        $scope.getListObj = function () {

            apiService.get('/api/coso/getAll', null, function (result) {

                $scope.ListObj = result.data;
                if (result.data.length > 0) {
                    var MaCoSo = result.data[result.data.length - 1].MaCoSo
                } else {
                    MaCoSo = 0;
                }

                var maso = parseInt(MaCoSo);

                var str = "" + (maso + 1);
                var pad = "000";
                var ans = pad.substring(0, pad.length - str.length) + str;
                $scope.coSoObj.MaCoSo = ans;
                console.log($scope.coSoObj);
            }, function () {
                console.log('Load  failed.');
            });

        }

 
        $scope.addCoSo = function () {
            $ngBootbox.confirm('Bạn chắc muốn thêm không').then(function () {
                console.log($scope.coSoObj);
                apiService.post('api/coso/create', $scope.coSoObj, function (result) {
                    notificationService.displaySuccess('Thêm thành công');
                    console.log($scope.coSoObj);
                    $('#themCoSoModal').modal('hide');
                    $scope.coSoObj = {}
                    $scope.getListObj();

                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });
            });



        }
        $scope.huy = function () {
            $scope.coSoObj = {}
            $scope.getListObj();
            $('.bs-example-modal-lg1').modal('hide');
        }

        $scope.getListObj();
    }


})(angular.module('platformTH_GV.quanlychiphiseo'));