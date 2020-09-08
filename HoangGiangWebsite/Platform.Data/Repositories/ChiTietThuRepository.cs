using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietThuRepository : IRepository<ChiTietThu>
    {

    
    }

    class ChiTietThuRepository : RepositoryBase<ChiTietThu>, IChiTietThuRepository
    {
        public ChiTietThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
