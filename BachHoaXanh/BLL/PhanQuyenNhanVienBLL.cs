using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhanQuyenNhanVienBLL
    {
        PhanQuyenNhanVienDAL pqnv = new PhanQuyenNhanVienDAL();
        public string timNhomNV(string manv)
        {
            return pqnv.timMaNhomNVTheoMaNV(manv);
        }
        public bool deletePhanQuyenNhanVien(string manv)
        {
            return pqnv.deletePhanQuyenNhanVien(manv);
        }
        public bool DeletePhanQuyenNhanVien(string mannv, string manv)
        {
            return pqnv.DeletePhanQuyenNhanVien(mannv, manv);
        }
        public DataTable GetData()
        {
            return pqnv.GetData();
        }
        public bool insertPhanQuyenNhanVien(string mannv, string manv)
        {
            return pqnv.insertPhanQuyenNhanVien(mannv, manv);
        }

    }
}
