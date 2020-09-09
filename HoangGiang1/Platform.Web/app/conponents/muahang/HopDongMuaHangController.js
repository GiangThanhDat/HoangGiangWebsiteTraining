(function (app) {
    'use strict';

    app.controller('HopDongMuaHangController', HopDongMuaHangController);

    HopDongMuaHangController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'commonService','$http'];
    function HopDongMuaHangController($scope, apiService, notificationService, $ngBootbox, $filter, commonService, $http) {
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

            NgayKy: new Date(),
            LaHopDongPhatSinh:false
        }
        $scope.getKhachHang = function (item) {
            $scope.timkiem = false;
            $scope.option = true;
            $scope.PhieuThu.MaNhaCungCap = item
        }
        $scope.test = function (selected) {
            if (selected) {
                $scope.timkiem = false;
                $scope.option = true;
                $scope.PhieuThu.MaNhaCungCap = selected.originalObject.MaNhaCungCap;
                $scope.KhacHang.MaNhaCungCap = selected.originalObject.MaNhaCungCap;
                $scope.KhacHang.DiaChi = selected.originalObject.DiaChi;
                $scope.KhacHang.TenNhaCungCap = selected.originalObject.TenNhaCungCap;

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
            apiService.get('/api/hopdongmua/getall', null, function (result) {
                if (result.data.length > 0) {
                    $scope.maphieuthu = result.data[result.data.length - 1].MaHopDongMua.split('HĐM')[1];
                }
                else {
                    $scope.maphieuthu = 0;
                }


                var maso = parseInt($scope.maphieuthu);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "HĐM"
                var ans = pad.substring(0) + ans1
                //alert(ans);
                $scope.PhieuThu.MaHopDongMua = ans

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getPhieuThu();
        //#endregion
        $scope.clickss = 0;
        // $scope.solanlap = [];
        $scope.themdong = function (ma, ten) {

            $scope.clickss++;
            $scope.solanlap = [];
            for (var i = 1; i <= $scope.clickss; i++) {
                $scope.solanlap.push(i);
            }
            $scope.ChiTietThu[$scope.clickss - 1] = { MaHopDongMua: $scope.PhieuThu.MaHopDongMua, SoLuong: 0}
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
        $scope.tinhTienThueGTGT = function (km, sl, vat, i, ck, mh,soluongnhan,lenhsx,thanhpham) {
            var thanhtien = km * sl * vat;
            var tth = sl * km;
            var TTTT = thanhtien + tth - ck;

            $scope.TienThueGTGT[i] = { TienThueGTGT: thanhtien };
            $scope.TongTienThanhToan[i] = { TongTienThanhToan: TTTT };
            $scope.ChiTietThu[i] = { MaHang: mh, MaHopDongMua: $scope.PhieuThu.MaHopDongMua, SoLuong: sl, ThanhTien: TTTT, DonGia: km, TienChietKhau: 0, TienThueGTGT: thanhtien,  LenhSanXuat: lenhsx, ThanhPham: thanhpham }


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
            $scope.PhieuThu.TongTienHang = total;
            $scope.PhieuThu.TienThueGTGT = total1;
            $scope.PhieuThu.TongTienThanhToan = total2;
            $scope.PhieuThu.TienChietKhau = 0;
            $ngBootbox.confirm('Bạn chắc muốn lưu  không').then(function () {

                apiService.post('/api/hopdongmua/create', $scope.PhieuThu, function (result) {
                    notificationService.displaySuccess("Lưu thành công");
                    apiService.post('/api/chitiethopdongmua/create', $scope.ChiTietThu, function (result) {
                            notificationService.displaySuccess("Lưu chi tiết thành công");

                        }, function () {
                            notificationService.displayWarning("Lưu chi tiết không thành công");

                        });
                   
                    $scope.PhieuThu = {
                        NgayKy: new Date(),
                        SoLuong: 0
                    }
                    getallKH(); GetAllNhanVien(); GetAllTinhTrang();  GetAllHangHoa(); getPhieuThu(); $scope.clickss = 0; $scope.solanlap = [];
                    $scope.ChiTietThu = []; $scope.ThanhTien = []; $scope.TienThueGTGT = [];
                    $scope.TongTienThanhToan = []; $scope.LuuMaHang = []; GetLoaiTien(); $scope.getAllNCC();



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
                MaNhaCungCap: $scope.addKH.MaNhaCungCap,
                MaTaiKhoan: matk
            }
        }
        $scope.addKhachHang = function () {
            $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
               
                    apiService.post('/api/nhacungcap/create', $scope.addKH, function (result) {
                        notificationService.displaySuccess("Thêm thành công");
                        $scope.getAllNCC();
                        apiService.post('/api/taikhoannganhang/create', $scope.addNganHang, function (result) {
                            $scope.addNganHang = [];

                            apiService.post('/api/nhacungcap-taikhoan/create', $scope.KhachHang_TaiKhoan, function (result) {

                                $scope.KhachHang_TaiKhoan = [];

                            }, function () {
                            });

                        }, function () {
                        });
                        getallKH()
                        $scope.addKH = {}
                        $scope.getAllNCC();
                       
                    }, function () {
                        notificationService.displayWarning('Thêm thất bại');
                    });
                
               




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
        $scope.checktrung = function (mahang, item, i, km, sl, vat, ck, ) {
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

                $scope.ChiTietThu[i] = { MaHang: mahang, MaHopDongMua: $scope.PhieuThu.MaHopDongMua, SoLuong: sl, ThanhTien: TTTT, DonGia: km, TienChietKhau: 0, TienThueGTGT: thanhtien }
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
                var soluongnhan = "";
                var lenhsx = "";
                var thanhpham = "";
                angular.forEach($scope.ChiTietThu, function (item) {
                    if (item.MaHang == mahang) {
                        soluongnhan = item.SoLuongNhan;
                        lenhsx = item.LenhSanXuat;
                        thanhpham = item.ThanhPham;
                    }
                })
                $scope.ChiTietThu[a] = { MaHang: mahang, MaHopDongMua: $scope.PhieuThu.MaHopDongMua, SoLuong: sl, ThanhTien: TTTT, DonGia: km, TienChietKhau: 0, TienThueGTGT: thanhtien, LenhSanXuat: lenhsx, ThanhPham: thanhpham }

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

        function GetAllTKNo() {

            apiService.get('/api/taikhoanno/getall', null, function (result) {

                $scope.TKNO = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllTKNo();
        function GetAllTKCo() {

            apiService.get('/api/taikhoanco/getall', null, function (result) {

                $scope.TKCO = result.data;


            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetAllTKCo();




        $scope.thongtinchung = true;
        $scope.hanghoadichvu = false;
        $scope.mothongtinchung = function () {

            $scope.thongtinchung = true;
            $scope.hanghoadichvu = false;
        }
        $scope.mohanghoadichvu = function () {
            $scope.thongtinchung = false;
            $scope.hanghoadichvu = true;
        }





    }


})(angular.module('platformTH_GV.muahang'));