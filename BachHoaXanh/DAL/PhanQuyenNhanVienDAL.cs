using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanQuyenNhanVienDAL
    {
        PhanQuyenNhanVienTableAdapter pqnv = new PhanQuyenNhanVienTableAdapter();


        //public DataTable GetDataTheoNhom(string mannv)
        //{
        //    return pqnv.GetDataByTimNVTheoNhom(mannv);
        //}
        public string timMaNhomNVTheoMaNV(string manv)
        {
            return pqnv.TimMaNhomTheoMaNV(manv);
        }
       
        public bool deletePhanQuyenNhanVien(string manv)
        {
            if (pqnv.DeletePhanQuyenNhanVien(manv) > 0)
                return true;
            return false;
        }
        public bool DeletePhanQuyenNhanVien(string mannv, string manv)
        {
            if (pqnv.Delete(mannv, manv) > 0)
                return true;
            return false;
        }
        public DataTable GetData()
        {
            return pqnv.GetData();
        }
        public bool insertPhanQuyenNhanVien(string mannv, string manv)
        {
            if (pqnv.Insert(mannv, manv) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
