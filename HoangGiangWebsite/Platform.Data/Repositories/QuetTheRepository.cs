
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IQuetTheRepository : IRepository<QuetThe>
    {
       
    }

  public  class QuetTheRepository : RepositoryBase<QuetThe>, IQuetTheRepository
    {
        public QuetTheRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

      
    }
}