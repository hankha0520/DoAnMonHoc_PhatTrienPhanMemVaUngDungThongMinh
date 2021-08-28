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
    public partial class frmDanhSachSP : Form
    {
        public frmDanhSachSP()
        {
            InitializeComponent();
        }
        SanPhamBLL sp = new SanPhamBLL();
        QL_NguoiDung ql = new QL_NguoiDung();        
        BangGiaBLL bg = new BangGiaBLL();       
        HSDSanPhamBLL hsdsp = new HSDSanPhamBLL();
        private void frmDanhSachSP_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = sp.GetSanPham();

        }

       

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.DataSource != null)
            {
                pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Anh\\" + dgvSanPham.CurrentRow.Cells[2].Value.ToString());
                dgvBangGia.DataSource = bg.GetBangGia(dgvSanPham.CurrentRow.Cells[0].Value.ToString());
                dgvHSD.DataSource = hsdsp.GetDataTheoMaSP(dgvSanPham.CurrentRow.Cells[0].Value.ToString());
            }
            else

                pictureBox1.Image = null;

        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiemSP.Text == string.Empty)
                {
                    dgvSanPham.DataSource = sp.GetSanPham();
                }
                else
                {
                    dgvSanPham.DataSource = ql.Search(txtTimKiemSP.Text, "SanPham", "MaSP", "TenSP");
                }
            }
            catch
            {
                return;
            }
        }
    }
}
