using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HSDSanPhamDAL
    {
        HSDSanPhamTableAdapter hsdsp = new HSDSanPhamTableAdapter();
        public DataTable GetDataTheoMaSP(string masp)
        {
            return hsdsp.GetDataByMaSP(masp);
        }
        public DataTable GetDataHH()
        {
            return hsdsp.GetDataByHetHan();
        }

        public bool insertHSD(string masp, DateTime hsd, int sl)
        {
            if (hsdsp.InsertHSD(masp, hsd.ToShortDateString(), sl) > 0)
                return true;
            else
                return false;
        }
       
        public DataTable timHSDMin(string masp)
        {
            return hsdsp.TimHSDMin(masp);
        }
       
        public bool updateSL_TinhTrangHH(int sl, string tt , string masp, string hsd)
        {
            if (hsdsp.UpdateSL_TT(sl, tt, masp, hsd) > 0)
                return true;
            else
                return false;
        }
        public bool UpdateTT(string tt, string masp, string hsd)
        {
            if (hsdsp.Update_TT(tt, masp, hsd) > 0)
                return true;
            return false;
           
        }
    }
}
