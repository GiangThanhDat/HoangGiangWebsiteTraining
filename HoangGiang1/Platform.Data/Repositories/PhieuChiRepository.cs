using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IPhieuChiRepository : IRepository<PhieuChi>
    {
        IQueryable<getThongTinTongHopQuy> getPhieuChi(DateTime ngaydau, DateTime ngaycuoi);
        IEnumerable<xemchitietphieuchi> xemPhieuChi(string MaPC);


    }

    class PhieuChiRepository : RepositoryBase<PhieuChi>, IPhieuChiRepository
    {
        public PhieuChiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getThongTinTongHopQuy> getPhieuChi(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.phieuChis

                        join C in DbContext.nhaCungCaps
                        on A.MaNhaCungCap equals C.MaNhaCungCap
                        join D in DbContext.loaiChis
                        on A.MaLoaiChi equals D.MaLoaiChi
                        where (ngaydau <= A.NgayChungTu && A.NgayChungTu <= ngaycuoi)




                        select new getThongTinTongHopQuy()
                        {
                            NgayHoachToan = A.NgayHoachToan,
                            NgayChungTu = A.NgayChungTu,
                            ChungTuGoc = A.ChungTuGoc,
                            DienGiai = A.DienGiai,
                            TongTienThanhToan = A.TongTienThanhToan,
                            TenKhachHang = C.TenNhaCungCap,
                            LyDoNop = A.LyDoChi,
                            TenLoaiThu = D.TenLoaiChi,
                            DaGhiSo = A.DaGhiSo,
                            MaPhieuThu = A.MaPhieuChi



                        };
            return query;

        }

        

        public IEnumerable<xemchitietphieuchi> xemPhieuChi(string MaPC)
        {
            var query = from A in DbContext.phieuChis

                        join C in DbContext.nhaCungCaps
                        on A.MaNhaCungCap equals C.MaNhaCungCap
                        join D in DbContext.loaiChis
                        on A.MaLoaiChi equals D.MaLoaiChi
                        join B in DbContext.loaiTiens
                        on A.MaLoaiTien equals B.MaLoaiTien
                        where A.MaPhieuChi.Equals(MaPC)
                        select new xemchitietphieuchi()
                        {
                            TenNhaCungCap=C.TenNhaCungCap,
                            MaNhaCungCap=C.MaNhaCungCap,
                            DiaChi=C.DiaChi,
                            TenLoaiChi=D.TenLoaiChi,
                            LyDoChi=A.LyDoChi,
                            ChungTuGoc=A.ChungTuGoc,
                            NgayHoachToan=A.NgayHoachToan,
                            NgayChungTu=A.NgayChungTu,
                            MaPhieuChi=A.MaPhieuChi,
                            VietTat=B.VietTat,
                            TyGia_VND = B.TyGia_VND,
                            NguoiNop=A.NguoiNop
                        };
            return query;
        }
    }
}
