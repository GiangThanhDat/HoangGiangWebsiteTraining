using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IDonMuaHangRepository : IRepository<DonMuaHang>
    {
        IQueryable<getdonmuahang> getDonMuaHang(DateTime ngaydau, DateTime ngaycuoi);
    
    }

    class DonMuaHangRepository : RepositoryBase<DonMuaHang>, IDonMuaHangRepository
    {
        public DonMuaHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getdonmuahang> getDonMuaHang(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.donMuaHangs
                        join B in DbContext.tinhTrangs
                        on A.MaTinhTrang equals B.MaTinhTrang
                        join C in DbContext.nhaCungCaps
                        on  A.MaNhaCungCap equals C.MaNhaCungCap
                        join D in DbContext.NhanVien
                        on A.MaSoNhanVien equals D.MaSoNhanVien
                        join G in DbContext.loaiTiens
                        on A.MaLoaiTien equals G.MaLoaiTien
                        where (ngaydau <= A.NgayDonHang && A.NgayDonHang <= ngaycuoi)
                        select new getdonmuahang() { 
                        TenTinhTrang =B.TenTinhTrang,
                        NgayDonHang=A.NgayDonHang,
                        MaDonMuaHang=A.MaDonMuaHang,
                        NgayGiaoHang=A.NgayGiaoHang,
                        TenNhaCungCap=C.TenNhaCungCap,
                        DienGiai=A.DienGiai,
                        TongTienHang=A.TongTienHang,
                        DiaChi=C.DiaChi,
                        HoVaTen=D.HoVaTen,
                        MaSoThue=C.MaSoThue,
                        VietTat=G.VietTat,
                        TyGia=A.TyGia
                        

                        
                        
                        
                        };
            return query;
        }
    }
}
