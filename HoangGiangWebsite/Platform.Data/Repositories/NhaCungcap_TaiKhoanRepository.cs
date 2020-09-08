using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface INhaCungCap_TaiKhoanRepository : IRepository<NhaCungCap_TaiKhoan>
    {

    
    }

    class NhaCungCap_TaiKhoanRepository : RepositoryBase<NhaCungCap_TaiKhoan>, INhaCungCap_TaiKhoanRepository
    {
        public NhaCungCap_TaiKhoanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
