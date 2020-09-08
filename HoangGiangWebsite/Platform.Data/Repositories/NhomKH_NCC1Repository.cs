
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface INhomKH_NCC1Repository : IRepository<NhomKH_NCC1>
    {

    }

   public class NhomKH_NCC1Repository : RepositoryBase<NhomKH_NCC1>, INhomKH_NCC1Repository
    {
        public NhomKH_NCC1Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
