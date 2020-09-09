using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietChungTuMuaDichVuRepository : IRepository<ChiTietChungTuMuaDichVu>
    {

        IEnumerable<getchungtumuadichvu> getchitietchungtumuadichvu(string machungtu);
    }

    class ChiTietChungTuMuaDichVuRepository : RepositoryBase<ChiTietChungTuMuaDichVu>, IChiTietChungTuMuaDichVuRepository
    {
        public ChiTietChungTuMuaDichVuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<getchungtumuadichvu> getchitietchungtumuadichvu(string machungtu)
        {
            var query = from a in DbContext.chiTietChungTuMuaDichVus
                        join b in DbContext.dichVus
                        on a.MaDichVu equals b.MaDichVu
                        where a.MaChungTuMuaDichVu.Equals(machungtu)
                        select new getchungtumuadichvu()
                        {
                            MaDichVu= b.MaDichVu,
                            TenDichVu=b.TenDichVu,
                            TKChiPhi_TKKho=a.TKChiPhi_TKKho,
                            TKCongNo=a.TKCongNo,
                            DoiTuong=a.DoiTuong,
                            TenDoiTuong=a.TenDoiTuong,
                            DonViTinh=b.DonViTinh,
                            SoLuong=a.SoLuong,
                            DonGia=b.DonGia,
                            ThanhTien=a.ThanhTien
                        };
            return query;
        }
    }
}
