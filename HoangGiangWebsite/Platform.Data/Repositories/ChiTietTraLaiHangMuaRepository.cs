using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietTraLaiHangMuaRepository : IRepository<ChiTietTraLaiHangMua>
    {
        IQueryable<getchitiettralaihangmua> getchitiettralaihangmua(string MaTraLaiHang);

    }

    class ChiTietTraLaiHangMuaRepository : RepositoryBase<ChiTietTraLaiHangMua>, IChiTietTraLaiHangMuaRepository
    {
        public ChiTietTraLaiHangMuaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitiettralaihangmua> getchitiettralaihangmua(string MaTraLaiHang)
        {
            var query = from A in DbContext.traLaiHangMuas
                        join B in DbContext.chiTietTraLaiHangMuas
                        on A.MaTraLaiHangMua equals B.MaTraLaiHangMua
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang
                   
                        where B.MaTraLaiHangMua.Equals(MaTraLaiHang)
                        select new getchitiettralaihangmua()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                             Kho=B.Kho,
                             TKKho=B.TKKho,
                             TKCongNo=B.TKCongNo,
                             DonViTinh=C.DonViTinh,
                             SoLuong=B.SoLuong,
                             GiaKhuyenMai=C.GiaKhuyenMai,
                             TongTienThanhToan=A.TongTienThanhToan,
                             DienGiaiThue=B.DienGiaiThue,
                             VAT=C.VAT,
                             TienThueGTGT=A.TienThueGTGT,
                             TKThueGTGT=B.TKThueGTGT,
                             NhomHHDVMuaVao=B.NhomHHDVMuaVao,
                             SoLo=B.SoLo,
                             HanSuDung=C.HanSuDung,
                             SoCTMuaHang=B.SoCTMuaHang,
                             SoHDMuaHang=B.SoHDMuaHang,
                             NgayHDMuaHang=B.NgayHDMuaHang,
                             MaThongKe=B.MaThongKe,
                             MaHopDongMua=B.MaHopDongMua


                           


                        };
            return query;
        }
    }
}
