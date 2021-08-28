using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        NhanVienTableAdapter nv = new NhanVienTableAdapter();
        public DataTable GetDataNV()
        {
            return nv.GetData();
        }
        public DataTable GetDataTheoMa(string maNV)
        {
            return nv.GetDataByTheoMa(maNV);
        }
        public string layMaNVMax()
        {
            try
            {
                return nv.LayMaNVMax().ToString();
            }
            catch
            {
                return null;
            }
        }
        public int? ktKhoaChinh(string manv)
        {
            try
            {
                return nv.KTKC(manv);
            }
            catch
            {
                return 0;
            }
        }
        public bool insertNhanVien(string manv, string tennv, DateTime ngaysinh, string gioitinh, string diachi, string sdt, string email, string matkhau, string hinh, DateTime ngayVL, string cmt)
        {
            if (nv.Insert(manv, tennv, ngaysinh, gioitinh, diachi, sdt, email, matkhau, hinh, ngayVL, cmt) > 0)
                return true;
            return false;
        }
        public bool updateNhanVien(string tennv, string ngaysinh, string gioitinh, string diachi, string sdt, string email, string matkhau, string hinh, string ngayVL, string cmt, string manv)
        {
            if (nv.UpdateNhanVien(tennv, ngaysinh, gioitinh, diachi, sdt, email, matkhau, hinh, ngayVL, cmt, manv) > 0)
                return true;
            return false;
        }
        public bool deleteNhanVien(string manv)
        {
            if (nv.DeleteNhanVien(manv) > 0)
                return true;
            return false;
        }
        public DataTable nvChuaPhanQuyen()
        {
            return nv.GetDataByNVChuaPQ();
        }
        public string LayTenNV(string manv)
        {
            return nv.layTenNV(manv);
        }
        public DataTable getDN(string MaNV, string MK)
        {
            return nv.GetDataByKTDN(MaNV, MK);
        }
        public bool updateTTNhanVien(string diachi, string sdt, string manv)
        {
            if (nv.Update_TTNV(diachi, sdt, manv) > 0)
                return true;
            return false;
        }
    }

}
