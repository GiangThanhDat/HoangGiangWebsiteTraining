using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITaiKhoanCoRepository : IRepository<TaiKhoanCo>
    {

    
    }

    class TaiKhoanCoRepository : RepositoryBase<TaiKhoanCo>, ITaiKhoanCoRepository
    {
        public TaiKhoanCoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
