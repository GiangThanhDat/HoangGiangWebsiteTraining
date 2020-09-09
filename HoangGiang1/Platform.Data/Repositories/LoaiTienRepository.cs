using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILoaiTienRepository : IRepository<LoaiTien>
    {

    
    }

    class LoaiTienRepository : RepositoryBase<LoaiTien>, ILoaiTienRepository
    {
        public LoaiTienRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
