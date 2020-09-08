(function (app) {
    'use strict';

    app.controller('thongKeTaiSanController', thongKeTaiSanController);

    thongKeTaiSanController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function thongKeTaiSanController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.maNhanVien = $scope.authentication.userName;
        $scope.ChucVu = {};
        $scope.FilerMaCoSo = [];
       
       
        $scope.GetAllTaiSan = function () {
            apiService.get('/api/taisan/getall', null, function (result) {

                $scope.GetNhanVien = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }

        $scope.GetChucVu = function () {
            var config = {
                params: {
                    msnv: $scope.maNhanVien
                }
            }
            apiService.get('/api/chucvu/getChucVu', config, function (result) {

                $scope.ChucVu = result.data;
                $scope.KiemTraChucVu();

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }


        $scope.TaiSanTheoNguoiNhap = function () {
            var config = {
                params: {
                    msnv: $scope.maNhanVien
                }
            }
            apiService.get('/api/taisan/getnguoinhap', config, function (result) {

                $scope.NguoiNhap = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.TaiSanTheoNguoiNhap();


         $scope.GetCoSo = function () {
            var config = {
                params: {
                    msnv: $scope.maNhanVien
                }
            }
             apiService.get('/api/coso/getTenCoSo', config, function (result) {

                $scope.CoSo = result.data;
              

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.getThongkeNguoiQuanLyTS = function () {
           
            apiService.get('/api/taisan/getThongkeNguoiQuanLyTS', null, function (result) {

                $scope.ThongkeCoSoNQLTS = result.data;
              

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.getThongkeNguoiQuanLyTS();




        $scope.GetThongKeTaiSan = function () {
            $scope.MaSoCoSo = "";
            $scope.KieuTaiSan = "";

            apiService.get('/api/taisan/getThongkeTaiSan', null, function (result) {

                $scope.ThongKeTaiSan = result.data;
                angular.forEach($scope.ThongKeTaiSan, function (item) {
                    angular.forEach($scope.NguoiNhap, function (value) {
                        if (item.NguoiNhap == value.NguoiNhap) {
                            item.TenNguoiNhap = value.HoVaTen

                        }


                    });

                });
                angular.forEach($scope.ThongKeTaiSan, function (item) {
                    angular.forEach($scope.ThongkeCoSoNQLTS, function (value) {
                        if (item.MaSoNhanVien == value.MaSoNhanVien) {
                            item.TenCoSoNguoiQL = value.TenCoSo

                        }


                    });

                });
                console.log($scope.ThongKeTaiSan);



                var newArr = [];
                angular.forEach($scope.ThongKeTaiSan, function (value) {
                  
                  
                    if ($scope.ChucVu.MaChucVu < 80 && $scope.CoSo.TenCoSo == value.TenCoSo) {
                            newArr.push(value)

                        };
                  
                    });
                   $scope.newArr = newArr;
                     if ($scope.ChucVu.MaChucVu < 80) {
                      $scope.ThongKeTaiSan = newArr;
                      }
              

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
      

       


         $scope.GetFilerMaCoSo = function (item) {
             var config = {
                 params: {
                     MaCoSo: item
                 }
             }
             apiService.get('/api/taisan/ChucNangLocTaiSanTheoMaCoSo', config, function (result) {
                
                 $scope.FilerMaCoSo = result.data;
                 $scope.hideThongKeMaCoSo = true;
                 $scope.hidethongkeAll = false;
                 $scope.hideThongKeKieuTaiSan = false;



            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
         $scope.GetFilerKieuTaiSan = function (item) {
             var config = {
                 params: {
                     Model: item
                 }
             }
             apiService.get('/api/taisan/ChucNangLocTaiSanTheoKieuTaiSan', config, function (result) {
               
                 $scope.FilerKieuTaiSan = result.data;

                 //angular.forEach($scope.FilerKieuTaiSan, function (item) {
                 //    angular.forEach($scope.ThongkeCoSoNQLTS, function (value) {
                 //        if (item.MaSoNhanVien == value.MaSoNhanVien) {
                 //            item.TenCoSoNguoiQL = value.TenCoSo

                 //        }


                 //    });
                 $scope.hideThongKeKieuTaiSan = true;
                 $scope.hidethongkeAll = false;
                 $scope.hideThongKeMaCoSo = false;
               


            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }




      



        $scope.GetChucVu();

        $scope.KiemTraChucVu = function () {
            if ($scope.ChucVu.MaChucVu > 80 && $scope.ChucVu.MaChucVu<=99 ) {
                $scope.hideCoSo = true
            }

        }

        $scope.GetCoSo()
        $scope.GetAllTaiSan();
        $scope.GetThongKeTaiSan();


       

    }


})(angular.module('platformTH_GV.quanlytaisan'));