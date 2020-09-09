using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IHangHoa_DonViTinhRepository : IRepository<HangHoa_DonViTinh>
    {

        IEnumerable<getdvt> getdvt(string mahang);
    }

    class HangHoa_DonViTinhRepository : RepositoryBase<HangHoa_DonViTinh>, IHangHoa_DonViTinhRepository
    {
        public HangHoa_DonViTinhRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<getdvt> getdvt(string mahang)
        {
            var query = from a in DbContext.hangHoas
                        join b in DbContext.hangHoa_DonViTinhs
                        on a.MaHang equals b.MaHang
                        join c in DbContext.donViTinhs
                        on b.MaDonViTinh equals c.MaDonViTinh
                        where a.MaHang.Equals(mahang)
                        select new getdvt()
                        {
                            MaDonViTinh = c.MaDonViTinh,
                            TenDonViTinh = c.TenDonViTinh,
                            MaHang = a.MaHang,
                            DonGia = b.DonGia

                        };
            return query;
        }
    }
}
