using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Model;
using Test.DataAccess;

namespace Test.BusinessRule
{
    public class clsMingZuR
    {
        public IQueryable<b_MingZu> GetMingZus()
        {
            return (new clsMingZuD()).GetMingZus();
        }

        public int UpdateMingZu(string strYuanMingZu, string strXinMingZu)
        {
            return (new clsMingZuD()).UpdateMingZu(strYuanMingZu, strXinMingZu);
        }


        public int UpdateMingZu(b_MingZu b_mingzu, string strYuanMingZu)
        {
            try
            {
                string strXinMingZu = b_mingzu.MingZu;
                b_mingzu.MingZu = strYuanMingZu;

                return (new clsMingZuD()).UpdateMingZu(b_mingzu, strXinMingZu);
            }
            catch(Exception e)
            {
                return -200;
            }
        }
    }
}
