using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachHoaXanh
{
    public class ChiTietPhieuNhap
    {
        private string _STT;
        private string _MaPN;
        private string _MaSP;
        private int _SoLuongNhap;
        private string _GhiChu;
        private string _NSX;
        private string _HSD;

        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        public string MaPN
        {
            get { return _MaPN; }
            set { _MaPN = value; }
        }
        public string MaSP
        {
            get { return _MaSP; }
            set { _MaSP = value; }
        }
        public int SoLuongNhap
        {
            get { return _SoLuongNhap; }
            set { _SoLuongNhap = value; }
        }
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        public string HSD
        {
            get { return _HSD; }
            set { _HSD = value; }
        }
        public string NSX
        {
            get { return _NSX; }
            set { _NSX = value; }
        }    
      
    }
}
