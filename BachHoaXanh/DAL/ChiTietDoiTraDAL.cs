using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietDoiTraDAL
    {
        ChiTietDoiTraTableAdapter ctdt = new ChiTietDoiTraTableAdapter();
        public DataTable GetDataTheoMaDoi(string madoi)
        {
            return ctdt.GetDataByMaDoi(madoi);
        }
        public bool Insert(string madoi, string masp, int sld)
        {
            if (ctdt.Insert(madoi, masp, sld) > 0)
                return true;
            return false;
        }
    }
}
