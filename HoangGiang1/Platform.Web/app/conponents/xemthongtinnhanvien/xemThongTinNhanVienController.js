(function (app) {
    'use strict';

    app.controller('xemThongTinNhanVienController', xemThongTinNhanVienController);

    xemThongTinNhanVienController.$inject = ['$scope', 'apiService', '$stateParams', '$window', 'notificationService', '$ngBootbox', '$filter'];
    function xemThongTinNhanVienController($scope, apiService, $stateParams, $window, notificationService, $ngBootbox, $filter) {
        $scope.msnv = "";
        $scope.closeTTCN = true
        $scope.viewTTCN = true
        $scope.closeNgonNgu = true
        $scope.viewNgonNgu = true
        $scope.LyLichNhanVien = {};
        $scope.QuaTrinhDaotao = [];
        $scope.putupdateimage = putupdateimage;
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

        $scope.msvc = $scope.authentication.userName;
        $scope.tenNhanVien = $scope.authentication.fullName;

        $scope.getAllListNhanvien = function () {
            $scope.listNhanvien = []
            apiService.get('/api/nhanvien/getall', null, function (result) {
                $scope.listNhanvien = result.data;
            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.search = function (keyword) {
            $scope.listNhanvien = []
            $scope.TTCN = false;
            $scope.listNhanVien = true;
            var config = {
                params: {
                    keyword: keyword
                }
            }
            apiService.get('/api/nhanvien/search', config, function (result) {
                $scope.listNhanvien = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }



        $scope.showlistNhanVien = function () {
            $scope.listNhanVien = true;
            $scope.TTCN = false;
            $scope.getAllListNhanvien()
        }
        $scope.mobangTTCN = function () {
            $scope.EditTTCN = true
            $scope.closeTTCN = false
            $scope.saveTNCN = true
            $scope.viewTTCN = false
        }
        $scope.huyTNCN = function () {
            $scope.EditTTCN = false
            $scope.closeTTCN = true
            $scope.saveTNCN = false
            $scope.viewTTCN = true
        }
        $scope.mobangNgonNgu = function () {
            $scope.EditNgonNgu = true
            $scope.closeNgonNgu = false
            $scope.saveNgonNgu = true
            $scope.viewNgonNgu = false
            $scope.insertNgonNgu = true

        }
        $scope.huyNgonNgu = function () {
            $scope.EditNgonNgu = false
            $scope.closeNgonNgu = true
            $scope.saveNgonNgu = false
            $scope.viewNgonNgu = true
            $scope.insertNgonNgu = false
            $scope.solanlapNN = [];
            $scope.clickNN = 0;
        }


        $scope.UpDateLyLichNhanVien = function () {


            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                apiService.put('/api/nhanvien/update', $scope.LyLichNhanVien, function (result) {
                    notificationService.displaySuccess("Sửa thành công");
                    $scope.EditTTCN = false
                    $scope.viewTTCN = true
                    $scope.closeTTCN = true
                    $scope.saveTNCN = false
                    console.log('Sửa thành công.');
                }, function () {
                    console.log('sửa thông tin không thành công.');
                });


            });

        }





        $scope.GetAll = GetAll;
        $scope.LyLichNhanVien = [];

        $scope.viewLichSuLamViec = true;
        $scope.btnsua = true;
     

        function GetAll(item) {
            $scope.item = item;
            $scope.TTCN = true;
            $scope.listNhanVien = false;
            var config = {
                params: {
                    msnv: item
                }
            }
            apiService.get('/api/nhanvien/getnhanVien', config, function (result) {
                $scope.LyLichNhanVien = result.data;
                var date1 = new Date($scope.LyLichNhanVien.NgayCapCMND);
                $scope.LyLichNhanVien.NgayCapCMND = $filter('date')(date1, "yyyy-MM-dd");

                var date1 = new Date($scope.LyLichNhanVien.NgaySinh);
                $scope.LyLichNhanVien.NgaySinh = $filter('date')(date1, "yyyy-MM-dd");

                $scope.AddNgonNgu = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
                $scope.AddQuaTrinhDaotao = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
                $scope.AddLichSulamViec = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
            }, function () {
                console.log('Load Thông tin  failed.');
            });
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
            apiService.get('/api/ngonngu/GetngonNgu', config, function (result) {
                $scope.NgonNgu = result.data;
            }, function () {
                console.log('Load Thông tin  failed.');
            });
            apiService.get('/api/lichsulamviec/GetLichSuLamViec', config, function (result) {

                $scope.LichSulamViec = result.data;
                $scope.newLS = result.data;


                angular.forEach($scope.newLS, function (item) {
                    var date1 = new Date(item.NgayBatDau);
                    item.NgayBatDau = $filter('date')(date1, "yyyy-MM-dd");
                    var date2 = new Date(item.NgayKetThuc);
                    item.NgayKetThuc = $filter('date')(date2, "yyyy-MM-dd");
                })

            }, function () {
                console.log('Load Thông tin  failed.');
            });
            apiService.get('/api/thongtintuyendung/GetthongTinTuyenDung', config, function (result) {

                $scope.ThongTinTuyenDung = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
            apiService.get('/api/quanlyngaynghi/GetquanLyNgayNghi', config, function (result) {

                $scope.QuanLyNgayNghi = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
            apiService.get('/api/quanlycongtac/GetquanLyCongTac', config, function (result) {

                $scope.QuanLyCongTac = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
            apiService.get('/api/the/Getthe', config, function (result) {
                $scope.The = result.data;
            }, function () {
                console.log('Load Thông tin  failed.');
            });
            apiService.get('/api/hoanthanhcongviec/GetHoanThanhCongViec', config, function (result) {
                $scope.HoanThanhCongViec = result.data;
            }, function () {
                console.log('Load Thông tin  failed.');
            });
            apiService.get('/api/quanlyquagio/GetQuanLyQuaGio', config, function (result) {

                $scope.QuanLyQuaGio = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });

            $scope.hide = true

        }

        //Lich su lam viec
        //#region
      
      

        $scope.suaLichSuLamViec = function () {
            $scope.btnsua = false;
            $scope.btnhuy = true;
            $scope.btnsave = true;
            $scope.AddLS = true;
            $scope.editLichSuLamViec = true;
            $scope.viewLichSuLamViec = false;


        }
        $scope.huyLichSulamViec = function () {
            $scope.GetAll($scope.item)
            $scope.btnsua = true;
            $scope.btnhuy = false;
            $scope.AddLS = false;
            $scope.btnsave = false;
            $scope.AddLichSulamViec = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
            $scope.solanlapLS = [];
            $scope.clickLS = 0;
            $scope.viewLichSuLamViec = true;
            $scope.editLichSuLamViec = false;
        }


        $scope.clickLS = 0;
        $scope.myFunctionLS = function () {

            $scope.clickLS++;
            $scope.solanlapLS = [];
            for (var i = 1; i <= $scope.clickLS; i++) {
                $scope.solanlapLS.push(i);
            }
            return $scope.solanlapLS;
        }

        $scope.kiemtraLS = function () {
            if ($scope.clickLS >= 1) {
                $scope.luuLichSuLamViec();


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
                                $scope.GetAll($scope.item)
                                $scope.btnsua = true;
                                $scope.btnhuy = false;
                                $scope.AddLS = false;
                                $scope.btnsave = false;
                                $scope.editLichSuLamViec = false;
                                $scope.viewLichSuLamViec = true;
                                $scope.AddLichSulamViec = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
                                $scope.solanlapLS = [];
                                $scope.clickLS = 0;



                               
                                console.log('Sửa thành công.');
                            }, function () {
                                console.log('sửa thông tin không thành công.');
                            });
                        });




                    });
                }

            }




            }



        






        $scope.luuLichSuLamViec = function () {
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

              else  if (item.TenCongTy == null) {
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

            else if (a != 1&& d != 1&&e != 1 ) {


                $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {


                    angular.forEach($scope.LichSulamViec, function (item) {
                        apiService.put('/api/lichsulamviec/update', item, function (result) {
                            notificationService.displaySuccess("Sửa lịch sử làm việc thành công");
                            
                        }, function () {
                            notificationService.displayWarming("Sửa lịch sử làm việc không thành công");
                        });
                    });

                    apiService.post('/api/lichsulamviec/create', $scope.AddLichSulamViec, function (result) {

                        notificationService.displaySuccess("Thêm thành công");
                      

                        $scope.GetAll($scope.item)
                        $scope.btnsua = true;
                        $scope.btnhuy = false;
                        $scope.AddLS = false;
                        $scope.btnsave = false;
                        $scope.editLichSuLamViec = false;
                        $scope.viewLichSuLamViec = true;
                        $scope.AddLichSulamViec = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
                        $scope.solanlapLS = [];
                        $scope.clickLS = 0;

                    }, function () {
                        notificationService.displaySuccess('Thêm không thành công');
                    });





                })
            };
        }
        //#endregion

        //Qua trinh dao tao
        //#region
        $scope.viewQuaTrinhDaoTao = true;
        $scope.editQuaTrinhDaoTao = false;
        $scope.suaQuaTrinhDaoTao = function () {
            $scope.viewQuaTrinhDaoTao = false;
            $scope.editQuaTrinhDaoTao = true;
            $scope.insertQTDT = true;


        }
        $scope.huyQuaTrinhDaoTao = function () {
            $scope.GetAll($scope.item)
            $scope.viewQuaTrinhDaoTao = true;
            $scope.editQuaTrinhDaoTao = false;
            $scope.insertQTDT = false;
            $scope.solanlapQTDT = [];
            $scope.clickQTDT = 0;
        }


        $scope.clickQTDT = 0;
        $scope.myFunctionQTDT = function () {

            $scope.clickQTDT++;
            $scope.solanlapQTDT = [];
            for (var i = 1; i <= $scope.clickQTDT; i++) {
                $scope.solanlapQTDT.push(i);
            }
            return $scope.solanlapQTDT;
        }

        $scope.kiemtraQTDT = function () {


            if ($scope.clickQTDT == 0) {

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


                                notificationService.displaySuccess("Sửa thành công quá trình đào tạo");
                                $scope.GetAll($scope.item)
                                $scope.viewQuaTrinhDaoTao = true;
                                $scope.editQuaTrinhDaoTao = false;
                                $scope.insertQTDT = false
                                $scope.solanlapQTDT = [];
                                $scope.clickQTDT = 0;
                            }, function () {
                                notificationService.displayWarming("Sửa không thành công");
                            });

                        });

                    });

                }
            }
            else if ($scope.clickQTDT >=1){
                $scope.luuQuaTrinhDaoTao();
            }


        }


        $scope.luuQuaTrinhDaoTao = function () {

          
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
                alert("Ngày bắt đầu phải nhỏ hơn ngày kết thúc Q")

            }

            if (d === 1) {
                alert("Thêm ngày bắt đầu phải nhỏ hơn ngày kết thúc")

            }

            else if (a != 1 && d !=1 && e!=1) {




                $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {

                    angular.forEach($scope.QuaTrinhDaotao, function (item) {


                        apiService.put('/api/QuaTrinhDaoTao/update', item, function (result) {


                            notificationService.displaySuccess("Sửa thành công");

                            $scope.viewQuaTrinhDaoTao = true;
                            $scope.editQuaTrinhDaoTao = false;

                        }, function () {
                            notificationService.displayWarming("Sửa không thành công");
                        });

                    });

                    apiService.post('/api/QuaTrinhDaoTao/create', $scope.AddQuaTrinhDaotao, function (result) {

                        notificationService.displaySuccess("Thêm thành công");
                        $scope.GetAll($scope.item)
                        $scope.viewQuaTrinhDaoTao = true;
                        $scope.editQuaTrinhDaoTao = false;
                        $scope.insertQTDT = false
                        $scope.AddQuaTrinhDaotao = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
                        $scope.solanlapQTDT = [];
                        $scope.clickQTDT = 0;
                    }, function () {
                        notificationService.displaySuccess('Thêm không thành công');
                    });

                });

            };
        }

        //#endregion

        //AddNongNgu


        $scope.clickNN = 0;
        $scope.myFunctionNN = function () {

            $scope.clickNN++;
            $scope.solanlapNN = [];
            for (var i = 1; i <= $scope.clickNN; i++) {
                $scope.solanlapNN.push(i);
            }
            return $scope.solanlapNN;
        }


        $scope.kiemtra = function () {
            if ($scope.clickNN==0) {

                $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                    angular.forEach($scope.NgonNgu, function (item) {
                        apiService.put('/api/ngonngu/update', item, function (result) {
                            notificationService.displaySuccess("Sửa thành công");
                            $scope.EditNgonNgu = false
                            $scope.saveNgonNgu = false
                            $scope.closeNgonNgu = true
                            $scope.viewNgonNgu = true
                            $scope.insertNgonNgu = false

                        }, function () {
                            console.log('sửa thông tin không thành công.');
                        });
                    });

                })

            }
            else if ($scope.clickNN >=1) {

                $scope.UpDateNgonNgu();
            }
        }
        $scope.UpDateNgonNgu = function () {


            $ngBootbox.confirm('Bạn chắc muốn Sửa  không').then(function () {
                angular.forEach($scope.NgonNgu, function (item) {
                    apiService.put('/api/ngonngu/update', item, function (result) {
                        notificationService.displaySuccess("Sửa thành công");
                        $scope.EditNgonNgu = false
                        $scope.saveNgonNgu = false
                        $scope.closeNgonNgu = true
                        $scope.viewNgonNgu = true

                    }, function () {
                        console.log('sửa thông tin không thành công.');
                    });
                });

                apiService.post('/api/ngonngu/create', $scope.AddNgonNgu, function (result) {

                    notificationService.displaySuccess("Thêm thành công");
                    $scope.EditNgonNgu = false
                    $scope.saveNgonNgu = false
                    $scope.closeNgonNgu = true
                    $scope.viewNgonNgu = true
                    $scope.insertNgonNgu = false
                    $scope.AddNgonNgu = [{ MaSoNhanVien: $scope.LyLichNhanVien.MaSoNhanVien }];
                    $scope.solanlapNN = [];
                    $scope.clickNN = 0;

                    var config = {
                        params: {
                            msnv: $scope.item
                        }
                    }
                    apiService.get('/api/ngonngu/GetngonNgu', config, function (result) {

                        $scope.NgonNgu = result.data;

                    }, function () {
                        console.log('Load Thông tin  failed.');
                    });

                }, function () {
                    notificationService.displaySuccess('Thêm không thành công');
                });

            });
        }







        $scope.GetChucVu = function (item) {
            var config = {
                params: {
                    msnv: item
                }
            }
            apiService.get('/api/nhanvien/getchucvu', config, function (result) {
                $scope.ChucVu = result.data;

            }, function () {
                console.log('load không thành công.');
            });
        }

        $scope.getAllListNhanvien();
        function GetCoSo() {

            apiService.get('/api/coso/getall', null, function (result) {

                $scope.getALLCoSo = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetCoSo();

    }
})(angular.module('platformTH_GV.xemthongtinnhanvien'));