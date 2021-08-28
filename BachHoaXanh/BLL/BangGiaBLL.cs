using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BangGiaBLL
    {
        BangGiaDAL bg = new BangGiaDAL();
        public DataTable GetData()
        {
            return bg.GetData();
        }
        public DataTable GetBangGia(string ma)
        {
            return bg.GetDataBG(ma);
        }
        public DataTable getGiaBanKM(string MaSP)
        {
            return bg.GetGiaBanKM(MaSP);
        }
        public bool deleteBangGia(string ma)
        {
            return bg.deleteBangGia(ma);
        }
        public DataTable GetDataChuaCoGia()
        {
            return bg.GetDataChuaCoGia();
        }
        public bool UpdateGiaBan(float giaban, string ngayAD, string masp)
        {
            return bg.UpdateGiaBan(giaban, ngayAD, masp);
        }
    }
}
