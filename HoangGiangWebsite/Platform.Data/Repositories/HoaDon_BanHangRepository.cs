using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IHoaDon_BanHangRepository : IRepository<HoaDon_BanHang>
    {
        IQueryable<getxuathoadonbanhang> getxuathoadonbanhang(DateTime ngaydau, DateTime ngaycuoi);

    }

    class HoaDon_BanHangRepository : RepositoryBase<HoaDon_BanHang>, IHoaDon_BanHangRepository
    {
        public HoaDon_BanHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getxuathoadonbanhang> getxuathoadonbanhang(DateTime ngaydau, DateTime ngaycuoi)
        {

            var query = from A in DbContext.hoaDon_BanHangs
                        join B in DbContext.khachHangs
                        on A.MaKhachHang equals B.MaKhachHang

                        join D in DbContext.loaiTiens
                        on A.MaLoaiTien equals D.MaLoaiTien
                        join G in DbContext.NhanVien
                        on A.MaSoNhanVien equals G.MaSoNhanVien
                       
                        where ngaydau <= A.NgayHoaDon && A.NgayHoaDon <= ngaycuoi
                        select new getxuathoadonbanhang()
                        {

                            MaHoaDon = A.MaHoaDon,
                            MaKhachHang = A.MaKhachHang,
                            TenKhachHang = B.TenKhachHang,
                            PhanLoai=B.PhanLoai,
                            ChiNhanh=B.ChiNhanh,
                            TyGia = A.TyGia,
                            HanThanhToan = A.HanThanhToan,
                            TongTienHang = A.TongTienHang,
                            TienThueGTGT = A.TienThueGTGT,
                            TongTienThanhToan = A.TongTienThanhToan,
                            MaSoThue = B.MaSoThue,
                            DiaChi = B.DiaChi,
                            TienChietKhau = A.TienChietKhau,
                            NgayHoaDon=A.NgayHoaDon,
                            HoVaTen=G.HoVaTen,
                            KyHieuHD=A.KyHieuHD,
                            MauSoHD=A.MauSoHD,
                            HinhThucTT=A.HinhThucTT,
                            TKNganHang=A.TKNganHang,
                            NguoiMuaHang=A.NguoiMuaHang,
                            VietTat=D.VietTat







                        };


            return query;

        }
    }
}
