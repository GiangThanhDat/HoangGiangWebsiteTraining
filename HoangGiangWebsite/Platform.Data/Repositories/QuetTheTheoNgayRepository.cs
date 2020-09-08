
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IQuetTheTheoNgayRepository : IRepository<QuetTheTheoNgay>
    {
       
    }

  public  class QuetTheTheoNgayRepository : RepositoryBase<QuetTheTheoNgay>, IQuetTheTheoNgayRepository
    {
        public QuetTheTheoNgayRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

      
    }
}