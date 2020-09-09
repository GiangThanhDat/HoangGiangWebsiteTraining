
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IThongTinCaNhanRepository : IRepository<ThongTinCaNhan>
    {
       
       ThongTinCaNhan GetLyLich(string msvc);
    }

    class ThongTinCaNhanRepository : RepositoryBase<ThongTinCaNhan>, IThongTinCaNhanRepository
    {
        public ThongTinCaNhanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ThongTinCaNhan GetLyLich(string msvc)
        {
            var query = from A in DbContext.ThongTinCaNhans


                        where A.MaSoVC.Equals(msvc)
                        select A;
                        
            return query.First();
        }

        
    }
}