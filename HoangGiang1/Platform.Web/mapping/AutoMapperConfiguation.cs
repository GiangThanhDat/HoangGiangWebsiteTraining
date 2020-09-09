using AutoMapper;
using Platform.Model;
using Platform.Model.Models;
using Platform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.mapping
{
    public class AutoMapperConfiguation
    {
        public static void Configure()
        {
          
            Mapper.CreateMap<Loi, LoiViewModel>();


			Mapper.CreateMap<ThongBao, ThongBaoViewModel>();

            Mapper.CreateMap<ApplicationGroup, ApplicationGroupViewModel>();
            Mapper.CreateMap<ApplicationRole, ApplicationRoleViewModel>();
            Mapper.CreateMap<ApplicationUser, ApplicationUserViewModel>();
            Mapper.CreateMap<ThongTinCaNhan, ThongTinCaNhanViewModel>();

            Mapper.CreateMap<NgonNgu, NgonNguViewModel>();
            Mapper.CreateMap<NhanVien, NhanVienViewModel>();
            Mapper.CreateMap<QuanLyCongTac, QuanLyCongTacViewModel>();
            Mapper.CreateMap<QuanLyNgayNghi, QuanLyNgayNghiViewModel>();
            Mapper.CreateMap<QuanLyQuaGio, QuanLyQuaGioViewModel>();
            Mapper.CreateMap<QuanLyVangMat, QuanLyVangMatViewModel>();
            Mapper.CreateMap<QuaTrinhDaoTao, QuaTrinhDaoTaoViewModel>();
            Mapper.CreateMap<The, TheViewModel>();
            Mapper.CreateMap<ThongTinTuyenDung, ThongTinTuyenDungViewModel>();
            Mapper.CreateMap<HoanThanhCongViec, HoanThanhCongViecViewModel>();
            Mapper.CreateMap<LichSuLamViec, LichSuLamViecViewModel>();
            Mapper.CreateMap<QuetThe, QuetTheViewModel>();
            Mapper.CreateMap<QuetTheTheoNgay, QuetTheTheoNgayViewModel>();
            Mapper.CreateMap<TaiSan, TaiSanViewModel>();
            Mapper.CreateMap<QuanLyTaiSan, QuanLyTaiSanViewModel>();
            Mapper.CreateMap<ChucVu, ChucVuViewModel>();
            Mapper.CreateMap<HangHoa, HangHoaViewModel>();
            Mapper.CreateMap<PhieuThu, PhieuThuViewModel>();
            Mapper.CreateMap<TaiKhoanNganHang, TaiKhoanNganHang>();
            Mapper.CreateMap<KhachHang_TaiKhoan, KhachHang_TaiKhoanViewModel>();
            Mapper.CreateMap<NhaCungCap_TaiKhoan, NhaCungCap_TaiKhoanViewModel>();
            Mapper.CreateMap<LoaiTien, LoaiTienViewModel>();
            Mapper.CreateMap<ChiTietThu, ChiTietThuViewModel>();
            Mapper.CreateMap<DonMuaHang, DonMuaHangViewModel>();
            Mapper.CreateMap<ChiTietDonMuaHang, ChiTietDonMuaHangViewModel>();
            Mapper.CreateMap<DieuKhoanTT, DieuKhoanTTViewModel>();
            Mapper.CreateMap<HopDongMua, HopDongMuaViewModel>();
            Mapper.CreateMap<ChiTietHopDongMua, ChiTietHopDongMuaViewModel>();
            Mapper.CreateMap<ChungTuMuaHang, ChungTuMuaHangViewModel>();
            Mapper.CreateMap<ChiTietChungTuMuaHang, ChiTietChungTuMuaHangViewModel>();
            Mapper.CreateMap<TraLaiHangMua, TraLaiHangMuaViewModel>();
            Mapper.CreateMap<ChiTietTraLaiHangMua, ChiTietTraLaiHangMuaViewModel>();
            Mapper.CreateMap<GiamGiaHangMua, GiamGiaHangMuaViewModel>();
            Mapper.CreateMap<ChiTietGiamGiaHangMua, ChiTietGiamGiaHangMuaViewModel>();
            Mapper.CreateMap<DichVu, DichVuViewModel>();
            Mapper.CreateMap<ChungTuMuaDichVu, ChungTuMuaDichVuViewModel>();
            Mapper.CreateMap<ChiTietChungTuMuaDichVu, ChiTietChungTuMuaDichVuViewModel>();
            Mapper.CreateMap<BaoGia, BaoGiaViewModel>();
            Mapper.CreateMap<ChiTietBaoGia, ChiTietBaoGiaViewModel>();
            Mapper.CreateMap<DonDatHang, DonDatHangViewModel>();
            Mapper.CreateMap<ChiTietDonDatHang, ChiTietDonDatHangViewModel>();
            Mapper.CreateMap<ChungTuBanHang, ChungTuBanHangViewModel>();
            Mapper.CreateMap<ChiTietChungTuBanHang, ChiTietChungTuBanHangViewModel>();
            Mapper.CreateMap<PhieuXuat_BanHang, PhieuXuat_BanHangViewModel>();
            Mapper.CreateMap<ChiTietPhieuXuat_BanHang, ChiTietPhieuXuat_BanHangViewModel>();
            Mapper.CreateMap<HoaDon_BanHang, HoaDon_BanHangViewModel>();
            Mapper.CreateMap<ChiTietHoaDon_BanHang, ChiTietHoaDon_BanHangViewModel>();
            Mapper.CreateMap<GiamGiaHangBan, GiamGiaHangBanViewModel>();
            Mapper.CreateMap<ChiTietGiamGiaHangBan, ChiTietGiamGiaHangBanViewModel>();
            Mapper.CreateMap<TraLaiHangBan, TraLaiHangBanViewModel>();
            Mapper.CreateMap<ChiTietTraLaiHangBan, ChiTietTraLaiHangBanViewModel>();
            Mapper.CreateMap<PhieuNhapKho, PhieuNhapKhoViewModel>();
            Mapper.CreateMap<ChiTietPhieuNhapKho, ChiTietPhieuNhapKhoViewModel>();
            Mapper.CreateMap<LenhSanXuat, LenhSanXuatViewModel>();
            Mapper.CreateMap<LenhSanXuat_NVL, LenhSanXuat_NVLViewModel>();
            Mapper.CreateMap<LenhSanXuat_ThanhPham, LenhSanXuat_ThanhPhamViewModel>();
            Mapper.CreateMap<LapRapThaoDo, LapRapThaoDoViewModel>();
            Mapper.CreateMap<ChiTietLapRapThaoDo, ChiTietLapRapThaoDoViewModel>();
            Mapper.CreateMap<TinhChatHangHoa, TinhChatHangHoaViewModel>();
            Mapper.CreateMap<NhomHangHoa, NhomHangHoaViewModel>();
            Mapper.CreateMap<LoaiTaiSanCoDinh, LoaiTaiSanCoDinhViewModel>();
            Mapper.CreateMap<LoaiCongCuDungCu, LoaiCongCuDungCuViewModel>();
            Mapper.CreateMap<CoCauToChuc, CoCauToChucViewModel>();
            Mapper.CreateMap<TaiKhoanKetChuyen, TaiKhoanKetChuyenViewModel>();
            Mapper.CreateMap<HeThongTaiKhoan, HeThongTaiKhoanViewModel>();
            Mapper.CreateMap<DinhKhoanTuDong, DinhKhoanTuDongViewModel>();
            Mapper.CreateMap<DonViTinh, DonViTinhViewModel>();
            Mapper.CreateMap<HangHoa_DonViTinh, HangHoa_DonViTinhViewModel>();
            Mapper.CreateMap<NhanVienVangMat,NhanVienVangMat>();
            Mapper.CreateMap<CoSo,CoSoViewModel>();


        }
    }
}