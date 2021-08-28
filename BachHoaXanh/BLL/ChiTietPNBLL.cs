using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChiTietPNBLL
    {
        ChiTietPNDAL ctpn = new ChiTietPNDAL();
        public DataTable GetCTPN(string ma)
        {
            return ctpn.GetDataCTPN(ma);
        }
        public bool InsertCTPN(string mapn, string masp, int slnhap, string ghichu, DateTime nsx, DateTime hsd)
        {
            return ctpn.InsertCTPN(mapn, masp, slnhap, ghichu, nsx, hsd);
        }
        public void getCTPN(Guna.UI2.WinForms.Guna2DataGridView dgv, string MaPN)
        {
            ctpn.GetCTPNTheoMaPN(dgv, MaPN);
        }
        public bool DeleteCTPN(string mapn)
        {
            return ctpn.DeleteCTPN(mapn);
        }
    }
}
