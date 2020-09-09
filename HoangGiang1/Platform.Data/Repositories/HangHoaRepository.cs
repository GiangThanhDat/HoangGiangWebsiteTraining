using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IHangHoaRepository : IRepository<HangHoa>
    {
        IEnumerable<lichsutongquan> getlichsu();
    }

    class HangHoaRepository : RepositoryBase<HangHoa>, IHangHoaRepository
    {
        public HangHoaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<lichsutongquan> getlichsu()
        {
            var query = from a in DbContext.hangHoas
                        join b in DbContext.NhanVien
                        on a.NguoiNhap equals b.MaSoNhanVien
                        join c in DbContext.chucVus
                        on b.MaChucVu equals c.MaChucVu
                        join d in DbContext.CoSo
                        on b.MaCoSo equals d.MaCoSo
                        select new lichsutongquan()
                        {
                            Ma = a.MaHang,
                            MaSoNhanVien = b.MaSoNhanVien,
                            HoVaTen = b.HoVaTen,
                            Ngay = a.NgayNhap,
                            MaChucVu = c.MaChucVu,
                            TenChucVu = c.TenChucVu,
                            TenCoSo = d.TenCoSo,
                            MaCoSo = d.MaCoSo

                        };
            return query;
        }

    }
}
