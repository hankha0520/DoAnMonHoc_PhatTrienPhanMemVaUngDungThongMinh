using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BangGiaDAL
    {
        BangGiaTableAdapter bg = new BangGiaTableAdapter();
        public DataTable GetData()
        {
            return bg.GetData();
        }
        public DataTable GetDataBG(string ma)
        {
            return bg.GetDataByMaSP(ma);
        }
        public DataTable GetGiaBanKM(string MaSP)
        {
            return bg.GetDataByGia(MaSP);
        }
        public bool deleteBangGia(string ma)
        {
            if (bg.DeleteBangGia(ma) > 0)
                return true;
            return false;
        }
        public DataTable GetDataChuaCoGia()
        {
            return bg.GetDataByChuaCoGia();
        }
        public bool UpdateGiaBan(float giaban, string ngayAD, string masp)
        {
            if (bg.UpdateGiaBan(giaban, ngayAD, masp) > 0)
                return true;
            return false;
        }
    }
}
