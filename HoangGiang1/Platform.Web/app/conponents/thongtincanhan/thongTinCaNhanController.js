(function (app) {
    'use strict';

    app.controller('thongTinCaNhanController', thongTinCaNhanController);

    thongTinCaNhanController.$inject = ['$scope', 'apiService', '$stateParams', '$window', 'notificationService', '$ngBootbox', '$filter'];
    function thongTinCaNhanController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tenNhanVien = $scope.authentication.fullName;
        
      
     
     
      
     
    
        $scope.QuanLyVangMat = [];
    
      
     
        $scope.LyLichNhanVien = [];

        $scope.putupdateimage = putupdateimage;






       
      
    
      
     
     
    
        $scope.GetQuanLyVangMat = GetQuanLyVangMat;
      
    
      
        $scope.GetLyLichNhanVien = GetLyLichNhanVien;


        $scope.UpDateLyLichNhanVien = UpDateLyLichNhanVien;
      
     
      
      
      
   
   
       
   
       
      
       

       

       
        $scope.hide = true;
        $scope.close = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;
            $scope.close = false;

        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
            $scope.close = true;
        }




      
       

     
        function GetQuanLyVangMat() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/quanlyvangmat/GetquanLyVangMat', config, function (result) {

                $scope.QuanLyVangMat = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        function GetLyLichNhanVien() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/nhanvien/getnhanVien', config, function (result) {

                $scope.LyLichNhanVien = result.data;
                var date1 = new Date($scope.LyLichNhanVien.NgayCapCMND);
                $scope.LyLichNhanVien.NgayCapCMND = $filter('date')(date1, "yyyy-MM-dd");
                 var date1 = new Date($scope.LyLichNhanVien.NgaySinh);
                $scope.LyLichNhanVien.NgaySinh = $filter('date')(date1, "yyyy-MM-dd");


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }


     
      
     
     
   
      
        $scope.GetQuanLyVangMat();
     
     
    
        $scope.GetLyLichNhanVien();







       


        function UpDateLyLichNhanVien() {


            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                apiService.put('/api/nhanvien/update', $scope.LyLichNhanVien, function (result) {
                    notificationService.displaySuccess("Sửa thành công");
                    $scope.GetLyLichNhanVien();
                    $scope.save = false;
                    $scope.close = true;
                    $scope.hide = !$scope.hide;
                    $scope.Edit = !$scope.Edit
                    console.log('Sửa thành công.');
                }, function () {
                    console.log('sửa thông tin không thành công.');
                });


            });

        }
    
     
        

        $scope.GetChucVu = function () {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/nhanvien/getchucvu', config, function (result) {
                $scope.ChucVu = result.data;

            }, function () {
                console.log('load không thành công.');
            });
      


        }

        function putupdateimage() {
            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                apiService.put('/api/nhanvien/update', $scope.LyLichNhanVien, function (result) {
                    notificationService.displaySuccess("Sửa ảnh thành công");
                    $scope.GetLyLichNhanVien();


                    console.log('Sửa thành công.');
                }, function () {
                    console.log('sửa thông tin không thành công.');
                });
            });

        }

     



      
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.LyLichNhanVien.Hinh = fileUrl;
            }
            finder.popup();
            $scope.putupdateimage();


        }
        $scope.GetChucVu();
   
    }
})(angular.module('platformTH_GV.thongtincanhan'));