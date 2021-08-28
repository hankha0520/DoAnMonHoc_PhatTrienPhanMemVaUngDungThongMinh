using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class ChiTietHuyBLL
    {
        ChiTietHuyDAL cth = new ChiTietHuyDAL();
        public DataTable GetDataTheoMaHuy(string mahuy)
        {
            return cth.GetDataTheoMaHuy(mahuy);
        }
        public bool insert(string MaHD, string MaSP, int sl)
        {
            return cth.themCTH(MaHD, MaSP, sl);
        }
    }
}
