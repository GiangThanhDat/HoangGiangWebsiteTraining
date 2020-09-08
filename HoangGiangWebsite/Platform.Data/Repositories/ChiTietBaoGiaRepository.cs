using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietBaoGiaRepository : IRepository<ChiTietBaoGia>
    {
        IQueryable<getchitietbaogia> getchitietbaogia(string MaBG);

    }

    class ChiTietBaoGiaRepository : RepositoryBase<ChiTietBaoGia>, IChiTietBaoGiaRepository
    {
        public ChiTietBaoGiaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietbaogia> getchitietbaogia(string MaBG)
        {
            var query = from A in DbContext.baoGias
                        join B in DbContext.chiTietBaoGias
                        on A.MaSoBaoGia equals B.MaSoBaoGia
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang
                        where B.MaSoBaoGia.Equals(MaBG)
                        select new getchitietbaogia()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                            DonViTinh = C.DonViTinh,
                            SoLuong = B.SoLuong,
                            ThanhTien = B.ThanhTien,
                            TienChietKhau = B.TienChietKhau,
                            TienThueGTGT = B.TienThueGTGT,
                            TongTien = A.TongTien,
                            GiaKhuyenMai = C.GiaKhuyenMai,
                            ChietKhau = C.ChietKhau,
                            VAT = C.VAT,



                        };
            return query;
        }
    }
}
