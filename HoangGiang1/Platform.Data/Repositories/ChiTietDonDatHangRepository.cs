using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietDonDatHangRepository : IRepository<ChiTietDonDatHang>
    {

        IQueryable<getchitietdondathang> getchitietdondathang(string MaDonDatHang);
    }

    class ChiTietDonDatHangRepository : RepositoryBase<ChiTietDonDatHang>, IChiTietDonDatHangRepository
    {
        public ChiTietDonDatHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietdondathang> getchitietdondathang(string MaDonDatHang)
        {
            var query = from A in DbContext.donDatHangs
                        join B in DbContext.chiTietDonDatHangs
                        on A.MaDonDatHang equals B.MaDonDatHang
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaDonDatHang.Equals(MaDonDatHang)
                        select new getchitietdondathang()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                            DonViTinh = C.DonViTinh,
                            SoLuong = B.SoLuong,
                            GiaKhuyenMai = C.GiaKhuyenMai,
                            VAT = C.VAT,
                            TienThueGTGT = A.TienThueGTGT,
                            ThanhTien=B.ThanhTien
                           
                          




                        };
            return query;
        }
    }
}
