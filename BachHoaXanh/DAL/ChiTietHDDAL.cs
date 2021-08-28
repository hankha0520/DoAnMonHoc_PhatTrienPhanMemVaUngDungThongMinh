using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietHDDAL
    {
        ChiTietHoaDonTableAdapter cthd = new ChiTietHoaDonTableAdapter();
        LinqBHXDataContext bhx = new LinqBHXDataContext();
        public DataTable GetDataCTHD(string mahd)
        {
            return cthd.GetDataByMaHD(mahd);
        }
        public bool themCTHD(string MaHD, string MaSP, int sl, float gb, float tt)
        {
            if (cthd.Insert(MaHD, MaSP, sl, gb, tt) > 0)
                return true;
            return false;
        }
        public void GetCTHDTheoMaHD(Guna.UI2.WinForms.Guna2DataGridView dgv, string MaHD)
        {
            var cthds = from cthd in bhx.ChiTietHoaDons join k in bhx.SanPhams on cthd.MaSP equals k.MaSP where cthd.MaHD == MaHD select new { msp = cthd.MaSP, tsp = k.TenSP, dvt = k.DVT, sl = cthd.SoLuong, gb = cthd.GiaBan, tt = cthd.ThanhTien };
            dgv.DataSource = cthds;
        }
        public bool Sua(string Mahd, string masp, int sl, float tt)
        {
            if (cthd.UpdateCTHD(sl,tt, Mahd, masp) > 0)
                return true;
            return false;
        }
        public bool xoa(string mahd, string masp)
        {
            if (cthd.DeleteQuery(mahd, masp) > 0)
                return true;
            return false;
        }
    }
}
