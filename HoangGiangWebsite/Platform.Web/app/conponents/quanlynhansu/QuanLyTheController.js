(function (app) {
    app.controller('QuanLyTheController', QuanLyTheController);

    function QuanLyTheController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
       
        $scope.The = [];
        $scope.edit = false

///get ten nhan vien theo MaSoNhanVien
        $scope.GetTenNhanVienThe = function () {
            $scope.The = [];
            apiService.get('/api/the/gettennhanvienthe', null, function (result) {

                $scope.TenNhanVienThe = result.data;
              

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        $scope.getbyID = {};
        $scope.GetTenNhanVienThe()
        $scope.sua = function () {
            $scope.edit = true
           

        }

        $scope.GetThe = function () {
            $scope.AllMaSoNhanVien = false;
            $scope.FilterMaSoNhanvien = [];
            $scope.The = [];
            apiService.get('/api/the/getall', null, function (result) {

                $scope.The = result.data;
                $scope.All = true;
                $scope.view = true;
                angular.forEach($scope.The, function (item) {
                    item.NgayYeuCau = new Date(item.NgayYeuCau);
                   
                    item.NgayCap = new Date(item.NgayCap);
                    
                    item.NgayHetHan = new Date(item.NgayHetHan);
                    angular.forEach($scope.TenNhanVienThe, function (value) {
                        if (item.MaSoNhanVien == value.MaSoNhanVien) {
                            item.HoVaTen = value.HoVaTen
                        }
                    });
                });

               
            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        


        $scope.search = function (keyword) {
            $scope.GetTenNhanVienThe()
            $scope.AllMaSoNhanVien = false;
            $scope.FilterMaSoNhanvien = [];
            $scope.The = [];
            var config = {
                params: {
                    name: keyword
                }
            }
            apiService.get('/api/the/search', config, function (result) {
                $scope.The = result.data;
                angular.forEach($scope.The, function (item) {
                    angular.forEach($scope.TenNhanVienThe, function (value) {
                        if (item.MaSoNhanVien == value.MaSoNhanVien) {
                            item.HoVaTen = value.HoVaTen
                        }
                    });
                });
              
                $scope.All = true;
                console.log($scope.The)
            }, function () {
                console.log('Load  failed.');
            });

        }
        



       $scope.getTheoMaNhanVien = function (item) {
           
            $scope.The = [];
            var config = {
                params: {
                    msnv: item
                }
            }
           apiService.get('/api/the/Getthe', config, function (result) {
               $scope.FilterMaSoNhanvien = result.data;
               $scope.All = false;
               $scope.AllMaSoNhanVien = true;
               angular.forEach($scope.FilterMaSoNhanvien, function (item) {
                   

                   angular.forEach($scope.TenNhanVienThe, function (value) {
                       if (item.MaSoNhanVien == value.MaSoNhanVien) {
                           item.HoVaTen = value.HoVaTen
                       }
                   });
               });
            }, function () {
                console.log('Load  failed.');
            });

        }
      $scope.Delete = function (item) {
         

          $scope.search()
            var config = {
                params: {
                    ID: item
                }
            }
          apiService.get('/api/the/delete', config, function (result) {
              //$scope.GetTenNhanVienThe()
              //$scope.getTheoMaNhanVien()
              //$scope.search()
              alert("Xóa thành công")
              $scope.GetThe()
              $scope.All = true;
             
            }, function () {
                console.log('Load  failed.');
            });

        }
        $scope.thutu;
        $scope.show = function (item) {
            $scope.thutu = item;
            return $scope.thutu;
        }
        $scope.huy = function (){
            $scope.thutu = -1;
            $scope.edit = false

        }
        $scope.luu = function () {

            apiService.put('/api/the/update', $scope.The, function (result) {
                $scope.thutu = -1;
                $scope.edit = false

                $scope.GetThe()

                notificationService.displaySuccess('Sửa thành công')
            }, function () {
                console.log('Load  failed.');

            });
                
                

        }
      
       
    }
})(angular.module('platformTH_GV.quanlynhansu'));