using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IDinhKhoanTuDongRepository : IRepository<DinhKhoanTuDong>
    {
      

    }

    class DinhKhoanTuDongRepository : RepositoryBase<DinhKhoanTuDong>, IDinhKhoanTuDongRepository
    {
        public DinhKhoanTuDongRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}
