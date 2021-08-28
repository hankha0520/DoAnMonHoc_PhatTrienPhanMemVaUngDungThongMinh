using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BangHuyBLL
    {
        BangHuyDAL bh = new BangHuyDAL();
        public DataTable GetData()
        {
            return bh.GetData();
        }
        public string LayMaHuyMax()
        {
            return bh.layMaHuy();
        }
        public bool insertBH(string MaHuy, string MaNV, string lyDo, DateTime NgayHuy, string MaDoi)
        {
            return bh.ThemBH(MaHuy, MaNV, lyDo, NgayHuy, MaDoi);

        }
    }

}
