using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITaiKhoanKetChuyenRepository : IRepository<TaiKhoanKetChuyen>
    {
      

    }

    class TaiKhoanKetChuyenRepository : RepositoryBase<TaiKhoanKetChuyen>, ITaiKhoanKetChuyenRepository
    {
        public TaiKhoanKetChuyenRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}
