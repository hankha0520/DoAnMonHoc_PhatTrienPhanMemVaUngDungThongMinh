using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ManHinhBLL
    {
        ManHinhDAL mh = new ManHinhDAL();
        public DataTable GetData()
        {
            return mh.GetData();
        }
    }
}
