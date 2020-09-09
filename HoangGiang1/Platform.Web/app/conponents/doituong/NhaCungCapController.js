(function (app) {
    'use strict';

    app.controller('NhaCungCapController', NhaCungCapController);

    NhaCungCapController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService', '$http', 'i18nService'];
    function NhaCungCapController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http, i18nService) {



        $scope.FilterTenNhaCungcap = {};
        $scope.view = true



        $scope.thaydoithongtin = function () {

            $scope.view = false
            $scope.edit = true

        }
        $scope.huy = function () {

            $scope.view = true
            $scope.edit = false
            $scope.getTenNhaCungcap($scope.item)

        }
        $scope.trove = function () {

            $scope.AllTenNhaCungcap = false
            $scope.hideAll = true

        }

        $scope.GetAllNhaCungCap = function () {
            $scope. NhomKH_NCC=''
            $scope.NhaCungCapAll=[]


            apiService.get('/api/nhacungcap/getall', null, function (result) {

                $scope.NhaCungCapAll = result.data;
                $scope.hideAll = true
                $scope.AllTenNhaCungcap = false




            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.getTenNhaCungcap = function (item) {
            $scope.item = item
            var config = {
                params: {
                    name: item
                }
            }
            apiService.get('/api/nhacungcap/getThongTinNhaCungCap', config, function (result) {

                $scope.FilterTenNhaCungcap = result.data;
                $scope.AllTenNhaCungcap = true
                $scope.hideAll = false

                $scope.view = true

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }
        $scope.update = function () {

            apiService.put('/api/nhacungcap/update', $scope.FilterTenNhaCungcap, function (result) {

                alert("Update Thành công")
                $scope.edit = false
                $scope.view = true

            }, function () {
                console.log('Load Thông tin  failed.');
            });

        }

        $scope.getbykeyword = function (keyword) {
            $scope.hideAll = true;
            $scope.AllTenNhaCungcap = false;

            $scope.NhaCungCapAll = [];
            var config = {
                params: {
                    name: keyword
                }
            }
            apiService.get('/api/nhacungcap/search', config, function (result) {

                $scope.NhaCungCapAll = result.data;

            }, function () {
                console.log('Load  failed.');
            });

        }






        $scope.addKH = {
        }

        function getallKH() {
            apiService.get('/api/khachhang/getall', null, function (result) {
                //  $scope.AllKhachHang = result.data;
                var maso = parseInt(result.data[result.data.length - 1].MaKhachHang);

                var str = "" + (maso + 1)
                var pad = "000000"
                var ans = pad.substring(0, pad.length - str.length) + str




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
                MaKhachHang: $scope.AddNhaCungCap.MaKhachHang,
                MaTaiKhoan: matk
            }
            $scope.KhachHang_TaiKhoan[i] = {
                MaNhaCungCap: $scope.addKH.MaNhaCungCap,
                MaTaiKhoan: matk
            }
        }
        $scope.addKhachHang = function () {
            $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
                if ($scope.NCC == false) {
                    apiService.post('/api/nhacungcap/create', $scope.addKH, function (result) {
                        notificationService.displaySuccess("Thêm thành công");
                        $('.bs-example-modal-lg1').modal('hide');

                        apiService.post('/api/taikhoannganhang/create', $scope.addNganHang, function (result) {
                            apiService.post('/api/nhacungcap-taikhoan/create', $scope.KhachHang_TaiKhoan, function (result) {
                                $scope.addNganHang = [];

                            }, function () {
                            });

                        }, function () {
                        });
                        $scope.getAllNCC();
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
                    apiService.post('/api/nhacungcap/create', $scope.addKH, function (result) {
                        notificationService.displaySuccess("Thêm nhà cung cấp thành công");
                        apiService.post('/api/nhacungcap-taikhoan/create', $scope.KhachHang_TaiKhoan, function (result) {
                            $scope.KhachHang_TaiKhoan = [];
                        }, function () {
                            notificationService.displayWarning('Thêm thất bại');
                        });
                        getallKH();
                        $scope.getAllNCC();
                        $scope.addKH = {}
                    }, function () {
                            notificationService.displayWarning('Thêm nhà cung cấp thất bại');
                    });
                    //#region
                    $scope.AddNhaCungCap.NhomKH_NCC = $scope.addKH.NhomKH_NCC;
                    $scope.AddNhaCungCap.PhanLoai = $scope.addKH.PhanLoai;
                    $scope.AddNhaCungCap.TenKhachHang = $scope.addKH.TenNhaCungCap;
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
                    apiService.post('/api/khachhang/create', $scope.AddNhaCungCap, function (result) {

                        notificationService.displaySuccess("Thêm khách hàng thành công");
                        apiService.post('/api/khachhang-taikhoan/create', $scope.NhaCungCap_TaiKhoan, function (result) {
                            $scope.NhaCungCap_TaiKhoan = [];
                        }, function () {
                            notificationService.displayWarning('Thêm thất bại');
                        });
                        getallKH()

                        $scope.AddNhaCungCap = {}
                    }, function () {
                            notificationService.displayWarning('Thêm khách hàng thất bại');
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