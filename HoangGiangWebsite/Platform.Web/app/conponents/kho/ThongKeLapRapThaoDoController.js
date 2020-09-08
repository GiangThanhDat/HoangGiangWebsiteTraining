(function (app) {
    'use strict';

    app.controller('ThongKeLapRapThaoDoController', ThongKeLapRapThaoDoController);

    ThongKeLapRapThaoDoController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService', '$http'];
    function ThongKeLapRapThaoDoController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http, $mdToast, $log) {
        $scope.gridOptions = {
            enableFiltering: false,

            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;

                $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);
            }
        }

        $scope.filterdate = function (item) {
            if (item == "nextmonth") {
                var d = new Date();
                var a = d.setMonth(d.getMonth(), 0);
                $scope.ngaycuoivalue = new Date(a);
                $scope.ngaycuoi = $scope.ngaycuoivalue;
                $scope.ngaycuoivalue = $filter('date')($scope.ngaycuoivalue, "yyyy-MM-dd");

                var e = new Date($scope.ngaycuoivalue)

                var b = e.setMonth(e.getMonth(), 1);
                $scope.ngaydauvalue = new Date(b);
                $scope.ngaydau = $scope.ngaydauvalue;
                $scope.ngaydauvalue = $filter('date')($scope.ngaydauvalue, "yyyy-MM-dd");



            }

            if (item == "lastmonth") {


                const now = new Date();
                var c = new Date(now.getFullYear(), now.getMonth() + 2);
                $scope.ngaycuoi = c
                var lastDay = new Date(now.getFullYear(), now.getMonth() + 1, 2);
                $scope.ngaydau = lastDay



            }
            if (item == "quytruoc") {


                var d = new Date();
                d.setFullYear(d.getFullYear(), d.getMonth() - 4);
                var q = d.setMonth(d.getMonth(), 1);
                $scope.ngaydauvalue = new Date(q);
                $scope.ngaydau = $scope.ngaydauvalue;
                $scope.ngaydauvalue = $filter('date')($scope.ngaydauvalue, "yyyy-MM-dd");

                var e = new Date();
                e.setFullYear(e.getFullYear(), e.getMonth() - 1);

                var b = e.setMonth(e.getMonth(), 0);
                $scope.ngaycuoivalue = new Date(b);
                $scope.ngaycuoi = $scope.ngaycuoivalue;
                $scope.ngaycuoivalue = $filter('date')($scope.ngaycuoivalue, "yyyy-MM-dd");




            }
            if (item == "quysau") {


                var d = new Date();
                d.setFullYear(d.getFullYear(), d.getMonth() + 2);
                var q = d.setMonth(d.getMonth(), 1);
                $scope.ngaydauvalue = new Date(q);
                $scope.ngaydau = $scope.ngaydauvalue;
                $scope.ngaydauvalue = $filter('date')($scope.ngaydauvalue, "yyyy-MM-dd");


                var e = new Date();
                e.setFullYear(e.getFullYear(), e.getMonth() + 5);

                var b = e.setMonth(e.getMonth(), 0);
                $scope.ngaycuoivalue = new Date(b);
                $scope.ngaycuoi = $scope.ngaycuoivalue;
                $scope.ngaycuoivalue = $filter('date')($scope.ngaycuoivalue, "yyyy-MM-dd");




            }
            if (item == "tuansau") {

                Date.prototype.getNextWeekDay = function (d) {
                    if (d) {
                        var next = this;
                        next.setDate(this.getDate() - this.getDay() + 7 + d);
                        return next;
                    }
                }
                var now = new Date();
                var nextMonday = now.getNextWeekDay(1); // 0 = Sunday, 1 = Monday, ...
                $scope.ngaydau = nextMonday;

                Date.prototype.getLastWeekDay = function (d) {
                    if (d) {
                        var last = this;
                        last.setDate(this.getDate() - this.getDay() + 13 + d);
                        return last;
                    }
                }
                var now1 = new Date();
                var lastMonday = now1.getLastWeekDay(1); // 0 = Sunday, 1 = Monday, ...



                $scope.ngaycuoi = lastMonday

            }
            if (item == "tuantruoc") {

                Date.prototype.getNextWeekDay = function (d) {
                    if (d) {
                        var next = this;
                        next.setDate(this.getDate() - this.getDay() - 7 + d);
                        return next;
                    }
                }
                var now = new Date();
                var nextMonday = now.getNextWeekDay(1); // 0 = Sunday, 1 = Monday, ...
                $scope.ngaydau = nextMonday;


                Date.prototype.getLastWeekDay = function (d) {
                    if (d) {
                        var last = this;
                        last.setDate(this.getDate() - this.getDay() + -1 + d);
                        return last;
                    }
                }
                var now1 = new Date();
                var lastMonday = now1.getLastWeekDay(1); // 0 = Sunday, 1 = Monday, ...



                $scope.ngaycuoi = lastMonday



            }
            if (item == "namsau") {
                var a = new Date().setFullYear(new Date().getFullYear(), 0, + 1)//lay nay dau thang dau nam hien tai tai 
                var c = new Date(a).setFullYear(new Date(a).getFullYear() + 1)// lay ngay dau nam dau nam ke tiep
                $scope.ngaydau = new Date(c)
                var d = new Date().setFullYear(new Date().getFullYear(), 0, 0)//lay nay dau thang dau nam hien tai tai 
                var e = new Date(d).setFullYear(new Date(d).getFullYear() + 2)// lay ngay dau nam dau nam ke tiep
                $scope.ngaydau = new Date(c)
                $scope.ngaycuoi = new Date(e)

                $scope.aa = new Date(e)



            }
            if (item == "namtruoc") {
                var a = new Date().setFullYear(new Date().getFullYear(), 0, + 1)//lay nay dau thang dau nam hien tai tai 
                var c = new Date(a).setFullYear(new Date(a).getFullYear() - 1)// lay ngay dau nam dau nam ke tiep
                $scope.ngaydau = new Date(c)
                var d = new Date().setFullYear(new Date().getFullYear(), 0, 0)//lay nay dau thang dau nam hien tai tai 
                var e = new Date(d).setFullYear(new Date(d).getFullYear() - 0)// lay ngay dau nam dau nam ke tiep

                $scope.ngaycuoi = new Date(e)

                $scope.aa = new Date(e)



            }
            if (item == "") {
                var d = new Date();
                d.setFullYear(d.getFullYear(), d.getMonth() - 4);
                var q = d.setMonth(d.getMonth(), 1);
                $scope.ngaydauvalue = new Date(q);
                $scope.ngaydau = $scope.ngaydauvalue;
                $scope.ngaydauvalue = $filter('date')($scope.ngaydauvalue, "yyyy-MM-dd");
                var b = $scope.ngaydau
                var c = new Date();
                $scope.ngaycuoi = c
                var month = ('0' + (b.getMonth() + 1)).slice(-2);
                var day = ('0' + b.getDate()).slice(-2);
                var year = b.getFullYear();

                var htmlDate = year + '-' + month + '-' + day;

                var monthND = ('0' + (c.getMonth() + 1)).slice(-2);
                var dayND = ('0' + c.getDate()).slice(-2);
                var yearND = c.getFullYear();

                var htmlDateND = yearND + '-' + monthND + '-' + dayND;
                $scope.first = htmlDate;
                $scope.last = htmlDateND;




            }



        }


        $scope.getfromtoday = function (ngaydau, ngaycuoi) {

            $scope.first = "";
            $scope.last = "";


            $scope.Data = [];

            if ($scope.ngaydau != null && $scope.ngaycuoi != null) {
                var month = ('0' + (ngaydau.getMonth() + 1)).slice(-2);
                var day = ('0' + ngaydau.getDate()).slice(-2);
                var year = ngaydau.getFullYear();

                var htmlDate = year + '-' + month + '-' + day;

                var monthND = ('0' + (ngaycuoi.getMonth() + 1)).slice(-2);
                var dayND = ('0' + ngaycuoi.getDate()).slice(-2);
                var yearND = ngaycuoi.getFullYear();

                var htmlDateND = yearND + '-' + monthND + '-' + dayND;
                $scope.first = htmlDate;
                $scope.last = htmlDateND;

            }
            else {
                var d = new Date();
                d.setFullYear(d.getFullYear(), d.getMonth() - 4);
                var q = d.setMonth(d.getMonth(), 1);
                $scope.ngaydauvalue = new Date(q);
                $scope.ngaydau = $scope.ngaydauvalue;
                $scope.ngaydauvalue = $filter('date')($scope.ngaydauvalue, "yyyy-MM-dd");
                var b = $scope.ngaydau
                var c = new Date();
                $scope.ngaycuoi = c
                var month = ('0' + (b.getMonth() + 1)).slice(-2);
                var day = ('0' + b.getDate()).slice(-2);
                var year = b.getFullYear();

                var htmlDate = year + '-' + month + '-' + day;

                var monthND = ('0' + (c.getMonth() + 1)).slice(-2);
                var dayND = ('0' + c.getDate()).slice(-2);
                var yearND = c.getFullYear();

                var htmlDateND = yearND + '-' + monthND + '-' + dayND;
                $scope.first = htmlDate;
                $scope.last = htmlDateND;


            }

            var config = {
                params: {
                    ngaydau: $scope.first,
                    ngaycuoi: $scope.last
                }
            }
            apiService.get('/api/laprapthaodo/getlenhlaprapthaodo', config, function (result) {
                $scope.getlenhlaprapthaodo = result.data;

                angular.forEach($scope.getlenhlaprapthaodo, function (item) {

                    item.Ngay = $filter('date')(item.Ngay, "dd-MM-yyyy");
                    //item.NgayChungTu = $filter('date')(item.NgayChungTu, "dd-MM-yyyy");
                    //item.HanThanhToan = $filter('date')(item.HanThanhToan, "dd-MM-yyyy");
                    //item.DaGhiSo = item.DaGhiSo.toString()
                    //item.TienDichVu = item.TienDichVu.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    item.ThanhTien = item.ThanhTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    item.GiaKhuyenMai = item.GiaKhuyenMai.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });


                })
                $scope.Data = $scope.getlenhlaprapthaodo;
                $scope.gridOptions.data = $scope.Data;
              

            }, function () {
                console.log('Load  failed.');
            });





        }
        $scope.getfromtoday();

        $scope.gridOptions.columnDefs = [
            { name: 'xemchitiet', width: 200, cellTemplate: '<span  ng-click="grid.appScope.xemDMH(row)">Xem chi tiết</span>', headerCellClass: 'text-center'},

            { name: 'Ngay', width: 200, enablePinning: false, headerCellClass: 'text-center'},
            { name: 'MaLapRapThaoDo', width: 200, pinnedLeft: false, headerCellClass: 'text-center' },
            { name: 'MaChungTuMuaDichVu', width: 200, pinnedRight: false, headerCellClass: 'text-center' },
            { name: 'MaThanhPham', width: 200, headerCellClass: 'text-center'},
            { name: 'TenThanhPham', width: 200, headerCellClass: 'text-center' },
            { name: 'DonViTinh', width: 200, headerCellClass: 'text-center'},
            { name: 'SoLuong', width: 200, headerCellClass: 'text-center'},
            { name: 'GiaKhuyenMai', width: 200, headerCellClass: 'text-center'},
            { name: 'ThanhTien', width: 200, headerCellClass: 'text-center'},
            { name: 'DaGhiSo', width: 200, visible: false, field: 'DaGhiSo' },



        ];
        $scope.gridOptions.columnDefs[0].displayName = 'Xem chi tiết'
        $scope.gridOptions.columnDefs[1].displayName = 'Ngày'
        $scope.gridOptions.columnDefs[2].displayName = 'Số lệnh'
        $scope.gridOptions.columnDefs[3].displayName = 'Loại'
        $scope.gridOptions.columnDefs[4].displayName = 'Mã thành phẩm/hàng hóa '
        $scope.gridOptions.columnDefs[5].displayName = 'Tên thành phẩm/hàng hóa'
        $scope.gridOptions.columnDefs[6].displayName = 'Đơn vị tính'
        $scope.gridOptions.columnDefs[7].displayName = 'Số lượng'
        $scope.gridOptions.columnDefs[8].displayName = 'Đơn giá'
        $scope.gridOptions.columnDefs[9].displayName = 'Thành tiền'

        $scope.xemDMH = function (row) {
            var index = row.entity.MaLapRapThaoDo;
            $('.bs-example-modal-lg').modal('show');
            angular.forEach($scope.Data, function (item) {

                if (item.MaLapRapThaoDo == index) {

                    $scope.singer = item;
                    $scope.Showsinger = true;



                }

            });
            var config = {
                params: {
                    MaLapRapThaoDo: index
                }
            }
            apiService.get('/api/chitietlaprapthaodo/getchitietlenhlaprapthaodo', config, function (result) {

                $scope.ChitietLRTD = result.data;
                angular.forEach($scope.ChitietLRTD, function (item) {

                    item.GiaKhuyenMai = item.GiaKhuyenMai.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    item.ThanhTien = item.ThanhTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                })
            }, function () {
                console.log('Load  failed.');
            });


        }
        //$scope.filter = function () {
        //    $scope.gridApi.grid.refresh();
        //};
        //$scope.singleFilter = function (renderableRows) {
        //    var matcher = new RegExp($scope.filterValue);
        //    renderableRows.forEach(function (row) {
        //        var match = false;
        //        ['DaGhiSo'].forEach(function (field) {
        //            if (row.entity[field].match(matcher)) {
        //                match = true;
        //            }
        //        });
        //        if (!match) {
        //            row.visible = false;
        //        }
        //    });
        //    return renderableRows;
        //};

    }
})(angular.module('platformTH_GV.kho'));


