using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IQuanLyTaiSanRepository : IRepository<QuanLyTaiSan>
    {

        IQueryable<getQuanLyTaiSanCaNhan> getQuanLyTaiSanCaNhan(string msnv);

    }

    class QuanLyTaiSanRepository : RepositoryBase<QuanLyTaiSan>, IQuanLyTaiSanRepository
    {
        public QuanLyTaiSanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getQuanLyTaiSanCaNhan> getQuanLyTaiSanCaNhan(string msnv)
        {
            var query = from A in DbContext.TaiSan
                        join B in DbContext.quanLyTaiSans
                        on A.MaTaiSan equals B.MaTaiSan
                        join C in DbContext.CoSo
                        on A.MaCoSo equals C.MaCoSo
                        where B.MaSoNhanVien.Equals(msnv)
                        select new getQuanLyTaiSanCaNhan() {
                            MaTaiSan = A.MaTaiSan,
                            NgayNhap = A.NgayNhap,
                            NgayBatDauSuDung = A.NgayBatDauSuDung,
                            NgayHetHan = A.NgayHetHan,
                            MaCoSo = A.MaCoSo,
                            KieuTaiSan = A.KieuTaiSan,
                            MoTaChiTiet = A.MoTaChiTiet,
                            TinhTrang = A.TinhTrang,
                            NguoiNhap = A.NguoiNhap,
                            NgayNhapLieu = A.NgayNhapLieu,
                            TenCoSo=C.TenCoSo


                        };
            return query;
        }
    }
}
