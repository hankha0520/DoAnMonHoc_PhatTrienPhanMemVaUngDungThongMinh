using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL hd = new HoaDonDAL();
        public DataTable GetHoaDon()
        {
            return hd.GetDataHD();
        }
        public string LayMaHDMax()
        {
            return hd.layMaHD();
        }

        public bool insert(string MaHD, DateTime NgayLap, float TongTien, string tTrang, string MaNV)
        {
            return hd.ThemHD(MaHD, NgayLap, TongTien, tTrang, MaNV);
        }
        public DataTable GetDataTheoMaHD(string mahd)
        {
            return hd.GetDataTheoMaHD(mahd);
        }
        public bool UpdateHD(string MaHD, string Manv, DateTime NgayLap)
        {
            return hd.CapNhat(MaHD, Manv, NgayLap);
        }
       
        public DataTable HDThang()
        {
            return hd.HDThang();
        }
      
    }
}
