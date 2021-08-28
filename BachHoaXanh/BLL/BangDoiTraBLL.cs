using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BangDoiTraBLL
    {
        BangDoiTraDAL dt = new BangDoiTraDAL();
        public DataTable GetData()
        {
            return dt.GetData();
        }
        public DataTable GetDataChuaHuy()
        {
            return dt.GetDataChuaHuy();
        }
        public bool Insert(string madoi, string manv, string mahd, DateTime ngayDoi)
        {
            return dt.Insert(madoi, manv, mahd, ngayDoi);
        }
        public string LayMaDoiMax()
        {
            return dt.layMaDoi();
        }
    }
}
