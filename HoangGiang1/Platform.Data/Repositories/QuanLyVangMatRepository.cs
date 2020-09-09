using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IQuanLyVangMatRepository : IRepository<QuanLyVangMat>
    {
        IEnumerable<NhanVienVangMat> xemtheongay(DateTime ngay);
        IEnumerable<NhanVienVangMat> xemtheomsnv(string msnv);
        IEnumerable<NhanVienVangMat> xemtheotennv(string tennv);
        IEnumerable<NhanVienVangMat> getall();
        IEnumerable<QuanLyVangMat> quanLyVangMat(string msnv);

    }

    public class QuanLyVangMatRepository : RepositoryBase<QuanLyVangMat>, IQuanLyVangMatRepository
    {
        public QuanLyVangMatRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<NhanVienVangMat> getall()
        {
            var query = from p in DbContext.QuanLyVangMat
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        select new NhanVienVangMat()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            TrangThai = p.TrangThai,
                            NgayVangMat = p.NgayVangMat,
                            GioRa = p.GioRa,
                            GioVao = p.GioVao,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo
                        };
            return query;
        }

        public IEnumerable<QuanLyVangMat> quanLyVangMat(string msnv)
        {
            var query = from A in DbContext.QuanLyVangMat
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;
        }

        public IEnumerable<NhanVienVangMat> xemtheomsnv(string msnv)
        {
            var query = from p in DbContext.QuanLyVangMat
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.MaSoNhanVien.Equals(msnv)
                        select new NhanVienVangMat() {
                            MaSoNhanVien=p.MaSoNhanVien,
                            TrangThai=p.TrangThai,
                            NgayVangMat=p.NgayVangMat,
                            GioRa=p.GioRa,
                            GioVao=p.GioVao,
                            HoVaTen=a.HoVaTen,
                            TenCoSo=b.TenCoSo
                        } ;
            return query;
        }

        public IEnumerable<NhanVienVangMat> xemtheongay(DateTime ngay)
        {
            var query = from p in DbContext.QuanLyVangMat
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.NgayVangMat.Equals(ngay)
                        select new NhanVienVangMat()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            TrangThai = p.TrangThai,
                            NgayVangMat = p.NgayVangMat,
                            GioRa = p.GioRa,
                            GioVao = p.GioVao,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo
                        };
            return query;

        }

        public IEnumerable<NhanVienVangMat> xemtheotennv(string tennv)
        {
            var query = from p in DbContext.QuanLyVangMat
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.NhanVien.HoVaTen.Contains(tennv)
                        select new NhanVienVangMat()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            TrangThai = p.TrangThai,
                            NgayVangMat = p.NgayVangMat,
                            GioRa = p.GioRa,
                            GioVao = p.GioVao,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo
                        };
            return query;
        }
    }
}
