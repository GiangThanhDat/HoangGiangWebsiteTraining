using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IBaoGiaRepository : IRepository<BaoGia>
    {
        IQueryable<getbaogia> getbaogia(DateTime ngaydau, DateTime ngaycuoi);

    }

    class BaoGiaRepository : RepositoryBase<BaoGia>, IBaoGiaRepository
    {
        public BaoGiaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getbaogia> getbaogia(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.baoGias
                        join B in DbContext.khachHangs
                        on A.MaKhachHang equals B.MaKhachHang

                        join D in DbContext.loaiTiens
                        on A.MaLoaiTien equals D.MaLoaiTien

                        join R in DbContext.NhanVien
                        on A.MaSoNhanVien equals R.MaSoNhanVien

                        where ngaydau <= A.NgayBaoGia && A.NgayBaoGia <= ngaycuoi
                        select new getbaogia()
                        {

                            MaSoBaoGia = A.MaSoBaoGia,
                            MaKhachHang = A.MaKhachHang,
                            TenKhachHang = B.TenKhachHang,
                            GhiChu=A.GhiChu,
                            NgayBaoGia=A.NgayBaoGia,
                            HieuLucDen=A.HieuLucDen,
                            MaLoaiTien=A.MaLoaiTien,
                            TienHang=A.TienHang,
                            TienThueGTGT=A.TienThueGTGT,
                            TienChietKhau=A.TienChietKhau,
                            TongTien=A.TongTien,
                            TyGia = A.TyGia,
                            MaSoThue = B.MaSoThue,
                            DiaChi = B.DiaChi,
                            HoVaTen = R.HoVaTen,
                            TenLoaiTien=D.TenLoaiTien,
                            NguoiLienHe=B.NguoiLienHe,
                            VietTat=D.VietTat
                            






                        };


            return query;
        }
    }
}
