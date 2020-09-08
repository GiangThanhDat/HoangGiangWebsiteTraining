(function (app) {
    'use strict';

    app.controller('ThongKeBanHangController', ThongKeBanHangController);

    ThongKeBanHangController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService', '$http'];
    function ThongKeBanHangController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http) {
        $scope.gridOptions = {
            enableFiltering: false,

            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;

                $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);
            }
        };
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


            $scope.getchungtubanhang = [];
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

            apiService.get('/api/chungtubanhang/getchungtubanhang', config, function (result) {

                $scope.getchungtubanhang = result.data;
                $scope.Data = result.data;
                angular.forEach($scope.Data, function (i) {
                    i.NgayChungTu = $filter('date')(i.NgayChungTu, "dd-MM-yyyy");
                    i.NgayHoachToan = $filter('date')(i.NgayHoachToan, "dd-MM-yyyy");
                    i.HanThanhToan = $filter('date')(i.HanThanhToan, "dd-MM-yyyy");
                    i.DaGhiSo = i.DaGhiSo.toString()
                    i.TongTienHang = i.TongTienHang.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    i.TienChietKhau = i.TienChietKhau.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    i.TienThueGTGT = i.TienThueGTGT.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });

                })
                $scope.gridOptions.data = $scope.Data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }


        $scope.gridOptions.columnDefs = [
            { name: 'xemchitiet', width: 200, cellTemplate: '<span  ng-click="grid.appScope.xemCTbanhang(row)">Xem chi tiết</span>', headerCellClass: 'text-center'},

            { name: 'NgayHoachToan', width: 200, enablePinning: false, headerCellClass: 'text-center'},
            { name: 'NgayChungTu', width: 200, pinnedLeft: false, headerCellClass: 'text-center' },
            { name: 'MaChungTuBanHang', width: 200, pinnedRight: false, headerCellClass: 'text-center'},
            { name: 'SoHoaDon', width: 200, headerCellClass: 'text-center'},
            { name: 'TenKhachHang', width: 200, headerCellClass: 'text-center'},
            { name: 'DienGiai', width: 200, headerCellClass: 'text-center'},
            { name: 'TongTienHang', width: 200, headerCellClass: 'text-center'},
            { name: 'TienChietKhau', width: 200, headerCellClass: 'text-center'},
            { name: 'TienThueGTGT', width: 200, headerCellClass: 'text-center' },
            { name: 'DaGhiSo', width: 200, visible: false, field: 'DaGhiSo' },



        ];
        $scope.gridOptions.columnDefs[0].displayName = 'Xem chi tiết'
        $scope.gridOptions.columnDefs[1].displayName = 'Ngày hạch toán'
        $scope.gridOptions.columnDefs[2].displayName = 'Ngày chứng từ'
        $scope.gridOptions.columnDefs[3].displayName = 'Số chứng từ'
        $scope.gridOptions.columnDefs[4].displayName = 'Số hóa đơn '
        $scope.gridOptions.columnDefs[5].displayName = 'Khách hàng'
        $scope.gridOptions.columnDefs[6].displayName = 'Diễn giải '
        $scope.gridOptions.columnDefs[7].displayName = 'Tổng tiền hàng '
        $scope.gridOptions.columnDefs[8].displayName = 'Tiền chiết khấu'
        $scope.gridOptions.columnDefs[9].displayName = 'Tiền thuế GTGT '

        $scope.xemCTbanhang = function (row) {
            var index = row.entity.MaChungTuBanHang;
            $scope.singer = {}
            $('.bs-example-modal-lg').modal('show');
            angular.forEach($scope.Data, function (i) {

                if (i.MaChungTuBanHang == index) {
                    $scope.singer = i;
                }

            })



            var config = {
                params: {
                    MaChungTuBanHang: index
                }
            }
            apiService.get('/api/chitietchungtubanhang/getchitietchungtubanhang', config, function (result) {

                $scope.XemChiTiet = result.data;

                angular.forEach($scope.XemChiTiet, function (item) {
                    if (item.GiaKhuyenMai != null) {
                        item.GiaKhuyenMai = item.GiaKhuyenMai.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });

                    }
                    if (item.ThanhTien != null) {
                        item.ThanhTien = item.ThanhTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                    if (item.TienThueGTGT != null) {
                        item.TienThueGTGT = item.TienThueGTGT.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                    if (item.TienChietKhau != null) {
                        item.TienChietKhau = item.TienChietKhau.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }


                })


                if (result.data.length > 0) {
                    $scope.chitiet = true
                }
                else {
                    $scope.chitiet = false
                }
            }, function () {
                console.log('Load  failed.');
            });





        }

        $scope.filter = function () {
            $scope.gridApi.grid.refresh();
        };
        $scope.singleFilter = function (renderableRows) {
            var matcher = new RegExp($scope.filterValue);
            renderableRows.forEach(function (row) {
                var match = false;
                ['DaGhiSo'].forEach(function (field) {
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
    }


})(angular.module('platformTH_GV.banhang'));