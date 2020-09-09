using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILoaiCongCuDungCuRepository : IRepository<LoaiCongCuDungCu>
    {
      

    }

    class LoaiCongCuDungCuRepository : RepositoryBase<LoaiCongCuDungCu>, ILoaiCongCuDungCuRepository
    {
        public LoaiCongCuDungCuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}
