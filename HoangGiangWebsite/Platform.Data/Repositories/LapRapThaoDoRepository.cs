using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILapRapThaoDoRepository : IRepository<LapRapThaoDo>
    {

        IQueryable<getlenhlaprapthaodo> getlenhlaprapthaodo(DateTime ngaydau, DateTime ngaycuoi);
    }

    class LapRapThaoDoRepository : RepositoryBase<LapRapThaoDo>, ILapRapThaoDoRepository
    {
        public LapRapThaoDoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getlenhlaprapthaodo> getlenhlaprapthaodo(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.lapRapThaoDos
                        join B in DbContext.thanhPhams
                        on A.MaThanhPham equals B.MaThanhPham
                        join C in DbContext.hangHoas
                        on A.MaHang equals C.MaHang
                        where ngaydau <= A.Ngay && A.Ngay <= ngaycuoi
                        select new getlenhlaprapthaodo() { 
                        Ngay=A.Ngay,
                        MaLapRapThaoDo=A.MaLapRapThaoDo,
                        MaThanhPham=B.MaThanhPham,
                        TenThanhPham=B.TenThanhPham,
                        DonViTinh=B.DonViTinh,
                        SoLuong=A.SoLuong,
                        GiaKhuyenMai=C.GiaKhuyenMai,
                        ThanhTien=A.ThanhTien,
                        DienGiai=A.DienGiai
                        
                        
                        
                        
                        
                        }
                        ;
            return query;
        }
    }
}
