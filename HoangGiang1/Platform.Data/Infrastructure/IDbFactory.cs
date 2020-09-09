using System;

namespace Platform.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        QLTHDbContext Init();
    }
   
}