using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietGiamGiaHangMuaRepository : IRepository<ChiTietGiamGiaHangMua>
    {

        IQueryable<getchitietgiamgiahnagmua> getchitietgiamgiahangmua(string MaGiamGiaHangMua);
    }

    class ChiTietGiamGiaHangMuaRepository : RepositoryBase<ChiTietGiamGiaHangMua>, IChiTietGiamGiaHangMuaRepository
    {
        public ChiTietGiamGiaHangMuaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietgiamgiahnagmua> getchitietgiamgiahangmua(string MaGiamGiaHangMua)
        {
            var query = from A in DbContext.giamGiaHangMuas
                        join B in DbContext.chiTietGiamGiaHangMuas
                        on A.MaGiamGiaHangMua equals B.MaGiamGiaHangMua
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaGiamGiaHangMua.Equals(MaGiamGiaHangMua)
                        select new getchitietgiamgiahnagmua()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                            Kho = B.Kho,
                            TKKho = B.TKKho,
                            TKCongNo = B.TKCongNo,
                            DonViTinh = C.DonViTinh,
                            SoLuong = B.SoLuong,
                            GiaKhuyenMai = C.GiaKhuyenMai,
                            TongTienThanhToan = A.TongTienThanhToan,
                            DienGiaiThue = B.DienGiaiThue,
                            VAT = C.VAT,
                            TienThueGTGT = A.TienThueGTGT,
                            TKThueGTGT = B.TKThueGTGT,
                            NhomHHDVMuaVao = B.NhomHHDVMuaVao,
                            SoLo = B.SoLo,
                            HanSuDung = C.HanSuDung,
                            SoCTMuaHang = B.SoCTMuaHang,
                            SoHDMuaHang = B.SoHDMuaHang,
                            NgayHDMuaHang = B.NgayHDMuaHang,
                            MaThongKe = B.MaThongKe,
                            MaHopDongMua = B.MaHopDongMua





                        };
            return query;
        }
    }
}
