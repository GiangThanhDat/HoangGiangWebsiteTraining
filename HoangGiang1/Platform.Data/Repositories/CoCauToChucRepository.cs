using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ICoCauTocChucRepository : IRepository<CoCauToChuc>
    {
      

    }

    class CoCauTocChucRepository : RepositoryBase<CoCauToChuc>, ICoCauTocChucRepository
    {
        public CoCauTocChucRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}
