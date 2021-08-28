using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChiTietHDBLL
    {
        ChiTietHDDAL cthd = new ChiTietHDDAL();
        public DataTable GetChiTietHD(string ma)
        {
            return cthd.GetDataCTHD(ma);
        }
        public bool insert(string MaHD, string MaSP, int sl, float gb, float tt)
        {
            return cthd.themCTHD(MaHD, MaSP, sl, gb, tt);
        }
        public void getCTHD(Guna.UI2.WinForms.Guna2DataGridView dgv, string MaHD)
        {
            cthd.GetCTHDTheoMaHD(dgv, MaHD);
        }
        public bool Update(string MaHD, string MaSP, int sl, float tt)
        {
            return cthd.Sua(MaHD, MaSP, sl, tt);
        }
        public bool Delete(string MaHD, string MaSP)
        {
            return cthd.xoa(MaHD, MaSP);
        }
    }
}
