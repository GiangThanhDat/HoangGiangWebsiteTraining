using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITinhTrangRepository : IRepository<TinhTrang>
    {

    
    }

    class TinhTrangRepository : RepositoryBase<TinhTrang>, ITinhTrangRepository
    {
        public TinhTrangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
