(function (app) {
    app.controller('NgonNguController', NgonNguController);

    function NgonNguController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
      
        $scope.msvc = $scope.authentication.userName;
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.NgonNgu = [];
        $scope.AddNgonNgu = [{ MaSoNhanVien: $scope.msvc }];
        $scope.GetNgonNgu = GetNgonNgu;
        $scope.UpDateNgonNgu = UpDateNgonNgu;
     
        $scope.deleteItem = deleteItem;

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            ID: id
                        }
                    }
                    apiService.del('/api/ngonngu/delete', config, function () {
                        $scope.GetNgonNgu();
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                        function () {
                            notificationService.displayError('Xóa không thành công.');
                        });
                });
        }
       

        $scope.kiemtra = function () {



            if ($scope.clickss >= 1) {
                $scope.UpDateNgonNgu();

            }
            else {
                $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                    angular.forEach($scope.NgonNgu, function (item) {
                        apiService.put('/api/ngonngu/update', item, function (result) {
                            notificationService.displaySuccess("Sửa thành công");
                            $scope.GetNgonNgu();
                            $scope.save = false;
                            $scope.hide = true
                            $scope.Edit = false
                            $scope.Add = false

                        }, function () {
                            console.log('sửa thông tin không thành công.');
                        });
                    });
                    

                });


            }
        }
        $scope.hide = true;
        $scope.clone = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;
            $scope.clone = false;
           
            $scope.Add = true;
            $scope.delete = true;

        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
            $scope.clone = true;
            $scope.AddNgonNgu = [{ MaSoNhanVien: $scope.msvc }];
            $scope.solanlap2 = [];
            $scope.clickss = 0;
            $scope.Add = false
            $scope.delete = false
           

            $scope.GetNgonNgu();
        }
        function GetNgonNgu() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/ngonngu/GetngonNgu', config, function (result) {
                if (result.data.length > 0) {
                    $scope.NgonNgu = result.data;
                    $scope.clone = true;
                }
                else {
                    $scope.clone = false;
                }
               

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        $scope.clickss = 0;
        $scope.myFunction2 = function () {

            $scope.clickss++;
            $scope.solanlap2 = [];
            for (var i = 1; i <= $scope.clickss; i++) {
                $scope.solanlap2.push(i);
            }
            return $scope.solanlap2;
        }
        function UpDateNgonNgu() {
            var a = 0;
            var b = 0;
            angular.forEach($scope.NgonNgu, function (item) {

                if (item.TenNgonNgu == null) {
                    alert("Tên ngôn ngữ không được bỏ trống")
                    a = 1
                }
                else if (item.Nghe == null) {
                    alert(" Nge không được bỏ trống")
                    a = 1
                }
                 else if (item.Noi == null) {
                    alert("Nói không được bỏ trống")
                    a = 1
                }
                else if (item.Doc == null) {
                    alert("Đọc không được bỏ trống")
                    a = 1
                }
                else if (item.Viet == null) {
                    alert("Viết không được bỏ trống")
                    a = 1
                }


            })
            angular.forEach($scope.AddNgonNgu, function (item) {

                if (item.TenNgonNgu == null) {
                    alert("Tên ngôn ngữ không được bỏ trống")
                    b = 1
                }
                else if (item.Nghe == null) {
                    alert(" Nge không được bỏ trống")
                   b = 1
                }
                 else if (item.Noi == null) {
                    alert("Nói không được bỏ trống")
                    b = 1
                }
                else if (item.Doc == null) {
                    alert("Đọc không được bỏ trống")
                   b= 1
                }
                else if (item.Viet == null) {
                    alert("Viết không được bỏ trống")
                    b = 1
                }


            })
            if (a != 1 && b != 1) {


            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                angular.forEach($scope.NgonNgu, function (item) {
                    apiService.put('/api/ngonngu/update', item, function (result) {
                        notificationService.displaySuccess("Sửa thành công");
                      
                        $scope.save = false;
                        $scope.hide = true
                        $scope.Edit = false
                        $scope.Add = false
                        $scope.GetNgonNgu();
                    }, function () {
                        console.log('sửa thông tin không thành công.');
                    });
                });
                apiService.post('/api/ngonngu/create', $scope.AddNgonNgu, function (result) {
                 
                    notificationService.displaySuccess("Thêm thành công");
                    $scope.save = false
                    $scope.Add = false
                    $scope.close = true
                    $scope.hide = true
                    $scope.Edit = false
                    $scope.AddNgonNgu = [{ MaSoNhanVien: $scope.msvc }];
                    $scope.solanlap2 = [];
                    $scope.clickss = 0;
                    $scope.GetNgonNgu();
                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });

            });
            }

        }


        $scope.GetNgonNgu();
     

    }
})(angular.module('platformTH_GV.thongtincanhan'));