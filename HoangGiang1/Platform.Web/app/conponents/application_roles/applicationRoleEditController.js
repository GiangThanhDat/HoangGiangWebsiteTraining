(function (app) {
    'use strict';

    app.controller('applicationRoleEditController', applicationRoleEditController);

    applicationRoleEditController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams', 'loginService', '$injector'];

    function applicationRoleEditController($scope, apiService, notificationService, $location, $stateParams, loginService, $injector) {
        if ($scope.kiemtrarole('SinhVien') === 'SinhVien' && $scope.kiemtrarole('Admin') != 'Admin') {
            loginService.logOut();
            var stateService = $injector.get('$state');
            stateService.go('dangnhap');
            notificationService.displayError("Bạn không có quyền truy cập trang này");
        }
        else {
            //#region

            $scope.role = {}


            $scope.updateApplicationRole = updateApplicationRole;

            function updateApplicationRole() {
                apiService.put('/api/applicationRole/update', $scope.role, addSuccessed, addFailed);
            }
            function loadDetail() {
                apiService.get('/api/applicationRole/detail/' + $stateParams.id, null,
                    function (result) {
                        $scope.role = result.data;
                    },
                    function (result) {
                        notificationService.displayError(result.data);
                    });
            }

            function addSuccessed() {
                notificationService.displaySuccess($scope.role.Name + ' đã được cập nhật thành công.');

                $location.url('application_roles');
            }
            function addFailed(response) {
                notificationService.displayError(response.data.Message);
                notificationService.displayErrorValidation(response);
            }
            loadDetail();
        //#endregion
        }
        
    }
})(angular.module('platformTH_GV.application_roles'));