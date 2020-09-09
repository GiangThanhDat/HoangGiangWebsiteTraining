using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILenhSanXuat_ThanhPhamRepository : IRepository<LenhSanXuat_ThanhPham>
    {
        IQueryable<getchitietlenhsanxuatthanhpham> getchitietlenhsanxuatthanhpham(string MaLenhSanXuat);


    }

    class LenhSanXuat_ThanhPhamRepository : RepositoryBase<LenhSanXuat_ThanhPham>, ILenhSanXuat_ThanhPhamRepository
    {
        public LenhSanXuat_ThanhPhamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietlenhsanxuatthanhpham> getchitietlenhsanxuatthanhpham(string MaLenhSanXuat)
        {
            var query = from A in DbContext.lenhSanXuat_ThanhPhams
                        join B in DbContext.lenhSanXuats
                        on A.MaLenhSanXuat equals B.MaLenhSanXuat
                        join C in DbContext.thanhPhams
                        on A.MaThanhPham equals C.MaThanhPham
                        where B.MaLenhSanXuat.Equals(MaLenhSanXuat)
                        select new getchitietlenhsanxuatthanhpham
                        {
                            MaThanhPham = A.MaThanhPham,
                            TenThanhPham = C.TenThanhPham,
                            SoLuong = A.SoLuong,
                            DonViTinh = C.DonViTinh,
                            HopDongBan = C.HopDongBan,
                            DoiTuongDHCP = C.DoiTuongDHCP,
                            MaThongKe = C.MaThongKe,

                        };
            return query;
                      
        }
    }
}
