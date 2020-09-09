
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IQuanLyNhaCungCapRepository : IRepository<NhaCungCap>
    {
        NhaCungCap getThongTinNhaCungCap(string name);
    }

    class QuanLyNhaCungCapRepository : RepositoryBase<NhaCungCap>, IQuanLyNhaCungCapRepository
    {
        public QuanLyNhaCungCapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public NhaCungCap getThongTinNhaCungCap(string name)
        {
            var query = from A in DbContext.nhaCungCaps
                        where A.MaNhaCungCap.Equals(name)
                        select A;
            return query.First();
        }
    }
}
