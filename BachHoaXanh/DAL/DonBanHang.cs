using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonBanHang
    {
        string msp, tsp, dvt;
        int sl;
        float gb, tt;
        public DonBanHang()
        {

        }

        public string Msp { get => msp; set => msp = value; }
        public string Tsp { get => tsp; set => tsp = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public int Sl { get => sl; set => sl = value; }
        public float Gb { get => gb; set => gb = value; }
        public float Tt { get => tt; set => tt = value; }
    }
}

