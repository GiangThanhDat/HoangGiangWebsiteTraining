using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IHopDongMuaRepository : IRepository<HopDongMua>
    {

        IQueryable<gethopdongmuahang> gethopdongmuahang(DateTime ngaydau, DateTime ngaycuoi);
    
    }

    class HopDongMuaRepository : RepositoryBase<HopDongMua>, IHopDongMuaRepository
    {
        public HopDongMuaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<gethopdongmuahang> gethopdongmuahang(DateTime ngaydau, DateTime ngaycuoi)
        {

            var query = from A in DbContext.hopDongMuas
                        join B in DbContext.nhaCungCaps
                        on A.MaNhaCungCap equals B.MaNhaCungCap
                        join C in DbContext.tinhTrangs
                        on A.MaTinhTrang equals C.MaTinhTrang
                        join D in DbContext.loaiTiens 
                        on A.MaLoaiTien equals D.MaLoaiTien
                       
                        join R in DbContext.NhanVien
                        on A.MaSoNhanVien equals R.MaSoNhanVien

                        where ngaydau<= A.NgayKy&& A.NgayKy<=ngaycuoi
                        select new gethopdongmuahang() { 
                        TenTinhTrang=C.TenTinhTrang,
                        MaHopDongMua=A.MaHopDongMua,
                        NgayKy=A.NgayKy,
                        TrichYeu=A.TrichYeu,
                        TenNhaCungCap=B.TenNhaCungCap,
                        GiaTriHopDong=A.GiaTriHopDong,
                        GiaTriThanhLy=A.GiaTriThanhLy,
                        TenLoaiTien=D.TenLoaiTien,
                        TyGia=A.TyGia,
                        GiaTriHopDongQuyDoi=A.GiaTriHopDongQuyDoi,
                        GiaTriThanhLyQuyDoi=A.GiaTriThanhLyQuyDoi,
                        NgayThanhLy_HuyBo=A.NgayThanhLy_HuyBo,
                        LyDo=A.LyDo,
                        DieuKhoanKhac=A.DieuKhoanKhac,
                        DiaChi=B.DiaChi,
                        MaSoThue=B.MaSoThue,
                        NguoiLienHe=B.NguoiLienHe,
                        HanGiaoHang=A.HanGiaoHang,
                        DiaChiGiaoHang=A.DiaChiGiaoHang,
                        HanThanhToan=A.HanThanhToan,
                        VietTat=D.VietTat,
                        HoVaTen=R.HoVaTen

                        


                        
                        };


            return query;
        }
    }
}
