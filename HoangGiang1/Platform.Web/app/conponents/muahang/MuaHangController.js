(function (app) {
    'use strict';

    app.controller('MuaHangController', MuaHangController);

    MuaHangController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService','$http'];
    function MuaHangController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http) {
        $scope.gridOptions = {

            //rowTemplate: rowTempl

        };
        $scope.DanhSachMuaHang = [];
        $scope.Data = [];


        //var rowTempl = '<div ng-style="{ \'cursor\': row.cursor }" ' +
        //    'ng-repeat="col in renderedColumns" ' +
        //    'ng-class="{green: row.getProperty(\'age\')  < 30}"' +
        //    'class="ngCell {{col.cellClass}} {{col.colIndex()}}" ng-cell></div>';

//fliter date

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

//fliter date

//get data

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
            apiService.get('/api/donmuahang/getDonMuaHang', config, function (result) {
                $scope.DanhSachMuaHang = result.data;

                angular.forEach($scope.DanhSachMuaHang, function (item) {
                    item.NgayDonHang = $filter('date')(item.NgayDonHang, "dd-MM-yyyy");
                    item.NgayGiaoHang = $filter('date')(item.NgayGiaoHang, "dd-MM-yyyy");
                    item.TongTienHang = item.TongTienHang.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });


                })
                $scope.Data = $scope.DanhSachMuaHang;
                $scope.gridOptions.data = $scope.Data;
            }, function () {
                console.log('Load  failed.');
            });

         
             
           
               
            }




        


//get data

        //hidePinLeft: false, hidePinRight: true 

//UI Grid table
        $scope.gridOptions.columnDefs = [
            { name: 'xemchitiet', width: 200, cellTemplate: '<span  ng-click="grid.appScope.xemDMH(row)">Xem chi tiết</span>', enablePinning: false, headerCellClass: 'text-center'},

            { name: 'TenTinhTrang', width: 200, headerCellClass: 'text-center'},
            { name: 'NgayDonHang', width: 200, headerCellClass: 'text-center'},
            { name: 'MaDonMuaHang', width: 200, headerCellClass: 'text-center'},
            { name: 'NgayGiaoHang', width: 200, headerCellClass: 'text-center'},
            { name: 'TenNhaCungCap', width: 200, headerCellClass: 'text-center' },
            { name: 'DienGiai', width: 200, headerCellClass: 'text-center' },
            { name: 'TongTienHang', width: 200, headerCellClass: 'text-center' },
            { name: 'sochutuKU', width: 200, headerCellClass: 'text-center'},
            { name: 'chiNhanh', width: 200, headerCellClass: 'text-center' },
           


        ];
        $scope.gridOptions.columnDefs[0].displayName = 'Xem chi tiết'
        $scope.gridOptions.columnDefs[1].displayName = 'Tình trạng'
        $scope.gridOptions.columnDefs[2].displayName = 'Ngày đơn mua'
        $scope.gridOptions.columnDefs[3].displayName = 'Số đơn hàng '
        $scope.gridOptions.columnDefs[4].displayName = 'Ngày giao hàng'
        $scope.gridOptions.columnDefs[5].displayName = 'Nhà cung cấp '
        $scope.gridOptions.columnDefs[6].displayName = 'Diễn Giải '
        $scope.gridOptions.columnDefs[7].displayName = 'Giá trị đơn hàng '
        $scope.gridOptions.columnDefs[8].displayName = 'Số chứng từ CUkCUk  '
        $scope.gridOptions.columnDefs[9].displayName = 'Chi nhánh   '
        

//UI Grid table

        $scope.xemDMH = function (row) {
            var index = row.entity.MaDonMuaHang;
            $('.bs-example-modal-lg').modal('show');
            angular.forEach($scope.Data, function (item) {

                if (item.MaDonMuaHang == index) {

                    $scope.singer = item;
                    $scope.Showsinger = true;



                }

            });
            var config = {
                params: {
                    maMH: index
                }
            }
            apiService.get('/api/chitietdonmuahang/getchitiet', config, function (result) {

                $scope.ChitietMH = result.data;
                angular.forEach($scope.ChitietMH, function (item) {
                    if (item.GiaKhuyenMai != null) {
                        item.GiaKhuyenMai = item.GiaKhuyenMai.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });

                    }
                    if (item.ThanhTien != null) {
                        item.ThanhTien = item.ThanhTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                    if (item.TienThueGTGT != null) {
                        item.TienThueGTGT = item.TienThueGTGT.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                   


                })

                $scope.Showsinger = true;
            }, function () {
                console.log('Load  failed.');
            });


        }

        $scope.getfromtoday()
       
    }


})(angular.module('platformTH_GV.muahang'));