using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietPhieuChiRepository : IRepository<ChiTietPhieuChi>
    {

    
    }

    class ChiTietPhieuChiRepository : RepositoryBase<ChiTietPhieuChi>, IChiTietPhieuChiRepository
    {
        public ChiTietPhieuChiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
