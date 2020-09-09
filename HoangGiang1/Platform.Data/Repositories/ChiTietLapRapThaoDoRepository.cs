using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietLapRapThaoDoRepository : IRepository<ChiTietLapRapThaoDo>
    {
        IQueryable<getchitietlenhlaprapthaodo> getchitietlenhlaprapthaodo(string MaLapRapThaoDo);


    }

    class ChiTietLapRapThaoDoRepository : RepositoryBase<ChiTietLapRapThaoDo>, IChiTietLapRapThaoDoRepository
    {
        public ChiTietLapRapThaoDoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietlenhlaprapthaodo> getchitietlenhlaprapthaodo(string MaLapRapThaoDo)
        {
            var query = from A in DbContext.lapRapThaoDos
                        join B in DbContext.chiTietLapRapThaoDos
                        on A.MaLapRapThaoDo equals B.MaLapRapThaoDo
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang
                        select new getchitietlenhlaprapthaodo()
                        {
                            MaHang=C.MaHang,
                            TenHang=C.TenHang,
                            DonViTinh=C.DonViTinh,
                            SoLuong=B.SoLuong,
                            GiaKhuyenMai=C.GiaKhuyenMai,
                            ThanhTien=B.ThanhTien
                         



                        };

            return query;
        }
    }
}
