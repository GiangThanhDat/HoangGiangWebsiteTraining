(function (app) {
    app.controller('nopDonController', nopDonController);
    app.$inject = ['$scope', 'apiService', '$stateParams', 'loginService', '$injector', 'notificationService'];
    function nopDonController($scope, loginService, $injector, notificationService) {
        if ($scope.kiemtrarole('NopDon') === 'NopDon') {

            //#region
            $scope.clickshownopdon = clickshownopdon;
            function clickshownopdon() {
                $scope.allnopdon = true;
            }

            $scope.btnxem = true;
            $scope.toggle = function () {

                $scope.btnan = true;
                $scope.btnxem = false;

                // $scope.btnan = true;
                // $scope.show = true;



            };
            $scope.clickan = function () {

                if ($scope.btnan = true) {
                    $scope.btnan = false;
                }
                $scope.btnxem = true;
                $scope.allnopdon = false;


            };
            //#endregion
        }
        else {
            loginService.logOut();
            var stateService = $injector.get('$state');
            stateService.go('dangnhap');
            notificationService.displayError("Bạn không có quyền truy cập trang này");

        }
        



    }
})(angular.module('platformTH_GV.nopdon'));