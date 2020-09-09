(function (app) {
    'use strict';

    app.controller('applicationGroupAddController', applicationGroupAddController);

    applicationGroupAddController.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'loginService', '$injector'];

    function applicationGroupAddController($scope, apiService, notificationService, $location, loginService, $injector) {
        if ($scope.kiemtrarole('SinhVien') === 'SinhVien') {
            if ($scope.kiemtrarole('Admin') === 'Admin') {
                var stateService = $injector.get('$state');
        //#region
        $scope.group = {
            ID: 0,
            Roles: []
        }

        $scope.addAppGroup = addApplicationGroup;

        function addApplicationGroup() {
            apiService.post('/api/applicationGroup/add', $scope.group, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được thêm mới.');

            $location.url('application_groups');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.ModelState);
           // notificationService.displayErrorValidation(response);
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
        //#endregion
            }
            else {
                notificationService.displayError("Bạn không có quyền truy cập trang này");
                loginService.logOut();
                var stateService = $injector.get('$state');
                stateService.go('dangnhap');

            }

        }
        else {
            //#region
            $scope.group = {
                ID: 0,
                Roles: []
            }

            $scope.addAppGroup = addApplicationGroup;

            function addApplicationGroup() {
                apiService.post('/api/applicationGroup/add', $scope.group, addSuccessed, addFailed);
            }

            function addSuccessed() {
                notificationService.displaySuccess($scope.group.Name + ' đã được thêm mới.');

                $location.url('application_groups');
            }
            function addFailed(response) {
                notificationService.displayError(response.data.ModelState);
                // notificationService.displayErrorValidation(response);
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
        //#endregion
        }
    }
})(angular.module('platformTH_GV.application_groups'));