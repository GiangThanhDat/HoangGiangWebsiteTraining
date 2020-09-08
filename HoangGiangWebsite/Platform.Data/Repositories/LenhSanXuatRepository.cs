using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILenhSanXuatRepository : IRepository<LenhSanXuat>
    {
        IQueryable<getLenhSanXuat> getLenhSanXuat(DateTime ngaydau, DateTime ngaycuoi);

    }

    class LenhSanXuatRepository : RepositoryBase<LenhSanXuat>, ILenhSanXuatRepository
    {
        public LenhSanXuatRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getLenhSanXuat> getLenhSanXuat(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.lenhSanXuats
                        join B in DbContext.tinhTrangs
                        on A.MaTinhTrang equals B.MaTinhTrang
                       

                        where ngaydau <= A.Ngay && A.Ngay <= ngaycuoi
                        select new getLenhSanXuat()
                        {
                            TenTinhTrang = B.TenTinhTrang,
                            MaLenhSanXuat = A.MaLenhSanXuat,
                            Ngay = A.Ngay,
                            DienGiai=A.DienGiai,
                            DaGhiSo=A.DaGhiSo

                          




                        };


            return query;
        }
    }
}
