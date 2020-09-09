using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietHoaDon_BanHangRepository : IRepository<ChiTietHoaDon_BanHang>
    {
        IQueryable<getchitiethoadonbanhang> getchitiethoadonbanhang(string MaHoaDon);

    }

    class ChiTietHoaDon_BanHangRepository : RepositoryBase<ChiTietHoaDon_BanHang>, IChiTietHoaDon_BanHangRepository
    {
        public ChiTietHoaDon_BanHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitiethoadonbanhang> getchitiethoadonbanhang(string MaHoaDon)
        {
            var query = from A in DbContext.hoaDon_BanHangs
                        join B in DbContext.chiTietHoaDon_BanHangs
                        on A.MaHoaDon equals B.MaHoaDon
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaHoaDon.Equals(MaHoaDon)
                        select new getchitiethoadonbanhang()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                            TKCongNo_ChiPhi = B.TKCongNo_ChiPhi,
                            TKDoanhThu = B.TKDoanhThu,

                            DonViTinh = C.DonViTinh,
                            SoLuong = B.SoLuong,
                            GiaKhuyenMai = C.GiaKhuyenMai,
                            ThanhTien = B.ThanhTien,
                            ChietKhau = C.ChietKhau,
                            TienChietKhau = B.TienChietKhau,
                            VAT = C.VAT,
                            TienThueGTGT = A.TienThueGTGT,






                        };
            return query;
        }
    }
}
