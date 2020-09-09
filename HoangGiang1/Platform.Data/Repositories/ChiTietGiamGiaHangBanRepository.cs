using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietGiamGiaHangBanRepository : IRepository<ChiTietGiamGiaHangBan>
    {
        IQueryable<getchitietgiamgiahangban> getchitietgiamgiahangban(string MaGiamGiaHangBan);
    }

    class ChiTietGiamGiaHangBanRepository : RepositoryBase<ChiTietGiamGiaHangBan>, IChiTietGiamGiaHangBanRepository
    {
        public ChiTietGiamGiaHangBanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietgiamgiahangban> getchitietgiamgiahangban(string MaGiamGiaHangBan)
        {
            var query = from A in DbContext.giamGiaHangBans
                        join B in DbContext.chiTietGiamGiaHangBans
                        on A.MaGiamGiaHangBan equals B.MaGiamGiaHangBan
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaGiamGiaHangBan.Equals(MaGiamGiaHangBan)
                        select new getchitietgiamgiahangban()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                           
                            TKTien = B.TKTien,

                            DonViTinh = C.DonViTinh,
                            SoLuong = B.SoLuong,
                            GiaKhuyenMai = C.GiaKhuyenMai,
                            ThanhTien = B.ThanhTien,
                            ChietKhau = C.ChietKhau,
                            TienChietKhau = B.TienChietKhau,
                            VAT = C.VAT,
                            TienThueGTGT = A.TienThueGTGT,
                            TKGiamGia=B.TKGiamGia





                        };
            return query;
        }
    }
}
