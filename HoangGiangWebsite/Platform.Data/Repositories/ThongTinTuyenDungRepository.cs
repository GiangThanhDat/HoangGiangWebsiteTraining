using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IThongTinTuyenDungRepository : IRepository<ThongTinTuyenDung>
    {
        IEnumerable<ThongTinTuyenDung> thongTinTuyenDung(string msnv);
        ThongTinTuyenDung getID(int ID);

    }

    class ThongTinTuyenDungRepository : RepositoryBase<ThongTinTuyenDung>, IThongTinTuyenDungRepository
    {
        public ThongTinTuyenDungRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ThongTinTuyenDung getID(int ID)
        {
            var query = from A in DbContext.thongTinTuyenDungs
                        where A.ID.Equals(ID)
                        select A;
            return query.First();
        }

        public IEnumerable<ThongTinTuyenDung> thongTinTuyenDung(string msnv)
        {
            var query = from A in DbContext.thongTinTuyenDungs
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;
        }
    }
}
