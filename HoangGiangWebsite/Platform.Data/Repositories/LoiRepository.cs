
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface ILoiRepository : IRepository<Loi>
    {

    }

    class LoiRepository : RepositoryBase<Loi>, ILoiRepository
    {
        public LoiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
