using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface INhomHangHoaRepository : IRepository<NhomHangHoa>
    {
    
    }

    class NhomHangHoaRepository : RepositoryBase<NhomHangHoa>, INhomHangHoaRepository
    {
        public NhomHangHoaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       
    }
}
