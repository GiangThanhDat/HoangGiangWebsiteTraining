(function (app) {
    'use strict';

    app.controller('KhachhangController', KhachhangController);

    KhachhangController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function KhachhangController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.bangxem = false;
        $scope.bangchitiet = false;
        $scope.TTCN = {};
        $scope.gettatca = function () {
            $scope.KhachHang = [];
            $scope.NhomKH_NCC ="";
            $scope.PhanLoai ="";
            $scope.bangxem = true;
            $scope.bangchitiet = false;

            apiService.get('/api/khachhang/getall', null, function (result) {

                $scope.KhachHang = result.data;
               

            }, function () {
                console.log('Load  failed.');
            });

        }
        $scope.getbykeyword = function (keyword) {
            $scope.bangxem = true;
            $scope.bangchitiet = false;

            $scope.KhachHang = [];
            var config = {
                params: {
                    keyword: keyword
                }
            }
            apiService.get('/api/khachhang/getbykeyword', config, function (result) {

                $scope.KhachHang = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }
        $scope.getTTCN = function (id) {
            $scope.id = id;
            $scope.bangxem = false;
            $scope.bangchitiet = true;
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/khachhang/getbyid', config, function (result) {

                $scope.TTCN = result.data;

            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.trove = function () {
            $scope.bangxem = true;
            $scope.bangchitiet = false;
        }


        $scope.view = true;
        $scope.edit = false;
        $scope.thaydoithongtin = function () {
            $scope.view = false;
            $scope.edit = true;
        }
        $scope.huy = function () {
            $scope.view = true;
            $scope.edit = false;
            $scope.getTTCN($scope.id);
        }


        $scope.updateTTCN=function () {


            $ngBootbox.confirm('Bạn chắc muốn sửa  không').then(function () {
                if ($scope.TTCN.NhomKH_NCC=="") {
                    $scope.TTCN.NhomKH_NCC = null;
                }
                apiService.put('/api/khachhang/update', $scope.TTCN, function (result) {
                    notificationService.displaySuccess("Sửa thành công");
                    $scope.getTTCN($scope.id);
                    $scope.view = !$scope.view;
                    $scope.edit = !$scope.edit
                }, function () {
                   notificationService.displayWarning("Sửa không thành công");
                });


            });

        }
        $scope.addKH = {
        }

        function getallKH() {
            apiService.get('/api/khachhang/getall', null, function (result) {
              //  $scope.AllKhachHang = result.data;
                
                if (result.data.length > 0) {
                    $scope.allNhanVien = result.data[result.data.length - 1].MaKhachHang.split('KH')[1];
                }
                else {
                    $scope.allNhanVien = 0;
                }

                var maso = parseInt($scope.allNhanVien);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "KH"
                var ans = pad.substring(0) + ans1



                $scope.addKH = {
                    MaKhachHang: ans, PhanLoai: 'Tổ chức', QuocGia: 'Việt Nam'

                }
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        getallKH()

        $scope.clicks1 = 0;
        $scope.themdong1 = function () {

            $scope.clicks1++;
            $scope.solanlap1 = [];
            for (var i = 1; i <= $scope.clicks1; i++) {
                $scope.solanlap1.push(i);
            }
            return $scope.solanlap1;
        }
        $scope.ttchung = true;
        $scope.khac = false;
        $scope.mottchung = function () {

            $scope.ttchung = true;
            $scope.khac = false;
        }
        $scope.mokhac = function () {
            $scope.ttchung = false;
            $scope.khac = true;
        }
        $scope.showtochuc = true;
        $scope.showcanhan = false;
        $scope.tochuc = function () {
            $scope.showtochuc = true;
            $scope.showcanhan = false;
        }
        $scope.canhan = function () {
            $scope.showtochuc = false;
            $scope.showcanhan = true;
        }
        $scope.NCC = false;

        $scope.AddNhaCungCap = {}
        $scope.getAllNCC = function () {

            apiService.get('/api/nhacungcap/getall', null, function (result) {


                if (result.data.length > 0) {
                    $scope.AllNhaCungCap = result.data[result.data.length - 1].MaNhaCungCap

                } else {
                    $scope.AllNhaCungCap = 0;

                }

                var maso = parseInt($scope.AllNhaCungCap);

                var str = "" + (maso + 1)
                var pad = "0000"
                var ans = pad.substring(0, pad.length - str.length) + str
                $scope.AddNhaCungCap.MaNhaCungCap = ans;
                $scope.addKH.MaNhaCungCap = ans;
            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.getAllNCC();
        $scope.NCC = false;
        $scope.NhaCungCap_TaiKhoan = []
        $scope.KhachHang_TaiKhoan = []
        $scope.addNganHang = []
        $scope.addMaTK = function (matk, i) {
            $scope.NhaCungCap_TaiKhoan[i] = {
                MaNhaCungCap: $scope.AddNhaCungCap.MaNhaCungCap,
                MaTaiKhoan: matk
            }
            $scope.KhachHang_TaiKhoan[i] = {
                MaKhachHang: $scope.addKH.MaKhachHang,
                MaTaiKhoan: matk
            }
        }
        $scope.addKhachHang = function () {
            $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
                if ($scope.NCC == false) {
                    apiService.post('/api/khachhang/create', $scope.addKH, function (result) {
                        notificationService.displaySuccess("Thêm thành công");
                        $('.bs-example-modal-lg1').modal('hide');

                        apiService.post('/api/taikhoannganhang/create', $scope.addNganHang, function (result) {
                            apiService.post('/api/khachhang-taikhoan/create', $scope.KhachHang_TaiKhoan, function (result) {
                                $scope.addNganHang = [];

                            }, function () {
                            });

                        }, function () {
                        });
                        getallKH()

                        $scope.addKH = {}
                    }, function () {
                        notificationService.displayWarning('Thêm thất bại');
                    });
                }
                else {
                    apiService.post('/api/taikhoannganhang/create', $scope.addNganHang, function (result) {
                        $scope.addNganHang = [];
                    }, function () {
                        notificationService.displayWarning('Thêm thất bại');
                    });
                    apiService.post('/api/khachhang/create', $scope.addKH, function (result) {
                        notificationService.displaySuccess("Thêm khách hàng thành công");
                        apiService.post('/api/khachhang-taikhoan/create', $scope.KhachHang_TaiKhoan, function (result) {
                            $scope.KhachHang_TaiKhoan = [];
                        }, function () {
                            notificationService.displayWarning('Thêm thất bại');
                        });

                        getallKH()
                        $scope.addKH = {}
                    }, function () {
                        notificationService.displayWarning('Thêm khách hàng thất bại');
                    });
                    //#region
                    $scope.AddNhaCungCap.NhomKH_NCC = $scope.addKH.NhomKH_NCC;
                    $scope.AddNhaCungCap.PhanLoai = $scope.addKH.PhanLoai;
                    $scope.AddNhaCungCap.TenNhaCungCap = $scope.addKH.TenKhachHang;
                    $scope.AddNhaCungCap.ChiNhanh = $scope.addKH.ChiNhanh;
                    $scope.AddNhaCungCap.DiaChi = $scope.addKH.DiaChi;
                    $scope.AddNhaCungCap.SoDienThoai = $scope.addKH.SoDienThoai;
                    $scope.AddNhaCungCap.Fax = $scope.addKH.Fax;
                    $scope.AddNhaCungCap.Email = $scope.addKH.Email;
                    $scope.AddNhaCungCap.Website = $scope.addKH.Website;
                    $scope.AddNhaCungCap.MaSoThue = $scope.addKH.MaSoThue;
                    $scope.AddNhaCungCap.SoTaiKhoanNganHang = $scope.addKH.SoTaiKhoanNganHang;
                    $scope.AddNhaCungCap.TenNganHang = $scope.addKH.TenNganHang;
                    $scope.AddNhaCungCap.NguoiLienHe = $scope.addKH.NguoiLienHe;
                    $scope.AddNhaCungCap.XungHo = $scope.addKH.XungHo;
                    $scope.AddNhaCungCap.NVBanHang = $scope.addKH.NVBanHang;
                    $scope.AddNhaCungCap.DienGiai = $scope.addKH.DienGiai;
                    $scope.AddNhaCungCap.DieuKhoanTT = $scope.addKH.DieuKhoanTT;
                    $scope.AddNhaCungCap.SoNgayDuocNo = $scope.addKH.SoNgayDuocNo;
                    $scope.AddNhaCungCap.SoNoToiDa = $scope.addKH.SoNoToiDa;
                    $scope.AddNhaCungCap.QuocGia = $scope.addKH.QuocGia;
                    $scope.AddNhaCungCap.Quan_Huyen = $scope.addKH.Quan_Huyen;
                    $scope.AddNhaCungCap.Tinh_TP = $scope.addKH.Tinh_TP;
                    $scope.AddNhaCungCap.Xa_Phuong = $scope.addKH.Xa_Phuong;
                    $scope.AddNhaCungCap.DienThoaiCoDinh_LH = $scope.addKH.DienThoaiCoDinh_LH;
                    $scope.AddNhaCungCap.HoVaTen_LH = $scope.addKH.HoVaTen_LH;
                    $scope.AddNhaCungCap.Email_LH = $scope.addKH.Email_LH;
                    $scope.AddNhaCungCap.ChucDanh_LH = $scope.addKH.ChucDanh_LH;
                    $scope.AddNhaCungCap.DiaChi_LH = $scope.addKH.DiaChi_LH;
                    $scope.AddNhaCungCap.DTdidong_LH = $scope.addKH.DTdidong_LH;
                    $scope.AddNhaCungCap.DTKhac_LH = $scope.addKH.DTKhac_LH;
                    $scope.AddNhaCungCap.DaiDienTheoPL_LH = $scope.addKH.DaiDienTheoPL_LH;
                    $scope.AddNhaCungCap.TenNguoiNhan = $scope.addKH.TenNguoiNhan;
                    $scope.AddNhaCungCap.DienThoaiNguoiNhan = $scope.addKH.DienThoaiNguoiNhan;
                    $scope.AddNhaCungCap.DiaChiNguoiNhan = $scope.addKH.DiaChiNguoiNhan;
                    $scope.AddNhaCungCap.EmailNguoiNhan = $scope.addKH.EmailNguoiNhan;
                    $scope.AddNhaCungCap.DiaDiemGiaoHang = $scope.addKH.DiaDiemGiaoHang;
                    $scope.AddNhaCungCap.NgayCap = $scope.addKH.NgayCap;
                    $scope.AddNhaCungCap.NoiCap = $scope.addKH.NoiCap;
                    $scope.AddNhaCungCap.CMND = $scope.addKH.CMND;
                    //#endregion
                    apiService.post('/api/nhacungcap/create', $scope.AddNhaCungCap, function (result) {

                        notificationService.displaySuccess("Thêm nhà cung cấp thành công");
                        apiService.post('/api/nhacungcap-taikhoan/create', $scope.NhaCungCap_TaiKhoan, function (result) {
                            $scope.NhaCungCap_TaiKhoan = [];
                        }, function () {
                            notificationService.displayWarning('Thêm thất bại');
                        });
                        $scope.getAllNCC();
                        $scope.AddNhaCungCap = {}
                    }, function () {
                        notificationService.displayWarning('Thêm nhà cung cấp thất bại');
                    });

                }




            });
        }
        function GetAllNhanVien() {

            apiService.get('/api/nhanvien/getall', null, function (result) {

                $scope.LyLichNhanVien = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllNhanVien();
        function getNhomKH() {
            apiService.get('/api/nhomkh_ncc/getall', null, function (result) {
                $scope.NhomKH = result.data;

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        getNhomKH();
    }
   
    
})(angular.module('platformTH_GV.doituong'));