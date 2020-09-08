using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IPhieuNhapKhoRepository : IRepository<PhieuNhapKho>
    {
        IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi);
        IEnumerable<lichsutongquan> getlichsu();

    }

    class PhieuNhapKhoRepository : RepositoryBase<PhieuNhapKho>, IPhieuNhapKhoRepository
    {
        public PhieuNhapKhoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       
        public IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.phieuNhapKhos
                        join B in DbContext.khachHangs
                         on A.MaKhachHang equals B.MaKhachHang

                        where (ngaydau <= A.NgayChungTu && A.NgayChungTu <= ngaycuoi)
                        select new getphieunhapxuatkho()
                        {
                            NgayChungTu = A.NgayChungTu,
                            NgayHoachToan = A.NgayHoachToan,
                            MaPhieuXuat = A.MaPhieuNhapKho,
                            TongTienThanhToan = A.TongTienThanhToan,
                            NguoiNhan = A.NguoiGiaoHang,
                            TenKhachHang = B.TenKhachHang,
                            LyDoXuat = A.LyDoNhap,
                            DienGiai=A.DienGiai,
                            DaGhiSo=A.DaGhiSo,
                            ChungTuGoc=A.ChungTuGoc





                        };
            return query;
        }

        public IEnumerable<lichsutongquan> getlichsu()
        {
            var query = from a in DbContext.phieuNhapKhos
                        join b in DbContext.NhanVien
                        on a.MaSoNhanVien equals b.MaSoNhanVien
                        join c in DbContext.chucVus
                        on b.MaChucVu equals c.MaChucVu
                        join d in DbContext.CoSo
                        on b.MaCoSo equals d.MaCoSo
                        select new lichsutongquan()
                        {
                            Ma = a.MaPhieuNhapKho,
                            MaSoNhanVien = b.MaSoNhanVien,
                            HoVaTen = b.HoVaTen,
                            Ngay = a.NgayChungTu,
                            MaChucVu = c.MaChucVu,
                            TenChucVu = c.TenChucVu,
                            TenCoSo = d.TenCoSo,
                            MaCoSo = d.MaCoSo

                        };
            return query;
        }
    }
}
