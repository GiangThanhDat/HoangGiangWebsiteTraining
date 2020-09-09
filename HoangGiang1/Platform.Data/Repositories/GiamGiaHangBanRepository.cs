using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IGiamGiaHangBanRepository : IRepository<GiamGiaHangBan>
    {
        IQueryable<getgiamgiahangban> getgiamgiahangban(DateTime ngaydau, DateTime ngaycuoi);
    }

    class GiamGiaHangBanRepository : RepositoryBase<GiamGiaHangBan>, IGiamGiaHangBanRepository
    {
        public GiamGiaHangBanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getgiamgiahangban> getgiamgiahangban(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.giamGiaHangBans
                        join B in DbContext.khachHangs
                        on A.MaKhachHang equals B.MaKhachHang

                        join D in DbContext.loaiTiens
                        on A.MaLoaiTien equals D.MaLoaiTien

                        join R in DbContext.NhanVien
                        on A.MaSoNhanVien equals R.MaSoNhanVien
                     
                        where ngaydau <= A.NgayChungTu && A.NgayChungTu <= ngaycuoi
                        select new getgiamgiahangban()
                        {

                            MaGiamGiaHangBan = A.MaGiamGiaHangBan,
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
                            TienChietKhau = A.TienChietKhau,
                            NguoiLienHe = B.NguoiLienHe,
                       
                            
                            DaGhiSo = A.DaGhiSo








                        };


            return query;
        }
    }
}
