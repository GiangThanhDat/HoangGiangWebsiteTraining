using Microsoft.AspNet.Identity.EntityFramework;
using Platform.Model;
using Platform.Model.Models;
using System.Data.Entity;


namespace Platform.Data
{
    public class QLTHDbContext : IdentityDbContext<ApplicationUser>
    {
       public QLTHDbContext() : base("PlatformTH")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }
        public DbSet<ThongTinCaNhan> ThongTinCaNhans { set; get; }

        public DbSet<NhanVien> NhanVien { set; get; }
        public DbSet<LichSuLamViec> lichSuLamViecs { set; get; }
        public DbSet<NgonNgu> ngonNgus { set; get; }
        public DbSet<ThongTinTuyenDung> thongTinTuyenDungs { set; get; }
        public DbSet<HoanThanhCongViec> hoanThanhCongViecs { set; get; }
        public DbSet<The> thes { set; get; }
        public DbSet<QuanLyNgayNghi> quanLyNgayNghis { set; get; }
        public DbSet<QuanLyCongTac> quanLyCongTacs { set; get; }
        public DbSet<QuanLyQuaGio> quanLyQuaGios { set; get; }
        public DbSet<QuanLyVangMat> QuanLyVangMat { set; get; }
        public DbSet<ThongBao> ThongBao { set; get; }
        public DbSet<QuetThe> QuetThe { set; get; }
        public DbSet<QuetTheTheoNgay> QuetTheTheoNgay { set; get; }
        public DbSet<CoSo> CoSo { set; get; }
        public DbSet<TaiSan> TaiSan { set; get; }
        public DbSet<QuaTrinhDaoTao> quaTrinhDaoTaos { set; get; }
        public DbSet<ChucVu> chucVus { set; get; }
        public DbSet<QuanLyTaiSan> quanLyTaiSans { set; get; }
        public DbSet<KhachHang> khachHangs { set; get; }
        public DbSet<NhaCungCap> nhaCungCaps { set; get; }
        public DbSet<NhomKH_NCC1> nhomKH_NCCs { set; get; }
        public DbSet<TinhTrang> tinhTrangs { set; get; }
        public DbSet<TinhChatHangHoa>  tinhChatHangHoas { set; get; }
        public DbSet<PhieuThu>  phieuThus { set; get; }
        public DbSet<PhieuChi>  phieuChis { set; get; }
        public DbSet<NhomHangHoa>  nhomHangHoas { set; get; }
        public DbSet<LoaiThu> loaiThus { set; get; }
        public DbSet<LoaiChi>  loaiChis { set; get; }
        public DbSet<HangHoa>   hangHoas { set; get; }
        public DbSet<ChiTietThu> chiTietThus { set; get; }
        public DbSet<ChiTietPhieuChi> chiTietPhieuChis { set; get; }
        public DbSet<TaiKhoanNganHang> taiKhoanNganHangs { set; get; }
        public DbSet<KhachHang_TaiKhoan> khachHang_TaiKhoans { set; get; }
        public DbSet<NhaCungCap_TaiKhoan> nhaCungCap_TaiKhoans { set; get; }
        public DbSet<LoaiTien> loaiTiens { set; get; }
        public DbSet<TaiKhoanCo>  taiKhoanCos { set; get; }
        public DbSet<TaiKhoanNo> taiKhoanNos { set; get; }
        public DbSet<ChiTietDonMuaHang> chiTietDonMuaHangs { set; get; }
        public DbSet<DonMuaHang> donMuaHangs { set; get; }
        public DbSet<DieuKhoanTT> dieuKhoanTTs { set; get; }
        public DbSet<HopDongMua> hopDongMuas { set; get; }
        public DbSet<ChiTietHopDongMua> chiTietHopDongMuas { set; get; }
        public DbSet<ChungTuMuaHang> chungTuMuaHangs { set; get; }
        public DbSet<ChiTietChungTuMuaHang> chiTietChungTuMuaHangs { set; get; }
        public DbSet<TraLaiHangMua> traLaiHangMuas { set; get; }
        public DbSet<ChiTietTraLaiHangMua> chiTietTraLaiHangMuas { set; get; }
        public DbSet<GiamGiaHangMua> giamGiaHangMuas { set; get; }
        public DbSet<ChiTietGiamGiaHangMua> chiTietGiamGiaHangMuas { set; get; }
        public DbSet<DichVu> dichVus { set; get; }
        public DbSet<ChungTuMuaDichVu> chungTuMuaDichVus { set; get; }
        public DbSet<ChiTietChungTuMuaDichVu> chiTietChungTuMuaDichVus { set; get; }
        public DbSet<BaoGia> baoGias { set; get; }
        public DbSet<ChiTietBaoGia> chiTietBaoGias { set; get; }
        public DbSet<DonDatHang> donDatHangs { set; get; }
        public DbSet<ChiTietDonDatHang> chiTietDonDatHangs { set; get; }
        public DbSet<ChungTuBanHang> chungTuBanHangs { set; get; }
        public DbSet<ChiTietChungTuBanHang>  chiTietChungTuBanHangs { set; get; }
        public DbSet<PhieuXuat_BanHang>  phieuXuat_BanHangs { set; get; }
        public DbSet<ChiTietPhieuXuat_BanHang> chiTietPhieuXuat_BanHangs { set; get; }
        public DbSet<HoaDon_BanHang> hoaDon_BanHangs { set; get; }
        public DbSet<ChiTietHoaDon_BanHang> chiTietHoaDon_BanHangs { set; get; }
        public DbSet<GiamGiaHangBan> giamGiaHangBans { set; get; }
        public DbSet<ChiTietGiamGiaHangBan> chiTietGiamGiaHangBans { set; get; }
        public DbSet<TraLaiHangBan> traLaiHangBans { set; get; }
        public DbSet<ChiTietTraLaiHangBan> chiTietTraLaiHangBans { set; get; }
        public DbSet<PhieuNhapKho> phieuNhapKhos { set; get; }
        public DbSet<ChiTietPhieuNhapKho> chiTietPhieuNhapKhos { set; get; }
        public DbSet<LenhSanXuat> lenhSanXuats { set; get; }
        public DbSet<ThanhPham>  thanhPhams { set; get; }
        public DbSet<LenhSanXuat_NVL>  lenhSanXuat_NVLs { set; get; }
        public DbSet<LenhSanXuat_ThanhPham>  lenhSanXuat_ThanhPhams { set; get; }
        public DbSet<LapRapThaoDo>  lapRapThaoDos { set; get; }
        public DbSet<ChiTietLapRapThaoDo>  chiTietLapRapThaoDos { set; get; }
        public DbSet<LoaiTaiSanCoDinh>  loaiTaiSanCoDinhs { set; get; }
        public DbSet<LoaiCongCuDungCu>  loaiCongCuDungCus { set; get; }
        public DbSet<CoCauToChuc>  CoCauToChucs { set; get; }
        public DbSet<HeThongTaiKhoan>  heThongTaiKhoans { set; get; }
        public DbSet<TaiKhoanKetChuyen>  taiKhoanKetChuyens { set; get; }
        public DbSet<DinhKhoanTuDong>  dinhKhoanTuDongs { set; get; }
        public DbSet<DonViTinh>  donViTinhs { set; get; }
        public DbSet<HangHoa_DonViTinh>  hangHoa_DonViTinhs { set; get; }
       


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }
        public static QLTHDbContext Create()
        {
            return new QLTHDbContext();
        }
    }
}
