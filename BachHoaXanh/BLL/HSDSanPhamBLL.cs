using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HSDSanPhamBLL
    {
        HSDSanPhamDAL hsdsp = new HSDSanPhamDAL();
        public DataTable GetDataTheoMaSP(string masp)
        {
            return hsdsp.GetDataTheoMaSP(masp);
        }
        public DataTable GetDataHH()
        {
            return hsdsp.GetDataHH();
        }
        public bool insertHSD(string masp, DateTime hsd, int sl)
        {
            return hsdsp.insertHSD(masp, hsd, sl);
        }
      
       
        public DataTable timHSDMin(string masp)
        {
            return hsdsp.timHSDMin(masp);
        }
        public bool updateSL_TinhTrangHH(int sl, string tt, string masp, string hsd)
        {
            return hsdsp.updateSL_TinhTrangHH(sl, tt, masp, hsd);
        }
        public bool updateTinhTrangHH(string tt, string masp, string hsd)
        {
            return hsdsp.UpdateTT(tt, masp, hsd);
        }
    }
}
