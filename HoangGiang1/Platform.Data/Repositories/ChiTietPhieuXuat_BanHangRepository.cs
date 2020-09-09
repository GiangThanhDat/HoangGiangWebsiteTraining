using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietPhieuXuat_BanHangRepository : IRepository<ChiTietPhieuXuat_BanHang>
    {
        IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuXuat);

    }

    class ChiTietPhieuXuat_BanHangRepository : RepositoryBase<ChiTietPhieuXuat_BanHang>, IChiTietPhieuXuat_BanHangRepository
    {
        public ChiTietPhieuXuat_BanHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuXuat)
        {
            var query = from A in DbContext.phieuXuat_BanHangs
                        join B in DbContext.chiTietPhieuXuat_BanHangs
                        on A.MaPhieuXuat equals B.MaPhieuXuat
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaPhieuXuat.Equals(MaPhieuXuat)
                        select new chitietxuatnhapkho()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                            Kho = B.Kho,
                            TKCo = B.TKCo,
                            TKNo = B.TKNo,
                            DonViTinh = C.DonViTinh,
                            GiaKhuyenMai = C.GiaKhuyenMai,


                            ////SoLuong = B.SoLuong,

                            //ThanhTien = B.ThanhTien,

                            ////TienChietKhau = B.TienChietKhau,
                            //VAT = C.VAT,






                        };
            return query;
        }
    }
}
