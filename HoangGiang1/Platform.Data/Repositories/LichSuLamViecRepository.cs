using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILichSuLamViecRepository : IRepository<LichSuLamViec>
    {
        IEnumerable<LichSuLamViec> GetLichSuLamViec(string msnv);
        LichSuLamViec getID(int id);

    }

    class LichSuLamViecRepository : RepositoryBase<LichSuLamViec>, ILichSuLamViecRepository
    {
        public LichSuLamViecRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public LichSuLamViec getID(int id)
        {
            var query = from A in DbContext.lichSuLamViecs
                        where A.ID.Equals(id)
                        select A;
            return query.First();

        }

        public IEnumerable<LichSuLamViec> GetLichSuLamViec(string msnv)
        {
            var query = from A in DbContext.lichSuLamViecs
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;

        }

    }
}
