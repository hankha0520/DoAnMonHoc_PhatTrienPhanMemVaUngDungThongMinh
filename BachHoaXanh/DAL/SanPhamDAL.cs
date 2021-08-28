using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        SanPhamTableAdapter sp = new SanPhamTableAdapter();
        public DataTable GetDataSP()
        {
            return sp.GetData();
        }
        public string layTenSP(string masp)
        {
            return sp.layTenSP(masp).ToString();
        }
        public DataTable getSanPham(string MaSP)
        {
            return sp.GetDataByTheoMaSP(MaSP);
        }
        public int LayTongSLT(string MaSP)
        {
            if (sp.LayTongSLTon(MaSP) == null)
                return 0;
            else
                return int.Parse(sp.LayTongSLTon(MaSP).ToString());           
        }
        public bool insertSP(string masp, string tensp, string hinhanh, string dvt, string loaiSP)
        {
            if (sp.InsertSP(masp, tensp, hinhanh, dvt, loaiSP) > 0)
                return true;
            return false;
        }
        public string LayMaSPMax()
        {
            try
            {
                return sp.LayMaSPMax().ToString();
            }
            catch
            {
                return null;
            }
        }
        public bool updateSP(string tensp, string hinhanh, string dvt, string maloaisp, string masp)
        {
            if (sp.UpdateSP(tensp, hinhanh, dvt, maloaisp, masp) > 0)
                return true;
            return false;
        }
        public bool deleteSP(string masp)
        {
            if (sp.DeleteSP(masp) > 0)
                return true;
            return false;
        }
    }
}
