using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITaiSanRepository : IRepository<TaiSan>
    {
        IQueryable<Chucnangthongketaisan> getThongkeTaiSan();
        IQueryable<Chucnangthongketaisan> getThongkeNguoiQuanLyTS();
        IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoMaCoSo( string MaCoSo);
        IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoKieuTaiSan( string KieuTaiSan);
        IQueryable<getnguoinhap> getnguoinhap( string msnv);
     

    }

    class TaiSanRepository : RepositoryBase<TaiSan>, ITaiSanRepository
    {
        public TaiSanRepository (IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoKieuTaiSan(string KieuTaiSan)
        {
            var query = from A in DbContext.TaiSan
                        join B in DbContext.quanLyTaiSans
                        on A.MaTaiSan equals B.MaTaiSan
                        join C in DbContext.NhanVien
                        on B.MaSoNhanVien equals C.MaSoNhanVien
                        join D in DbContext.CoSo
                        on A.MaCoSo equals D.MaCoSo
                        where A.KieuTaiSan.Equals(KieuTaiSan)
                        select new Chucnangthongketaisan()
                        {
                            MaTaiSan = A.MaTaiSan,
                            NgayNhap = A.NgayNhap,
                            NgayBatDauSuDung = A.NgayBatDauSuDung,
                            NgayHetHan = A.NgayHetHan,
                            MaCoSo = D.MaCoSo,
                            KieuTaiSan = A.KieuTaiSan,
                            MoTaChiTiet = A.MoTaChiTiet,
                            TinhTrang = A.TinhTrang,
                            NguoiNhap = A.NguoiNhap,
                            NgayNhapLieu = A.NgayNhapLieu,
                            HoVaTen = C.HoVaTen,
                            TenCoSo = D.TenCoSo

                        };
            return query;
        }

        public IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoMaCoSo(string MaCoSo)
        {
            var query = from A in DbContext.TaiSan
                        join B in DbContext.quanLyTaiSans
                        on A.MaTaiSan equals B.MaTaiSan
                        join C in DbContext.NhanVien
                        on B.MaSoNhanVien equals C.MaSoNhanVien
                        join D in DbContext.CoSo
                        on C.MaCoSo equals D.MaCoSo
                        where D.MaCoSo.Equals(MaCoSo)
                        select new Chucnangthongketaisan()
                        {
                            MaTaiSan = A.MaTaiSan,
                            NgayNhap = A.NgayNhap,
                            NgayBatDauSuDung = A.NgayBatDauSuDung,
                            NgayHetHan = A.NgayHetHan,
                            MaCoSo = D.MaCoSo,
                            KieuTaiSan = A.KieuTaiSan,
                            MoTaChiTiet = A.MoTaChiTiet,
                            TinhTrang = A.TinhTrang,
                            NguoiNhap = A.NguoiNhap,
                            NgayNhapLieu = A.NgayNhapLieu,
                            HoVaTen = C.HoVaTen,
                            TenCoSo = D.TenCoSo

                        };
            return query;
        }

        public IQueryable<getnguoinhap> getnguoinhap(string msnv)
        {
            var query = from A in DbContext.TaiSan

                        join C in DbContext.NhanVien
                        on A.NguoiNhap equals C.MaSoNhanVien
                        select new getnguoinhap()
                        {
                            HoVaTen = C.HoVaTen,
                         NguoiNhap=A.NguoiNhap

                        };


                       
            return query;
        }

        public IQueryable<Chucnangthongketaisan> getThongkeNguoiQuanLyTS()
        {
            var query = from A in DbContext.TaiSan
                        join B in DbContext.quanLyTaiSans
                        on A.MaTaiSan equals B.MaTaiSan
                        join C in DbContext.NhanVien
                        on B.MaSoNhanVien equals C.MaSoNhanVien
                        join D in DbContext.CoSo
                        on C.MaCoSo equals D.MaCoSo


                        select new Chucnangthongketaisan()
                        {
                            MaTaiSan = A.MaTaiSan,
                           
                            MaCoSo = D.MaCoSo,
                           
                            TenCoSo = D.TenCoSo,
                            MaSoNhanVien = C.MaSoNhanVien

                        };
            return query;
        }

        public IQueryable<Chucnangthongketaisan> getThongkeTaiSan()
        {
            var query = from A in DbContext.TaiSan
                        join B in DbContext.quanLyTaiSans
                        on A.MaTaiSan equals B.MaTaiSan
                        join C in DbContext.NhanVien
                        on B.MaSoNhanVien equals C.MaSoNhanVien
                        join D in DbContext.CoSo
                        on A.MaCoSo equals D.MaCoSo

                        
                        select new Chucnangthongketaisan()
                        {
                            MaTaiSan = A.MaTaiSan,
                            NgayNhap = A.NgayNhap,
                            NgayBatDauSuDung = A.NgayBatDauSuDung,
                            NgayHetHan = A.NgayHetHan,
                            MaCoSo = D.MaCoSo,
                            KieuTaiSan = A.KieuTaiSan,
                            MoTaChiTiet = A.MoTaChiTiet,
                            TinhTrang = A.TinhTrang,
                            NguoiNhap = A.NguoiNhap,
                            NgayNhapLieu = A.NgayNhapLieu,
                            HoVaTen = C.HoVaTen,
                            TenCoSo=D.TenCoSo,
                            MaSoNhanVien=C.MaSoNhanVien

                        };
            return query;
        }
    }
}
