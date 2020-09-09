using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILenhSanXuat_NVLRepository : IRepository<LenhSanXuat_NVL>
    {

        IQueryable<getlenhsanxuatNVL> getlenhsanxuatNVL(string MaLenhSanXuat);
    }

    class LenhSanXuat_NVLRepository : RepositoryBase<LenhSanXuat_NVL>, ILenhSanXuat_NVLRepository
    {
        public LenhSanXuat_NVLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getlenhsanxuatNVL> getlenhsanxuatNVL(string MaLenhSanXuat)
        {
            var query = from A in DbContext.lenhSanXuats
                        join B in DbContext.lenhSanXuat_NVLs
                        on A.MaLenhSanXuat equals B.MaLenhSanXuat
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang
                        where B.MaLenhSanXuat.Equals(MaLenhSanXuat)
                        select new getlenhsanxuatNVL
                        {
                            MaLenhSanXuat_NVL=B.MaLenhSanXuat_NVL,
                            DonViTinh=C.DonViTinh,
                            SoLuong_1DonVi=B.SoLuong_1DonVi,
                            SoLuong=B.SoLuong,
                            DoiTuongDHCP=B.DoiTuongDHCP,
                            KhoanMucCP=B.KhoanMucCP,
                            MaThongKe=B.MaThongKe

                        };
            return query;
        }
    }
}
