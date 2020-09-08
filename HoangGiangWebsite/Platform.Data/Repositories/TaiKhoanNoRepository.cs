using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITaiKhoanNoRepository : IRepository<TaiKhoanNo>
    {

    
    }

    class TaiKhoanNoRepository : RepositoryBase<TaiKhoanNo>, ITaiKhoanNoRepository
    {
        public TaiKhoanNoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
