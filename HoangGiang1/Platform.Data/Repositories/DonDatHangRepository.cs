using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IDonDatHangRepository : IRepository<DonDatHang>
    {
        IQueryable<getdondathang> gettdondathang(DateTime ngaydau, DateTime ngaycuoi);

    }

    class DonDatHangRepository : RepositoryBase<DonDatHang>, IDonDatHangRepository
    {
        public DonDatHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getdondathang> gettdondathang(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.donDatHangs
                        join B in DbContext.khachHangs
                        on A.MaKhachHang equals B.MaKhachHang

                        join D in DbContext.loaiTiens
                        on A.MaLoaiTien equals D.MaLoaiTien

                        join R in DbContext.NhanVien
                        on A.MaSoNhanVien equals R.MaSoNhanVien
                        join G in DbContext.tinhTrangs
                        on A.MaTinhTrang equals G.MaTinhTrang
                        join H in DbContext.dieuKhoanTTs
                        on A.MaDieuKhoan equals H.MaDieuKhoan

                        
                        where ngaydau <= A.NgayGiaoHang && A.NgayGiaoHang <= ngaycuoi
                        select new getdondathang()
                        {

                            MaDonDatHang = A.MaDonDatHang,
                            MaKhachHang = A.MaKhachHang,
                            TenKhachHang = B.TenKhachHang,
                            TenTinhTrang=G.TenTinhTrang,
                            NgayDonHang=A.NgayDonHang,
                            NgayGiaoHang=A.NgayGiaoHang,
                            DienGiai=A.DienGiai,
                            TongTienHang=A.TongTienHang,
                            TongChietKhau=A.TongTienThanhToan,
                            HoVaTen=R.HoVaTen,
                            DiaChi=B.DiaChi,
                            MaSoThue=B.MaSoThue,
                            NguoiNhanHang=A.NguoiNhanHang,
                            TenDieuKhoan=H.TenDieuKhoan,
                            SoNgayDuocNo=A.SoNgayDuocNo,
                            TyGia=A.TyGia,
                            TenLoaiTien=D.TenLoaiTien,
                            VietTat=D.VietTat,
                            TongTienThanhToan=A.TongTienThanhToan
                            






                        };


            return query;
        }
    }
}
