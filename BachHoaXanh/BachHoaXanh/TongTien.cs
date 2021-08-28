
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachHoaXanh
{
    public class TongTien
    {
        public float tinhTongTien(Guna.UI2.WinForms.Guna2DataGridView dgv, int cell)
        {
            float tongtien = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                tongtien += float.Parse(dgv.Rows[i].Cells[cell].Value.ToString());
            }
            return tongtien;
        }
    }
}
