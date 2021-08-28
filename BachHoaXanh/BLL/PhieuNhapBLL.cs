using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PhieuNhapBLL
    {
        PhieuNhapDAL pn = new PhieuNhapDAL();
        public DataTable GetPhieuNhap()
        {
            return pn.GetDataPN();
        }
        public DataTable GetDataChuaNhap()
        {
            return pn.GetDataChuaNhap();
        }
        public bool updatePN(string mapn, string ngayNhap, string manv, string ttn)
        {
            return pn.UpdatePN(mapn, ngayNhap, manv, ttn);
        }
        public string LayMaPNMax()
        {
            return pn.layMaPNMax();
        }
        public bool InsertPN(string mapn, string tinhTrangNhap)
        {
            return pn.InsertPN(mapn, tinhTrangNhap);
        }
        public DataTable GetDataTheoMaPN(string mapn)
        {
            return pn.GetDataTheoMaPN(mapn);
        }
        public bool DeletePN(string mapn)
        {
            return pn.DeletePN(mapn);
        }
    }
}
