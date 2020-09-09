
using Platform.Data.Infrastructure;

namespace Platform.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private QLTHDbContext dbContext;
       


        public QLTHDbContext Init()
        {
            return dbContext ?? (dbContext = new QLTHDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            { dbContext.Dispose();
               
            }

        }
       

       
    }
}