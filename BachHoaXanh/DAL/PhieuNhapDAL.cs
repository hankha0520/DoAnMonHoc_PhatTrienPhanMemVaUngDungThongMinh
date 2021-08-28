using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhapDAL
    {
        PhieuNhapTableAdapter pn = new PhieuNhapTableAdapter();
        public DataTable GetDataPN()
        {
            return pn.GetData();
        }
        public DataTable GetDataChuaNhap()
        {
            return pn.GetDataByChuaNhap();
        }
        public bool UpdatePN(string mapn, string ngayNhap, string manv, string tinhTrangNhap)
        {
            if (pn.UpdatePN(ngayNhap, manv, tinhTrangNhap, mapn) > 0)
                return true;
            else
                return false;
        }
        public string layMaPNMax()
        {
            try
            {
                return pn.LayMaPNMax().ToString();
            }
            catch
            {
                return null;
            }
        }
        public bool InsertPN(string mapn, string tinhTrangNhap)
        {
            if (pn.InsertPN(mapn, tinhTrangNhap) > 0)
                return true;
            else
                return false;
        }
        public DataTable GetDataTheoMaPN(string mapn)
        {
            return pn.GetDataTheoMaPN(mapn);
        }
        public bool DeletePN(string mapn)
        {
            if (pn.DeletePN(mapn) > 0)
                return true;
            return false;
        }
    }
}
