using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietChungTuMuaHangRepository : IRepository<ChiTietChungTuMuaHang>
    {

    
    }

    class ChiTietChungTuMuaHangRepository : RepositoryBase<ChiTietChungTuMuaHang>, IChiTietChungTuMuaHangRepository
    {
        public ChiTietChungTuMuaHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
