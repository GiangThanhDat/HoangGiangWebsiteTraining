using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITinhChatHangHoaRepository : IRepository<TinhChatHangHoa>
    {

    
    }

    class TinhChatHangHoaRepository : RepositoryBase<TinhChatHangHoa>, ITinhChatHangHoaRepository
    {
        public TinhChatHangHoaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}
