using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietDoiTraBLL
    {
        ChiTietDoiTraDAL ctdt = new ChiTietDoiTraDAL();
        public DataTable GetDataTheoMaDoi(string madoi)
        {
            return ctdt.GetDataTheoMaDoi(madoi);
        }
        public bool Insert(string madoi, string masp, int sld)
        {
            return ctdt.Insert(madoi, masp, sld);
        }
    }
}
