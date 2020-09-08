using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IHeThongTaiKhoanRepository : IRepository<HeThongTaiKhoan>
    {
      

    }

    class HeThongTaiKhoanRepository : RepositoryBase<HeThongTaiKhoan>, IHeThongTaiKhoanRepository
    {
        public HeThongTaiKhoanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}
