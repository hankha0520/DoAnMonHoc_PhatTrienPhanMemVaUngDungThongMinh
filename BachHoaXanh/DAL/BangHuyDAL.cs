using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BangHuyDAL
    {
        BangHuyTableAdapter bh = new BangHuyTableAdapter();
        public DataTable GetData()
        {
            return bh.GetData();
        }
        public string layMaHuy()
        {
            try
            {
                return bh.LayMaHuyMax().ToString();
            }
            catch
            {
                return null;
            }
        }
        public bool ThemBH(string MaHuy, string MaNV, string LyDo, DateTime NgayHuy, string MaDoi)
        {
            try
            {
                if (bh.Insert(MaHuy, MaNV, LyDo, NgayHuy, MaDoi) > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }

        }
    }
}
