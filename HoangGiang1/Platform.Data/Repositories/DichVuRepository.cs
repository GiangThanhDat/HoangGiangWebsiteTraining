using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IDichVuRepository : IRepository<DichVu>
    {

    
    }

    class DichVuRepository : RepositoryBase<DichVu>, IDichVuRepository
    {
        public DichVuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
