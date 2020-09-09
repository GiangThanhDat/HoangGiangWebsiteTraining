using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChungTuMuaHangRepository : IRepository<ChungTuMuaHang>
    {

    
    }

    class ChungTuMuaHangRepository : RepositoryBase<ChungTuMuaHang>, IChungTuMuaHangRepository
    {
        public ChungTuMuaHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
