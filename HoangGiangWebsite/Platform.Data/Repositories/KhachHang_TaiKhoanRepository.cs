using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IKhachHang_TaiKhoanRepository : IRepository<KhachHang_TaiKhoan>
    {

    
    }

    class KhachHang_TaiKhoanRepository : RepositoryBase<KhachHang_TaiKhoan>, IKhachHang_TaiKhoanRepository
    {
        public KhachHang_TaiKhoanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
