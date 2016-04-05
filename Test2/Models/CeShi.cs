using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class CeShi
    {
        public int NianLing { get; set; }
        public string XingMing { get; set; }
    }

    public class CeShiDBContext : DbContext
    {
        public CeShiDBContext()
                : base("ConnectionString")
        {

        }

        public System.Data.Entity.DbSet<Test.Common.Model.b_MingZu> b_MingZu { get; set; }
    }
}