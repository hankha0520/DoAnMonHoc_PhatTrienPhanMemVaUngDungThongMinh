using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        LoaiSanPhamTableAdapter lsp = new LoaiSanPhamTableAdapter();
        public DataTable GetData()
        {
            return lsp.GetData1();
        }
        public bool InsertLoaiSP(string maloai, string tenloai, string ghichu)
        {
            if (lsp.Insert(maloai, tenloai, ghichu) > 0)
                return true;
            return false;
        }

        public string LayMaLoaiSPMax()
        {
            try
            {
                return lsp.LayMaLoaiMax().ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}
