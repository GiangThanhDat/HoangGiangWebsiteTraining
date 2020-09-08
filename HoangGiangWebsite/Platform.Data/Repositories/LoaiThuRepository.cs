﻿using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ILoaiThuRepository : IRepository<LoaiThu>
    {

    
    }

    class LoaiThuRepository : RepositoryBase<LoaiThu>, ILoaiThuRepository
    {
        public LoaiThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       



    }
}