using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILoaiTaiSanCoDinhRepository : IRepository<LoaiTaiSanCoDinh>
    {
    
    }

    class LoaiTaiSanCoDinhRepository : RepositoryBase<LoaiTaiSanCoDinh>, ILoaiTaiSanCoDinhRepository
    {
        public LoaiTaiSanCoDinhRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       
    }
}
