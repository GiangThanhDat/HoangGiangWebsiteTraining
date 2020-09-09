using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface INgonNguRepository : IRepository<NgonNgu>
    {
        IEnumerable<NgonNgu> ngonNgu(string msnv);
        NgonNgu getID(int ID);
    }

    class NgonNguRepository : RepositoryBase<NgonNgu>, INgonNguRepository
    {
        public NgonNguRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public NgonNgu getID(int ID)
        {
            var query = from A in DbContext.ngonNgus
                        where A.ID.Equals(ID)
                        select A;
            return query.First();
        }

        public IEnumerable<NgonNgu> ngonNgu(string msnv)
        {
            var query = from A in DbContext.ngonNgus
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;

        }

    }
}
