using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhomNhanVienDAL
    {
        NhomNhanVienTableAdapter nnv = new NhomNhanVienTableAdapter();
        public DataTable GetData()
        {
            return nnv.GetData();
        }
    }
}
