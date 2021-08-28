using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nv = new NhanVienDAL();
        public DataTable GetNhanVien()
        {
            return nv.GetDataNV();
        }
        public DataTable GetNVTheoMa(string manv)
        {
            return nv.GetDataTheoMa(manv);
        }
        public string LayMaNVMax()
        {
            return nv.layMaNVMax();
        }
        public int? ktkc(string manv)
        {
            return nv.ktKhoaChinh(manv);
        }
        public bool insertNhanVien(string manv, string tennv, DateTime ngaysinh, string gioitinh, string diachi, string sdt, string email, string matkhau, string hinh, DateTime ngayVL, string cmt)
        {
            return nv.insertNhanVien(manv, tennv, ngaysinh, gioitinh, diachi, sdt, email, matkhau, hinh, ngayVL, cmt);
        }
        public bool updateNhanVien(string tennv, string ngaysinh, string gioitinh, string diachi, string sdt, string email, string matkhau, string hinh, string ngayVL, string cmt, string manv)
        {
            return nv.updateNhanVien(tennv, ngaysinh, gioitinh, diachi, sdt, email, matkhau, hinh, ngayVL, cmt, manv);

        }
        public bool deleteNhanVien(string manv)
        {
            return nv.deleteNhanVien(manv);
        }

        public DataTable nvChuaPhanQuyen()
        {
            return nv.nvChuaPhanQuyen();
        }
        public string LayTenNV(string manv)
        {
            return nv.LayTenNV(manv);
        }
        public DataTable getDN(string manv, string mk)
        {
            return nv.getDN(manv, mk);
        }
        public bool updateTTNhanVien(string diachi, string sdt, string manv)
        {
            return (nv.updateTTNhanVien(diachi, sdt, manv));

        }
    
}
}
