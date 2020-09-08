using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IDonViTinhRepository : IRepository<DonViTinh>
    {

    
    }

    class DonViTinhRepository : RepositoryBase<DonViTinh>, IDonViTinhRepository
    {
        public DonViTinhRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
