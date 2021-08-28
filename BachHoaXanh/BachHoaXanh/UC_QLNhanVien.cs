using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using BLL;

namespace BachHoaXanh
{
    public partial class UC_QLNhanVien : UserControl
    {
        public UC_QLNhanVien()
        {
            InitializeComponent();
            themCotDGV();
            load();
            
        }       

        public void load()
        {
            dgvDSNV.DataSource = nv.GetNhanVien();
            dgvPhanQuyenNhanVien.DataSource = pqnv.GetData();
            cboNhanVien.DataSource = nv.nvChuaPhanQuyen();
            cboNhomNV.DataSource = nnv.GetData();
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DisplayMember = "TenNV";
            cboNhomNV.ValueMember = "MaNhomNV";
            cboNhomNV.DisplayMember = "TenNhomNV";
           

        }
        public void themCotDGV()
        {
            DataGridViewButtonColumn btnHuy = new DataGridViewButtonColumn();
            btnHuy.Name = "btnHuy";
            btnHuy.HeaderText = "Rời nhóm";
            this.dgvPhanQuyenNhanVien.Columns.Add(btnHuy);
            btnHuy.Text = "Rời nhóm";

        }


        NhomNhanVienBLL nnv = new NhomNhanVienBLL();
        NhanVienBLL nv = new NhanVienBLL();
        PhanQuyenNhanVienBLL pqnv = new PhanQuyenNhanVienBLL();
        QL_NguoiDung ql = new QL_NguoiDung();
        private void dgvDSNV_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = dgvDSNV.CurrentRow.Cells[0].Value.ToString();
            txtNhanVien.Text = dgvDSNV.CurrentRow.Cells[1].Value.ToString();
            dateNgaySinh.Text = dgvDSNV.CurrentRow.Cells[2].Value.ToString();
            cboGioiTinh.Text = dgvDSNV.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgvDSNV.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dgvDSNV.CurrentRow.Cells[5].Value.ToString();
            txtGmail.Text = dgvDSNV.CurrentRow.Cells[6].Value.ToString();
            dateNgayVL.Text = dgvDSNV.CurrentRow.Cells[9].Value.ToString();
            txtCMT.Text = dgvDSNV.CurrentRow.Cells[10].Value.ToString();
            txtAnh.Text = dgvDSNV.CurrentRow.Cells[8].Value.ToString();
            txtMatKhau.Text = dgvDSNV.CurrentRow.Cells[7].Value.ToString();            
            guna2PictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Anh\\" + dgvDSNV.CurrentRow.Cells[8].Value.ToString());
        }

        

        
        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiem.Text == string.Empty)
                {
                    dgvDSNV.DataSource = nv.GetNhanVien();
                }
                else
                {
                    dgvDSNV.DataSource = ql.Search(txtTimKiem.Text, "NhanVien", "MaNV", "TenNV");                   
                }
            }
            catch
            {
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = btnXoa.Enabled = false;
            txtMaNV.Text = txtNhanVien.Text = txtDiaChi.Text = txtSDT.Text = txtGmail.Text = txtCMT.Text = dateNgayVL.Text = dateNgaySinh.Text = txtAnh.Text = txtMatKhau.Text = string.Empty;
            guna2PictureBox1.Image = null;
            if (nv.LayMaNVMax() == string.Empty)
            {
                txtMaNV.Text = "NV001";
            }
            else
            {
                int nvmax = int.Parse(nv.LayMaNVMax().Trim());
                txtMaNV.Text = "NV00" + (nvmax + 1).ToString();
            }
            txtMatKhau.Visible = txtAnh.Visible = guna2Button1.Visible = true ;           
            txtNhanVien.ReadOnly = txtDiaChi.ReadOnly = txtSDT.ReadOnly = txtGmail.ReadOnly = txtCMT.ReadOnly = txtAnh.ReadOnly = txtMatKhau.ReadOnly = false;
            txtNhanVien.Select();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = btnSua.Enabled = btnThem.Enabled = true;
            if(nv.ktkc(txtMaNV.Text) == 0)
            {
                if(nv.insertNhanVien(txtMaNV.Text, txtNhanVien.Text, DateTime.Parse(dateNgaySinh.Value.ToString()), cboGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, txtGmail.Text, txtMatKhau.Text, txtAnh.Text, DateTime.Parse(dateNgayVL.Value.ToString()), txtCMT.Text))
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    load();
                    txtNhanVien.ReadOnly = txtDiaChi.ReadOnly = txtSDT.ReadOnly = txtGmail.ReadOnly = txtCMT.ReadOnly = txtAnh.ReadOnly = txtMatKhau.ReadOnly = true;
                    txtMatKhau.Visible = txtAnh.Visible = guna2Button1.Visible = false;

                }
            }
            else
            {
                if (nv.updateNhanVien(txtNhanVien.Text, dateNgaySinh.Value.ToString(), cboGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, txtGmail.Text, txtMatKhau.Text, txtAnh.Text, dateNgayVL.Value.ToString(), txtCMT.Text, txtMaNV.Text))
                {
                    MessageBox.Show("Cập nhật nhân viên thành công");
                    load();
                    txtNhanVien.ReadOnly = txtDiaChi.ReadOnly = txtSDT.ReadOnly = txtGmail.ReadOnly = txtCMT.ReadOnly = txtAnh.ReadOnly = txtMatKhau.ReadOnly = true;
                    txtMatKhau.Visible = txtAnh.Visible = guna2Button1.Visible = false;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = btnXoa.Enabled = false;
            txtNhanVien.ReadOnly = txtDiaChi.ReadOnly = txtSDT.ReadOnly = txtGmail.ReadOnly = txtCMT.ReadOnly = txtAnh.ReadOnly = txtMatKhau.ReadOnly = false;
            txtMatKhau.Visible = txtAnh.Visible = guna2Button1.Visible= true;
        }
        Image file;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.png;*.jpg)|;*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(ofd.FileName);
                guna2PictureBox1.Image = file;
                string tenhinh = ofd.FileName.Substring(75);
                txtAnh.Text = tenhinh;
            }
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (pqnv.deletePhanQuyenNhanVien(txtMaNV.Text))
            {
                if (nv.deleteNhanVien(txtMaNV.Text))
                    flag = 1;
            }
            if (flag == 1)
            {
                MessageBox.Show("Xóa thành công");
                load();
            }
        }

        private void dgvPhanQuyenNhanVien_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvPhanQuyenNhanVien.CurrentCell.ColumnIndex == 2)
            {
                Button btShow = e.Control as Button;
                btShow.Click += BtShow_Click;
                btShow.Text = "Rời nhóm";
            }
        }

        public void BtShow_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn muốn mời nhân viên ra khỏi nhóm này", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                if (pqnv.DeletePhanQuyenNhanVien(dgvPhanQuyenNhanVien.CurrentRow.Cells[1].Value.ToString(), dgvPhanQuyenNhanVien.CurrentRow.Cells[2].Value.ToString()))
                {
                    MessageBox.Show("Hủy nhân viên khỏi nhóm thành công");
                    load();
                }
                else
                    MessageBox.Show("Hủy nhân viên khỏi nhóm không thành công");
            }
        }

        private void btnPhanNhom_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn muốn đưa nhân viên vào nhóm này", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                if (pqnv.insertPhanQuyenNhanVien(cboNhomNV.SelectedValue.ToString(), cboNhanVien.SelectedValue.ToString()))
                {
                    MessageBox.Show("Phân nhóm nhân viên thành công");
                    load();
                }
                else
                    MessageBox.Show("Phân nhóm nhân viên không thành công");
            }
        }

        private void dgvPhanQuyenNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string command = dgvPhanQuyenNhanVien.Columns[e.ColumnIndex].Name;
                if (command == "btnHuy") // colbtn là tên cột chứa button
                {
                    BtShow_Click(sender, e);
                }
            }
        }
    }
}
