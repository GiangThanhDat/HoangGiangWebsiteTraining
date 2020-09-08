(function (app) {
    'use strict';

    app.controller('QuyController', QuyController);

    QuyController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'dateFilter', '$http', '$log'];
    function QuyController($scope, apiService, notificationService, $ngBootbox, $filter, dateFilter, $http, $log) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tenNhanVien = $scope.authentication.fullName;

        $scope.gridOptions = {
            enableFiltering: false,

            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;

                $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);
                $scope.gridApi.grid.registerRowsProcessor($scope.singleFilterr, 200);


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

        $scope.getfromtoday = function (ngaydau, ngaycuoi, phieuchi) {

            $scope.first = "";
            $scope.last = "";




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


            $scope.Data = [];
            $scope.DanhSachPhieuChi = [];
            $scope.DanhSachPhieuThu = [];
            apiService.get('/api/phieuthu/getPhieuThu', config, function (result) {

                $scope.DanhSachPhieuThu = result.data;
                apiService.get('/api/phieuchi/getPhieuChi', config, function (result) {

                    $scope.DanhSachPhieuChi = result.data;
                    $scope.Data = $scope.DanhSachPhieuThu.concat($scope.DanhSachPhieuChi);
                    angular.forEach($scope.Data, function (item) {
                        item.NgayHoachToan = $filter('date')(item.NgayHoachToan, "dd-MM-yyyy");
                        item.NgayChungTu = $filter('date')(item.NgayChungTu, "dd-MM-yyyy");
                        item.DaGhiSo = item.DaGhiSo.toString()


                    })

                    $scope.gridOptions.data = $scope.Data;

                }, function () {
                    console.log('Load phiếu thu false.');
                });

            }, function () {
                console.log('Load phiếu chi false.');
            });



        }

        $scope.xemPT = function (row) {
            var index = row.entity.MaPhieuThu;
            if ((index.includes('PC')) == true) {
                $('.bs-example-modal-lg1').modal('show');

                var config = {
                    params: {
                        MaPC: index
                    }
                }
                apiService.get('/api/phieuchi/xemPhieuChi', config, function (result) {

                    $scope.XemPhieuChi = result.data[0];

                }, function () {
                    console.log('Load  failed.');
                });
                var config = {
                    params: {
                        MaPC: index
                    }
                }
                apiService.get('/api/chitietphieuchi/xemChiTietPhieuChi', config, function (result) {

                    $scope.XemChiTietPhieuChi = result.data;

                }, function () {
                    console.log('Load  failed.');
                });
            }
            else if ((index.includes('PT')) == true) {
                $('.bs-example-modal-lg').modal('show');
                angular.forEach($scope.DanhSachPhieuThu, function (item) {

                    if (item.MaPhieuThu == index) {
                        console.log(item)
                        $scope.singer = item;

                        $scope.singer.NgayHoachToan = $filter('date')($scope.singer.NgayHoachToan, "dd-MM-yyyy");
                        $scope.singer.NgayChungTu = $filter('date')($scope.singer.NgayChungTu, "dd-MM-yyyy");


                        $scope.Showsinger = true;

                    }


                    var config = {
                        params: {
                            maPT: index
                        }
                    }
                    apiService.get('/api/phieuthu/getchitietphieuthu', config, function (result) {

                        $scope.ChitietPT = result.data;
                        $scope.Showsinger = true;
                    }, function () {
                        console.log('Load  failed.');
                    });







                })
            }


        }

        $scope.gridOptions.columnDefs = [
            { name: 'XemChiTiet', width: 200, cellTemplate: '<button class="btn primary" ng-click="grid.appScope.xemPT(row)">Xem chi tiết</button>' },

            { name: 'NgayHoachToan', width: 200, enablePinning: false, hidePinLeft: false, hidePinRight: true },
            { name: 'NgayChungTu', width: 200, pinnedLeft: false },
            { name: 'MaPhieuThu', width: 200, pinnedRight: false, field: 'MaPhieuThu' },
            { name: 'DienGiai', width: 200 },
            { name: 'TongTienThanhToan', width: 200 },
            { name: 'TenKhachHang', width: 200 },
            { name: 'LyDoNop', width: 200 },
            { name: 'NgayChungTu', width: 200 },
            { name: 'TenLoaiThu', width: 200 },
            { name: 'ChungTuGoc', width: 200 },
            { name: 'dssd', width: 200 },
            { name: 'dsd    ', width: 200 },
            { name: 'DaGhiSo', width: 200, visible: false, field: 'DaGhiSo' },


        ];

        $scope.gridOptions.columnDefs[0].displayName = 'Xem chi tiết'
        $scope.gridOptions.columnDefs[1].displayName = 'Ngày hoạch toán'
        $scope.gridOptions.columnDefs[2].displayName = 'Ngày chứng từ'
        $scope.gridOptions.columnDefs[3].displayName = 'Số chứng từ '
        $scope.gridOptions.columnDefs[4].displayName = 'Diễn giải'
        $scope.gridOptions.columnDefs[5].displayName = 'Số tiền '
        $scope.gridOptions.columnDefs[6].displayName = 'Đối tượng '
        $scope.gridOptions.columnDefs[7].displayName = 'Lý do thu chi '
        $scope.gridOptions.columnDefs[8].displayName = 'Ngày ghi sổ quỹ  '
        $scope.gridOptions.columnDefs[9].displayName = 'Loại chứng từ   '
        $scope.gridOptions.columnDefs[10].displayName = 'Số chứng từ(Số QT)  '
        $scope.gridOptions.columnDefs[11].displayName = 'Số chứng từ CUKCU  '
        $scope.gridOptions.columnDefs[12].displayName = 'Chi nhánh  '

        $scope.filter = function () {
            $scope.gridApi.grid.refresh();
        };
        $scope.filterr = function () {
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
        $scope.singleFilterr = function (renderableRowss) {
            var matcherr = new RegExp($scope.phieuchi);
            renderableRowss.forEach(function (row) {
                var match = false;
                ['MaPhieuThu'].forEach(function (field) {
                    if (row.entity[field].match(matcherr)) {
                        match = true;
                    }
                });
                if (!match) {
                    row.visible = false;
                }
            });
            return renderableRowss;
        };


        $scope.getfromtoday();
    }
})(angular.module('platformTH_GV.quy'));