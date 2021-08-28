using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL sp = new SanPhamDAL();
        public DataTable GetSanPham()
        {
            return sp.GetDataSP();
        }
        public string layTenSP(string masp)
        {
            return sp.layTenSP(masp);
        }
        public DataTable GetSanPhamTheoMa(string MaSP)
        {
            return sp.getSanPham(MaSP);
        }
        public int LayTongSLT(string MaSP)
        {
            return sp.LayTongSLT(MaSP);
        }
        public bool insertSP(string masp, string tensp, string hinhanh, string dvt, string loaiSP)
        {
            return sp.insertSP(masp, tensp, hinhanh, dvt, loaiSP);
        }
        public string layMaSPMax()
        {
            return sp.LayMaSPMax();
        }
        public bool updateSP(string tensp, string hinhanh, string dvt, string maloaisp, string masp)
        {
            return sp.updateSP(tensp, hinhanh, dvt, maloaisp, masp);
        }
        public bool deleteSP(string masp)
        {
            return sp.deleteSP(masp);
        }
    }
}
