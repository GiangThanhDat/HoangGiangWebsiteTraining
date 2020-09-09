
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IQuaTrinhDaoTaoRepository : IRepository<QuaTrinhDaoTao>
    {
        IEnumerable<QuaTrinhDaoTao> GetQuaTrinhDaoTao(string msnv);
        QuaTrinhDaoTao getID(int ID);
    }

    class QuaTrinhDaoTaoRepository : RepositoryBase<QuaTrinhDaoTao>, IQuaTrinhDaoTaoRepository
    {
        public QuaTrinhDaoTaoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public QuaTrinhDaoTao getID(int ID)
        {
            var query = from A in DbContext.quaTrinhDaoTaos
                        where A.ID.Equals(ID)
                        select A;
            return query.First();
        }

        public IEnumerable<QuaTrinhDaoTao> GetQuaTrinhDaoTao(string msnv)
        {
            var query = from A in DbContext.quaTrinhDaoTaos
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;
        }
    }
}