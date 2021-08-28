using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiSanPhamBLL
    {
        LoaiSanPhamDAL lsp = new LoaiSanPhamDAL();
        public DataTable GetData()
        {
            return lsp.GetData();
        }
        public bool InsertLoaiSP(string maloai, string tenloai, string ghichu)
        {
            return lsp.InsertLoaiSP(maloai, tenloai, ghichu);
        }
        public string LayMaLoaiSPMax()
        {
            return lsp.LayMaLoaiSPMax();
        }
    }
}
