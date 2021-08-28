using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonNhapHang
    {
        string msp, tsp;
        int sl;
        
        DateTime nsx, hsd;

        public DonNhapHang()
        {
        }
        public string Msp { get => msp; set => msp = value; }
        public string Tsp { get => tsp; set => tsp = value; }
        public int Sl { get => sl; set => sl = value; }        
        public DateTime Nsx { get => nsx; set => nsx = value; }
        public DateTime Hsd { get => hsd; set => hsd = value; }
    }
}
