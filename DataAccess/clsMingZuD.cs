using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Model;

namespace Test.DataAccess
{
    public class clsMingZuD
    {
        private ChuanNongDBContext db;

        public clsMingZuD()
        {
            this.db = new ChuanNongDBContext();
        }

        public IQueryable<b_MingZu> GetMingZus()
        {
            return this.db.b_MingZu.Where(m => m.ZhuangTai == 0).OrderBy(m => m.PaiXu).ThenBy(m => m.MingZu);
        }

        public int UpdateMingZu(string strYuanMingZu, string strXinMingZu)
        {
            return this.db.Database.ExecuteSqlCommand(string.Format("UPDATE b_MingZu SET MingZu='{0}' WHERE MingZu='{1}'", strXinMingZu, strYuanMingZu));
        }

        public int UpdateMingZu(b_MingZu b_mingzu, string strXinMingZu)
        {
            using(DbConnection con = ((IObjectContextAdapter)db).ObjectContext.Connection)
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    db.Entry(b_mingzu).State = EntityState.Modified;
                    db.SaveChanges();
                    this.db.Database.ExecuteSqlCommand(string.Format("UPDATE b_MingZu SET MingZu='{0}' WHERE MingZu='{1}'", strXinMingZu, b_mingzu.MingZu));

                    tran.Commit();
                    /*
                    try
                    {
                        this.db.Database.ExecuteSqlCommand("SELECT 1/0");
                    }
                    catch(Exception err)
                    {
                        tran.Rollback();
                        db.Entry(b_mingzu).Reload();
                        throw err;
                    }
                    */
                }
            }
            return 1;
        }

    }
}
