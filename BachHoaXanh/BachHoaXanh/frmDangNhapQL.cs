using BLL;
using System;
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
    public partial class frmDangNhapQL : Form
    {
        public frmDangNhapQL()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        NhanVienBLL nv = new NhanVienBLL();
        PhanQuyenNhanVienBLL pqnv = new PhanQuyenNhanVienBLL();
        public string MaQL;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            foreach (DataRow dr in nv.getDN(txtMaQL.Text, txtMK.Text).Rows)
            {
                if (pqnv.timNhomNV(txtMaQL.Text) == "NNV01")
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
            if (flag == 1)
            {
                MessageBox.Show("Đăng nhập thành công với tư cách quản lý");
                UC_NghiepVu.MaQL = txtMaQL.Text;
                //frmSanPhamHuy.maql = txtmaql.Text;
                guna2ImageButton1.PerformClick();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void frmDangNhapQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                guna2Button1.PerformClick();
        }
    }
}
