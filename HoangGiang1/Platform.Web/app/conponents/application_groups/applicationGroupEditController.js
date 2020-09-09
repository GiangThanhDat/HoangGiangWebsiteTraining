(function (app) {
    'use strict';

    app.controller('applicationGroupEditController', applicationGroupEditController);

    applicationGroupEditController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams', 'loginService', '$injector'];

    function applicationGroupEditController($scope, apiService, notificationService, $location, $stateParams, loginService, $injector) {
         
        if ($scope.kiemtrarole('SinhVien') === 'SinhVien') {
            if ($scope.kiemtrarole('Admin') === 'Admin') {
                var stateService = $injector.get('$state');
                //#region
                $scope.group = {}


                $scope.updateApplicationGroup = updateApplicationGroup;

                function updateApplicationGroup() {
                    apiService.put('/api/applicationGroup/update', $scope.group, addSuccessed, addFailed);
                }
                function loadDetail() {
                    apiService.get('/api/applicationGroup/detail/' + $stateParams.id, null,
                        function (result) {
                            $scope.group = result.data;
                        },
                        function (result) {
                            notificationService.displayError(result.data);
                        });
                }

                function addSuccessed() {
                    notificationService.displaySuccess($scope.group.Name + ' đã được cập nhật thành công.');

                    $location.url('application_groups');
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
                loadDetail();
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
            $scope.group = {}

            
            $scope.updateApplicationGroup = updateApplicationGroup;

            function updateApplicationGroup() {
                apiService.put('/api/applicationGroup/update', $scope.group, addSuccessed, addFailed);
            }
            function loadDetail() {
                apiService.get('/api/applicationGroup/detail/' + $stateParams.id, null,
                    function (result) {
                        $scope.group = result.data;
                    },
                    function (result) {
                        notificationService.displayError(result.data);
                    });
            }

            function addSuccessed() {
                notificationService.displaySuccess($scope.group.Name + ' đã được cập nhật thành công.');

                $location.url('application_groups');
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
            loadDetail();
        //#endregion
        }
    }
})(angular.module('platformTH_GV.application_groups'));