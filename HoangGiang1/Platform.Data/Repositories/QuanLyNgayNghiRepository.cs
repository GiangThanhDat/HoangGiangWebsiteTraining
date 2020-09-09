using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IQuanLyNgayNghiRepository : IRepository<QuanLyNgayNghi>
    {

        IEnumerable<QuanLyNgayNghi> quanLyNgayNghi(string msnv);
        QuanLyNgayNghi getID(int ID);
        IEnumerable<getQuanLyNgayNghi> xemtheongay(DateTime ngay);
        IEnumerable<getQuanLyNgayNghi> xemtheomsnv(string msnv);
        IEnumerable<getQuanLyNgayNghi> xemtheotennv(string tennv);
        IEnumerable<getQuanLyNgayNghi> getall();
    }

    class QuanLyNgayNghiRepository : RepositoryBase<QuanLyNgayNghi>, IQuanLyNgayNghiRepository
    {
        public QuanLyNgayNghiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       

        public QuanLyNgayNghi getID(int ID)
        {
            var query = from A in DbContext.quanLyNgayNghis
                        where A.ID.Equals(ID)
                        select A;
            return query.First();
        }

        public IEnumerable<QuanLyNgayNghi> quanLyNgayNghi(string msnv)
        {
            var query = from A in DbContext.quanLyNgayNghis
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;
        }

        public IEnumerable<getQuanLyNgayNghi> xemtheomsnv(string msnv)
        {
            var query = from p in DbContext.quanLyNgayNghis
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.MaSoNhanVien.Equals(msnv)
                        select new getQuanLyNgayNghi()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau = p.GioBatDau,
                            GioKetThuc = p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            LoaiNghi=p.LoaiNghi,
                            TongNgayLamViecNghi = p.TongNgayLamViecNghi,
                            TongNgayNghi=p.TongNgayNghi

                        };
            return query;
        }

        public IEnumerable<getQuanLyNgayNghi> xemtheongay(DateTime ngay)
        {
            var query = from p in DbContext.quanLyNgayNghis
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.NgayBatDau.Equals(ngay)
                        select new getQuanLyNgayNghi()
                        {

                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau = p.GioBatDau,
                            GioKetThuc = p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            LoaiNghi = p.LoaiNghi,
                            TongNgayLamViecNghi = p.TongNgayLamViecNghi,
                            TongNgayNghi = p.TongNgayNghi
                        };
            return query;
        }

        public IEnumerable<getQuanLyNgayNghi> xemtheotennv(string tennv)
        {
            var query = from p in DbContext.quanLyNgayNghis
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.NhanVien.HoVaTen.Contains(tennv)
                        select new getQuanLyNgayNghi()
                        {

                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau = p.GioBatDau,
                            GioKetThuc = p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            LoaiNghi = p.LoaiNghi,
                            TongNgayLamViecNghi = p.TongNgayLamViecNghi,
                            TongNgayNghi = p.TongNgayNghi
                        };
            return query;
        }
        public IEnumerable<getQuanLyNgayNghi> getall()
        {
            var query = from p in DbContext.quanLyNgayNghis
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        select new getQuanLyNgayNghi()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau = p.GioBatDau,
                            GioKetThuc = p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            LoaiNghi = p.LoaiNghi,
                            TongNgayLamViecNghi = p.TongNgayLamViecNghi,
                            TongNgayNghi = p.TongNgayNghi
                        };
            return query;
        }
    }
}
