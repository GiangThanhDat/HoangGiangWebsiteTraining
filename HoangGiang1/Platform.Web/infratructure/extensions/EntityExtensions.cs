using Platform.Model;
using Platform.Model.Models;
using Platform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.infratructure.extensions
{
    public static class EntityExtensions
    {
       

        public static void UpdateThongBao(this ThongBao thongBao, ThongBaoViewModel thongBaoVm)
        {
            thongBao.MaSoTB = thongBaoVm.MaSoTB;
            thongBao.NoiDung = thongBaoVm.NoiDung;
            thongBao.NgayThongBao = thongBaoVm.NgayThongBao;

        }
        public static void UpdateThongTinCaNhan(this ThongTinCaNhan thongTinCaNhan, ThongTinCaNhanViewModel thongTinCaNhanVm)
        {
            thongTinCaNhan.MaSoVC = thongTinCaNhanVm.MaSoVC;
            thongTinCaNhan.HoTen = thongTinCaNhanVm.HoTen;
            thongTinCaNhan.NgaySinh = thongTinCaNhanVm.NgaySinh;
            thongTinCaNhan.DiaChi = thongTinCaNhanVm.DiaChi;
            thongTinCaNhan.DienThoai = thongTinCaNhanVm.DienThoai;
            thongTinCaNhan.Email = thongTinCaNhanVm.Email;
            thongTinCaNhan.Hinh = thongTinCaNhanVm.Hinh;
            thongTinCaNhan.DaXoa = thongTinCaNhanVm.NghiViec;
            thongTinCaNhan.NguoiXoa = thongTinCaNhanVm.NguoiXoa;
            thongTinCaNhan.ThoiGianXoa = thongTinCaNhanVm.ThoiGianXoa;
            thongTinCaNhan.MaPK = thongTinCaNhanVm.MaPK;
            thongTinCaNhan.Phai = thongTinCaNhanVm.Phai;
            thongTinCaNhan.SHCC = thongTinCaNhanVm.SHCC;
            thongTinCaNhan.CMND = thongTinCaNhanVm.CMND;
            thongTinCaNhan.NgayCap = thongTinCaNhanVm.NgayCap;
            thongTinCaNhan.NoiCap = thongTinCaNhanVm.NoiCap;
            thongTinCaNhan.MST = thongTinCaNhanVm.MST;
            thongTinCaNhan.QuocTich = thongTinCaNhanVm.QuocTich;
            thongTinCaNhan.DanToc = thongTinCaNhanVm.DanToc;
            thongTinCaNhan.SoTaiKhoan = thongTinCaNhanVm.SoTaiKhoan;
            thongTinCaNhan.NganHang = thongTinCaNhanVm.NganHang;
            thongTinCaNhan.ChiNhanh = thongTinCaNhanVm.ChiNhanh;
            thongTinCaNhan.ChucVu = thongTinCaNhanVm.ChucVu;
            thongTinCaNhan.CQCongTac = thongTinCaNhanVm.CQCongTac;
            thongTinCaNhan.DiaChiCQ = thongTinCaNhanVm.DiaChiCQ;
            thongTinCaNhan.WebsiteCQ = thongTinCaNhanVm.WebsiteCQ;
            thongTinCaNhan.LanhDaoCQ = thongTinCaNhanVm.LanhDaoCQ;
            thongTinCaNhan.DienThoaiCQ = thongTinCaNhanVm.DienThoaiCQ;
            thongTinCaNhan.DienThoaiLanhDao = thongTinCaNhanVm.DienThoaiLanhDao;
            thongTinCaNhan.NamBatDauCongTac = thongTinCaNhanVm.NamBatDauCongTac;
            thongTinCaNhan.NamNghiHuu = thongTinCaNhanVm.NamNghiHuu;
            thongTinCaNhan.HocVu = thongTinCaNhanVm.HocVu;
            thongTinCaNhan.NamDat = thongTinCaNhanVm.NamDat;
            thongTinCaNhan.NuocTotNghiep = thongTinCaNhanVm.NuocTotNghiep;
            thongTinCaNhan.ChuyenNganh = thongTinCaNhanVm.ChuyenNganh;
            thongTinCaNhan.ChuyenMonHienTai = thongTinCaNhanVm.ChuyenMonHienTai;
            thongTinCaNhan.HocHam = thongTinCaNhanVm.HocHam;
            thongTinCaNhan.NamCongNhan = thongTinCaNhanVm.NamCongNhan;
            thongTinCaNhan.ChucDanh = thongTinCaNhanVm.ChucDanh;
        }


        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        }







        public static void UpdateNhanVien(this NhanVien nhanVien, NhanVienViewModel nhanVienVm)
        {

            nhanVien.MaSoNhanVien = nhanVienVm.MaSoNhanVien;
            nhanVien.HoVaTen = nhanVienVm.HoVaTen;
            nhanVien.GioiTinh = nhanVienVm.GioiTinh;
            nhanVien.SoCMND = nhanVienVm.SoCMND;
            nhanVien.NgayCapCMND = nhanVienVm.NgayCapCMND;
            nhanVien.NoiCapCMND = nhanVienVm.NoiCapCMND;
            nhanVien.NgaySinh = nhanVienVm.NgaySinh;
            nhanVien.TinhTrangHonNhan = nhanVienVm.TinhTrangHonNhan;
            nhanVien.QuocTich = nhanVienVm.QuocTich;
            nhanVien.DiaChi = nhanVienVm.DiaChi;
            nhanVien.SoDienThoai = nhanVienVm.SoDienThoai;
            nhanVien.Email = nhanVienVm.Email;
            nhanVien.HoTenLienHeKhanCap = nhanVienVm.HoTenLienHeKhanCap;
            nhanVien.QuanHeLienHeKhanCap = nhanVienVm.QuanHeLienHeKhanCap;
            nhanVien.DiaChiLienHeKhanCap = nhanVienVm.DiaChiLienHeKhanCap;
            nhanVien.SDTLienHeKhanCap = nhanVienVm.SDTLienHeKhanCap;
            nhanVien.Hinh = nhanVienVm.Hinh;
            nhanVien.Bac = nhanVienVm.Bac;
            nhanVien.TrangThai = nhanVienVm.TrangThai;
            nhanVien.MaCoSo = nhanVienVm.MaCoSo;
            nhanVien.MaChucVu = nhanVienVm.MaChucVu; 
            nhanVien.MaSoThue = nhanVienVm.MaSoThue; 
            nhanVien.SoTaiKhoanNganHang = nhanVienVm.SoTaiKhoanNganHang; 
            nhanVien.TenNganHang = nhanVienVm.TenNganHang; 
            nhanVien.ChiNhanh = nhanVienVm.ChiNhanh; 
         
    }
        public static void UpdateQuaTrinhDaoTao(this QuaTrinhDaoTao quaTrinhDaoTao, QuaTrinhDaoTaoViewModel quaTrinhDaoTaoVm)
        {

            quaTrinhDaoTao.ID = quaTrinhDaoTaoVm.ID;
            quaTrinhDaoTao.MaSoNhanVien = quaTrinhDaoTaoVm.MaSoNhanVien;
            quaTrinhDaoTao.NgayBatDau = quaTrinhDaoTaoVm.NgayBatDau;
            quaTrinhDaoTao.NgayKetThuc = quaTrinhDaoTaoVm.NgayKetThuc;
            quaTrinhDaoTao.TenTruong = quaTrinhDaoTaoVm.TenTruong;
            quaTrinhDaoTao.LoaiBang = quaTrinhDaoTaoVm.LoaiBang;
            quaTrinhDaoTao.ChuyenNganh = quaTrinhDaoTaoVm.ChuyenNganh;
            quaTrinhDaoTao.XepLoai = quaTrinhDaoTaoVm.XepLoai;
        }

        public static void UpdateLichSuLamViec(this LichSuLamViec lichSuLamViec, LichSuLamViecViewModel lichSuLamViecVm)
        {

            lichSuLamViec.ID = lichSuLamViecVm.ID;
            lichSuLamViec.MaSoNhanVien = lichSuLamViecVm.MaSoNhanVien;
            lichSuLamViec.NgayBatDau = lichSuLamViecVm.NgayBatDau;
            lichSuLamViec.NgayKetThuc = lichSuLamViecVm.NgayKetThuc;
            lichSuLamViec.TenCongTy = lichSuLamViecVm.TenCongTy;
            lichSuLamViec.ViTriLamViec = lichSuLamViecVm.ViTriLamViec;
            lichSuLamViec.NoiDungCongViec = lichSuLamViecVm.NoiDungCongViec;
          
        }

        public static void UpdateNgonNgu(this NgonNgu ngonNgu, NgonNguViewModel ngonNguVm)
        {

            ngonNgu.ID = ngonNguVm.ID;
            ngonNgu.MaSoNhanVien = ngonNguVm.MaSoNhanVien;
            ngonNgu.TenNgonNgu = ngonNguVm.TenNgonNgu;
            ngonNgu.Nghe = ngonNguVm.Nghe;
            ngonNgu.Noi = ngonNguVm.Noi;
            ngonNgu.Doc = ngonNguVm.Doc;
            ngonNgu.Viet = ngonNguVm.Viet;

        }
        public static void UpdateThongTinTuyenDung(this ThongTinTuyenDung thongTinTuyenDung, ThongTinTuyenDungViewModel thongTinTuyenDungVm)
        {

            thongTinTuyenDung.ID = thongTinTuyenDungVm.ID;
            thongTinTuyenDung.MaSoNhanVien = thongTinTuyenDungVm.MaSoNhanVien;
            thongTinTuyenDung.NgayTuyen = thongTinTuyenDungVm.NgayTuyen;
            thongTinTuyenDung.LoaiHopDong = thongTinTuyenDungVm.LoaiHopDong;
            thongTinTuyenDung.DiaDiemLamViec = thongTinTuyenDungVm.DiaDiemLamViec;
            thongTinTuyenDung.NgayBatDau = thongTinTuyenDungVm.NgayBatDau;
            thongTinTuyenDung.NgayKetThuc = thongTinTuyenDungVm.NgayKetThuc;
            thongTinTuyenDung.HinhThucLuong = thongTinTuyenDungVm.HinhThucLuong;
            thongTinTuyenDung.SoTienLuong = thongTinTuyenDungVm.SoTienLuong;
        }

        public static void UpdateHoanThanhCongViec(this HoanThanhCongViec hoanThanhCongViec, HoanThanhCongViecViewModel hoanThanhCongViecVm)
        {

            hoanThanhCongViec.ID = hoanThanhCongViecVm.ID;
            hoanThanhCongViec.MaSoNhanVien = hoanThanhCongViecVm.MaSoNhanVien;
            hoanThanhCongViec.LoaiDanhGia = hoanThanhCongViecVm.LoaiDanhGia;
            hoanThanhCongViec.NgayBatDau = hoanThanhCongViecVm.NgayBatDau;
            hoanThanhCongViec.NgayKetThuc = hoanThanhCongViecVm.NgayKetThuc;
            hoanThanhCongViec.XepLoai = hoanThanhCongViecVm.XepLoai;
            

        }

        public static void UpdateThe(this The the, TheViewModel theVm)
        {

            the.ID = theVm.ID;
            the.MaSoNhanVien = theVm.MaSoNhanVien;
            the.MaThe = theVm.MaThe;
            the.LoaiThe = theVm.LoaiThe;
            the.NgayYeuCau = theVm.NgayYeuCau;
            the.NgayCap = theVm.NgayCap;
            the.NgayHetHan = theVm.NgayHetHan;
            the.TrangThai = theVm.TrangThai;
          
        }
        
        public static void UpdateQuanLyNgayNghi(this QuanLyNgayNghi quanLyNgayNghi, QuanLyNgayNghiViewModel quanLyNgayNghiVm)
        {

            quanLyNgayNghi.ID = quanLyNgayNghiVm.ID;
            quanLyNgayNghi.MaSoNhanVien = quanLyNgayNghiVm.MaSoNhanVien;
            quanLyNgayNghi.GioBatDau = quanLyNgayNghiVm.GioBatDau;
            quanLyNgayNghi.NgayBatDau = quanLyNgayNghiVm.NgayBatDau;
            quanLyNgayNghi.GioKetThuc = quanLyNgayNghiVm.GioKetThuc;
            quanLyNgayNghi.NgayKetThuc = quanLyNgayNghiVm.NgayKetThuc;
            quanLyNgayNghi.LoaiNghi = quanLyNgayNghiVm.LoaiNghi;
            quanLyNgayNghi.TongGio = quanLyNgayNghiVm.TongGio;
            quanLyNgayNghi.TongNgayLamViecNghi = quanLyNgayNghiVm.TongNgayLamViecNghi;
            quanLyNgayNghi.TongNgayNghi = quanLyNgayNghiVm.TongNgayNghi;
          

        }

        public static void UpdateQuanLyCongTac(this QuanLyCongTac quanLyCongTac, QuanLyCongTacViewModel quanLyCongTacVm)
        {

            quanLyCongTac.ID = quanLyCongTacVm.ID;
            quanLyCongTac.MaSoNhanVien = quanLyCongTacVm.MaSoNhanVien;
            quanLyCongTac.GioBatDau = quanLyCongTacVm.GioBatDau;
            quanLyCongTac.NgayBatDau = quanLyCongTacVm.NgayBatDau;
            quanLyCongTac.GioKetThuc = quanLyCongTacVm.GioKetThuc;
            quanLyCongTac.NgayKetThuc = quanLyCongTacVm.NgayKetThuc;
            quanLyCongTac.TongGio = quanLyCongTacVm.TongGio;
            quanLyCongTac.TongNgayLamViec = quanLyCongTacVm.TongNgayLamViec;
            quanLyCongTac.TongNgay = quanLyCongTacVm.TongNgay;
            quanLyCongTac.DiaDiem = quanLyCongTacVm.DiaDiem;
            quanLyCongTac.NoiDung = quanLyCongTacVm.NoiDung;
           
        }
         public static void UpdateQuanLyQuaGio(this QuanLyQuaGio quanLyQuaGio, QuanLyQuaGioViewModel quanLyQuaGioVm)
        {

            quanLyQuaGio.ID = quanLyQuaGioVm.ID;
            quanLyQuaGio.MaSoNhanVien = quanLyQuaGioVm.MaSoNhanVien;
            quanLyQuaGio.SoGio = quanLyQuaGioVm.SoGio;
            quanLyQuaGio.PhanLoai = quanLyQuaGioVm.PhanLoai;
           
        }
        public static void UpdateQuanLyVangMat(this QuanLyVangMat quanLyVangMat, QuanLyVangMatViewModel quanLyVangMatVm)
        {

            quanLyVangMat.ID = quanLyVangMatVm.ID;
            quanLyVangMat.MaSoNhanVien = quanLyVangMatVm.MaSoNhanVien;
            quanLyVangMat.NgayVangMat = quanLyVangMatVm.NgayVangMat;
            quanLyVangMat.GioVao = quanLyVangMatVm.GioVao;
            quanLyVangMat.GioRa = quanLyVangMatVm.GioRa;
            quanLyVangMat.TrangThai = quanLyVangMatVm.TrangThai;
            
        }
        public static void UpdateQuetThe(this QuetThe quetThe, QuetTheViewModel quetTheVm)
        {

            quetThe.ID = quetTheVm.ID;
            quetThe.MaSoNhanVien = quetTheVm.MaSoNhanVien;
            quetThe.GioQuetThe = quetTheVm.GioQuetThe;
            quetThe.NgayQuetThe = quetTheVm.NgayQuetThe;
           

        }
        public static void UpdateQuetTheTheoNgay(this QuetTheTheoNgay quetThe, QuetTheTheoNgayViewModel quetTheVm)
        {

            quetThe.ID = quetTheVm.ID;
            quetThe.MaSoNhanVien = quetTheVm.MaSoNhanVien;
            quetThe.GioQuetThe = quetTheVm.GioQuetThe;
            quetThe.NgayQuetThe = quetTheVm.NgayQuetThe;


        }
        public static void UpdateCoSo(this CoSo coSo, CoSoViewModel coSoVM)
        {

            coSo.MaCoSo = coSoVM.MaCoSo;
            coSo.DiaChi = coSoVM.DiaChi;
            coSo.TenCoSo = coSoVM.TenCoSo;
            coSo.CapToChuc = coSoVM.CapToChuc;



        }
        public static void UpdateTaiSan(this TaiSan taiSan, TaiSanViewModel taiSanVM)
        {

            taiSan.MaTaiSan = taiSanVM.MaTaiSan;
            taiSan.NgayNhap = taiSanVM.NgayNhap;
            taiSan.NgayBatDauSuDung = taiSanVM.NgayBatDauSuDung;
            taiSan.NgayHetHan = taiSanVM.NgayHetHan;
            taiSan.MaCoSo = taiSanVM.MaCoSo;
            taiSan.KieuTaiSan = taiSanVM.KieuTaiSan;
            taiSan.MoTaChiTiet = taiSanVM.MoTaChiTiet;
            taiSan.TinhTrang = taiSanVM.TinhTrang;
            taiSan.NgayNhapLieu = taiSanVM.NgayNhapLieu;
            taiSan.NguoiNhap = taiSanVM.NguoiNhap;

        }
        public static void UpdateQuanLyTaiSan(this QuanLyTaiSan quanLyTaiSan, QuanLyTaiSanViewModel quanLyTaiSanVM)
        {

            quanLyTaiSan.ID = quanLyTaiSanVM.ID;
            quanLyTaiSan.MaSoNhanVien = quanLyTaiSanVM.MaSoNhanVien;
            quanLyTaiSan.MaTaiSan = quanLyTaiSanVM.MaTaiSan;

        }
        public static void UpdateChucVu(this ChucVu chucVu, ChucVuViewModel chucVuVm)
        {

            chucVu.MaChucVu = chucVuVm.MaChucVu;
            chucVu.TenChucVu = chucVuVm.TenChucVu;
          

        }
        public static void UpdateKhachHang(this KhachHang khachHang, KhachHangViewModel khachHangVm)
        {
            khachHang.MaKhachHang = khachHangVm.MaKhachHang;
            khachHang.NhomKH_NCC = khachHangVm.NhomKH_NCC;
            khachHang.PhanLoai = khachHangVm.PhanLoai;
            khachHang.TenKhachHang = khachHangVm.TenKhachHang;
            khachHang.ChiNhanh = khachHangVm.ChiNhanh;
            khachHang.DiaChi = khachHangVm.DiaChi;
            khachHang.SoDienThoai = khachHangVm.SoDienThoai;
            khachHang.Fax = khachHangVm.Fax;
            khachHang.Email = khachHangVm.Email;
            khachHang.Website = khachHangVm.Website;
            khachHang.MaSoThue = khachHangVm.MaSoThue;
            khachHang.SoTaiKhoanNganHang = khachHangVm.SoTaiKhoanNganHang;
            khachHang.TenNganHang = khachHangVm.TenNganHang;
            khachHang.NguoiLienHe = khachHangVm.NguoiLienHe;
            khachHang.DaXoa = khachHangVm.DaXoa;
            khachHang.NguoiXoa = khachHangVm.NguoiXoa;
            khachHang.NgayXoa = khachHangVm.NgayXoa;
            khachHang.XungHo = khachHangVm.XungHo;
            khachHang.NVBanHang = khachHangVm.NVBanHang;
            khachHang.DienGiai = khachHangVm.DienGiai;
            khachHang.SoNgayDuocNo = khachHangVm.SoNgayDuocNo;
            khachHang.SoNoToiDa = khachHangVm.SoNoToiDa;
            khachHang.QuocGia = khachHangVm.QuocGia;
            khachHang.Quan_Huyen = khachHangVm.Quan_Huyen;
            khachHang.Tinh_TP = khachHangVm.Tinh_TP;
            khachHang.Xa_Phuong = khachHangVm.Xa_Phuong;
            khachHang.DienThoaiCoDinh_LH = khachHangVm.DienThoaiCoDinh_LH;
            khachHang.HoVaTen_LH = khachHangVm.HoVaTen_LH;
            khachHang.Email_LH = khachHangVm.Email_LH;
            khachHang.ChucDanh_LH = khachHangVm.ChucDanh_LH;
            khachHang.DiaChi_LH = khachHangVm.DiaChi_LH;
            khachHang.DTdidong_LH = khachHangVm.DTdidong_LH;
            khachHang.DTKhac_LH = khachHangVm.DTKhac_LH;
            khachHang.TenNguoiNhan = khachHangVm.TenNguoiNhan;
            khachHang.DienThoaiNguoiNhan = khachHangVm.DienThoaiNguoiNhan;
            khachHang.DiaChiNguoiNhan = khachHangVm.DiaChiNguoiNhan;
            khachHang.EmailNguoiNhan = khachHangVm.EmailNguoiNhan;
            khachHang.DaiDienTheoPL_LH = khachHangVm.DaiDienTheoPL_LH;
            khachHang.DiaDiemGiaoHang = khachHangVm.DiaDiemGiaoHang;
            khachHang.NoiCap = khachHangVm.NoiCap;
            khachHang.CMND = khachHangVm.CMND;
            khachHang.DieuKhoanTT = khachHangVm.DieuKhoanTT;
            khachHang.NgayCap = khachHangVm.NgayCap;
            
        }

        public static void UpdateNhaCungCap(this NhaCungCap nhaCungCap, NhaCungCapViewModel nhaCungCapVm)
        {

            nhaCungCap.MaNhaCungCap = nhaCungCapVm.MaNhaCungCap;
            nhaCungCap.NhomKH_NCC = nhaCungCapVm.NhomKH_NCC;
            nhaCungCap.PhanLoai = nhaCungCapVm.PhanLoai;
            nhaCungCap.TenNhaCungCap = nhaCungCapVm.TenNhaCungCap;
            nhaCungCap.ChiNhanh = nhaCungCapVm.ChiNhanh;
            nhaCungCap.DiaChi = nhaCungCapVm.DiaChi;
            nhaCungCap.SoDienThoai = nhaCungCapVm.SoDienThoai;
            nhaCungCap.Fax = nhaCungCapVm.Fax;
            nhaCungCap.Email = nhaCungCapVm.Email;
            nhaCungCap.Website = nhaCungCapVm.Website;
            nhaCungCap.MaSoThue = nhaCungCapVm.MaSoThue;
            nhaCungCap.SoTaiKhoanNganHang = nhaCungCapVm.SoTaiKhoanNganHang;
            nhaCungCap.TenNganHang = nhaCungCapVm.TenNganHang;
            nhaCungCap.NguoiLienHe = nhaCungCapVm.NguoiLienHe;
            nhaCungCap.XungHo = nhaCungCapVm.XungHo;
            nhaCungCap.NVBanHang = nhaCungCapVm.NVBanHang;
            nhaCungCap.DienGiai = nhaCungCapVm.DienGiai;
            nhaCungCap.SoNgayDuocNo = nhaCungCapVm.SoNgayDuocNo;
            nhaCungCap.SoNoToiDa = nhaCungCapVm.SoNoToiDa;
            nhaCungCap.QuocGia = nhaCungCapVm.QuocGia;
            nhaCungCap.Quan_Huyen = nhaCungCapVm.Quan_Huyen;
            nhaCungCap.Tinh_TP = nhaCungCapVm.Tinh_TP;
            nhaCungCap.Xa_Phuong = nhaCungCapVm.Xa_Phuong;
            nhaCungCap.DienThoaiCoDinh_LH = nhaCungCapVm.DienThoaiCoDinh_LH;
            nhaCungCap.HoVaTen_LH = nhaCungCapVm.HoVaTen_LH;
            nhaCungCap.Email_LH = nhaCungCapVm.Email_LH;
            nhaCungCap.ChucDanh_LH = nhaCungCapVm.ChucDanh_LH;
            nhaCungCap.DiaChi_LH = nhaCungCapVm.DiaChi_LH;
            nhaCungCap.DTdidong_LH = nhaCungCapVm.DTdidong_LH;
            nhaCungCap.DTKhac_LH = nhaCungCapVm.DTKhac_LH;
            nhaCungCap.TenNguoiNhan = nhaCungCapVm.TenNguoiNhan;
            nhaCungCap.DienThoaiNguoiNhan = nhaCungCapVm.DienThoaiNguoiNhan;
            nhaCungCap.DiaChiNguoiNhan = nhaCungCapVm.DiaChiNguoiNhan;
            nhaCungCap.EmailNguoiNhan = nhaCungCapVm.EmailNguoiNhan;
            nhaCungCap.DaiDienTheoPL_LH = nhaCungCapVm.DaiDienTheoPL_LH;
            nhaCungCap.DiaDiemGiaoHang = nhaCungCapVm.DiaDiemGiaoHang;
            nhaCungCap.NoiCap = nhaCungCapVm.NoiCap;
            nhaCungCap.CMND = nhaCungCapVm.CMND;
            nhaCungCap.DieuKhoanTT = nhaCungCapVm.DieuKhoanTT;
            nhaCungCap.NgayCap = nhaCungCapVm.NgayCap;



        }
        public static void UpdatePhieuThu(this PhieuThu phieuThu, PhieuThuViewModel phieuThuVm)
        {
            phieuThu.MaPhieuThu = phieuThuVm.MaPhieuThu;
            phieuThu.MaKhachHang = phieuThuVm.MaKhachHang;
            phieuThu.MaSoNhanVien = phieuThuVm.MaSoNhanVien;
            phieuThu.MaLoaiThu = phieuThuVm.MaLoaiThu;
            phieuThu.MaTinhTrang = phieuThuVm.MaTinhTrang;
            phieuThu.LyDoNop = phieuThuVm.LyDoNop;
            phieuThu.DienGiai = phieuThuVm.DienGiai;
            phieuThu.NgayHoachToan = phieuThuVm.NgayHoachToan;
            phieuThu.NgayChungTu = phieuThuVm.NgayChungTu;
            phieuThu.TongTienHang = phieuThuVm.TongTienHang;
            phieuThu.TienChietKhau = phieuThuVm.TienChietKhau;
            phieuThu.TienThueGTGT = phieuThuVm.TienThueGTGT;
            phieuThu.TongTienThanhToan = phieuThuVm.TongTienThanhToan;
            phieuThu.DaGhiSo = phieuThuVm.DaGhiSo;
            phieuThu.MaLoaiTien = phieuThuVm.MaLoaiTien;
            phieuThu.TyGia = phieuThuVm.TyGia;
            phieuThu.NguoiNop = phieuThuVm.NguoiNop;
            phieuThu.ChungTuGoc = phieuThuVm.ChungTuGoc;

        }
        public static void UpdateChiTietThu(this ChiTietThu chiTietThu, ChiTietThuViewModel chiTietThuVm)
        {
            chiTietThu.MaCTPT = chiTietThuVm.MaCTPT;
            chiTietThu.MaPhieuThu = chiTietThuVm.MaPhieuThu;
            chiTietThu.MaHang = chiTietThuVm.MaHang;
            chiTietThu.SoLuong = chiTietThuVm.SoLuong;
            chiTietThu.SoTien = chiTietThuVm.SoTien;
            chiTietThu.DienGiai = chiTietThuVm.DienGiai;
            chiTietThu.SoTaiKhoanCo = chiTietThuVm.SoTaiKhoanCo;
            chiTietThu.SoTaiKhoanNo = chiTietThuVm.SoTaiKhoanNo;
            chiTietThu.MaKhachHang = chiTietThuVm.MaKhachHang;
            chiTietThu.TenKhachHang = chiTietThuVm.TenKhachHang;
            chiTietThu.TaiKhoanNganHang = chiTietThuVm.TaiKhoanNganHang;
            chiTietThu.MucThuChi = chiTietThuVm.MucThuChi;
            chiTietThu.DonVi = chiTietThuVm.DonVi;
            chiTietThu.CongTrinh = chiTietThuVm.CongTrinh;
            chiTietThu.HopDongBan = chiTietThuVm.HopDongBan;
            chiTietThu.MaThongKe = chiTietThuVm.MaThongKe;
      
    }

        public static void UpdateHangHhoa(this HangHoa hangHoa, HangHoaViewModel hangHoaVm)
        {
            hangHoa.MaHang = hangHoaVm.MaHang;
            hangHoa.TenHang = hangHoaVm.TenHang;
            hangHoa.MaNhomHH = hangHoaVm.MaNhomHH;
            hangHoa.MaTinhChat = hangHoaVm.MaTinhChat;
            hangHoa.DonViTinh = hangHoaVm.DonViTinh;
            hangHoa.BaoHanh = hangHoaVm.BaoHanh;
            hangHoa.NguonGoc = hangHoaVm.NguonGoc;
            hangHoa.MoTa = hangHoaVm.MoTa;
            hangHoa.GiaNhap = hangHoaVm.GiaNhap;
            hangHoa.GiaBan = hangHoaVm.GiaBan;
            hangHoa.GiaKhuyenMai = hangHoaVm.GiaKhuyenMai;
            hangHoa.VAT = hangHoaVm.VAT;
            hangHoa.ChietKhau = hangHoaVm.ChietKhau;
            hangHoa.HanSuDung = hangHoaVm.HanSuDung;
            hangHoa.ThanhPham = hangHoaVm.ThanhPham;
            hangHoa.SoLo = hangHoaVm.SoLo;
            hangHoa.HinhAnh = hangHoaVm.HinhAnh;
            hangHoa.NguoiSua = hangHoaVm.NguoiSua;
            hangHoa.NgaySua = hangHoaVm.NgaySua;
            hangHoa.NgayNhap = hangHoaVm.NgayNhap;
            hangHoa.NguoiNhap = hangHoaVm.NguoiNhap;
        }
        public static void UpdatePhieuChi(this PhieuChi phieuChi, PhieuChiViewModel phieuChiVm)
        {
            phieuChi.MaPhieuChi = phieuChiVm.MaPhieuChi;
            phieuChi.MaSoNhanVien = phieuChiVm.MaSoNhanVien;
            phieuChi.MaNhaCungCap = phieuChiVm.MaNhaCungCap;
            phieuChi.MaLoaiChi = phieuChiVm.MaLoaiChi;
            phieuChi.MaTinhTrang = phieuChiVm.MaTinhTrang;
            phieuChi.LyDoChi = phieuChiVm.LyDoChi;
            phieuChi.DienGiai = phieuChiVm.DienGiai;
            phieuChi.NgayHoachToan = phieuChiVm.NgayHoachToan;
            phieuChi.NgayChungTu = phieuChiVm.NgayChungTu;
            phieuChi.TongTienDichVu = phieuChiVm.TongTienDichVu;
            phieuChi.TienChietKhau = phieuChiVm.TienChietKhau;
            phieuChi.TienThueGTGT = phieuChiVm.TienThueGTGT;
            phieuChi.TongTienThanhToan = phieuChiVm.TongTienThanhToan;
            phieuChi.ChungTuGoc = phieuChiVm.ChungTuGoc;
            phieuChi.MaLoaiTien = phieuChiVm.MaLoaiTien;
            phieuChi.TyGia = phieuChiVm.TyGia;
            phieuChi.NguoiNop = phieuChiVm.NguoiNop;
            phieuChi.DaGhiSo = phieuChiVm.DaGhiSo;
        } 
        public static void UpdateChiTietPhieuChi(this ChiTietPhieuChi chiTietPhieuChi, ChiTietPhieuChiViewModel chiTietPhieuChiVm)
        {
            chiTietPhieuChi.MaCTPC = chiTietPhieuChiVm.MaCTPC;
            chiTietPhieuChi.MaPhieuChi = chiTietPhieuChiVm.MaPhieuChi;
            chiTietPhieuChi.MaHang = chiTietPhieuChiVm.MaHang;
            chiTietPhieuChi.SoLuong = chiTietPhieuChiVm.SoLuong;
            chiTietPhieuChi.SoTien = chiTietPhieuChiVm.SoTien;
            chiTietPhieuChi.DienGiai = chiTietPhieuChiVm.DienGiai;
            chiTietPhieuChi.SoTaiKhoanCo = chiTietPhieuChiVm.SoTaiKhoanCo;
            chiTietPhieuChi.SoTaiKhoanNo = chiTietPhieuChiVm.SoTaiKhoanNo;
            chiTietPhieuChi.MaNhaCungCap = chiTietPhieuChiVm.MaNhaCungCap;
            chiTietPhieuChi.TenNhaCungCap = chiTietPhieuChiVm.TenNhaCungCap;
            chiTietPhieuChi.TaiKhoanNganHang = chiTietPhieuChiVm.TaiKhoanNganHang;
            chiTietPhieuChi.MucThuChi = chiTietPhieuChiVm.MucThuChi;
            chiTietPhieuChi.DonVi = chiTietPhieuChiVm.DonVi;
            chiTietPhieuChi.CongTrinh = chiTietPhieuChiVm.CongTrinh;
            chiTietPhieuChi.HopDongBan = chiTietPhieuChiVm.HopDongBan;
            chiTietPhieuChi.MaThongKe = chiTietPhieuChiVm.MaThongKe;
            chiTietPhieuChi.KhoanMucCP = chiTietPhieuChiVm.KhoanMucCP;
            chiTietPhieuChi.DoiTuongDHCP = chiTietPhieuChiVm.DoiTuongDHCP;
            chiTietPhieuChi.DonDatHang = chiTietPhieuChiVm.DonDatHang;
            chiTietPhieuChi.DonMuaHang = chiTietPhieuChiVm.DonMuaHang;
        }
        public static void UpdateKhachHang_TaiKhoan(this KhachHang_TaiKhoan khachHang_TaiKhoan, KhachHang_TaiKhoanViewModel khachHang_TaiKhoanVm)
        {
            khachHang_TaiKhoan.MaTaiKhoan = khachHang_TaiKhoanVm.MaTaiKhoan;
            khachHang_TaiKhoan.MaKhachHang = khachHang_TaiKhoanVm.MaKhachHang;
            khachHang_TaiKhoan.GhiChu = khachHang_TaiKhoanVm.GhiChu;
            khachHang_TaiKhoan.id = khachHang_TaiKhoanVm.id;
        }
        public static void UpdateNhaCungCap_TaiKhoan(this NhaCungCap_TaiKhoan khachHang_TaiKhoan, NhaCungCap_TaiKhoanViewModel khachHang_TaiKhoanVm)
        {
            khachHang_TaiKhoan.MaTaiKhoan = khachHang_TaiKhoanVm.MaTaiKhoan;
            khachHang_TaiKhoan.MaNhaCungCap = khachHang_TaiKhoanVm.MaNhaCungCap;
            khachHang_TaiKhoan.GhiChu = khachHang_TaiKhoanVm.GhiChu;
            khachHang_TaiKhoan.id = khachHang_TaiKhoanVm.id;

        }
        public static void UpdateTaiKhoanNganHang(this TaiKhoanNganHang taiKhoanNganHang, TaiKhoanNganHangViewModel taiKhoanNganHangVm)
        {
            taiKhoanNganHang.MaTaiKhoan = taiKhoanNganHangVm.MaTaiKhoan;
            taiKhoanNganHang.TenNganHang = taiKhoanNganHangVm.TenNganHang;
            taiKhoanNganHang.ChiNhanh = taiKhoanNganHangVm.ChiNhanh;
            taiKhoanNganHang.TinhTP = taiKhoanNganHangVm.TinhTP;
        }
        public static void UpdateLoaiTien(this LoaiTien loaiTien, LoaiTienViewModel loaiTienVm)
        {
            loaiTien.MaLoaiTien = loaiTienVm.MaLoaiTien;
            loaiTien.TenLoaiTien = loaiTienVm.TenLoaiTien;
            loaiTien.VietTat = loaiTienVm.VietTat;
            loaiTien.MenhGia = loaiTienVm.MenhGia;
            loaiTien.TyGia_VND = loaiTienVm.TyGia_VND;
          
        }
        public static void UpdateDieuKhoanTT(this DieuKhoanTT dieuKhoanTT, DieuKhoanTTViewModel dieuKhoanTTVm)
        {
            dieuKhoanTT.MaDieuKhoan = dieuKhoanTTVm.MaDieuKhoan;
            dieuKhoanTT.TenDieuKhoan = dieuKhoanTTVm.TenDieuKhoan;
          
        }
        public static void UpdateDonMuaHang(this DonMuaHang donMuaHang, DonMuaHangViewModel donMuaHangVm)
        {
            donMuaHang.MaDonMuaHang = donMuaHangVm.MaDonMuaHang;
            donMuaHang.MaNhaCungCap = donMuaHangVm.MaNhaCungCap;
            donMuaHang.DienGiai = donMuaHangVm.DienGiai;
            donMuaHang.MaSoNhanVien = donMuaHangVm.MaSoNhanVien;
            donMuaHang.MaDieuKhoan = donMuaHangVm.MaDieuKhoan;
            donMuaHang.SoNgayDuocNo = donMuaHangVm.SoNgayDuocNo;
            donMuaHang.NgayDonHang = donMuaHangVm.NgayDonHang;
            donMuaHang.NgayGiaoHang = donMuaHangVm.NgayGiaoHang;
            donMuaHang.MaTinhTrang = donMuaHangVm.MaTinhTrang;
            donMuaHang.MaLoaiTien = donMuaHangVm.MaLoaiTien;
            donMuaHang.TyGia = donMuaHangVm.TyGia;
            donMuaHang.TongTienHang = donMuaHangVm.TongTienHang;
            donMuaHang.TienThue = donMuaHangVm.TienThue;
            donMuaHang.TienChietKhau = donMuaHangVm.TienChietKhau;
            donMuaHang.TongTienThanhToan = donMuaHangVm.TongTienThanhToan;
           
    }
        public static void UpdateChiTietDonMuaHang(this ChiTietDonMuaHang donMuaHang, ChiTietDonMuaHangViewModel donMuaHangVm)
        {
            donMuaHang.MaDonMuaHang = donMuaHangVm.MaDonMuaHang;
            donMuaHang.MaCTDMH = donMuaHangVm.MaCTDMH;
            donMuaHang.MaHang = donMuaHangVm.MaHang;
            donMuaHang.SoLuong = donMuaHangVm.SoLuong;
            donMuaHang.SoLuongNhan = donMuaHangVm.SoLuongNhan;
            donMuaHang.DonGia = donMuaHangVm.DonGia;
            donMuaHang.ThanhTien = donMuaHangVm.ThanhTien;
            donMuaHang.ThueGTGT = donMuaHangVm.ThueGTGT;
            donMuaHang.TienThueGTGT = donMuaHangVm.TienThueGTGT;
            donMuaHang.LenhSanXuat = donMuaHangVm.LenhSanXuat;
            donMuaHang.ThanhPham = donMuaHangVm.ThanhPham;
             
    }
        public static void UpdateHopDongMua(this HopDongMua hopDongMua, HopDongMuaViewModel hopDongMuaVm)
        {
            hopDongMua.MaHopDongMua = hopDongMuaVm.MaHopDongMua;
            hopDongMua.TrichYeu = hopDongMuaVm.TrichYeu;
            hopDongMua.MaNhaCungCap = hopDongMuaVm.MaNhaCungCap;
            hopDongMua.MaLoaiTien = hopDongMuaVm.MaLoaiTien;
            hopDongMua.TyGia = hopDongMuaVm.TyGia;
            hopDongMua.GiaTriHopDong = hopDongMuaVm.GiaTriHopDong;
            hopDongMua.NguoiLienHe = hopDongMuaVm.NguoiLienHe;
            hopDongMua.GiaTriHopDongQuyDoi = hopDongMuaVm.GiaTriHopDongQuyDoi;
            hopDongMua.HanGiaoHang = hopDongMuaVm.HanGiaoHang;
            hopDongMua.MaTinhTrang = hopDongMuaVm.MaTinhTrang;
            hopDongMua.DiaChiGiaoHang = hopDongMuaVm.DiaChiGiaoHang;
            hopDongMua.GiaTriThanhLy = hopDongMuaVm.GiaTriThanhLy;
            hopDongMua.GiaTriThanhLyQuyDoi = hopDongMuaVm.GiaTriThanhLyQuyDoi;
            hopDongMua.HanThanhToan = hopDongMuaVm.HanThanhToan;
            hopDongMua.NgayThanhLy_HuyBo = hopDongMuaVm.NgayThanhLy_HuyBo;
            hopDongMua.MaSoNhanVien = hopDongMuaVm.MaSoNhanVien;
            hopDongMua.LyDo = hopDongMuaVm.LyDo;
            hopDongMua.DieuKhoanKhac = hopDongMuaVm.DieuKhoanKhac;
            hopDongMua.LaHopDongPhatSinh = hopDongMuaVm.LaHopDongPhatSinh;
            hopDongMua.TienChietKhau = hopDongMuaVm.TienChietKhau;
            hopDongMua.TienThueGTGT = hopDongMuaVm.TienThueGTGT;
            hopDongMua.TongTienThanhToan = hopDongMuaVm.TongTienThanhToan;
            hopDongMua.NgayKy = hopDongMuaVm.NgayKy;
        }
        public static void UpdateChiTietHopDongMua(this ChiTietHopDongMua chiTietHopDongMua, ChiTietHopDongMuaViewModel chiTietHopDongMuaVm)
        {
            chiTietHopDongMua.MaChiTietHopDongMua = chiTietHopDongMuaVm.MaChiTietHopDongMua;
            chiTietHopDongMua.MaHopDongMua = chiTietHopDongMuaVm.MaHopDongMua;
            chiTietHopDongMua.MaHang = chiTietHopDongMuaVm.MaHang;
            chiTietHopDongMua.SoLuong = chiTietHopDongMuaVm.SoLuong;
            chiTietHopDongMua.TienChietKhau = chiTietHopDongMuaVm.TienChietKhau;
            chiTietHopDongMua.TienThueGTGT = chiTietHopDongMuaVm.TienThueGTGT;
            chiTietHopDongMua.ThanhTien = chiTietHopDongMuaVm.ThanhTien;
         
    }
        public static void UpdateChungTuMuaHang(this ChungTuMuaHang chungTuMuaHang, ChungTuMuaHangViewModel chungTuMuaHangVm)
        {
            chungTuMuaHang.MaChungTuMuaHang = chungTuMuaHangVm.MaChungTuMuaHang;
            chungTuMuaHang.MaNhaCungCap = chungTuMuaHangVm.MaNhaCungCap;
            chungTuMuaHang.NguoiGiaoHang = chungTuMuaHangVm.NguoiGiaoHang;
            chungTuMuaHang.DienGiai = chungTuMuaHangVm.DienGiai;
            chungTuMuaHang.MaSoNhanVien = chungTuMuaHangVm.MaSoNhanVien;
            chungTuMuaHang.ChungTuGoc = chungTuMuaHangVm.ChungTuGoc;
            chungTuMuaHang.DieuKhoanTT = chungTuMuaHangVm.DieuKhoanTT;
            chungTuMuaHang.SoNgayDuocNo = chungTuMuaHangVm.SoNgayDuocNo;
            chungTuMuaHang.HanThanhToan = chungTuMuaHangVm.HanThanhToan;
            chungTuMuaHang.MaLoaiTien = chungTuMuaHangVm.MaLoaiTien;
            chungTuMuaHang.NgayHoachToan = chungTuMuaHangVm.NgayHoachToan;
            chungTuMuaHang.TyGia = chungTuMuaHangVm.TyGia;
            chungTuMuaHang.TongTienHang = chungTuMuaHangVm.TongTienHang;
            chungTuMuaHang.ChiPhiGiaoHang = chungTuMuaHangVm.ChiPhiGiaoHang;
            chungTuMuaHang.TienChietKhau = chungTuMuaHangVm.TienChietKhau;
            chungTuMuaHang.GiaTriNhapKho = chungTuMuaHangVm.GiaTriNhapKho;
            chungTuMuaHang.TongTienThanhToan = chungTuMuaHangVm.TongTienThanhToan;
      

    }
        public static void UpdateChiTietChungTuMuaHang(this ChiTietChungTuMuaHang chungTuMuaHang, ChiTietChungTuMuaHangViewModel chungTuMuaHangVm)
        {
            chungTuMuaHang.MaChiTietChungTuMuaHang = chungTuMuaHangVm.MaChiTietChungTuMuaHang;
            chungTuMuaHang.MaHang = chungTuMuaHangVm.MaHang;
            chungTuMuaHang.Kho = chungTuMuaHangVm.Kho;
            chungTuMuaHang.TKKho = chungTuMuaHangVm.TKKho;
            chungTuMuaHang.TKCongNo = chungTuMuaHangVm.TKCongNo;
            chungTuMuaHang.SoLuong = chungTuMuaHangVm.SoLuong;
            chungTuMuaHang.ThanhTien = chungTuMuaHangVm.ThanhTien;
            chungTuMuaHang.TienChietKhau = chungTuMuaHangVm.TienChietKhau;
            chungTuMuaHang.ChiPhiMuaHang = chungTuMuaHangVm.ChiPhiMuaHang;
            chungTuMuaHang.GiaTriNhapKho = chungTuMuaHangVm.GiaTriNhapKho;
            chungTuMuaHang.SoLo = chungTuMuaHangVm.SoLo;
            chungTuMuaHang.DoiTuongDHCP = chungTuMuaHangVm.DoiTuongDHCP;
            chungTuMuaHang.CongTrinh = chungTuMuaHangVm.CongTrinh;
            chungTuMuaHang.MaHopDongMua = chungTuMuaHangVm.MaHopDongMua;
            chungTuMuaHang.MaDonMuaHang = chungTuMuaHangVm.MaDonMuaHang;
            chungTuMuaHang.MaThongKe = chungTuMuaHangVm.MaThongKe;
            chungTuMuaHang.MaChungTuMuaHang = chungTuMuaHangVm.MaChungTuMuaHang;



        }
        public static void UpdateChiTietTraLaiHangMua(this ChiTietTraLaiHangMua chiTietTraLaiHangMua, ChiTietTraLaiHangMuaViewModel chiTietTraLaiHangMuaVm)
        {
            chiTietTraLaiHangMua.MaChiTietTraLaiHangMua = chiTietTraLaiHangMuaVm.MaChiTietTraLaiHangMua;
            chiTietTraLaiHangMua.MaTraLaiHangMua = chiTietTraLaiHangMuaVm.MaTraLaiHangMua;
            chiTietTraLaiHangMua.MaHang = chiTietTraLaiHangMuaVm.MaHang;
            chiTietTraLaiHangMua.Kho = chiTietTraLaiHangMuaVm.Kho;
            chiTietTraLaiHangMua.TKKho = chiTietTraLaiHangMuaVm.TKKho;
            chiTietTraLaiHangMua.TKCongNo = chiTietTraLaiHangMuaVm.TKCongNo;
            chiTietTraLaiHangMua.SoLuong = chiTietTraLaiHangMuaVm.SoLuong;
            chiTietTraLaiHangMua.ThanhTien = chiTietTraLaiHangMuaVm.ThanhTien;
            chiTietTraLaiHangMua.DienGiaiThue = chiTietTraLaiHangMuaVm.DienGiaiThue;
            chiTietTraLaiHangMua.TienThueGTGT = chiTietTraLaiHangMuaVm.TienThueGTGT;
            chiTietTraLaiHangMua.TKThueGTGT = chiTietTraLaiHangMuaVm.TKThueGTGT;
            chiTietTraLaiHangMua.NhomHHDVMuaVao = chiTietTraLaiHangMuaVm.NhomHHDVMuaVao;
            chiTietTraLaiHangMua.SoLo = chiTietTraLaiHangMuaVm.SoLo;
            chiTietTraLaiHangMua.SoCTMuaHang = chiTietTraLaiHangMuaVm.SoCTMuaHang;
            chiTietTraLaiHangMua.SoHDMuaHang = chiTietTraLaiHangMuaVm.SoHDMuaHang;
            chiTietTraLaiHangMua.NgayHDMuaHang = chiTietTraLaiHangMuaVm.NgayHDMuaHang;
            chiTietTraLaiHangMua.MaHopDongMua = chiTietTraLaiHangMuaVm.MaHopDongMua;
            chiTietTraLaiHangMua.MaThongKe = chiTietTraLaiHangMuaVm.MaThongKe;
        }
        public static void UpdateTraLaiHangMua(this TraLaiHangMua traLaiHangMua, TraLaiHangMuaViewModel traLaiHangMuaVm)
        {
            traLaiHangMua.MaTraLaiHangMua = traLaiHangMuaVm.MaTraLaiHangMua;
            traLaiHangMua.MaNhaCungCap = traLaiHangMuaVm.MaNhaCungCap;
            traLaiHangMua.NguoiNhanHang = traLaiHangMuaVm.NguoiNhanHang;
            traLaiHangMua.DienGiai = traLaiHangMuaVm.DienGiai;
            traLaiHangMua.MaSoNhanVien = traLaiHangMuaVm.MaSoNhanVien;
            traLaiHangMua.ChungTuGoc = traLaiHangMuaVm.ChungTuGoc;
            traLaiHangMua.MaLoaiTien = traLaiHangMuaVm.MaLoaiTien;
            traLaiHangMua.TyGia = traLaiHangMuaVm.TyGia;
            traLaiHangMua.NgayHoachToan = traLaiHangMuaVm.NgayHoachToan;
            traLaiHangMua.NgayChungTu = traLaiHangMuaVm.NgayChungTu;
            traLaiHangMua.TongTienHang = traLaiHangMuaVm.TongTienHang;
            traLaiHangMua.TienThueGTGT = traLaiHangMuaVm.TienThueGTGT;
            traLaiHangMua.TongTienThanhToan = traLaiHangMuaVm.TongTienThanhToan;
            traLaiHangMua.DaGhiSo = traLaiHangMuaVm.DaGhiSo;


        }
        public static void UpdateChiTietGiamGiaHangMua(this ChiTietGiamGiaHangMua chiTietTraLaiHangMua, ChiTietGiamGiaHangMuaViewModel chiTietTraLaiHangMuaVm)
        {
            chiTietTraLaiHangMua.MaChiTietGiamGiaHangMua = chiTietTraLaiHangMuaVm.MaChiTietGiamGiaHangMua;
            chiTietTraLaiHangMua.MaGiamGiaHangMua = chiTietTraLaiHangMuaVm.MaGiamGiaHangMua;
            chiTietTraLaiHangMua.MaHang = chiTietTraLaiHangMuaVm.MaHang;
            chiTietTraLaiHangMua.Kho = chiTietTraLaiHangMuaVm.Kho;
            chiTietTraLaiHangMua.TKKho = chiTietTraLaiHangMuaVm.TKKho;
            chiTietTraLaiHangMua.TKCongNo = chiTietTraLaiHangMuaVm.TKCongNo;
            chiTietTraLaiHangMua.SoLuong = chiTietTraLaiHangMuaVm.SoLuong;
            chiTietTraLaiHangMua.ThanhTien = chiTietTraLaiHangMuaVm.ThanhTien;
            chiTietTraLaiHangMua.DienGiaiThue = chiTietTraLaiHangMuaVm.DienGiaiThue;
            chiTietTraLaiHangMua.TienThueGTGT = chiTietTraLaiHangMuaVm.TienThueGTGT;
            chiTietTraLaiHangMua.TKThueGTGT = chiTietTraLaiHangMuaVm.TKThueGTGT;
            chiTietTraLaiHangMua.NhomHHDVMuaVao = chiTietTraLaiHangMuaVm.NhomHHDVMuaVao;
            chiTietTraLaiHangMua.SoLo = chiTietTraLaiHangMuaVm.SoLo;
            chiTietTraLaiHangMua.SoCTMuaHang = chiTietTraLaiHangMuaVm.SoCTMuaHang;
            chiTietTraLaiHangMua.SoHDMuaHang = chiTietTraLaiHangMuaVm.SoHDMuaHang;
            chiTietTraLaiHangMua.NgayHDMuaHang = chiTietTraLaiHangMuaVm.NgayHDMuaHang;
            chiTietTraLaiHangMua.MaHopDongMua = chiTietTraLaiHangMuaVm.MaHopDongMua;
            chiTietTraLaiHangMua.MaThongKe = chiTietTraLaiHangMuaVm.MaThongKe;
        }
        public static void UpdateGiamGiaHangMua(this GiamGiaHangMua traLaiHangMua, GiamGiaHangMuaViewModel traLaiHangMuaVm)
        {
            traLaiHangMua.MaGiamGiaHangMua = traLaiHangMuaVm.MaGiamGiaHangMua;
            traLaiHangMua.MaNhaCungCap = traLaiHangMuaVm.MaNhaCungCap;
            traLaiHangMua.DienGiai = traLaiHangMuaVm.DienGiai;
            traLaiHangMua.MaSoNhanVien = traLaiHangMuaVm.MaSoNhanVien;
            traLaiHangMua.ChungTuGoc = traLaiHangMuaVm.ChungTuGoc;
            traLaiHangMua.MaLoaiTien = traLaiHangMuaVm.MaLoaiTien;
            traLaiHangMua.TyGia = traLaiHangMuaVm.TyGia;
            traLaiHangMua.NgayHoachToan = traLaiHangMuaVm.NgayHoachToan;
            traLaiHangMua.NgayChungTu = traLaiHangMuaVm.NgayChungTu;
            traLaiHangMua.TongTienHang = traLaiHangMuaVm.TongTienHang;
            traLaiHangMua.TienThueGTGT = traLaiHangMuaVm.TienThueGTGT;
            traLaiHangMua.TongTienThanhToan = traLaiHangMuaVm.TongTienThanhToan;
            traLaiHangMua.DaGhiSo = traLaiHangMuaVm.DaGhiSo;



        }
        public static void UpdateDichVu(this DichVu dichVu, DichVuViewModel dichVuVm)
        {
            dichVu.MaDichVu = dichVuVm.MaDichVu;
            dichVu.TenDichVu = dichVuVm.TenDichVu;
            dichVu.DonViTinh = dichVuVm.DonViTinh;
            dichVu.DonGia = dichVuVm.DonGia;
            dichVu.VAT = dichVuVm.VAT;
            dichVu.ChietKhau = dichVuVm.ChietKhau;
        }
        public static void UpdateChungTuMuaDichVu(this ChungTuMuaDichVu chungTuMuaDichVu, ChungTuMuaDichVuViewModel chungTuMuaDichVuVm)
        {
            chungTuMuaDichVu.MaChungTuMuaDichVu = chungTuMuaDichVuVm.MaChungTuMuaDichVu;
            chungTuMuaDichVu.MaNhaCungCap = chungTuMuaDichVuVm.MaNhaCungCap;
            chungTuMuaDichVu.DienGiai = chungTuMuaDichVuVm.DienGiai;
            chungTuMuaDichVu.MaSoNhanVien = chungTuMuaDichVuVm.MaSoNhanVien;
            chungTuMuaDichVu.MaDieuKhoan = chungTuMuaDichVuVm.MaDieuKhoan;
            chungTuMuaDichVu.SoNgayDuocNo = chungTuMuaDichVuVm.SoNgayDuocNo;
            chungTuMuaDichVu.HanThanhToan = chungTuMuaDichVuVm.HanThanhToan;
            chungTuMuaDichVu.MaLoaiTien = chungTuMuaDichVuVm.MaLoaiTien;
            chungTuMuaDichVu.TyGia = chungTuMuaDichVuVm.TyGia;
            chungTuMuaDichVu.NgayHoachToan = chungTuMuaDichVuVm.NgayHoachToan;
            chungTuMuaDichVu.NgayChungTu = chungTuMuaDichVuVm.NgayChungTu;
            chungTuMuaDichVu.TienDichVu = chungTuMuaDichVuVm.TienDichVu;
            chungTuMuaDichVu.TienThueGTGT = chungTuMuaDichVuVm.TienThueGTGT;
            chungTuMuaDichVu.TienChietKhau = chungTuMuaDichVuVm.TienChietKhau;
            chungTuMuaDichVu.TongTienThanhToan = chungTuMuaDichVuVm.TongTienThanhToan;
            chungTuMuaDichVu.DaGhiSo = chungTuMuaDichVuVm.DaGhiSo;

        }
        public static void UpdateChiTietChungTuMuaDichVu(this ChiTietChungTuMuaDichVu chiTietChungTuMuaDichVu, ChiTietChungTuMuaDichVuViewModel chiTietChungTuMuaDichVuVm)
        {
            chiTietChungTuMuaDichVu.MaChiTietChungTuMuaDichVu = chiTietChungTuMuaDichVuVm.MaChiTietChungTuMuaDichVu;
            chiTietChungTuMuaDichVu.MaChungTuMuaDichVu = chiTietChungTuMuaDichVuVm.MaChungTuMuaDichVu;
            chiTietChungTuMuaDichVu.TKChiPhi_TKKho = chiTietChungTuMuaDichVuVm.TKChiPhi_TKKho;
            chiTietChungTuMuaDichVu.TKCongNo = chiTietChungTuMuaDichVuVm.TKCongNo;
            chiTietChungTuMuaDichVu.DoiTuong = chiTietChungTuMuaDichVuVm.DoiTuong;
            chiTietChungTuMuaDichVu.TenDoiTuong = chiTietChungTuMuaDichVuVm.TenDoiTuong;
            chiTietChungTuMuaDichVu.SoLuong = chiTietChungTuMuaDichVuVm.SoLuong;
            chiTietChungTuMuaDichVu.ThanhTien = chiTietChungTuMuaDichVuVm.ThanhTien;
            chiTietChungTuMuaDichVu.MaDichVu = chiTietChungTuMuaDichVuVm.MaDichVu;
        }
        public static void UpdateBaoGia(this BaoGia baoGia, BaoGiaViewModel baoGiaVm)
        {
            baoGia.MaSoBaoGia = baoGiaVm.MaSoBaoGia;
            baoGia.MaKhachHang = baoGiaVm.MaKhachHang;
            baoGia.GhiChu = baoGiaVm.GhiChu;
            baoGia.MaSoNhanVien = baoGiaVm.MaSoNhanVien;
            baoGia.NgayBaoGia = baoGiaVm.NgayBaoGia;
            baoGia.HieuLucDen = baoGiaVm.HieuLucDen;
            baoGia.MaLoaiTien = baoGiaVm.MaLoaiTien;
            baoGia.TyGia = baoGiaVm.TyGia;
            baoGia.TienHang = baoGiaVm.TienHang;
            baoGia.TienThueGTGT = baoGiaVm.TienThueGTGT;
            baoGia.TienChietKhau = baoGiaVm.TienChietKhau;
            baoGia.TongTien = baoGiaVm.TongTien;
        }
        public static void UpdateChiTietBaoGia(this ChiTietBaoGia chiTietBaoGia, ChiTietBaoGiaViewModel chiTietBaoGiaVm)
        {
            chiTietBaoGia.MaChiTietBaoGia = chiTietBaoGiaVm.MaChiTietBaoGia;
            chiTietBaoGia.MaSoBaoGia = chiTietBaoGiaVm.MaSoBaoGia;
            chiTietBaoGia.MaHang = chiTietBaoGiaVm.MaHang;
            chiTietBaoGia.SoLuong = chiTietBaoGiaVm.SoLuong;
            chiTietBaoGia.ThanhTien = chiTietBaoGiaVm.ThanhTien;
            chiTietBaoGia.TienChietKhau = chiTietBaoGiaVm.TienChietKhau;
            chiTietBaoGia.TienThueGTGT = chiTietBaoGiaVm.TienThueGTGT;
        
    }
        public static void UpdateChiTietDonDatHang(this ChiTietDonDatHang chiTietDonDatHang, ChiTietDonDatHangViewModel chiTietDonDatHangVm)
        {
            chiTietDonDatHang.MaChiTietDonDatHang = chiTietDonDatHangVm.MaChiTietDonDatHang;
            chiTietDonDatHang.MaDonDatHang = chiTietDonDatHangVm.MaDonDatHang;
            chiTietDonDatHang.MaHang = chiTietDonDatHangVm.MaHang;
            chiTietDonDatHang.SoLuong = chiTietDonDatHangVm.SoLuong;
            chiTietDonDatHang.SoLuongDaGiao = chiTietDonDatHangVm.SoLuongDaGiao;
            chiTietDonDatHang.ThanhTien = chiTietDonDatHangVm.ThanhTien;
            chiTietDonDatHang.TienThueGTGT = chiTietDonDatHangVm.TienThueGTGT;
        }
        public static void UpdateDonDatHang(this DonDatHang donDatHang, DonDatHangViewModel donDatHangVm)
        {
            donDatHang.MaDonDatHang = donDatHangVm.MaDonDatHang;
            donDatHang.MaKhachHang = donDatHangVm.MaKhachHang;
            donDatHang.NguoiNhanHang = donDatHangVm.NguoiNhanHang;
            donDatHang.DienGiai = donDatHangVm.DienGiai;
            donDatHang.MaSoNhanVien = donDatHangVm.MaSoNhanVien;
            donDatHang.MaDieuKhoan = donDatHangVm.MaDieuKhoan;
            donDatHang.SoNgayDuocNo = donDatHangVm.SoNgayDuocNo;
            donDatHang.NgayDonHang = donDatHangVm.NgayDonHang;
            donDatHang.MaTinhTrang = donDatHangVm.MaTinhTrang;
            donDatHang.NgayGiaoHang = donDatHangVm.NgayGiaoHang;
            donDatHang.MaLoaiTien = donDatHangVm.MaLoaiTien;
            donDatHang.TyGia = donDatHangVm.TyGia;
            donDatHang.TongTienHang = donDatHangVm.TongTienHang;
            donDatHang.TienThueGTGT = donDatHangVm.TienThueGTGT;
            donDatHang.TongChietKhau = donDatHangVm.TongChietKhau;
            donDatHang.TongTienThanhToan = donDatHangVm.TongTienThanhToan;
        }

        public static void UpdateChungTuBanHang(this ChungTuBanHang chungTuBanHang, ChungTuBanHangViewModel chungTuBanHangVm)
        {
            chungTuBanHang.MaChungTuBanHang = chungTuBanHangVm.MaChungTuBanHang;
            chungTuBanHang.MaKhachHang = chungTuBanHangVm.MaKhachHang;
            chungTuBanHang.DienGiai = chungTuBanHangVm.DienGiai;
            chungTuBanHang.MaSoNhanVien = chungTuBanHangVm.MaSoNhanVien;
            chungTuBanHang.NgayHoachToan = chungTuBanHangVm.NgayHoachToan;
            chungTuBanHang.NgayChungTu = chungTuBanHangVm.NgayChungTu;
            chungTuBanHang.MaDieuKhoan = chungTuBanHangVm.MaDieuKhoan;
            chungTuBanHang.SoNgayDuocNo = chungTuBanHangVm.SoNgayDuocNo;
            chungTuBanHang.HanThanhToan = chungTuBanHangVm.HanThanhToan;
            chungTuBanHang.MaLoaiTien = chungTuBanHangVm.MaLoaiTien;
            chungTuBanHang.TyGia = chungTuBanHangVm.TyGia;
            chungTuBanHang.TongTienHang = chungTuBanHangVm.TongTienHang;
            chungTuBanHang.TienThueGTGT = chungTuBanHangVm.TienThueGTGT;
            chungTuBanHang.TienChietKhau = chungTuBanHangVm.TienChietKhau;
            chungTuBanHang.TongTienThanhToan = chungTuBanHangVm.TongTienThanhToan;
            chungTuBanHang.DaGhiSo = chungTuBanHangVm.DaGhiSo;
            chungTuBanHang.MaSoBaoGia = chungTuBanHangVm.MaSoBaoGia;
            chungTuBanHang.MaPhieuGoc = chungTuBanHangVm.MaPhieuGoc;
            chungTuBanHang.MaPhieuMoi = chungTuBanHangVm.MaPhieuMoi;
            chungTuBanHang.DaThayDoi = chungTuBanHangVm.DaThayDoi;
            chungTuBanHang.NgayThayDoi = chungTuBanHangVm.NgayThayDoi;
            chungTuBanHang.NhanVienThayDoi = chungTuBanHangVm.NhanVienThayDoi;
            chungTuBanHang.CoSoThayDoi = chungTuBanHangVm.CoSoThayDoi;
    }
        public static void UpdateChiTietChungTuBanHang(this ChiTietChungTuBanHang chiTietChungTuBanHang, ChiTietChungTuBanHangViewModel chiTietChungTuBanHangVm)
        {
            chiTietChungTuBanHang.MaChiTietChungTuBanHang = chiTietChungTuBanHangVm.MaChiTietChungTuBanHang;
            chiTietChungTuBanHang.MaChungTuBanHang = chiTietChungTuBanHangVm.MaChungTuBanHang;
            chiTietChungTuBanHang.MaHang = chiTietChungTuBanHangVm.MaHang;
            chiTietChungTuBanHang.TKCongNo_ChiPhi = chiTietChungTuBanHangVm.TKCongNo_ChiPhi;
            chiTietChungTuBanHang.TKDoanhThu = chiTietChungTuBanHangVm.TKDoanhThu;
            chiTietChungTuBanHang.SoLuong = chiTietChungTuBanHangVm.SoLuong;
            chiTietChungTuBanHang.ThanhTien = chiTietChungTuBanHangVm.ThanhTien;
            chiTietChungTuBanHang.TienChietKhau = chiTietChungTuBanHangVm.TienChietKhau;
            chiTietChungTuBanHang.TienThueGTGT = chiTietChungTuBanHangVm.TienThueGTGT;
            chiTietChungTuBanHang.MaDonViTinh = chiTietChungTuBanHangVm.MaDonViTinh;
           
    }
        public static void UpdatePhieuXuat_BanHang(this PhieuXuat_BanHang phieuXuat_BanHang, PhieuXuat_BanHangViewModel phieuXuat_BanHangVm)
        {
            phieuXuat_BanHang.MaPhieuXuat = phieuXuat_BanHangVm.MaPhieuXuat;
            phieuXuat_BanHang.MaKhachHang = phieuXuat_BanHangVm.MaKhachHang;
            phieuXuat_BanHang.NguoiNhan = phieuXuat_BanHangVm.NguoiNhan;
            phieuXuat_BanHang.LyDoXuat = phieuXuat_BanHangVm.LyDoXuat;
            phieuXuat_BanHang.MaSoNhanVien = phieuXuat_BanHangVm.MaSoNhanVien;
            phieuXuat_BanHang.ChungTuGoc = phieuXuat_BanHangVm.ChungTuGoc;
            phieuXuat_BanHang.NgayHoachToan = phieuXuat_BanHangVm.NgayHoachToan;
            phieuXuat_BanHang.NgayChungTu = phieuXuat_BanHangVm.NgayChungTu;
            phieuXuat_BanHang.MaDieuKhoan = phieuXuat_BanHangVm.MaDieuKhoan;
            phieuXuat_BanHang.SoNgayDuocNo = phieuXuat_BanHangVm.SoNgayDuocNo;
            phieuXuat_BanHang.HanThanhToan = phieuXuat_BanHangVm.HanThanhToan;
            phieuXuat_BanHang.MaLoaiTien = phieuXuat_BanHangVm.MaLoaiTien;
            phieuXuat_BanHang.TyGia = phieuXuat_BanHangVm.TyGia;
            phieuXuat_BanHang.TongTienHang = phieuXuat_BanHangVm.TongTienHang;
            phieuXuat_BanHang.TienThueGTGT = phieuXuat_BanHangVm.TienThueGTGT;
            phieuXuat_BanHang.TienChietKhau = phieuXuat_BanHangVm.TienChietKhau;
            phieuXuat_BanHang.TongTienThanhToan = phieuXuat_BanHangVm.TongTienThanhToan;
            phieuXuat_BanHang.MaChungTuBanHang = phieuXuat_BanHangVm.MaChungTuBanHang;
            phieuXuat_BanHang.MaTraLaiHangBan = phieuXuat_BanHangVm.MaTraLaiHangBan;
          
    }
        public static void UpdateChiTietPhieuXuat_BanHang(this ChiTietPhieuXuat_BanHang chiTietPhieuXuat_BanHang, ChiTietPhieuXuat_BanHangViewModel chiTietPhieuXuat_BanHangVm)
        {
            chiTietPhieuXuat_BanHang.MaChiTietPhieuXuat = chiTietPhieuXuat_BanHangVm.MaChiTietPhieuXuat;
            chiTietPhieuXuat_BanHang.MaPhieuXuat = chiTietPhieuXuat_BanHangVm.MaPhieuXuat;
            chiTietPhieuXuat_BanHang.MaHang = chiTietPhieuXuat_BanHangVm.MaHang;
            chiTietPhieuXuat_BanHang.TKCongNo_ChiPhi = chiTietPhieuXuat_BanHangVm.TKCongNo_ChiPhi;
            chiTietPhieuXuat_BanHang.TKDoanhThu = chiTietPhieuXuat_BanHangVm.TKDoanhThu;
            chiTietPhieuXuat_BanHang.SoLuong = chiTietPhieuXuat_BanHangVm.SoLuong;
            chiTietPhieuXuat_BanHang.ThanhTien = chiTietPhieuXuat_BanHangVm.ThanhTien;
            chiTietPhieuXuat_BanHang.TienChietKhau = chiTietPhieuXuat_BanHangVm.TienChietKhau;
            chiTietPhieuXuat_BanHang.TienThueGTGT = chiTietPhieuXuat_BanHangVm.TienThueGTGT;
            chiTietPhieuXuat_BanHang.Kho = chiTietPhieuXuat_BanHangVm.Kho;
            chiTietPhieuXuat_BanHang.TKNo = chiTietPhieuXuat_BanHangVm.TKNo;
            chiTietPhieuXuat_BanHang.TKCo = chiTietPhieuXuat_BanHangVm.TKCo;
          
        }
        public static void UpdateHoaDon_BanHang(this HoaDon_BanHang hoaDon_BanHang, HoaDon_BanHangViewModel hoaDon_BanHangVm)
        {
            hoaDon_BanHang.MaHoaDon = hoaDon_BanHangVm.MaHoaDon;
            hoaDon_BanHang.MaKhachHang = hoaDon_BanHangVm.MaKhachHang;
            hoaDon_BanHang.TKNganHang = hoaDon_BanHangVm.TKNganHang;
            hoaDon_BanHang.NguoiMuaHang = hoaDon_BanHangVm.NguoiMuaHang;
            hoaDon_BanHang.HinhThucTT = hoaDon_BanHangVm.HinhThucTT;
            hoaDon_BanHang.MauSoHD = hoaDon_BanHangVm.MauSoHD;
            hoaDon_BanHang.KyHieuHD = hoaDon_BanHangVm.KyHieuHD;
            hoaDon_BanHang.NgayHoaDon = hoaDon_BanHangVm.NgayHoaDon;
            hoaDon_BanHang.MaDieuKhoan = hoaDon_BanHangVm.MaDieuKhoan;
            hoaDon_BanHang.SoNgayDuocNo = hoaDon_BanHangVm.SoNgayDuocNo;
            hoaDon_BanHang.HanThanhToan = hoaDon_BanHangVm.HanThanhToan;
            hoaDon_BanHang.TyGia = hoaDon_BanHangVm.TyGia;
            hoaDon_BanHang.TongTienHang = hoaDon_BanHangVm.TongTienHang;
            hoaDon_BanHang.TienThueGTGT = hoaDon_BanHangVm.TienThueGTGT;
            hoaDon_BanHang.TienChietKhau = hoaDon_BanHangVm.TienChietKhau;
            hoaDon_BanHang.TongTienThanhToan = hoaDon_BanHangVm.TongTienThanhToan;
            hoaDon_BanHang.MaLoaiTien = hoaDon_BanHangVm.MaLoaiTien;
            hoaDon_BanHang.MaChungTuBanHang = hoaDon_BanHangVm.MaChungTuBanHang;
            hoaDon_BanHang.MaSoNhanVien = hoaDon_BanHangVm.MaSoNhanVien;
        }
        public static void UpdateChiTietHoaDon_BanHang(this ChiTietHoaDon_BanHang chiTietHoaDon_BanHang, ChiTietHoaDon_BanHangViewModel chiTietHoaDon_BanHangVm)
        {
            chiTietHoaDon_BanHang.MaChiTietHoaDonBanHang = chiTietHoaDon_BanHangVm.MaChiTietHoaDonBanHang;
            chiTietHoaDon_BanHang.MaHoaDon = chiTietHoaDon_BanHangVm.MaHoaDon;
            chiTietHoaDon_BanHang.MaHang = chiTietHoaDon_BanHangVm.MaHang;
            chiTietHoaDon_BanHang.TKCongNo_ChiPhi = chiTietHoaDon_BanHangVm.TKCongNo_ChiPhi;
            chiTietHoaDon_BanHang.TKDoanhThu = chiTietHoaDon_BanHangVm.TKDoanhThu;
            chiTietHoaDon_BanHang.SoLuong = chiTietHoaDon_BanHangVm.SoLuong;
            chiTietHoaDon_BanHang.ThanhTien = chiTietHoaDon_BanHangVm.ThanhTien;
            chiTietHoaDon_BanHang.TienChietKhau = chiTietHoaDon_BanHangVm.TienChietKhau;
            chiTietHoaDon_BanHang.TienThueGTGT = chiTietHoaDon_BanHangVm.TienThueGTGT;
         
    }
        public static void UpdateGiamGiaHangBan(this GiamGiaHangBan giamGiaHangBan, GiamGiaHangBanViewModel giamGiaHangBanVm)
        {
            giamGiaHangBan.MaGiamGiaHangBan = giamGiaHangBanVm.MaGiamGiaHangBan;
            giamGiaHangBan.MaKhachHang = giamGiaHangBanVm.MaKhachHang;
            giamGiaHangBan.DienGiai = giamGiaHangBanVm.DienGiai;
            giamGiaHangBan.MaSoNhanVien = giamGiaHangBanVm.MaSoNhanVien;
            giamGiaHangBan.NgayHoachToan = giamGiaHangBanVm.NgayHoachToan;
            giamGiaHangBan.TongTienHang = giamGiaHangBanVm.TongTienHang;
            giamGiaHangBan.TienThueGTGT = giamGiaHangBanVm.TienThueGTGT;
            giamGiaHangBan.TienChietKhau = giamGiaHangBanVm.TienChietKhau;
            giamGiaHangBan.TongTienThanhToan = giamGiaHangBanVm.TongTienThanhToan;
            giamGiaHangBan.MaLoaiTien = giamGiaHangBanVm.MaLoaiTien;
            giamGiaHangBan.TyGia = giamGiaHangBanVm.TyGia;
            giamGiaHangBan.DaGhiSo = giamGiaHangBanVm.DaGhiSo;
        }
        public static void UpdateChiTietGiamGiaHangBan(this ChiTietGiamGiaHangBan chiTietGiamGiaHangBan, ChiTietGiamGiaHangBanViewModel ChiTietGiamGiaHangBanVm)
        {
            chiTietGiamGiaHangBan.MaChiTietGiamGiaHangBan = ChiTietGiamGiaHangBanVm.MaChiTietGiamGiaHangBan;
            chiTietGiamGiaHangBan.MaGiamGiaHangBan = ChiTietGiamGiaHangBanVm.MaGiamGiaHangBan;
            chiTietGiamGiaHangBan.MaHang = ChiTietGiamGiaHangBanVm.MaHang;
            chiTietGiamGiaHangBan.TKGiamGia = ChiTietGiamGiaHangBanVm.TKGiamGia;
            chiTietGiamGiaHangBan.TKTien = ChiTietGiamGiaHangBanVm.TKTien;
            chiTietGiamGiaHangBan.SoLuong = ChiTietGiamGiaHangBanVm.SoLuong;
            chiTietGiamGiaHangBan.ThanhTien = ChiTietGiamGiaHangBanVm.ThanhTien;
            chiTietGiamGiaHangBan.TienChietKhau = ChiTietGiamGiaHangBanVm.TienChietKhau;
            chiTietGiamGiaHangBan.TienThueGTGT = ChiTietGiamGiaHangBanVm.TienThueGTGT;
        }
        public static void UpdateChiTietTraLaiHangBan(this ChiTietTraLaiHangBan chiTietTraLaiHangBan, ChiTietTraLaiHangBanViewModel chiTietTraLaiHangBanVm)
        {
            chiTietTraLaiHangBan.MaTraLaiHangBan = chiTietTraLaiHangBanVm.MaTraLaiHangBan;
            chiTietTraLaiHangBan.MaChiTietTraLaiHangBan = chiTietTraLaiHangBanVm.MaChiTietTraLaiHangBan;
            chiTietTraLaiHangBan.MaHang = chiTietTraLaiHangBanVm.MaHang;
            chiTietTraLaiHangBan.TKTraLai = chiTietTraLaiHangBanVm.TKTraLai;
            chiTietTraLaiHangBan.TKTien = chiTietTraLaiHangBanVm.TKTien;
            chiTietTraLaiHangBan.SoLuong = chiTietTraLaiHangBanVm.SoLuong;
            chiTietTraLaiHangBan.ThanhTien = chiTietTraLaiHangBanVm.ThanhTien;
            chiTietTraLaiHangBan.TienChietKhau = chiTietTraLaiHangBanVm.TienChietKhau;
            chiTietTraLaiHangBan.MucThuChi = chiTietTraLaiHangBanVm.MucThuChi;
            
    }
        public static void UpdateTraLaiHangBan(this TraLaiHangBan traLaiHangBan, TraLaiHangBanViewModel traLaiHangBanVm)
        {
            traLaiHangBan.MaTraLaiHangBan = traLaiHangBanVm.MaTraLaiHangBan;
            traLaiHangBan.MaKhachHang = traLaiHangBanVm.MaKhachHang;
            traLaiHangBan.DienGiai = traLaiHangBanVm.DienGiai;
            traLaiHangBan.MaSoNhanVien = traLaiHangBanVm.MaSoNhanVien;
            traLaiHangBan.MaLoaiTien = traLaiHangBanVm.MaLoaiTien;
            traLaiHangBan.NgayHoachToan = traLaiHangBanVm.NgayHoachToan;
            traLaiHangBan.NgayChungTu = traLaiHangBanVm.NgayChungTu;
            traLaiHangBan.TyGia = traLaiHangBanVm.TyGia;
            traLaiHangBan.TongTienHang = traLaiHangBanVm.TongTienHang;
            traLaiHangBan.TienThueGTGT = traLaiHangBanVm.TienThueGTGT;
            traLaiHangBan.TienChietKhau = traLaiHangBanVm.TienChietKhau;
            traLaiHangBan.TongTienThanhToan = traLaiHangBanVm.TongTienThanhToan;
            traLaiHangBan.DaGhiSo = traLaiHangBanVm.DaGhiSo;
           
    }
        public static void UpdateNhomKH_NCC1(this NhomKH_NCC1 nhomKH_NCC1, NhomKH_NCC1ViewModel nhomKH_NCC1Vm)
        {
            nhomKH_NCC1.NhomKH_NCC = nhomKH_NCC1Vm.NhomKH_NCC;
            nhomKH_NCC1.TenNhomKH_NCC = nhomKH_NCC1Vm.TenNhomKH_NCC;
            nhomKH_NCC1.DienGiai = nhomKH_NCC1Vm.DienGiai;
    }
         public static void UpdatePhieuNhapKho(this PhieuNhapKho phieuNhapKho, PhieuNhapKhoViewModel phieuNhapKhoVm)
        {
            phieuNhapKho.MaPhieuNhapKho = phieuNhapKhoVm.MaPhieuNhapKho;
            phieuNhapKho.MaKhachHang = phieuNhapKhoVm.MaKhachHang;
            phieuNhapKho.NguoiGiaoHang = phieuNhapKhoVm.NguoiGiaoHang;
            phieuNhapKho.DienGiai = phieuNhapKhoVm.DienGiai;
            phieuNhapKho.ChungTuGoc = phieuNhapKhoVm.ChungTuGoc;
            phieuNhapKho.NgayHoachToan = phieuNhapKhoVm.NgayHoachToan;
            phieuNhapKho.NgayChungTu = phieuNhapKhoVm.NgayChungTu;
            phieuNhapKho.ChungTuThamChieu = phieuNhapKhoVm.ChungTuThamChieu;
            phieuNhapKho.MaSoNhanVien = phieuNhapKhoVm.MaSoNhanVien;
         
    }
        public static void UpdateChiTietPhieuNhapKho(this ChiTietPhieuNhapKho chiTietPhieuNhapKho, ChiTietPhieuNhapKhoViewModel chiTietPhieuNhapKhoVm)
        {
            chiTietPhieuNhapKho.MaChiTietPhieuNhapKho = chiTietPhieuNhapKhoVm.MaChiTietPhieuNhapKho;
            chiTietPhieuNhapKho.MaPhieuNhapKho = chiTietPhieuNhapKhoVm.MaPhieuNhapKho;
            chiTietPhieuNhapKho.MaHang = chiTietPhieuNhapKhoVm.MaHang;
            chiTietPhieuNhapKho.Kho = chiTietPhieuNhapKhoVm.Kho;
            chiTietPhieuNhapKho.TKNo = chiTietPhieuNhapKhoVm.TKNo;
            chiTietPhieuNhapKho.TKCo = chiTietPhieuNhapKhoVm.TKCo;
            chiTietPhieuNhapKho.ThanhTien = chiTietPhieuNhapKhoVm.ThanhTien;
            chiTietPhieuNhapKho.MaLenhSanXuat = chiTietPhieuNhapKhoVm.MaLenhSanXuat;
            chiTietPhieuNhapKho.MaLenhSanXuat = chiTietPhieuNhapKhoVm.MaLenhSanXuat;
           
    }
        public static void UpdateLenhSanXuat(this LenhSanXuat lenhSanXuat, LenhSanXuatViewModel lenhSanXuatVm)
        {
            lenhSanXuat.MaLenhSanXuat = lenhSanXuatVm.MaLenhSanXuat;
            lenhSanXuat.DienGiai = lenhSanXuatVm.DienGiai;
            lenhSanXuat.Ngay = lenhSanXuatVm.Ngay;
            lenhSanXuat.MaTinhTrang = lenhSanXuatVm.MaTinhTrang;
            lenhSanXuat.DaGhiSo = lenhSanXuatVm.DaGhiSo;
          

    }
        public static void UpdateLenhSanXuat_ThanhPham(this LenhSanXuat_ThanhPham lenhSanXuat, LenhSanXuat_ThanhPhamViewModel lenhSanXuatVm)
        {
            lenhSanXuat.MaLenhSanXuat_ThanhPham = lenhSanXuatVm.MaLenhSanXuat_ThanhPham;
            lenhSanXuat.MaLenhSanXuat = lenhSanXuatVm.MaLenhSanXuat;
            lenhSanXuat.SoLuong = lenhSanXuatVm.SoLuong;
            lenhSanXuat.MaThanhPham = lenhSanXuatVm.MaThanhPham;
            


    }
        public static void UpdateLenhSanXuat_NVL(this LenhSanXuat_NVL lenhSanXuat, LenhSanXuat_NVLViewModel lenhSanXuatVm)
        {
            lenhSanXuat.MaLenhSanXuat_NVL = lenhSanXuatVm.MaLenhSanXuat_NVL;
            lenhSanXuat.MaLenhSanXuat = lenhSanXuatVm.MaLenhSanXuat;
            lenhSanXuat.MaHang = lenhSanXuatVm.MaHang;
            lenhSanXuat.SoLuong_1DonVi = lenhSanXuatVm.SoLuong_1DonVi;
            lenhSanXuat.SoLuong = lenhSanXuatVm.SoLuong;
            lenhSanXuat.DoiTuongDHCP = lenhSanXuatVm.DoiTuongDHCP;
            lenhSanXuat.KhoanMucCP = lenhSanXuatVm.KhoanMucCP;
            lenhSanXuat.MaThongKe = lenhSanXuatVm.MaThongKe;

    }
        public static void UpdateChiTietLapRapThaoDo(this ChiTietLapRapThaoDo chiTietLapRapThaoDo, ChiTietLapRapThaoDoViewModel chiTietLapRapThaoDoVm)
        {
            chiTietLapRapThaoDo.MaChiTietLapRapThaoDo = chiTietLapRapThaoDoVm.MaChiTietLapRapThaoDo;
            chiTietLapRapThaoDo.MaLapRapThaoDo = chiTietLapRapThaoDoVm.MaLapRapThaoDo;
            chiTietLapRapThaoDo.MaHang = chiTietLapRapThaoDoVm.MaHang;
            chiTietLapRapThaoDo.SoLuong = chiTietLapRapThaoDoVm.SoLuong;
            chiTietLapRapThaoDo.ThanhTien = chiTietLapRapThaoDoVm.ThanhTien;
           
    }
        public static void UpdateLapRapThaoDo(this LapRapThaoDo lapRapThaoDo, LapRapThaoDoViewModel lapRapThaoDoVm)
        {
            lapRapThaoDo.MaLapRapThaoDo = lapRapThaoDoVm.MaLapRapThaoDo;
            lapRapThaoDo.MaHang = lapRapThaoDoVm.MaHang;
            lapRapThaoDo.MaThanhPham = lapRapThaoDoVm.MaThanhPham;
            lapRapThaoDo.SoLuong = lapRapThaoDoVm.SoLuong;
            lapRapThaoDo.Ngay = lapRapThaoDoVm.Ngay;
            lapRapThaoDo.DienGiai = lapRapThaoDoVm.DienGiai;
            lapRapThaoDo.ThanhTien = lapRapThaoDoVm.ThanhTien;
            lapRapThaoDo.DonGia = lapRapThaoDoVm.DonGia;
    }
        public static void UpdateLoaiTaiSanCoDinh(this LoaiTaiSanCoDinh loaiTaiSanCoDinh, LoaiTaiSanCoDinhViewModel loaiTaiSanCoDinhVm)
        {
            loaiTaiSanCoDinh.MaLoaiTSCD = loaiTaiSanCoDinhVm.MaLoaiTSCD;
            loaiTaiSanCoDinh.TenLoaiTSCD = loaiTaiSanCoDinhVm.TenLoaiTSCD;
            loaiTaiSanCoDinh.SoTaiKhoanCo = loaiTaiSanCoDinhVm.SoTaiKhoanCo;
            loaiTaiSanCoDinh.SoTaiKhoanNo = loaiTaiSanCoDinhVm.SoTaiKhoanNo;
            loaiTaiSanCoDinh.Thuoc = loaiTaiSanCoDinhVm.Thuoc;
          
    }
        public static void UpdateLoaiCongCuDungCu(this LoaiCongCuDungCu loaiCongCuDungCu, LoaiCongCuDungCuViewModel loaiCongCuDungCuVM)
        {
            loaiCongCuDungCu.MaLoaiCCDC = loaiCongCuDungCuVM.MaLoaiCCDC;
            loaiCongCuDungCu.TenLoaiCCDC = loaiCongCuDungCuVM.TenLoaiCCDC;
            loaiCongCuDungCu.DienGiai = loaiCongCuDungCuVM.DienGiai;
            loaiCongCuDungCu.SoTaiKhoanCo = loaiCongCuDungCuVM.SoTaiKhoanCo;


        }
        public static void UpdateCoCauToChuc(this CoCauToChuc coCauToChuc, CoCauToChucViewModel coCauToChucVM)
        {
            coCauToChuc.MaDonVi = coCauToChucVM.MaDonVi;
            coCauToChuc.TenDonVi = coCauToChucVM.TenDonVi;
            coCauToChuc.DiaChi = coCauToChucVM.DiaChi;
            coCauToChuc.CapToChuc = coCauToChucVM.CapToChuc;


        }
        public static void UpdateTaiKhoanKetChuyen(this TaiKhoanKetChuyen taiKhoanKetChuyen, TaiKhoanKetChuyenViewModel taiKhoanKetChuyenVM)
        {
            taiKhoanKetChuyen.Id = taiKhoanKetChuyenVM.Id;
            taiKhoanKetChuyen.ThuTuKetChuyen = taiKhoanKetChuyenVM.ThuTuKetChuyen;
            taiKhoanKetChuyen.MaKetChuyen = taiKhoanKetChuyenVM.MaKetChuyen;
            taiKhoanKetChuyen.KetChuyenTu = taiKhoanKetChuyenVM.KetChuyenTu;
            taiKhoanKetChuyen.KetChuyenDen = taiKhoanKetChuyenVM.KetChuyenDen;
            taiKhoanKetChuyen.BenKetChuyen = taiKhoanKetChuyenVM.BenKetChuyen;
            taiKhoanKetChuyen.DienGiai = taiKhoanKetChuyenVM.DienGiai;
            taiKhoanKetChuyen.LoaiKetChuyen = taiKhoanKetChuyenVM.LoaiKetChuyen;
            taiKhoanKetChuyen.NgungTheoDoi = taiKhoanKetChuyenVM.NgungTheoDoi;
           


        }
         public static void UpdateHeThongTaiKhoan(this HeThongTaiKhoan heThongTaiKhoan, HeThongTaiKhoanViewModel heThongTaiKhoanVM)
        {
            heThongTaiKhoan.Id = heThongTaiKhoanVM.Id;
            heThongTaiKhoan.SoTaiKhoan = heThongTaiKhoanVM.SoTaiKhoan;
            heThongTaiKhoan.TenTaiKhoan = heThongTaiKhoanVM.TenTaiKhoan;
            heThongTaiKhoan.TinhChat = heThongTaiKhoanVM.TinhChat;
            heThongTaiKhoan.TenTiengAnh = heThongTaiKhoanVM.TenTiengAnh;
            heThongTaiKhoan.DienGiai = heThongTaiKhoanVM.DienGiai;
            heThongTaiKhoan.NgungTheoDoi = heThongTaiKhoanVM.NgungTheoDoi;
          
           


        }
         public static void UpdateDinhKhoanTuDong(this DinhKhoanTuDong dinhKhoanTuDong, DinhKhoanTuDongViewModel khoanTuDongVM)
        {
            dinhKhoanTuDong.Id = khoanTuDongVM.Id;
            dinhKhoanTuDong.LoaiChungTu = khoanTuDongVM.LoaiChungTu;
            dinhKhoanTuDong.TenDinhKhoan = khoanTuDongVM.TenDinhKhoan;
            dinhKhoanTuDong.SoTaiKhoanCo = khoanTuDongVM.SoTaiKhoanCo;
            dinhKhoanTuDong.SoTaiKhoanNo = khoanTuDongVM.SoTaiKhoanNo;
         }
         public static void UpdateDonViTinh(this DonViTinh donViTinh, DonViTinhViewModel donViTinhVm)
        {
            donViTinh.MaDonViTinh = donViTinhVm.MaDonViTinh;
            donViTinh.TenDonViTinh = donViTinhVm.TenDonViTinh;
        }
         public static void UpdateHangHoa_DonViTinh(this HangHoa_DonViTinh hanghoa_DonViTinh, HangHoa_DonViTinhViewModel hanghoa_DonViTinhVm)
        {
            hanghoa_DonViTinh.MaDonViTinh = hanghoa_DonViTinhVm.MaDonViTinh;
            hanghoa_DonViTinh.MaHang = hanghoa_DonViTinhVm.MaHang;
            hanghoa_DonViTinh.DonGia = hanghoa_DonViTinhVm.DonGia;
        }


    }
}
