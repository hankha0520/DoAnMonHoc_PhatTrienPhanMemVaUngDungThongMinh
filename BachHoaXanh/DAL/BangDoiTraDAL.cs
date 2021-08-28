using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BangDoiTraDAL
    {
        BangTraDoiTableAdapter dt = new BangTraDoiTableAdapter();
        public DataTable GetData()
        {
            return dt.GetData();
        }
        public DataTable GetDataChuaHuy()
        {
            return dt.GetDataByChuaHuy();
        }
        public bool Insert(string madoi, string manv, string mahd, DateTime ngayDoi)
        {
            if (dt.Insert(madoi, manv, mahd, ngayDoi) > 0)
                return true;
            return false;
        }
        public string layMaDoi()
        {
            try
            {
                return dt.LayMaDoiMax().ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}
