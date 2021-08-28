using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace BachHoaXanh
{
    public partial class UC_ThongTinNV : UserControl
    {
        public UC_ThongTinNV()
        {
            InitializeComponent();
        }
        NhanVienBLL nv = new NhanVienBLL();
       // NhomNhanVienBLL nnv = new NhomNhanVienBLL();
        PhanQuyenNhanVienBLL pqnv = new PhanQuyenNhanVienBLL();

        private void UC_ThongTinNV_Load(object sender, EventArgs e)
        {
            foreach (DataRow dr in nv.GetNVTheoMa(Form1.TenDN).Rows)
            {
                txtMaNV.Text = dr["MaNV"].ToString();
                txtHoTen.Text = dr["TenNV"].ToString();
                dataNgaySinh.Text = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                txtDiaChi.Text = dr["DiaChi"].ToString();                
                txtDD.Text = dr["SDT"].ToString();
                pAnhNV.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Anh\\" +  dr["hinhNV"].ToString());
            }
        }

        private void btnSuaDiaChi_Click(object sender, EventArgs e)
        {
            txtDiaChi.ReadOnly = false;
        }

        private void btnSuaDD_Click(object sender, EventArgs e)
        {
            txtDD.ReadOnly = false;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if(nv.updateTTNhanVien(txtDiaChi.Text, txtDD.Text, txtMaNV.Text))
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công");
                UC_ThongTinNV_Load(sender, e);
                txtDiaChi.ReadOnly = txtDD.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin nhân viên không thành công");
            }
        }
    }
}
