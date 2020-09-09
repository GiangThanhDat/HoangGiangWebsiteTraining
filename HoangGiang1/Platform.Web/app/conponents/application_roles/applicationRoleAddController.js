(function (app) {
    'use strict';

    app.controller('applicationRoleAddController', applicationRoleAddController);

    applicationRoleAddController.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'loginService', '$injector'];

    function applicationRoleAddController($scope, apiService, notificationService, $location,loginService,$injector) {
        if ($scope.kiemtrarole('SinhVien') === 'SinhVien' && $scope.kiemtrarole('Admin') != 'Admin') {
            loginService.logOut();
            var stateService = $injector.get('$state');
            stateService.go('dangnhap');
            notificationService.displayError("Bạn không có quyền truy cập trang này");
        }
        else {
            //#region
            $scope.role = {
                Id: 0
            }

            $scope.addAppRole = addAppRole;

            function addAppRole() {
                apiService.post('/api/applicationRole/add', $scope.role, addSuccessed, addFailed);
            }

            function addSuccessed() {
                notificationService.displaySuccess($scope.role.Name + ' đã được thêm mới.');

                $location.url('application_roles');
            }
            function addFailed(response) {
                notificationService.displayError(response.data.Message);
                notificationService.displayErrorValidation(response);
            }

            function loadRoles() {
                apiService.get('/api/applicationRole/getlistall',
                    null,
                    function (response) {
                        $scope.roles = response.data;
                    }, function (response) {
                        notificationService.displayError('Không tải được danh sách quyền.');
                    });

            }

            loadRoles();
            //#endregion        }
        }
    }
})(angular.module('platformTH_GV.application_roles'));