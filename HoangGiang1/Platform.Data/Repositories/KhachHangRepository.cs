
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IKhachHangRepository : IRepository<KhachHang>
    {

    }

   public class KhachHangRepository : RepositoryBase<KhachHang>, IKhachHangRepository
    {
        public KhachHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
