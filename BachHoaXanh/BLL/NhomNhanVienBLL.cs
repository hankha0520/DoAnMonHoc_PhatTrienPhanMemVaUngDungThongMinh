using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhomNhanVienBLL
    {
        NhomNhanVienDAL nnv = new NhomNhanVienDAL();
        public DataTable GetData()
        {
            return nnv.GetData();
        }
    }
}
