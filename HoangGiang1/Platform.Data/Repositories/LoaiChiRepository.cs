using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILoaiChiRepository : IRepository<LoaiChi>
    {

    
    }

    class LoaiChiRepository : RepositoryBase<LoaiChi>, ILoaiChiRepository
    {
        public LoaiChiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
