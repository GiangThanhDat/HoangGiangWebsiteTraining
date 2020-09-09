
using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{

    public interface IThongBaoRepository : IRepository<ThongBao>
    {
       
        IEnumerable<ThongBao> GetThongBao( string mssv);
        IQueryable<ThongBao> chitietTB(int MaSoTB);									   
    }

    class ThongBaoRepository : RepositoryBase<ThongBao>, IThongBaoRepository
    {
        public ThongBaoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        // cach goi 10 thong bao dau tien
         public IQueryable<ThongBao> chitietTB(int MaSoTB)
        {
            var query = from A in DbContext.ThongBao
                        where A.MaSoTB == MaSoTB
                        select A;
            return query;
        }

        public IEnumerable<ThongBao> GetThongBao(string mssv)
        {
            IQueryable<ThongBao> query = from p in DbContext.ThongBao
                                         orderby p.NgayThongBao descending
                                         select p;

									 

																		  

            return query;
        }

        // cach goi 10 thong bao dau tien
   
        //public IQueryable<ThongBao> GetThongBao(string tag, int pageIndex, int pageSize, out int totalRow)
        //{
        //    IQueryable<ThongBao> custQuery3 =
        //    (from custs in DbContext.ThongBaos                    
        //    orderby custs.NgayThongBao descending
        //    select custs).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    totalRow = custQuery3.Count();
        //    return custQuery3;

        //}

    }
}

