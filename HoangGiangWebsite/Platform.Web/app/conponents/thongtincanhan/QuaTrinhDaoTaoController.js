(function (app) {
    app.controller('QuaTrinhDaoTaoController', QuaTrinhDaoTaoController);

    function QuaTrinhDaoTaoController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter,$q) {
        $scope.msvc = $scope.authentication.userName;
        $scope.tenNhanVien = $scope.authentication.fullName;
       
        $scope.QuaTrinhDaotao = [];
        $scope.AddQuaTrinhDaotao = [{ MaSoNhanVien: $scope.msvc }];
        $scope.GetQuaTrinhDaotao = GetQuaTrinhDaotao;
      
        $scope.UpDateQuaTrinhDaotao = UpDateQuaTrinhDaotao;
        $scope.deleteItem = deleteItem;

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            ID: id
                        }
                    }
                    apiService.del('/api/QuaTrinhDaoTao/delete', config, function () {
                        $scope.GetQuaTrinhDaotao();
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

        $scope.clickss = 0;
        $scope.myFunction2 = function () {

            $scope.clickss++;
            $scope.solanlap2 = [];
            for (var i = 1; i <= $scope.clickss; i++) {
                $scope.solanlap2.push(i);
            }
           
            return $scope.solanlap2;
        }
        $scope.kiemtra = function () {



            if ($scope.clickss >= 1) {
                $scope.UpDateQuaTrinhDaotao();

            }
            else {

                var a = 0;
               
                angular.forEach($scope.QuaTrinhDaotao, function (item) {
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
                       
                     
                        angular.forEach($scope.QuaTrinhDaotao, function (item) {
                          
                          
                            apiService.put('/api/QuaTrinhDaoTao/update', item, function (result) {

                                $scope.GetQuaTrinhDaotao();
                                notificationService.displaySuccess("Sửa thành công");
                                $scope.hide = true
                                $scope.Edit = false
                                $scope.Add = false
                                $scope.save = false
                                $scope.close = true;

                               
                            }, function () {
                                console.log('sửa thông tin không thành công.');
                            });
                          
                        });
                       
                        
                        
                    });

                }

            }

        }


       
        $scope.huy = function () {
            $scope.Edit = false
            $scope.hide = true
            $scope.save = false;
            $scope.closehuy = false;
            $scope.close = true;
            $scope.GetQuaTrinhDaotao();
            $scope.AddQuaTrinhDaotao = [{ MaSoNhanVien: $scope.msvc }];
            $scope.solanlap2 = [];
            $scope.clickss = 0;
            $scope.Add = false
            $scope.delete = false
        }

        function GetQuaTrinhDaotao() {
            var config = {
                params: {
                    msnv: $scope.msvc
                }
            }
            apiService.get('/api/QuaTrinhDaoTao/GetQuaTrinhDaoTao', config, function (result) {

              
               
                    $scope.QuaTrinhDaotao = result.data;
                $scope.newarr = result.data;
                



              
                angular.forEach($scope.newarr, function (item) {
                    var date1 = new Date(item.NgayBatDau);
                    item.NgayBatDau = $filter('date')(date1, "yyyy-MM-dd");
                    var date2 = new Date(item.NgayKetThuc);
                    item.NgayKetThuc = $filter('date')(date2, "yyyy-MM-dd");
                 

                   
                    


                })





            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }

        function UpDateQuaTrinhDaotao() {
            var a = 0;
            var d = 0;
            var e = 0;
           
            
            angular.forEach($scope.QuaTrinhDaotao, function (item) {
                var b = new Date(item.NgayBatDau).getTime();
                var c = new Date(item.NgayKetThuc).getTime();
                if (b > c || b == c) {

                    a = 1
                }

            })
            angular.forEach($scope.AddQuaTrinhDaotao, function (item) {
                var b = new Date(item.NgayBatDau).getTime();
                var c = new Date(item.NgayKetThuc).getTime();
                if (b > c || b == c) {
                    d = 1
                  
                }
                if (item.NgayBatDau == null) {
                    e = 1

                    alert("Ngày bắt đầu không được bỏ trống")
                }
                else if (item.NgayKetThuc == null) {
                    e = 1

                    alert("Ngày kết thúc không được bỏ trống")
                }
                else if (item.TenTruong == null) {
                    e = 1

                    alert("Tên trường không được bỏ trống")
                }
                else if (item.LoaiBang == null) {

                    alert("Loại bảng không được bỏ trống")
                   e = 1

                }
                else if (item.ChuyenNganh == null) {

                    alert("Chuyên ngành không được bỏ trống")
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
                  
                    angular.forEach($scope.QuaTrinhDaotao, function (item) {
                      
                        apiService.put('/api/QuaTrinhDaoTao/update', item, function (result) {
                          
                            $scope.GetQuaTrinhDaotao();
                            notificationService.displaySuccess("Sửa thành công");
                            $scope.hide = true
                            $scope.Edit = false
                            $scope.Add = false
                            $scope.save = false
                            $scope.close = true
                            d = 1;
                        }, function () {
                            console.log('sửa thông tin không thành công.');
                        });
                    });
                  

                        apiService.post('/api/QuaTrinhDaoTao/create', $scope.AddQuaTrinhDaotao, function (result) {

                            notificationService.displaySuccess("Thêm thành công");
                            $scope.GetQuaTrinhDaotao();
                            $scope.Addrow = false
                            $scope.save = false
                            $scope.Add = false
                            $scope.close = true
                            $scope.hide = true
                            $scope.Edit = false
                            $scope.AddQuaTrinhDaotao = [{ MaSoNhanVien: $scope.msvc }];
                            $scope.solanlap2 = [];
                            $scope.clickss = 0;
                        }, function () {
                            notificationService.displaySuccess('Thêm không thành công');
                        });

                  

                });
               
            }
        }


        
        $scope.GetQuaTrinhDaotao();
    }
})(angular.module('platformTH_GV.thongtincanhan'));