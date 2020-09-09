using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChungTuBanHangRepository : IRepository<ChungTuBanHang>
    {
        IQueryable<getchungtubanhang> getchungtubanhang(DateTime ngaydau, DateTime ngaycuoi);
        IQueryable<getchungtubanhang> getthongkechungtubanhangtimeline(string mactbh);
        IQueryable<getchungtubanhang> gettheongay(DateTime ngaydau, DateTime ngaycuoi,bool dathaydoi);
        IEnumerable<getchungtubanhang> getctbh(DateTime ngaydau, DateTime ngaycuoi,string macoso, bool dathaydoi);
        IEnumerable<lichsutongquan> getlichsu();
    }

    class ChungTuBanHangRepository : RepositoryBase<ChungTuBanHang>, IChungTuBanHangRepository
    {
        public ChungTuBanHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchungtubanhang> getchungtubanhang(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.chungTuBanHangs
                        join B in DbContext.khachHangs
                        on A.MaKhachHang equals B.MaKhachHang

                        join D in DbContext.loaiTiens
                        on A.MaLoaiTien equals D.MaLoaiTien

                        join R in DbContext.NhanVien
                        on A.MaSoNhanVien equals R.MaSoNhanVien
                        join H in DbContext.dieuKhoanTTs
                        on A.MaDieuKhoan equals H.MaDieuKhoan
                        where ngaydau <= A.NgayChungTu && A.NgayChungTu <= ngaycuoi
                        select new getchungtubanhang()
                        {

                            MaChungTuBanHang = A.MaChungTuBanHang,
                            MaKhachHang = A.MaKhachHang,
                            TenKhachHang = B.TenKhachHang,
                         
                            DienGiai = A.DienGiai,
                        
                            VietTat = D.VietTat,
                            TyGia = A.TyGia,
                            NgayHoachToan = A.NgayHoachToan,
                            NgayChungTu = A.NgayChungTu,
                            TongTienHang = A.TongTienHang,
                            TienThueGTGT = A.TienThueGTGT,
                            TongTienThanhToan = A.TongTienThanhToan
                           ,
                            MaSoThue = B.MaSoThue,
                            DiaChi = B.DiaChi,
                            HoVaTen = R.HoVaTen,
                            TienChietKhau=A.TienChietKhau,
                            NguoiLienHe=B.NguoiLienHe,
                            TenDieuKhoan=H.TenDieuKhoan,
                            SoNgayDuocNo=A.SoNgayDuocNo,
                            HanThanhToan=A.HanThanhToan,
                            DaGhiSo=A.DaGhiSo








                        };


            return query;
        }

        public IEnumerable<getchungtubanhang> getctbh(DateTime ngaydau, DateTime ngaycuoi, string macoso,bool dathaydoi)
        {
            var query = from p in DbContext.chungTuBanHangs
                        join a in DbContext.NhanVien
                        on p.MaSoNhanVien equals a.MaSoNhanVien
                        join b in DbContext.CoSo
                        on a.MaCoSo equals b.MaCoSo
                        join c in DbContext.chucVus
                        on a.MaChucVu equals c.MaChucVu
                        where ngaydau <= p.NgayChungTu && p.NgayChungTu <= ngaycuoi && b.MaCoSo == macoso&&p.DaThayDoi==dathaydoi
                        select new getchungtubanhang()
                        {
                            NgayChungTu = p.NgayChungTu,
                            TongTienThanhToan = p.TongTienThanhToan,
                            MaSoNhanVien = p.MaSoNhanVien,
                            MaCoSo=b.MaCoSo,
                            TenCoSo=b.TenCoSo,
                            MaChucVu=c.MaChucVu,
                            TenChucVu=c.TenChucVu,
                            HoVaTen=a.HoVaTen
                        };
            return query;
        }

        
        public IQueryable<getchungtubanhang> gettheongay(DateTime ngaydau, DateTime ngaycuoi, bool dathaydoi)
        {
            var query = from p in DbContext.chungTuBanHangs
                        where ngaydau <= p.NgayChungTu && p.NgayChungTu <= ngaycuoi && p.DaThayDoi == dathaydoi
                        select new getchungtubanhang()
                        {
                            NgayChungTu = p.NgayChungTu,
                            TongTienThanhToan= p.TongTienThanhToan,
                            MaSoNhanVien=p.MaSoNhanVien
                        };
            return query;
        }
        public IEnumerable<lichsutongquan> getlichsu()
        {
            var query = from a in DbContext.chungTuBanHangs
                        join b in DbContext.NhanVien
                        on a.MaSoNhanVien equals b.MaSoNhanVien
                        join c in DbContext.chucVus
                        on b.MaChucVu equals c.MaChucVu
                        join d in DbContext.CoSo
                        on b.MaCoSo equals d.MaCoSo
                        where a.DaThayDoi==false
                        select new lichsutongquan()
                        {
                            Ma = a.MaChungTuBanHang,
                            MaSoNhanVien = b.MaSoNhanVien,
                            HoVaTen = b.HoVaTen,
                            Ngay = a.NgayChungTu,
                            MaChucVu = c.MaChucVu,
                            TenChucVu = c.TenChucVu,
                            TenCoSo=d.TenCoSo,
                            MaCoSo=d.MaCoSo,
                            Tien=a.TongTienThanhToan

                        };
            return query;
        }

        public IQueryable<getchungtubanhang> getthongkechungtubanhangtimeline(string mactbh)
        {
            var query = from A in DbContext.chungTuBanHangs
                        join B in DbContext.khachHangs
                        on A.MaKhachHang equals B.MaKhachHang

                        
                        join R in DbContext.NhanVien
                        on A.MaSoNhanVien equals R.MaSoNhanVien
                        
                        where A.MaChungTuBanHang.Equals(mactbh)
                        select new getchungtubanhang()
                        {

                            MaChungTuBanHang = A.MaChungTuBanHang,
                            MaKhachHang = A.MaKhachHang,
                            TenKhachHang = B.TenKhachHang,

                            DienGiai = A.DienGiai,

                            TyGia = A.TyGia,
                            NgayHoachToan = A.NgayHoachToan,
                            NgayChungTu = A.NgayChungTu,
                            TongTienHang = A.TongTienHang,
                            TienThueGTGT = A.TienThueGTGT,
                            TongTienThanhToan = A.TongTienThanhToan
                           ,
                            MaSoThue = B.MaSoThue,
                            DiaChi = B.DiaChi,
                            HoVaTen = R.HoVaTen,
                            TienChietKhau = A.TienChietKhau,
                            NguoiLienHe = B.NguoiLienHe,
                            SoNgayDuocNo = A.SoNgayDuocNo,
                            HanThanhToan = A.HanThanhToan,
                            DaGhiSo = A.DaGhiSo
                        };


            return query;
        }
    }
}
