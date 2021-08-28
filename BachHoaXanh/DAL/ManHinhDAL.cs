using DAL.DataSetBHXTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManHinhDAL
    {
        ManHinhTableAdapter mh = new ManHinhTableAdapter();
        public DataTable GetData()
        {
            return mh.GetData();
        }
    }
}
