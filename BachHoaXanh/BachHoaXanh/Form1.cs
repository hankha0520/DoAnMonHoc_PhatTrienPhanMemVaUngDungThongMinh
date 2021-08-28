using BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachHoaXanh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string TenDN = string.Empty;

        NhanVienBLL nv = new NhanVienBLL();
        PhanQuyenNhanVienBLL pqnv = new PhanQuyenNhanVienBLL();
        PhanQuyenNhomBLL pqn = new PhanQuyenNhomBLL();
        ManHinhBLL mh = new ManHinhBLL();

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void showUserControl(System.Windows.Forms.Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void mnuQLSanPham_Click(object sender, EventArgs e)
        {
            UC_QLHangHoa uc = new UC_QLHangHoa();
            showUserControl(uc);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            UC_ThongTinNV uc = new UC_ThongTinNV();
            showUserControl(uc);
        }

        private void mnuNghiepVu_Click(object sender, EventArgs e)
        {
            UC_NghiepVu uc = new UC_NghiepVu();
            showUserControl(uc);
        }

        private void mnuQLNhanVien_Click(object sender, EventArgs e)
        {
            UC_QLNhanVien uc = new UC_QLNhanVien();
            showUserControl(uc);
        }

        private void mnuNghiepVuPRO_Click(object sender, EventArgs e)
        {
            UC_NghiepVuPRO uc = new UC_NghiepVuPRO();
            showUserControl(uc);
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string nhomNV = pqnv.timNhomNV(TenDN);
           
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.Tag != null)
                {
                    if (pqn.KiemTraQuyen(nhomNV, item.Tag.ToString()))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
            }

            foreach (DataRow dr in nv.GetNVTheoMa(Form1.TenDN).Rows)
            {               
                lblTenNV.Text = dr["TenNV"].ToString();
                guna2CirclePictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Anh\\" + dr["hinhNV"].ToString());
            }
        }

       
    }
}
