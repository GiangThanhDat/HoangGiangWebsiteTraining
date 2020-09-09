using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IPhieuThuRepository : IRepository<PhieuThu>
    {
        IQueryable<getThongTinTongHopQuy> getPhieuThu(DateTime ngaydau, DateTime ngaycuoi);
        IQueryable<getchitietphieuthu> getchitietphieuthu(string maPT);


    }

    class PhieuThuRepository : RepositoryBase<PhieuThu>, IPhieuThuRepository
    {
        public PhieuThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IQueryable<getchitietphieuthu> getchitietphieuthu(string maPT)
        {
            var query = from A in DbContext.phieuThus
                        join B in DbContext.chiTietThus
                      on A.MaPhieuThu equals B.MaPhieuThu
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang
                        where A.MaPhieuThu.Equals(maPT)
                        select new getchitietphieuthu()
                        {

                            MaHang = B.MaHang,
                            SoLuong = B.SoLuong,
                            SoTien = B.SoTien,
                            DienGiai = B.DienGiai,
                            SoTaiKhoanCo = B.SoTaiKhoanCo,
                            SoTaiKhoanNo = B.SoTaiKhoanNo,
                            MaKhachHang = B.MaKhachHang,
                            TenKhachHang = B.TenKhachHang,
                            TaiKhoanNganHang = B.TaiKhoanNganHang,
                            MucThuChi = B.MucThuChi,
                            DonVi = B.DonVi,
                            CongTrinh = B.CongTrinh,
                            HopDongBan = B.HopDongBan,
                            MaThongKe = B.MaThongKe,

                            TenHang = C.TenHang,
                            MaNhomHH = C.MaNhomHH,
                            MaTinhChat = C.MaTinhChat,
                            DonViTinh = C.DonViTinh,
                            BaoHanh = C.BaoHanh,
                            NguonGoc = C.NguonGoc,
                            MoTa = C.MoTa,
                            GiaNhap = C.GiaNhap,
                            GiaBan = C.GiaBan,
                            GiaKhuyenMai = C.GiaKhuyenMai,
                            VAT = C.VAT,
                            ChietKhau = C.ChietKhau,
                            HanSuDung = C.HanSuDung

                        };
            return query;
        }
        public IQueryable<getThongTinTongHopQuy> getPhieuThu(DateTime ngaydau, DateTime ngaycuoi)
        {


            var query = from A in DbContext.phieuThus


                        join C in DbContext.khachHangs
                         on A.MaKhachHang equals C.MaKhachHang
                        join D in DbContext.loaiThus
                        on A.MaLoaiThu equals D.MaLoaiThu
                        join R in DbContext.tinhTrangs
                        on A.MaTinhTrang equals R.MaTinhTrang
                        join Y in DbContext.loaiTiens
                        on A.MaLoaiTien equals Y.MaLoaiTien
                        join G in DbContext.NhanVien
                        on A.MaSoNhanVien equals G.MaSoNhanVien

                        where (ngaydau <= A.NgayChungTu && A.NgayChungTu <= ngaycuoi)




                        select new getThongTinTongHopQuy()
                        {
                            NgayHoachToan = A.NgayHoachToan,
                            NgayChungTu = A.NgayChungTu,
                            ChungTuGoc = A.ChungTuGoc,
                            DienGiai = A.DienGiai,
                            TongTienThanhToan = A.TongTienThanhToan,
                            TenKhachHang = C.TenKhachHang,
                            LyDoNop = A.LyDoNop,
                            TenLoaiThu = D.TenLoaiThu,
                            DaGhiSo = A.DaGhiSo,
                            MaPhieuThu = A.MaPhieuThu,
                            NguoiNop = A.NguoiNop,
                            TenTinhTrang = R.TenTinhTrang,
                            DiaChi = C.DiaChi,
                            TenLoaiTien = Y.TenLoaiTien,
                            TyGia = A.TyGia,
                            HoVaTen=G.HoVaTen,
                            VietTat=Y.VietTat







                        };
            return query;


        }




    }
}
