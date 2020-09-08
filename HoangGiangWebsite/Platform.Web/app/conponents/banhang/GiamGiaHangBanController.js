﻿(function (app) {
    'use strict';

    app.controller('GiamGiaHangBanController', GiamGiaHangBanController);

    GiamGiaHangBanController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService','$http'];
    function GiamGiaHangBanController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http) {
        $scope.openmodal = function () {
            $('.bs-example-modal-lg').modal('show');
            // window.open('https://localhost:44308/admin#/themphieuthu', '_blank', 'width=500, height=400')

        }
        $scope.openmodal();
        $scope.KhacHang = {}
        //#region
        $scope.timkiem = true;
        $scope.option = false
        $scope.PhieuThu = {

            NgayHoachToan: new Date(),
            NgayChungTu: new Date(),
            NgayHoaDon: new Date(),

            
            
        }
        $scope.getKhachHang = function (item) {
            $scope.timkiem = false;
            $scope.option = true;
            $scope.PhieuThu.MaKhachHang = item
        }
        $scope.test = function (selected) {
            if (selected) {
                $scope.timkiem = false;
                $scope.option = true;
                $scope.PhieuThu.MaKhachHang = selected.originalObject.MaKhachHang;
                $scope.KhacHang.MaKhachHang = selected.originalObject.MaKhachHang;
                $scope.KhacHang.DiaChi = selected.originalObject.DiaChi;
                $scope.KhacHang.TenKhachHang = selected.originalObject.TenKhachHang;

            }

        };
        $scope.motimkiem = function () {
            $scope.timkiem = true;
            $scope.option = false;
            $scope.test.originalObject = [];
        }
        $scope.getTinhTrang = function (item) {
            $scope.PhieuThu.MaTinhTrang = item
        }
        //#region
        $scope.addKH = {
        }

        function getallKH() {
            apiService.get('/api/khachhang/getall', null, function (result) {
                $scope.AllKhachHang = result.data;
                var maso = parseInt(result.data[result.data.length - 1].MaKhachHang.split('KH')[1]);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "KH"
                var ans = pad.substring(0) + ans1



                $scope.addKH = {
                    MaKhachHang: ans, PhanLoai: 'Tổ chức',QuocGia:'Việt Nam'

                }
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        getallKH()
        $scope.addNV = {};
        function GetAllNhanVien() {

            apiService.get('/api/nhanvien/getall', null, function (result) {

                $scope.LyLichNhanVien = result.data;

                var maso = parseInt(result.data[result.data.length - 1].MaSoNhanVien);

                var str = "" + (maso + 1)
                var pad = "0000"
                var ans = pad.substring(0, pad.length - str.length) + str

                $scope.addNV = {
                    MaSoNhanVien: ans
                }

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllNhanVien();
        function GetAllTinhTrang() {

            apiService.get('/api/tinhtrang/getall', null, function (result) {

                $scope.AllTinhTrang = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        function getallNCC() {
            apiService.get('/api/nhacungcap/getall', null, function (result) {
                $scope.AllNCC = result.data;
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        getallNCC()
        GetAllTinhTrang();
        function GetAllDieuKhoan() {

            apiService.get('/api/dieukhoantt/getall', null, function (result) {

                $scope.DieuKhoan = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllDieuKhoan();
        function GetAllHangHoa() {

            apiService.get('/api/hanghoa/getall', null, function (result) {

                $scope.AllHangHoa = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllHangHoa();

        function GetLoaiTien() {

            apiService.get('/api/loaitien/getall', null, function (result) {

                $scope.LoaiTien = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetLoaiTien();

        function GetAllTinhChatHangHoa() {

            apiService.get('/api/tinhchathanghoa/getall', null, function (result) {

                $scope.AllTinhChatHangHoa = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllTinhChatHangHoa();

        function getPhieuThu() {
            apiService.get('/api/giamgiahangban/getall', null, function (result) {
                if (result.data.length > 0) {
                    $scope.maphieuthu = result.data[result.data.length - 1].MaGiamGiaHangBan.split('BGG')[1];
                }
                else {
                    $scope.maphieuthu = 0;
                }


                var maso = parseInt($scope.maphieuthu);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "BGG"
                var ans = pad.substring(0) + ans1
                //alert(ans);
                $scope.PhieuThu.MaGiamGiaHangBan = ans

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getPhieuThu();
        //#endregion
        $scope.clickss = 0;
         $scope.solanlap = [];
        $scope.themdong = function (ma, ten) {

           
            if ($scope.solanlap.length > 0 && $scope.clickss == 0) {
                $scope.clickss = $scope.solanlap.length;
               // alert($scope.clickss);
            }
            $scope.clickss++;
            $scope.solanlap = [];
            for (var i = 1; i <= $scope.clickss; i++) {
                $scope.solanlap.push(i);
            }
            $scope.ChiTietThu[$scope.clickss - 1] = { MaGiamGiaHangBan: $scope.PhieuThu.MaGiamGiaHangBan, SoLuong: 0,GiaTriNhapKho:0}
            return $scope.solanlap;
        }
        $scope.deletesolanlap = function (item) {
            var index = $scope.solanlap.indexOf(item);
            $scope.solanlap.splice(index, 1);
            $scope.ChiTietThu.splice($scope.clickss - 1, 1);
            $scope.LuuMaHang.splice($scope.clickss - 1, 1);
            $scope.clickss--;
        }
        $scope.ChiTietThu = [];
        $scope.ThanhTien = [];
        $scope.tinhThanhTien = function (soluong, giaban, i) {
            var thanhtien = soluong * giaban;
            //$scope.ThanhTien[i] = { TongTienHang: thanhtien }
        }
        $scope.TienThueGTGT = [];
        $scope.TongTienThanhToan = [];
        $scope.tinhTienThueGTGT = function (km, sl, vat, i, ck, mh, SoLuongDaGiao,tenhang,dvt,TKGiamGia,TKTien) {
            var thanhtien = km * sl * vat;
            var tth = sl * km;
            var TTTT = thanhtien + tth - ck;
            //alert(km + '/' + sl + '/' + vat + '/' + i + '/' + ck + '/' + mh + '/' + SoLuongDaGiao + '/' + tenhang + '/' + dvt);
            $scope.ThanhTien[i] = { TongTienHang: tth }
            $scope.TienThueGTGT[i] = { TienThueGTGT: thanhtien };
            $scope.TongTienThanhToan[i] = { TongTienThanhToan: TTTT };
            $scope.ChiTietThu[i] = { MaHang: mh, MaGiamGiaHangBan: $scope.PhieuThu.MaGiamGiaHangBan, SoLuong: sl, ThanhTien: TTTT, DonGia: km, TienChietKhau: 0, TienThueGTGT: thanhtien, SoLuongDaGiao: SoLuongDaGiao, TenHang: tenhang, DonViTinh: dvt, GiaKhuyenMai: km, VAT: vat, ChietKhau: ck, TKGiamGia: TKGiamGia, TKTien: TKTien}


        }
        
        $scope.LuuMaLoaiTien = function (item, tygia) {
            $scope.PhieuThu.MaLoaiTien = item;
            $scope.PhieuThu.TyGia = tygia;
        }
        $scope.luutygia = function (tygia) {
            $scope.PhieuThu.TyGia = tygia;
        }
        $scope.LuuPhieuThu = function () {
            var total = 0;
            var total1 = 0;
            var total2 = 0;

            angular.forEach($scope.ThanhTien, function (item) {
                total += item.TongTienHang;
            })
            angular.forEach($scope.TienThueGTGT, function (item) {
                total1 += item.TienThueGTGT;
            })
            angular.forEach($scope.TongTienThanhToan, function (item) {
                total2 += item.TongTienThanhToan;
            })
            angular.forEach($scope.ChiTietThu, function (item) {
                item.MaHoaDon = $scope.PhieuThu.MaHoaDon
                item.MaPhieuChi = $scope.PhieuThu.MaPhieuChi
                item.SoTien = item.ThanhTien
            })
            

            $scope.PhieuThu.TongTienHang = total;
            $scope.PhieuThu.TienThueGTGT = total1;
            $scope.PhieuThu.TongTienThanhToan = total2;
            $scope.PhieuThu.TongChietKhau = 0;
            var link;
            var chitietlink;
            if ($scope.show =='Giảm trừ công nợ') {
                link ='giamgiahangban'
                chitietlink ='chitietgiamgiahangban'
            }
            else if ($scope.show == 'Trả lại tiền mặt') {
                link = 'phieuchi'
                chitietlink = 'chitietphieuchi'
            }
            $ngBootbox.confirm('Bạn chắc muốn lưu  không').then(function () {

                apiService.post('/api/' + link+'/create', $scope.PhieuThu, function (result) {
                    notificationService.displaySuccess("Lưu thành công");
                    apiService.post('/api/' + chitietlink +'/create', $scope.ChiTietThu, function (result) {
                            notificationService.displaySuccess("Lưu chi tiết thành công");

                        }, function () {
                            notificationService.displayWarning("Lưu chi tiết không thành công");

                    });
                   

                   
                    $scope.PhieuThu = {
                        NgayHoachToan: new Date(),
                        NgayChungTu: new Date(),
                        NgayHoaDon: new Date(),

                    }
                    getPhieuChi();
                    getallKH(); GetAllNhanVien(); GetAllTinhTrang();  GetAllHangHoa(); getPhieuThu(); $scope.clickss = 0; $scope.solanlap = [];
                     $scope.ThanhTien = []; $scope.TienThueGTGT = [];
                    $scope.TongTienThanhToan = []; $scope.LuuMaHang = []; GetLoaiTien(); $scope.getAllNCC(); getBaoGia(); getallKH();
                    $scope.KhacHang = {};
                    $scope.$broadcast('angucomplete-alt:clearInput');



                }, function () {
                    notificationService.displayWarning("Lưu không thành công");
                });


            });
        }
        //#endregion
        //#region
        function getNhomKH() {
            apiService.get('/api/nhomkh_ncc/getall', null, function (result) {
                $scope.NhomKH = result.data;

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
       
        getNhomKH();
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
                        apiService.post('/api/taikhoannganhang/create', $scope.addNganHang, function (result) {
                            apiService.post('/api/khachhang-taikhoan/create', $scope.KhachHang_TaiKhoan, function (result) {


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
        $scope.LuuNhanVien = function () {
            $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
                apiService.post('/api/nhanvien/create', $scope.addNV, function (result) {
                    notificationService.displaySuccess("Thêm thành công");
                    $scope.addNV = {};
                    GetAllNhanVien();
                }, function () {
                    notificationService.displayWarning('Thêm thất bại');
                });
            });
        }

        $scope.GetSeoTitle = function () {
            $scope.addHH.MaHang = commonService.getSeoTitle($scope.addHH.TenHang);
        };

        $scope.LuuHH = function () {
            $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
                apiService.post('/api/hanghoa/create', $scope.addHH, function (result) {
                    notificationService.displaySuccess("Thêm thành công");
                    $scope.addHH = {};
                    GetAllHangHoa();
                }, function () {
                    notificationService.displayWarning('Thêm thất bại');
                });
            });
        }
        //#endregion
        $scope.LuuMaHang = [];
        $scope.checktrung = function (mahang, item, i, km, sl, vat, ck,tenhang,dvt ) {
            var a = $scope.LuuMaHang.findIndex(x => x.mahang === mahang);

            if (a == -1) {
                $scope.ChiTietThu[i] = { SoLuong: 1 }
                $scope.LuuMaHang[i] = { mahang };
                sl = ($scope.ChiTietThu[i].SoLuong)
                var thanhtien = km * sl * vat;
                var tth = sl * km;
                var TTTT = thanhtien + tth - ck;
                var thanhtien1 = sl * km;
                $scope.ThanhTien[i] = { TongTienHang: thanhtien1 }
                $scope.TienThueGTGT[i] = { TienThueGTGT: thanhtien };
                $scope.TongTienThanhToan[i] = { TongTienThanhToan: TTTT };

                $scope.ChiTietThu[i] = { MaHang: mahang, MaGiamGiaHangBan: $scope.PhieuThu.MaGiamGiaHangBan, SoLuong: sl, ThanhTien: TTTT, DonGia: km, TienChietKhau: 0, TienThueGTGT: thanhtien, GiaTriNhapKho: 0,TenHang:tenhang,DonViTinh:dvt,GiaKhuyenMai:km,VAT:vat,ChietKhau:ck}
            }
            else {
                var index = $scope.solanlap.indexOf(item);
                sl = ($scope.ChiTietThu[a].SoLuong) + 1
                $scope.solanlap.splice(index, 1);
                $scope.LuuMaHang.splice(i, 1);
                
               
                $scope.clickss--;
                var thanhtien = km * sl * vat;
                var tth = sl * km;
                var TTTT = thanhtien + tth - ck;
                var thanhtien1 = sl * km;
                $scope.ThanhTien[a] = { TongTienHang: thanhtien1 }
                $scope.TienThueGTGT[a] = { TienThueGTGT: thanhtien };
                $scope.TongTienThanhToan[a] = { TongTienThanhToan: TTTT };
               
                var SoLuongDaGiao = "";
                var TKGiamGia = "";
                var TKTien = "";
               
                angular.forEach($scope.ChiTietThu, function (item) {
                    if (item.MaHang == mahang) {
                       
                        SoLuongDaGiao = item.SoLuongDaGiao;
                        TKGiamGia = item.TKGiamGia;
                        TKTien = item.TKTien;
                       
                    }
                })
                $scope.ChiTietThu[a] = { MaHang: mahang, MaGiamGiaHangBan: $scope.PhieuThu.MaGiamGiaHangBan, SoLuong: sl, ThanhTien: TTTT, DonGia: km, TienChietKhau: 0, TienThueGTGT: thanhtien, SoLuongDaGiao: SoLuongDaGiao, TenHang: tenhang, DonViTinh: dvt, GiaKhuyenMai: km, VAT: vat, TKGiamGia: TKGiamGia, TKTien: TKTien }

                $scope.ChiTietThu.splice(i, 1);
            }
        }



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

        function GetAllDonMuaHang() {

            apiService.get('/api/donmuahang/getall', null, function (result) {

                $scope.AllDonMuaHang = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllDonMuaHang();
        function GetAllHopDongMua() {

            apiService.get('/api/hopdongmua/getall', null, function (result) {

                $scope.AllHopDongMua = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllHopDongMua();



        function getBaoGia() {
            apiService.get('/api/baogia/getall', null, function (result) {
                $scope.AllBaoGia = result.data;
                angular.forEach($scope.AllBaoGia, function (item) {
                    item.MaChungTu = item.MaSoBaoGia
                })

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
       
        getBaoGia();
        $scope.HangHoa = {}
        $scope.getChiTietBaoGia = getChiTietBaoGia;
        function getChiTietBaoGia(id) {
            var controller
            if ((id.includes('BG')) == true) {
                 controller = 'chitietbaogia';
            }
            else if ((id.includes('BH')) == true) {
                controller = 'chitietchungtubanhang';
            }
            var config = {
                params: {
                    id:id
                   
                }
            }
            apiService.get('/api/' + controller+'/getbyid', config, function (result) {
                $scope.AllChiTietBaoGia = result.data;
                $scope.ChiTietThu = angular.copy($scope.AllChiTietBaoGia);
                $scope.solanlap.length = 0;
                $scope.clickss=0
                for (var i = 0; i < $scope.AllChiTietBaoGia.length; i++) {
                    $scope.ChiTietThu[i].MaHang = $scope.AllChiTietBaoGia[i].MaHang;
                    angular.forEach($scope.AllHangHoa, function (item) {
                        if (item.MaHang == $scope.AllChiTietBaoGia[i].MaHang) {
                            $scope.ChiTietThu[i].TenHang = item.TenHang;
                            $scope.ChiTietThu[i].DonViTinh = item.DonViTinh;
                            $scope.ChiTietThu[i].GiaKhuyenMai = item.GiaKhuyenMai;
                            $scope.ChiTietThu[i].VAT = item.VAT;
                            $scope.ChiTietThu[i].ChietKhau = item.ChietKhau;
                            $scope.ChiTietThu[i].MaGiamGiaHangBan = $scope.PhieuThu.MaGiamGiaHangBan;
                            var thanhtien = item.GiaKhuyenMai * $scope.AllChiTietBaoGia[i].SoLuong * item.VAT;
                            var tth = item.GiaKhuyenMai * $scope.AllChiTietBaoGia[i].SoLuong;
                            var TTTT = thanhtien + tth - item.ChietKhau;
                            $scope.ThanhTien[i] = { TongTienHang: tth }
                            $scope.TienThueGTGT[i] = { TienThueGTGT: thanhtien };
                            $scope.TongTienThanhToan[i] = { TongTienThanhToan: TTTT };
                            $scope.LuuMaHang[i] = { mahang:item.MaHang };
                        }
                        
                    })
                  
                    $scope.solanlap.push(i)
                }
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
       

        $scope.newPhieuThu = function (selected) {
            if (selected) {

                $scope.PhieuThu.MaKhachHang = selected.originalObject.MaKhachHang;
                $scope.PhieuThu.MaSoNhanVien = selected.originalObject.MaSoNhanVien;
               
                $scope.PhieuThu.DienGiai = selected.originalObject.DienGiai;
                angular.forEach($scope.AllKhachHang, function (item) {
                    if (item.MaKhachHang == selected.originalObject.MaKhachHang) {
                        $scope.KhacHang.MaKhachHang = item.MaKhachHang;
                        $scope.KhacHang.TenKhachHang = item.TenKhachHang;
                        $scope.KhacHang.DiaChi = item.DiaChi;
                        $scope.KhacHang.MaSoThue = item.MaSoThue;
                    }
                })
                $scope.getChiTietBaoGia(selected.originalObject.MaChungTu);
                
                
            }

        };
       
        $scope.chungtughino = true;
        $scope.phieuxuat = false;
        $scope.phieuchi = false;
        $scope.mochungtughino = function () {
            $scope.chungtughino = true;
            $scope.phieuxuat = false;
            $scope.phieuchi = false;
        }
        $scope.mophieuxuat = function () {
            $scope.chungtughino = false;
            $scope.phieuxuat = true;
            $scope.phieuchi = false;

        }  
        $scope.mophieuchi = function () {
            $scope.chungtughino = false;
            $scope.phieuxuat = false;
            $scope.phieuchi = true;
        }  

        function getHoaDon() {
            apiService.get('/api/hoadon_banhang/getall', null, function (result) {
                if (result.data.length > 0) {
                    $scope.MaHoaDon = result.data[result.data.length - 1].MaHoaDon;
                }
                else {
                    $scope.MaHoaDon = 0;
                }


                var maso = parseInt($scope.MaHoaDon);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str

                //alert(ans);
                $scope.PhieuThu.MaHoaDon = ans1

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getHoaDon();

        function getCTBH() {
            apiService.get('/api/chungtubanhang/getall', null, function (result) {
                $scope.CTBH = result.data;
                angular.forEach($scope.CTBH, function (item) {
                    item.MaChungTu = item.MaChungTuBanHang
                })
                $scope.merge = $scope.AllBaoGia.concat($scope.CTBH)
                console.log($scope.merge)

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getCTBH();





        $scope.show = 'Giảm trừ công nợ';

        function getPhieuChi() {
            apiService.get('/api/phieuchi/getall', null, function (result) {
                if (result.data.length > 0) {
                    $scope.maphieuthu = result.data[result.data.length - 1].MaPhieuChi.split('PC')[1];
                }
                else {
                    $scope.maphieuthu = 0;
                }


                var maso = parseInt($scope.maphieuthu);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "PC"
                var ans = pad.substring(0) + ans1
                //alert(ans);
                $scope.PhieuThu.MaPhieuChi = ans

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getPhieuChi();







    }


})(angular.module('platformTH_GV.banhang'));