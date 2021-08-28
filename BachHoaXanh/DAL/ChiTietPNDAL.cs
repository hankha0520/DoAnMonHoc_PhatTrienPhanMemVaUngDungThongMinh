using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPNDAL
    {
        ChiTietPhieuNhapTableAdapter ctpn = new ChiTietPhieuNhapTableAdapter();
        LinqBHXDataContext bhx = new LinqBHXDataContext();

        public DataTable GetDataCTPN(string ma)
        {
            return ctpn.GetDataByMaPN(ma);
        }
        public bool InsertCTPN(string mapn, string masp, int slnhap, string ghichu, DateTime nsx, DateTime hsd)
        {
            if (ctpn.Insert(mapn, masp, slnhap, ghichu, nsx, hsd) > 0)
                return true;
            return false;
        }
        public void GetCTPNTheoMaPN(Guna.UI2.WinForms.Guna2DataGridView dgv, string MaPN)
        {
            var ctpns = from ctpn in bhx.ChiTietPhieuNhaps join k in bhx.SanPhams on ctpn.MaSP equals k.MaSP where ctpn.MaPN == MaPN select new { msp = ctpn.MaSP, tsp = k.TenSP, sl = ctpn.SoLuongNhap, nsx = ctpn.NSX, hsd = ctpn.HSD };
            dgv.DataSource = ctpns;
        }
        public bool DeleteCTPN(string mapn)
        {
            if (ctpn.DeleteCTPN(mapn) > 0)
                return true;
            return false;
        }
    }
}
