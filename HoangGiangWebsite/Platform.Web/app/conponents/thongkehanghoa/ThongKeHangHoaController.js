(function (app) {
    'use strict';

    app.controller('ThongKeHangHoaController', ThongKeHangHoaController);

    ThongKeHangHoaController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService', '$http'];
    function ThongKeHangHoaController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http, $mdToast, $log) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tenNhanVien = $scope.authentication.fullName;
        $scope.singer = {}
       
      
        $scope.gridOptions = {
            enableFiltering: false,

            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;

                $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);
            }
        }
        


        $scope.getfromtoday = function () {
            apiService.get('/api/hanghoa/getall', null, function (result) {
                $scope.getAllHangHoa = result.data;

                $scope.Data = $scope.getAllHangHoa;
                $scope.gridOptions.data = $scope.Data;


            }, function () {
                console.log('Load  failed.');
            });





        }
      

        $scope.gridOptions.columnDefs = [
            { name: 'xemchitiet', width: 200, cellTemplate: '<span  ng-click="grid.appScope.xemHangHoa(row)">Xem chi tiết</span>', headerCellClass: 'text-center' },

            { name: 'MaHang', width: 200, enablePinning: false, headerCellClass: 'text-center', field: 'MaHang' },
            { name: 'TenHang', width: 200, pinnedLeft: false, headerCellClass: 'text-center', field: 'TenHang'  },
            { name: 'MoTa', width: 200, pinnedRight: false, headerCellClass: 'text-center' },
            { name: 'GiaNhap', width: 200, headerCellClass: 'text-center' },
            { name: 'GiaBan', width: 200, headerCellClass: 'text-center' },
            { name: 'GiaKhuyenMai', width: 200, headerCellClass: 'text-center' },
            {
                name: 'HinhAnh', width: 200, headerCellClass: 'text-center',
                cellTemplate: '<div class=\"ui-grid-cell-contents ng-scope ng-binding\"><img ng-src=\"{{COL_FIELD}}\" border=\"0\" width=\"50\"height=\"50\">', height:200}
            //{ name: 'GiaKhuyenMai', width: 200, headerCellClass: 'text-center' },
            //{ name: 'ThanhTien', width: 200, headerCellClass: 'text-center' },
            //{ name: 'DaGhiSo', width: 200, visible: false, field: 'DaGhiSo' },



        ];
        $scope.gridOptions.columnDefs[0].displayName = 'Xem chi tiết'
        $scope.gridOptions.columnDefs[1].displayName = 'Mã hàng'
        $scope.gridOptions.columnDefs[2].displayName = 'Tên hàng'
        $scope.gridOptions.columnDefs[3].displayName = 'Mô tả'
        $scope.gridOptions.columnDefs[4].displayName = 'Giá nhập'
        $scope.gridOptions.columnDefs[5].displayName = 'Giá bán'
        $scope.gridOptions.columnDefs[6].displayName = 'Giá khuyến mãi'
        $scope.gridOptions.columnDefs[7].displayName = 'Hình Ảnh'

        $scope.getnhomHang = function () {
            apiService.get('/api/nhomhanghoa/getall', null, function (result) {
                $scope.getAllNhomHangHoa = result.data;
            }, function () {
                console.log('Load  failed.');
            });


        }
        $scope.gettinhchathanghoa = function () {
            apiService.get('/api/tinhchathanghoa/getall', null, function (result) {
                $scope.getAlltinhchathanghoa = result.data;
            }, function () {
                console.log('Load  failed.');
            });


        }
       
        $scope.xemHangHoa = function (row) {
          

            var index = row.entity.MaHang;
            $('.bs-example-modal-lg').modal('show');

            angular.forEach($scope.Data, function (item) {
                if (item.MaHang == index) {
                   
                    $scope.singer = item;
                   
                }
            });

            angular.forEach($scope.getAllNhomHangHoa, function (item) {
                if (item.MaNhomHH == $scope.singer.MaNhomHH) {
                    $scope.singer.TenNhom = item.TenNhom;
                   
                }
            });
            


        }

        $scope.update = function () {
            $scope.singer.NguoiSua = $scope.tenNhanVien;
            $ngBootbox.confirm('Bạn chắc muốn sửa không').then(function () {
                apiService.put('/api/hanghoa/update', $scope.singer, function (result) {
                    $('.bs-example-modal-lg').modal('hide');
                    $scope.getfromtoday()
                    $scope.getnhomHang()
                    $scope.gettinhchathanghoa()
                }, function () {
                    console.log('Load  failed.');
                });
            });

        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.singer.HinhAnh = fileUrl;
            }
            finder.popup();



        }

        $scope.filter = function () {
            $scope.gridApi.grid.refresh();
        };
        $scope.singleFilter = function (renderableRows) {
            var matcher = new RegExp($scope.filevalue);
            renderableRows.forEach(function (row) {
                var match = false;
                ['MaHang','TenHang'].forEach(function (field) {
                    if (row.entity[field].match(matcher)) {
                        match = true;
                    }
                });
                if (!match) {
                    row.visible = false;
                }
            });
            return renderableRows;
        };
        $scope.getfromtoday();
        $scope.getnhomHang()
        $scope.gettinhchathanghoa()
    }
})(angular.module('platformTH_GV.thongkehanghoa'));


