using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITaiKhoanNganHangRepository : IRepository<TaiKhoanNganHang>
    {

    
    }

    class TaiKhoanNganHangRepository : RepositoryBase<TaiKhoanNganHang>, ITaiKhoanNganHangRepository
    {
        public TaiKhoanNganHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
