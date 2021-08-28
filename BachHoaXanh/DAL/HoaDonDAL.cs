using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        HoaDonTableAdapter hd = new HoaDonTableAdapter();
        public DataTable GetDataHD()
        {
            return hd.GetData();
        }
        public string layMaHD()
        {
            try
            {
                return hd.LayMaHDMax().ToString();
            }
            catch
            {
                return null;
            }
        }
        public bool ThemHD(string MaHD, DateTime NgayLap, float TongTien, string tTrang, string MaNV)
        {
            try
            {
                if (hd.Insert(MaHD, NgayLap, TongTien, tTrang, MaNV) > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }

        }
        public DataTable GetDataTheoMaHD(string mahd)
        {
            return hd.GetDataByMaHD(mahd);
        }
        public bool CapNhat(string MaHD, string Manv, DateTime NgayLap)
        {
            try
            {
                if (hd.UpdateHD(NgayLap, Manv, MaHD) > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
      
        public DataTable HDThang()
        {
            return hd.TimHDTrongThang();
        }
      
    }
}
