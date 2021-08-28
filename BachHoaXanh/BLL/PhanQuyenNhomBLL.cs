using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhanQuyenNhomBLL
    {
        public PhanQuyenNhomBLL()
        { }
        PhanQuyenNhomDAL pqn = new PhanQuyenNhomDAL();
        public bool KiemTraQuyen(string mannv, string mamh)
        {
            return pqn.KiemTraQuyen(mannv, mamh);
        }
    }
}
