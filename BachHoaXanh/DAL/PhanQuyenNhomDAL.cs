using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanQuyenNhomDAL
    {
        PhanQuyenNhomTableAdapter pnn = new PhanQuyenNhomTableAdapter();
        public bool KiemTraQuyen(string mannv, string mamh)
        {
            return (bool)pnn.KiemTraQuyen(mannv, mamh);
        }
    }
}
