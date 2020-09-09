using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IQuanLyCongTacRepository : IRepository<QuanLyCongTac>
    {
        IEnumerable<QuanLyCongTac> quanLyCongTac(string msnv);
        QuanLyCongTac getID(int ID);
        IEnumerable<getQuanLyCongTac> xemtheongay(DateTime ngay);
        IEnumerable<getQuanLyCongTac> xemtheomsnv(string msnv);
        IEnumerable<getQuanLyCongTac> xemtheotennv(string tennv);
        IEnumerable<getQuanLyCongTac> getall();
    }

    class QuanLyCongTacRepository : RepositoryBase<QuanLyCongTac>, IQuanLyCongTacRepository
    {
        public QuanLyCongTacRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public QuanLyCongTac getID(int ID)
        {
            var query = from A in DbContext.quanLyCongTacs
                        where A.ID.Equals(ID)
                        select A;
            return query.First();
        }

        public IEnumerable<QuanLyCongTac> quanLyCongTac(string msnv)
        {
            var query = from A in DbContext.quanLyCongTacs
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;
        }

       

        public IEnumerable<getQuanLyCongTac> xemtheongay(DateTime ngay)
        {
            var query = from p in DbContext.quanLyCongTacs
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.NgayBatDau.Equals(ngay)
                        select new getQuanLyCongTac()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau=p.GioBatDau,
                            GioKetThuc=p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            TongNgayLamViec = p.TongNgayLamViec,
                            TongNgay = p.TongNgay,
                            DiaDiem = p.DiaDiem,
                            NoiDung = p.NoiDung,

                        };
            return query;

        }

        public IEnumerable<getQuanLyCongTac> xemtheotennv(string tennv)
        {
            var query = from p in DbContext.quanLyCongTacs
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.NhanVien.HoVaTen.Contains(tennv)
                        select new getQuanLyCongTac()
                        {

                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau = p.GioBatDau,
                            GioKetThuc = p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            TongNgayLamViec = p.TongNgayLamViec,
                            TongNgay = p.TongNgay,
                            DiaDiem = p.DiaDiem,
                            NoiDung = p.NoiDung,
                        };
            return query;
        }
        public IEnumerable<getQuanLyCongTac> xemtheomsnv(string msnv)
        {
            var query = from p in DbContext.quanLyCongTacs
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        where p.MaSoNhanVien.Equals(msnv)
                        select new getQuanLyCongTac()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau = p.GioBatDau,
                            GioKetThuc = p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            TongNgayLamViec = p.TongNgayLamViec,
                            TongNgay = p.TongNgay,
                            DiaDiem = p.DiaDiem,
                            NoiDung = p.NoiDung,
                        };
            return query;
        }
        public IEnumerable<getQuanLyCongTac> getall()
        {
            var query = from p in DbContext.quanLyCongTacs
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        select new getQuanLyCongTac()
                        {
                            MaSoNhanVien = p.MaSoNhanVien,
                            HoVaTen = a.HoVaTen,
                            TenCoSo = b.TenCoSo,
                            GioBatDau = p.GioBatDau,
                            GioKetThuc = p.GioKetThuc,
                            NgayBatDau = p.NgayBatDau,
                            NgayKetThuc = p.NgayKetThuc,
                            TongGio = p.TongGio,
                            TongNgayLamViec = p.TongNgayLamViec,
                            TongNgay = p.TongNgay,
                            DiaDiem = p.DiaDiem,
                            NoiDung = p.NoiDung,
                        };
            return query;
        }
    }
}
