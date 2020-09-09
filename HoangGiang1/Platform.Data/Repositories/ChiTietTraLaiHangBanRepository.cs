using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietTraLaiHangBanRepository : IRepository<ChiTietTraLaiHangBan>
    {
        IQueryable<getchitiettralaihangban> getchitiettralaihangban(string MaTraLaiHangBan);

    }

    class ChiTietTraLaiHangBanRepository : RepositoryBase<ChiTietTraLaiHangBan>, IChiTietTraLaiHangBanRepository
    {
        public ChiTietTraLaiHangBanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitiettralaihangban> getchitiettralaihangban(string MaTraLaiHangBan)
        {
            var query = from A in DbContext.traLaiHangBans
                        join B in DbContext.chiTietTraLaiHangBans
                        on A.MaTraLaiHangBan equals B.MaTraLaiHangBan
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaTraLaiHangBan.Equals(MaTraLaiHangBan)
                        select new getchitiettralaihangban()
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
                            TKTraLai = B.TKTraLai,
                            





                        };
            return query;
        }
    }
}
