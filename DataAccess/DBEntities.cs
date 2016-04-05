using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Test.Common.Model;

namespace Test.DataAccess
{
    public class ChuanNongDBContext : DbContext
    {
        public ChuanNongDBContext()
                : base("ConnectionString")
        {

        }

        public DbSet<b_MingZu> b_MingZu { get; set; }
        public DbSet<b_XiaoQu> b_XiaoQu { get; set; }
        public DbSet<b_XueLi> b_XueLi { get; set; }

    }
}
