using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChungTuMuaDichVuRepository : IRepository<ChungTuMuaDichVu>
    {
        IEnumerable<getchungtumuadichvu> getchungtumuadichvu(DateTime ngaydau, DateTime ngaycuoi);

    }

    class ChungTuMuaDichVuRepository : RepositoryBase<ChungTuMuaDichVu>, IChungTuMuaDichVuRepository
    {
        public ChungTuMuaDichVuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<getchungtumuadichvu> getchungtumuadichvu(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from a in DbContext.chungTuMuaDichVus
                        join b in DbContext.nhaCungCaps
                        on a.MaNhaCungCap equals b.MaNhaCungCap
                        join c in DbContext.NhanVien
                        on a.MaSoNhanVien equals c.MaSoNhanVien
                        join d in DbContext.dieuKhoanTTs
                        on a.MaDieuKhoan equals d.MaDieuKhoan
                        join e in DbContext.loaiTiens
                        on a.MaLoaiTien equals e.MaLoaiTien
                        where (ngaydau <= a.NgayChungTu && a.NgayChungTu <= ngaycuoi)
                        select new getchungtumuadichvu()
                        {
                            MaNhaCungCap=a.MaNhaCungCap,
                            TenNhaCungCap=b.TenNhaCungCap,
                            DienGiai=a.DienGiai,
                            MaSoNhanVien=a.MaSoNhanVien,
                            HoVaTen=c.HoVaTen,
                            NgayHoachToan=a.NgayHoachToan,
                            NgayChungTu=a.NgayChungTu,
                            MaChungTuMuaDichVu=a.MaChungTuMuaDichVu,
                            TenDieuKhoan=d.TenDieuKhoan,
                            SoNgayDuocNo=a.SoNgayDuocNo,
                            HanThanhToan=a.HanThanhToan,
                            VietTat=e.VietTat,
                            TyGia=a.TyGia,
                            TienDichVu=a.TienDichVu,
                            TienChietKhau=a.TienChietKhau,
                            TienThueGTGT=a.TienThueGTGT,
                            TongTienThanhToan=a.TongTienThanhToan,
                            DaGhiSo=a.DaGhiSo

                        };
            return query;

        }
    }
}
