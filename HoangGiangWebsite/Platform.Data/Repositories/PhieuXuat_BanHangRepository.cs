using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IPhieuXuat_BanHangRepository : IRepository<PhieuXuat_BanHang>
    {
        IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi);

    }

    class PhieuXuat_BanHangRepository : RepositoryBase<PhieuXuat_BanHang>, IPhieuXuat_BanHangRepository
    {
        public PhieuXuat_BanHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.phieuXuat_BanHangs
                        join B in DbContext.khachHangs
                         on A.MaKhachHang equals B.MaKhachHang

                        where (ngaydau <= A.NgayChungTu && A.NgayChungTu <= ngaycuoi)
                        select new getphieunhapxuatkho()
                        {
                            NgayChungTu=A.NgayChungTu,
                            NgayHoachToan=A.NgayHoachToan,
                            MaPhieuXuat=A.MaPhieuXuat,
                           TongTienThanhToan=A.TongTienThanhToan,
                           NguoiNhan=A.NguoiNhan,
                           TenKhachHang=B.TenKhachHang,
                           LyDoXuat=A.LyDoXuat,
                           DienGiai=A.DienGiai,
                           DaGhiSo=A.DaGhiSo,
                           ChungTuGoc=A.ChungTuGoc

                            

                           

                        };
            return query;
        }
    }
}
