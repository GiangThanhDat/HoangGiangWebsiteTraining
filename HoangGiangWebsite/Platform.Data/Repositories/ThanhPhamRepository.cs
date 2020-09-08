using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IThanhPhamRepository : IRepository<ThanhPham>
    {

    
    }

    class ThanhPhamRepository : RepositoryBase<ThanhPham>, IThanhPhamRepository
    {
        public ThanhPhamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
