(function (app) {
    'use strict';
 
    app.controller('applicationGroupListController', applicationGroupListController);

    applicationGroupListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter',  'loginService', '$injector'];

    function applicationGroupListController($scope, apiService, notificationService, $ngBootbox, $filter, loginService, $injector) {
        
        if ($scope.kiemtrarole('SinhVien') === 'SinhVien') {
            if ($scope.kiemtrarole('Admin') === 'Admin') {
                var stateService = $injector.get('$state');
                //#region
                $scope.loading = true;
                $scope.data = [];
                $scope.page = 0;
                $scope.pageCount = 0;
                $scope.search = search;
                $scope.clearSearch = clearSearch;
                $scope.deleteItem = deleteItem;
                $scope.selectAll = selectAll;

                $scope.deleteMultiple = deleteMultiple;

                function deleteMultiple() {
                    var listId = [];
                    $.each($scope.selected, function (i, item) {
                        listId.push(item.ID);
                    });
                    var config = {
                        params: {
                            checkedList: JSON.stringify(listId)
                        }
                    }
                    apiService.del('api/applicationGroup/deletemulti', config, function (result) {
                        notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                        search();
                    }, function (error) {
                        notificationService.displayError('Xóa không thành công');
                    });
                }

                $scope.isAll = false;
                function selectAll() {
                    if ($scope.isAll === false) {
                        angular.forEach($scope.data, function (item) {
                            item.checked = true;
                        });
                        $scope.isAll = true;
                    } else {
                        angular.forEach($scope.data, function (item) {
                            item.checked = false;
                        });
                        $scope.isAll = false;
                    }
                }

                $scope.$watch("data", function (n, o) {
                    var checked = $filter("filter")(n, { checked: true });
                    if (checked.length) {
                        $scope.selected = checked;
                        $('#btnDelete').removeAttr('disabled');
                    } else {
                        $('#btnDelete').attr('disabled', 'disabled');
                    }
                }, true);

                function deleteItem(id) {
                    $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                        .then(function () {
                            var config = {
                                params: {
                                    id: id
                                }
                            }
                            apiService.del('/api/applicationGroup/delete', config, function () {
                                notificationService.displaySuccess('Đã xóa thành công.');
                                search();
                            },
                                function () {
                                    notificationService.displayError('Xóa không thành công.');
                                });
                        });
                }
                function search(page) {
                    page = page || 0;

                    $scope.loading = true;
                    var config = {
                        params: {
                            page: page,
                            pageSize: 10,
                            filter: $scope.filterExpression
                        }
                    }

                    apiService.get('api/applicationGroup/getlistpaging', config, dataLoadCompleted, dataLoadFailed);
                }

                function dataLoadCompleted(result) {
                    $scope.data = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pagesCount = result.data.TotalPages;
                    $scope.totalCount = result.data.TotalCount;
                    $scope.loading = false;

                    if ($scope.filterExpression && $scope.filterExpression.length) {
                        notificationService.displayInfo(result.data.Items.length + ' items found');
                    }
                }
                function dataLoadFailed(response) {
                    notificationService.displayError(response.data);
                }

                function clearSearch() {
                    $scope.filterExpression = '';
                    search();
                }

                $scope.search();
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
            $scope.loading = true;
            $scope.data = [];
            $scope.page = 0;
            $scope.pageCount = 0;
            $scope.search = search;
            $scope.clearSearch = clearSearch;
            $scope.deleteItem = deleteItem;
            $scope.selectAll = selectAll;

            $scope.deleteMultiple = deleteMultiple;

            function deleteMultiple() {
                var listId = [];
                $.each($scope.selected, function (i, item) {
                    listId.push(item.ID);
                });
                var config = {
                    params: {
                        checkedList: JSON.stringify(listId)
                    }
                }
                apiService.del('api/applicationGroup/deletemulti', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công');
                });
            }

            $scope.isAll = false;
            function selectAll() {
                if ($scope.isAll === false) {
                    angular.forEach($scope.data, function (item) {
                        item.checked = true;
                    });
                    $scope.isAll = true;
                } else {
                    angular.forEach($scope.data, function (item) {
                        item.checked = false;
                    });
                    $scope.isAll = false;
                }
            }

            $scope.$watch("data", function (n, o) {
                var checked = $filter("filter")(n, { checked: true });
                if (checked.length) {
                    $scope.selected = checked;
                    $('#btnDelete').removeAttr('disabled');
                } else {
                    $('#btnDelete').attr('disabled', 'disabled');
                }
            }, true);

            function deleteItem(id) {
                $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                    .then(function () {
                        var config = {
                            params: {
                                id: id
                            }
                        }
                        apiService.del('/api/applicationGroup/delete', config, function () {
                            notificationService.displaySuccess('Đã xóa thành công.');
                            search();
                        },
                            function () {
                                notificationService.displayError('Xóa không thành công.');
                            });
                    });
            }
            function search(page) {
                page = page || 0;

                $scope.loading = true;
                var config = {
                    params: {
                        page: page,
                        pageSize: 10,
                        filter: $scope.filterExpression
                    }
                }

                apiService.get('api/applicationGroup/getlistpaging', config, dataLoadCompleted, dataLoadFailed);
            }

            function dataLoadCompleted(result) {
                $scope.data = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;

                if ($scope.filterExpression && $scope.filterExpression.length) {
                    notificationService.displayInfo(result.data.Items.length + ' items found');
                }
            }
            function dataLoadFailed(response) {
                notificationService.displayError(response.data);
            }

            function clearSearch() {
                $scope.filterExpression = '';
                search();
            }

            $scope.search();
        //#endregion
        }
    }
})(angular.module('platformTH_GV.application_groups'));