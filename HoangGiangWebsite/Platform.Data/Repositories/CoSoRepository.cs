using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ICoSoRepository : IRepository<CoSo>
    {

        getCoSo getTenCoSo(string msnv);
    }

    class CoSoRepository : RepositoryBase<CoSo>, ICoSoRepository
    {
        public CoSoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

   

        public getCoSo getTenCoSo(string msnv)
        {
            var query = from A in DbContext.CoSo
                        join B in DbContext.NhanVien
                        on A.MaCoSo equals B.MaCoSo
                        where B.MaSoNhanVien.Equals(msnv)
                        select new getCoSo()
                        {
                            MaCoSo = A.MaCoSo,
                            TenCoSo = A.TenCoSo,
                        };
            return query.First();
        }

        
    }
}
