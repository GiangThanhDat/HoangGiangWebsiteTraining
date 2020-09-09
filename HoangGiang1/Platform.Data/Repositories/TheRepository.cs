using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITheRepository : IRepository<The>
    {

        IEnumerable<The> the(string msnv);
        IQueryable<The> searchs(string name);
        The getID(int ID);
        IQueryable<gettennhanvienthe>  gettennhanvienthe();
    }

    class TheRepository : RepositoryBase<The>, ITheRepository
    {
        public TheRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public The getID(int ID)
        {
            var query = from A in DbContext.thes
                        where A.ID.Equals(ID)
                        select A;
            return query.First();
        }

        public IQueryable<gettennhanvienthe> gettennhanvienthe()
        {
            var query = from A in DbContext.thes
                        join B in DbContext.NhanVien
                        on A.MaSoNhanVien equals B.MaSoNhanVien
                        select new gettennhanvienthe()
                        {
                            MaSoNhanVien=B.MaSoNhanVien,
                            HoVaTen=B.HoVaTen

                        };
            return query;
        }

        public IQueryable<The> searchs(string name)
        {
            var query = from A in DbContext.thes
                        join B in DbContext.NhanVien
                        on A.MaSoNhanVien equals B.MaSoNhanVien
                        where A.MaSoNhanVien.Contains(name)||B.HoVaTen.Contains(name)||A.LoaiThe.Contains(name)
                        select A;
            return query;
        }

        public IEnumerable<The> the(string msnv)
        {
            var query = from A in DbContext.thes
                        where A.MaSoNhanVien.Equals(msnv)
                        select A;
            return query;
        }



    }
}
