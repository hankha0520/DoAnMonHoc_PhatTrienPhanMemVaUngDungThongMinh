using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietHuyDAL
    {

        ChiTietHuyTableAdapter cth = new ChiTietHuyTableAdapter();
        public DataTable GetDataTheoMaHuy(string mahuy)
        {
            return cth.GetDataByMaHuy(mahuy);
        }
        public bool themCTH(string MaHD, string MaSP, int sl)
        {
            if (cth.Insert(MaHD, MaSP, sl) > 0)
                return true;
            return false;
        }
    }
}
