using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IDieuKhoanTTRepository : IRepository<DieuKhoanTT>
    {

    
    }

    class DieuKhoanTTRepository : RepositoryBase<DieuKhoanTT>, IDieuKhoanTTRepository
    {
        public DieuKhoanTTRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
