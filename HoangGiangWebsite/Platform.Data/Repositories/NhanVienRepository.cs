
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface INhanVienRepository : IRepository<NhanVien>
    {
        NhanVien GetLyLich(string msnv);
        IEnumerable<NhanVienVangMat> getbymsnv(string msnv);
        NhanVien nhanVien(string msnv);
        getChucVu getchucvu(string msnv);
        IQueryable<getnhanvien> getnhanvien();
    }

    class NhanVienRepository : RepositoryBase<NhanVien>, INhanVienRepository
    {
        public NhanVienRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<NhanVienVangMat> getbymsnv(string msnv)
        {
            var query = from A in DbContext.NhanVien
                        join b in DbContext.CoSo
                        on A.MaCoSo equals b.MaCoSo


                        where A.MaSoNhanVien.Equals(msnv)
                        select new NhanVienVangMat()
                        {
                            MaSoNhanVien = A.MaSoNhanVien,
                            HoVaTen = A.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            MaCoSo=b.MaCoSo
                        };

            return query;
        }

        public NhanVien GetLyLich(string msnv)
        {
            var query = from A in DbContext.NhanVien


                        where A.MaSoNhanVien.Equals(msnv)
                        select A;

            return query.First();
        }
        public NhanVien nhanVien(string msnv)
        {
            var query = from A in DbContext.NhanVien
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query.First();

        }
        public IQueryable<getnhanvien> getnhanvien()
        {
            var query = from A in DbContext.NhanVien
                        join B in DbContext.CoSo
                        on A.MaCoSo equals B.MaCoSo
                        select new getnhanvien()
                        {
                            MaSoNhanVien = A.MaSoNhanVien,
                            HoVaTen = A.HoVaTen,
                            TenCoSo = B.TenCoSo

                        };
            return query;
        }

        public getChucVu getchucvu(string msnv)
        {
            var query = from A in DbContext.NhanVien
                        join B in DbContext.chucVus
                        on A.MaChucVu equals B.MaChucVu
                        where A.MaSoNhanVien.Equals(msnv)
                        select new getChucVu()
                        {
                            MaChucVu = B.MaChucVu,
                            TenChucVu = B.TenChucVu

                        };
            return query.First();
        }


    }
}