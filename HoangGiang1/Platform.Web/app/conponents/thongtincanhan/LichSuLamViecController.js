(function (app) {
    app.controller('LichSuLamViecController', LichSuLamViecController);

    function LichSuLamViecController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tennhanvien = $scope.authentication.fullName;
        $scope.LichSulamViec = [];
        $scope.AddLichSulamViec = [{ MaSoNhanVien: $scope.msvc}];
        $scope.GetLichSulamViec = GetLichSulamViec;
        $scope.UpDateLichSulamViec = UpDateLichSulamViec;

        $scope.deleteItem = deleteItem;

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            ID: id
                        }
                    }
                    apiService.del('/api/lichsulamviec/delete', config, function () {
                        $scope.GetLichSulamViec();
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                        function () {
                            notificationService.displayError('Xóa không thành công.');
                        });
                });
        }



        


        $scope.hide = true;
        $scope.close = true;
        $scope.mobang = function () {
            $scope.Edit = true
            $scope.hide = false;
            $scope.save = true;
            $scope.closehuy = true;
            $scope.Add = true;
            $scope.close = false;
            $scope.delete = true;

        }
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
            $scope.GetLichSulamViec();
            $scope.AddLichSulamViec = [{ MaSoNhanVien: $scope.msvc }];
            $scope.solanlap2 = [];
            $scope.clickss = 0;
            $scope.Add = false
            $scope.close = true
            $scope.delete = false
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





        function GetLichSulamViec() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/lichsulamviec/GetLichSuLamViec', config, function (result) {

                $scope.LichSulamViec = result.data;
                angular.forEach($scope.LichSulamViec, function (item) {
                    var date1 = new Date(item.NgayBatDau);
                    item.NgayBatDau = $filter('date')(date1, "yyyy-MM-dd");
                    var date2 = new Date(item.NgayKetThuc);
                    item.NgayKetThuc = $filter('date')(date2, "yyyy-MM-dd");
                })

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        $scope.kiemtra = function () {



            if ($scope.clickss >= 1) {
                $scope.UpDateLichSulamViec();

            }
            else {
                var a = 0;
              
                angular.forEach($scope.LichSulamViec, function (item) {
                    var b = new Date(item.NgayBatDau).getTime();
                    var c = new Date(item.NgayKetThuc).getTime();
                    if (b > c || b == c) {

                        a = 1
                    }

                })
               

                if (a === 1) {
                    alert("Ngày bắt đầu phải nhỏ hơn ngày kết thúc")

                }
              
                else if (a != 1) {


                    $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {


                        angular.forEach($scope.LichSulamViec, function (item) {
                            apiService.put('/api/lichsulamviec/update', item, function (result) {
                                notificationService.displaySuccess("Sửa thành công");
                                $scope.GetLichSulamViec();
                                $scope.save = false;
                                $scope.hide = true
                                $scope.Edit = false
                                $scope.Add = false
                                $scope.close = true
                                console.log('Sửa thành công.');
                            }, function () {
                                console.log('sửa thông tin không thành công.');
                            });
                        });




                    });
                }

            }
        }
        function UpDateLichSulamViec() {
            var a = 0;
            var d = 0;
            var e = 0;

            angular.forEach($scope.LichSulamViec, function (item) {
                var b = new Date(item.NgayBatDau).getTime();
                var c = new Date(item.NgayKetThuc).getTime();
                if (b > c || b == c) {

                    a = 1
                }





            })

            angular.forEach($scope.AddLichSulamViec, function (item) {
                var b = new Date(item.NgayBatDau).getTime();
                var c = new Date(item.NgayKetThuc).getTime();
                if (b > c || b == c) {

                    d = 1
                }
                if (item.NgayBatDau == null) {
                    alert("Ngày bắt đầu  không được bỏ trống")
                    e = 1
                }
                else if (item.NgayKetThuc == null) {
                    alert("Ngày kết thúc  không được bỏ trống")
                    e = 1
                }

                else if (item.TenCongTy == null) {
                    alert("Tên công ty không được bỏ trống")
                    e = 1
                }
                else if (item.ViTriLamViec == null) {
                    alert("Vị trí làm việc không được bỏ trống")
                    e = 1
                }
                else if (item.NoiDungCongViec == null) {
                    alert("Nội dung công việc không được bỏ trống")
                    e = 1
                }


            })


            if (a === 1) {
                alert("Ngày bắt đầu phải nhỏ hơn ngày kết thúc")

            }
            if (d === 1) {
                alert("Thêm ngày bắt đầu phải nhỏ hơn ngày kết thúc")

            }

            else if (a != 1 && d != 1 && e != 1) {


                $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                  

                    angular.forEach($scope.LichSulamViec, function (item) {
                        apiService.put('/api/lichsulamviec/update', item, function (result) {
                            notificationService.displaySuccess("Sửa thành công");
                            $scope.GetLichSulamViec();
                            $scope.save = false;
                            $scope.hide = true
                            $scope.Edit = false
                            $scope.Add = false
                            console.log('Sửa thành công.');
                        }, function () {
                            console.log('sửa thông tin không thành công.');
                        });
                    });
                    apiService.post('/api/lichsulamviec/create', $scope.AddLichSulamViec, function (result) {

                        notificationService.displaySuccess("Thêm thành công");
                        $scope.GetLichSulamViec();

                        $scope.save = false
                        $scope.Add = false
                        $scope.close = true
                        $scope.hide = true
                        $scope.Edit = false
                        $scope.AddLichSulamViec = [{ MaSoNhanVien: $scope.msvc }];
                        $scope.solanlap2 = [];
                        $scope.clickss = 0;
                    }, function () {
                        notificationService.displaySuccess('Thêm không thành công');
                    });
                    
                   

                    
                        
                    

                });
            }
        }

        $scope.GetLichSulamViec();
    }
})(angular.module('platformTH_GV.thongtincanhan'));