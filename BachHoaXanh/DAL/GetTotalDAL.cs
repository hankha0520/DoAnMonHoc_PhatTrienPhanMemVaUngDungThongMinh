using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GetTotalDAL
    {
        GetTotalTableAdapter tt = new GetTotalTableAdapter();
        public DataTable GetData()
        {
            return tt.GetData();
        }
    }
}
