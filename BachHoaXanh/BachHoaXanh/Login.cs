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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        QL_NguoiDung CauHinh = new QL_NguoiDung();
        PhanQuyenNhanVienBLL pqnv = new PhanQuyenNhanVienBLL();
      
        public void ProcessLogin()
        {
            int result;
            result = CauHinh.Check_User(txtMaNV.Text, txtMK.Text);
            //Check_User viết trong Class QL_NguoiDung
            // Wrong username or pass
            if (result == 10)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                txtMaNV.ResetText();
                txtMK.ResetText();
                txtMaNV.Select();
                return;
            }
            // Account had been disabled
            else if (result == 20)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            Form1 frm = new Form1();
            Form1.TenDN = txtMaNV.Text;
            //frmNhanVien.MK = txtMK.Text;
            frm.Show();
            this.Hide();

        }
        public void ProcessConfig()
        {
            //frmConfig frm = new frmConfig();
            //frm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nhomNV = pqnv.timNhomNV(txtMaNV.Text);
            if (string.IsNullOrEmpty(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("không được bỏ trống mã nhân viên");
                txtMaNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtMK.Text))
            {
                MessageBox.Show("Không được bỏ trống mật khẩu");
                this.txtMK.Focus();
                return;
            }
            int kq = CauHinh.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                ProcessConfig();
            }

            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                ProcessConfig();
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                guna2Button1.PerformClick();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
