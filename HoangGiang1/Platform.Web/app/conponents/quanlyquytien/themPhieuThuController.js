(function (app) {
    'use strict';

    app.controller('themPhieuThuController', themPhieuThuController);

    themPhieuThuController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter','commonService'];
    function themPhieuThuController($scope, apiService, notificationService, $ngBootbox, $filter, commonService) {
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
            SoLuong:0
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
                $scope.KhacHang.DiaChi = selected.originalObject.MaKhachHang;
                $scope.KhacHang.TenKhachHang = selected.originalObject.TenKhachHang;
             
            }
            
        };
        $scope.motimkiem = function () {
            $scope.timkiem = true;
            $scope.option = false;
            $scope.test.originalObject = [];
        }
        $scope.getLoaiThu = function (item) {
            $scope.PhieuThu.MaLoaiThu = item
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
                var maso = parseInt(result.data[result.data.length - 1].MaKhachHang);

                var str = "" + (maso + 1)
                var pad = "000000"
                var ans = pad.substring(0, pad.length - str.length) + str




                $scope.addKH = {
                    MaKhachHang: ans, PhanLoai: 'Tổ chức'

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
        GetAllTinhTrang();
        function GetAllLoaiThu() {

            apiService.get('/api/loaithu/getall', null, function (result) {

                $scope.AllLoaiThu = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllLoaiThu();
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
            apiService.get('/api/phieuthu/getall', null, function (result) {
                if (result.data.length > 0) {
                    $scope.maphieuthu = result.data[result.data.length - 1].MaPhieuThu.split('PT')[1];
                }
                else {
                    $scope.maphieuthu = 0;
                }

               
                var maso = parseInt($scope.maphieuthu);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "PT"
                var ans = pad.substring(0) + ans1

                $scope.PhieuThu.MaPhieuThu=ans
                
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getPhieuThu();
        //#endregion
        $scope.clickss = 0;
       // $scope.solanlap = [];
        $scope.themdong = function () {

            $scope.clickss++;
            $scope.solanlap = [];
            for (var i = 1; i <= $scope.clickss; i++) {
                $scope.solanlap.push(i);
            }
            return $scope.solanlap;
        }
        $scope.deletesolanlap = function (item) {
            var index = $scope.solanlap.indexOf(item);
            $scope.solanlap.splice(index, 1);
            $scope.clickss--;
        }
        $scope.ChiTietThu = [];
        $scope.ThanhTien=[];
        $scope.tinhThanhTien = function (soluong, giaban, i) {
           var thanhtien = soluong * giaban;
            $scope.ThanhTien[i] = { TongTienHang: thanhtien }
        }
        $scope.TienThueGTGT = [];
        $scope.TongTienThanhToan = [];
        $scope.tinhTienThueGTGT = function (km, sl, vat, i, ck, mh) {
            var thanhtien = km * sl * vat;
            var tth = sl * km;
            var TTTT = thanhtien+tth-ck;

            $scope.TienThueGTGT[i] = { TienThueGTGT: thanhtien };
            $scope.TongTienThanhToan[i] = { TongTienThanhToan: TTTT };
            $scope.ChiTietThu[i] = { MaHang: mh, MaPhieuThu: $scope.PhieuThu.MaPhieuThu, SoLuong: sl, SoTien: TTTT }


        }
        $scope.LuuMaLoaiTien = function (item,tygia) {
            $scope.PhieuThu.MaLoaiTien = item;
            $scope.PhieuThu.TyGia = tygia;
        }
        $scope.luutygia = function ( tygia) {
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
            $scope.PhieuThu.TongTienHang = total;
            $scope.PhieuThu.TienThueGTGT = total1;
            $scope.PhieuThu.TongTienThanhToan = total2;
            $ngBootbox.confirm('Bạn chắc muốn lưu  không').then(function () {
               
                apiService.post('/api/phieuthu/create', $scope.PhieuThu, function (result) {
                    notificationService.displaySuccess("Lưu thành công");
                    angular.forEach($scope.ChiTietThu, function (item) {
                        if (item.MaHang) {
                            apiService.post('/api/chitietthu/create', item, function (result) {
                            }, function () {
                            });
                        }
                        
                    });
                    $scope.PhieuThu = {

                        NgayHoachToan: new Date(),
                        NgayChungTu: new Date(),
                        SoLuong: 0
                    }
                    getallKH(); GetAllNhanVien(); GetAllTinhTrang(); GetAllLoaiThu(); GetAllHangHoa(); getPhieuThu(); $scope.clickss = 0; $scope.solanlap = [];
                    $scope.ChiTietThu = []; $scope.ThanhTien = []; $scope.TienThueGTGT = [];
                    $scope.TongTienThanhToan = []; $scope.LuuMaHang = []; GetLoaiTien();


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
                if ($scope.NCC==false) {
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
        $scope.checktrung = function (mahang, item, i, km, sl, vat, ck,) {
            var a = $scope.LuuMaHang.indexOf(mahang);
            $scope.ChiTietThu[i] = { SoLuong: 1 }

            if (a == -1) {

                $scope.LuuMaHang.push(mahang);
                sl = ($scope.ChiTietThu[i].SoLuong)
                var thanhtien = km * sl * vat;
                var tth = sl * km;
                var TTTT = thanhtien + tth - ck;
                var thanhtien1 = sl * km;
                $scope.ThanhTien[i] = { TongTienHang: thanhtien1 }
                $scope.TienThueGTGT[i] = { TienThueGTGT: thanhtien };
                $scope.TongTienThanhToan[i] = { TongTienThanhToan: TTTT };

                $scope.ChiTietThu[i] = { MaHang: mahang, MaPhieuThu: $scope.PhieuThu.MaPhieuThu, SoLuong: sl, SoTien: TTTT }
            }
            else {

                var index = $scope.solanlap.indexOf(item);
                sl = ($scope.ChiTietThu[a].SoLuong)+1
                $scope.solanlap.splice(index, 1);
                $scope.clickss--;
                var thanhtien = km * sl * vat;
                var tth = sl * km;
                var TTTT = thanhtien + tth - ck;
                var thanhtien1 = sl * km;
                $scope.ThanhTien[a] = { TongTienHang: thanhtien1 }
                $scope.TienThueGTGT[a] = { TienThueGTGT: thanhtien };
                $scope.TongTienThanhToan[a] = { TongTienThanhToan: TTTT };

                $scope.ChiTietThu[a] = { MaHang: mahang, MaPhieuThu: $scope.PhieuThu.MaPhieuThu, SoLuong: sl, SoTien: TTTT }


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
     



    }
   
    
})(angular.module('platformTH_GV.quanlyquytien'));