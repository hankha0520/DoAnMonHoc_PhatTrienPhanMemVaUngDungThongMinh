using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class GetTotalBLL
    {
        GetTotalDAL tt = new GetTotalDAL();
        public DataTable GetData()
        {
            return tt.GetData();
        }
    }
}
