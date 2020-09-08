
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IChucVuRepository : IRepository<ChucVu>
    {
        IEnumerable<ChucVu> getChucVu(string msnv);
        getChucVu getChucVu1(string msnv);
    }

  public  class ChucVuRepository : RepositoryBase<ChucVu>, IChucVuRepository
    {
        public ChucVuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ChucVu> getChucVu(string msnv)
        {
            var query = from p in DbContext.chucVus
                        join a in DbContext.NhanVien
                        on p.MaChucVu equals a.MaChucVu
                        where a.MaSoNhanVien.Equals(msnv)
                        select p;
            return query;
        }

        public getChucVu getChucVu1(string msnv)
        {
            var query = from p in DbContext.chucVus
                         join a in DbContext.NhanVien
                         on p.MaChucVu equals a.MaChucVu
                         where a.MaSoNhanVien.Equals(msnv)
                         select new getChucVu()
                         {
                             MaChucVu = p.MaChucVu,
                             TenChucVu = p.TenChucVu
                         };
            return query.First();
        }
    }
}