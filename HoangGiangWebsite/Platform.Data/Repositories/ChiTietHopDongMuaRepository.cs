using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietHopDongMuaRepository : IRepository<ChiTietHopDongMua>
    {

        IQueryable<getchitiethopdongmua> getchitiethopdongmua(string MaHD);
    }

    class ChiTietHopDongMuaRepository : RepositoryBase<ChiTietHopDongMua>, IChiTietHopDongMuaRepository
    {
        public ChiTietHopDongMuaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitiethopdongmua> getchitiethopdongmua(string MaHD)
        {
            var query = from A in DbContext.hopDongMuas
                        join B in DbContext.chiTietHopDongMuas
                        on A.MaHopDongMua equals B.MaHopDongMua
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang
                        where B.MaHopDongMua.Equals(MaHD)
                        select new getchitiethopdongmua()
                        {
                            MaHang=C.MaHang,
                            TenHang=C.TenHang,
                            DonViTinh=C.DonViTinh,
                            SoLuong=B.SoLuong,
                            ThanhTien=B.ThanhTien,
                            TienChietKhau=B.TienChietKhau,
                            TienThueGTGT=B.TienThueGTGT,
                            TongTienThanhToan=A.TongTienThanhToan,
                            GiaKhuyenMai=C.GiaKhuyenMai,
                            ChietKhau=C.ChietKhau,
                            VAT=C.VAT,



                        };
            return query;
        }
    }
}
