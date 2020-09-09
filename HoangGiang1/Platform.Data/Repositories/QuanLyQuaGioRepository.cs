using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IQuanLyQuaGioRepository : IRepository<QuanLyQuaGio>
    {
        IEnumerable<QuanLyQuaGio> GetQuanLyQuaGio(string msnv);
        QuanLyQuaGio getID(int ID);

    }

    class QuanLyQuaGioRepository : RepositoryBase<QuanLyQuaGio>, IQuanLyQuaGioRepository
    {
        public QuanLyQuaGioRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public QuanLyQuaGio getID(int id)
        {
            var query = from A in DbContext.quanLyQuaGios
                        where A.ID.Equals(id)
                        select A;
            return query.First();
        }

        public IEnumerable<QuanLyQuaGio> GetQuanLyQuaGio(string msnv)
        {
            var query = from A in DbContext.quanLyQuaGios
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;   
        }
    }
}
