using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IHoanThanhCongViecRepository : IRepository<HoanThanhCongViec>
    {
        IEnumerable<HoanThanhCongViec> GetHoanThanhCongViec(string msnv);
        HoanThanhCongViec getID(int id);
      
    }

    class HoanThanhCongViecRepository : RepositoryBase<HoanThanhCongViec>, IHoanThanhCongViecRepository { 
        public HoanThanhCongViecRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<HoanThanhCongViec> GetHoanThanhCongViec(string msnv)
        {
            var query = from A in DbContext.hoanThanhCongViecs
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;
                        
        }

        public HoanThanhCongViec getID(int id)
        {
            var query = from A in DbContext.hoanThanhCongViecs
                        where A.ID.Equals(id)
                        select A;
            return query.First();
        }
    }
}
