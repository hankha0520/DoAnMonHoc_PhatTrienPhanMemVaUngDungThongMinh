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
using Accord.MachineLearning.Rules;
using DAL;

namespace BachHoaXanh
{
    public partial class UC_NghiepVuPRO : UserControl
    {
        List<DonNhapHang> list;
        public UC_NghiepVuPRO()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
            lblNgayHuy.Text = lblNgayHuy2.Text = lblNgayPN.Text = DateTime.Now.ToString();
            lblTenNV.Text = lblTenNV2.Text = lblTenNV1.Text = nv.LayTenNV(Form1.TenDN);
            LoadHuyDoi();
            LoadHuyHH();
            LoadSP();
            LoadThemPhieuNhap();
            loadCbo();
            list = new List<DonNhapHang>();

        }
        ChiTietPNBLL ctpn = new ChiTietPNBLL();
        PhieuNhapBLL pn = new PhieuNhapBLL();
        BangGiaBLL bg = new BangGiaBLL();
        LoaiSanPhamBLL lsp = new LoaiSanPhamBLL();
        NhanVienBLL nv = new NhanVienBLL();
        BangDoiTraBLL bd = new BangDoiTraBLL();
        ChiTietDoiTraBLL ctdt = new ChiTietDoiTraBLL();
        BangHuyBLL bh = new BangHuyBLL();
        ChiTietHuyBLL cth = new ChiTietHuyBLL();
        HSDSanPhamBLL hsdsp = new HSDSanPhamBLL();
        public void LoadThemPhieuNhap()
        {
            txtSL.Text = string.Empty;

            if (pn.LayMaPNMax() == string.Empty)
            {
                lblMaPN1.Text = "PN01";
            }
            else
            {
                int pnmax = int.Parse(pn.LayMaPNMax().Trim());
                lblMaPN1.Text = "PN0" + (pnmax + 1).ToString();
            }
        }
        private void uC_Gia1_Load(object sender, EventArgs e)
        {

        }
        public void loadCbo()
        {
            guna2ComboBox2.DataSource = sp.GetSanPham();
            guna2ComboBox2.DisplayMember = "TenSP";
            guna2ComboBox2.ValueMember = "MaSP";
            guna2ComboBox1.DataSource = sp.GetSanPham();
            guna2ComboBox1.DisplayMember = "TenSP";
            guna2ComboBox1.ValueMember = "MaSP";
            guna2ComboBox3.DataSource = sp.GetSanPham();
            guna2ComboBox3.DisplayMember = "TenSP";
            guna2ComboBox3.ValueMember = "MaSP";
            guna2ComboBox4.DataSource = sp.GetSanPham();
            guna2ComboBox4.DisplayMember = "TenSP";
            guna2ComboBox4.ValueMember = "MaSP";
            guna2ComboBox5.DataSource = sp.GetSanPham();
            guna2ComboBox5.DisplayMember = "TenSP";
            guna2ComboBox5.ValueMember = "MaSP";
            guna2ComboBox6.DataSource = sp.GetSanPham();
            guna2ComboBox6.DisplayMember = "TenSP";
            guna2ComboBox6.ValueMember = "MaSP";
            guna2ComboBox7.DataSource = sp.GetSanPham();
            guna2ComboBox7.DisplayMember = "TenSP";
            guna2ComboBox7.ValueMember = "MaSP";
            guna2ComboBox8.DataSource = sp.GetSanPham();
            guna2ComboBox8.DisplayMember = "TenSP";
            guna2ComboBox8.ValueMember = "MaSP";
            guna2ComboBox9.DataSource = sp.GetSanPham();
            guna2ComboBox9.DisplayMember = "TenSP";
            guna2ComboBox9.ValueMember = "MaSP";
            guna2ComboBox10.DataSource = sp.GetSanPham();
            guna2ComboBox10.DisplayMember = "TenSP";
            guna2ComboBox10.ValueMember = "MaSP";
            guna2ComboBox11.DataSource = sp.GetSanPham();
            guna2ComboBox11.DisplayMember = "TenSP";
            guna2ComboBox11.ValueMember = "MaSP";
        }

        public void LoadHuyDoi()
        {
            //timer1.Enabled = true;
            //timer1.Start();
            //lblNgayHuy.Text = DateTime.Now.ToString();
            //lblTenNV.Text = nv.LayTenNV(Form1.TenDN);
            dgvDSD.DataSource = bd.GetDataChuaHuy();

            if (bh.LayMaHuyMax() == string.Empty)
            {
                lblMaHuy.Text = "H001";
            }
            else
            {
                int hmax = int.Parse(bh.LayMaHuyMax().Trim());
                lblMaHuy.Text = "H00" + (hmax + 1).ToString();
            }
        }
        public void LoadHuyHH()
        {
            dgvSPHH.DataSource = hsdsp.GetDataHH();
            dgvBHuy.DataSource = bh.GetData();
            if (bh.LayMaHuyMax() == string.Empty)
            {
                lblMaHuy2.Text = "H001";
            }
            else
            {
                int hmax = int.Parse(bh.LayMaHuyMax().Trim());
                lblMaHuy2.Text = "H00" + (hmax + 1).ToString();
            }
        }
        public void LoadSP()
        {
            txtTenSP.Focus();
            if (sp.layMaSPMax() == string.Empty)
            {
                txtMaSP.Text = "SP001";
            }
            else
            {
                int spmax = int.Parse(sp.layMaSPMax().Trim());
                txtMaSP.Text = "SP00" + (spmax + 1).ToString();
            }
            dgvSanPham.DataSource = sp.GetSanPham();
            cboMaLoaiSP.DataSource = lsp.GetData();
            cboMaLoaiSP.DisplayMember = "TenLoaiSP";
            cboMaLoaiSP.ValueMember = "MaLoaiSP";

            if (lsp.LayMaLoaiSPMax() == string.Empty)
            {
                txtMaLoaiSP.Text = "LSP01";
            }
            else
            {
                int lspmax = int.Parse(lsp.LayMaLoaiSPMax().Trim());
                txtMaLoaiSP.Text = "LSP0" + (lspmax + 1).ToString();
            }
            cboTenSPChuaCoGia.DataSource = bg.GetDataChuaCoGia();
            cboTenSPChuaCoGia.ValueMember = "MaSP";
            cboTenSPChuaCoGia.DisplayMember = "TenSP";
        }
        private void btnHuySPTra_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (bh.insertBH(lblMaHuy.Text, Form1.TenDN, "Hàng lỗi", DateTime.Now, dgvCTD.CurrentRow.Cells[0].Value.ToString()))
            {

                for (int i = 0; i < dgvCTD.RowCount; i++)
                {
                    string MaSP = dgvCTD.Rows[i].Cells[1].Value.ToString();
                    int sl = int.Parse(dgvCTD.Rows[i].Cells[2].Value.ToString());
                    if (cth.insert(lblMaHuy.Text, MaSP, sl))
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
                    MessageBox.Show("Hủy thành công");
                    LoadHuyHH();
                    LoadHuyDoi();
                }
            }
            else
            {
                MessageBox.Show("Hủy thất bại");
            }
        }

        private void dgvDSD_SelectionChanged(object sender, EventArgs e)
        {
            dgvCTD.DataSource = ctdt.GetDataTheoMaDoi(dgvDSD.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvBHuy_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvCTH.DataSource = cth.GetDataTheoMaHuy(dgvBHuy.CurrentRow.Cells[0].Value.ToString());
                txtMaH.Text = dgvBHuy.CurrentRow.Cells[0].Value.ToString();
                txtLyDoHuy.Text = dgvBHuy.CurrentRow.Cells[2].Value.ToString();

            }
            catch
            {
                return;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNgayHuy.Text = lblNgayHuy2.Text = DateTime.Now.ToString();
        }

        private void btnHuy2_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (bh.insertBH(lblMaHuy2.Text, Form1.TenDN, "Hết hạn", DateTime.Now, null))
            {
                string MaSP = dgvSPHH.CurrentRow.Cells[0].Value.ToString();
                int sl = int.Parse(dgvSPHH.CurrentRow.Cells[2].Value.ToString());
                DateTime hsd = DateTime.Parse(dgvSPHH.CurrentRow.Cells[1].Value.ToString());

                if (cth.insert(lblMaHuy2.Text, MaSP, sl))
                {
                    if (hsdsp.updateTinhTrangHH("Đã hủy", MaSP, hsd.ToString()))
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
            }
            if (flag == 1)
            {
                MessageBox.Show("Hủy thành công");
                LoadHuyDoi();
                LoadHuyHH();
            }
            else
            {
                MessageBox.Show("Hủy thất bại");
            }
        }

        private void dgvSPHH_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaSPHH.Text = dgvSPHH.CurrentRow.Cells[0].Value.ToString();
                txtTTSPHH.Text = dgvSPHH.CurrentRow.Cells[3].Value.ToString();
                txtHSDHH.Text = dgvSPHH.CurrentRow.Cells[1].Value.ToString();
                txtSLHH.Text = dgvSPHH.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void dgvCTH_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaSPDH.Text = dgvCTH.CurrentRow.Cells[1].Value.ToString();
                txtSoLuongDH.Text = dgvCTH.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        ChiTietHDBLL cthd = new ChiTietHDBLL();
        SanPhamBLL sp = new SanPhamBLL();


        private void btnGoiY_Click(object sender, EventArgs e)
        {
            List<int[]> data = new List<int[]>();
            List<int> row = new List<int>();
            for (int i = 1; i < 17; i++)
            {
                DataTable dct = cthd.GetChiTietHD("HD0" + i);
                foreach (DataRow dt in dct.Rows)
                {
                    int val = int.Parse(dt[1].ToString().Substring(4, 1));
                    row.Add(val);
                }
                data.Add(row.ToArray());
            }


            int[][] input = data.ToArray();

            Apriori apriori = new Apriori(threshold: 2, confidence: 0.7);

            // Use the algorithm to learn a set matcher
            AssociationRuleMatcher<int> classifier = apriori.Learn(input);

            // Use the classifier to find orders that are similar to 
            // orders where clients have bought items 1 and 2 together:

            int spgy = int.Parse(guna2ComboBox2.SelectedValue.ToString().Substring(4, 1));
            int[][] matches = classifier.Decide(new[] { spgy });
            if (matches.Length <= 0)
            {
                MessageBox.Show("Không có gợi ý sắp xếp");
            }
            else
            {
                for (int i = 0; i < matches.Length; i++)
                {
                    string ma = "SP00" + matches[i][0].ToString();
                    MessageBox.Show(sp.layTenSP(ma));
                }
            }
        }
        Image file;
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.png;*.jpg)|;*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(ofd.FileName);
                guna2PictureBox9.Image = file;
                string tenhinh = ofd.FileName.Substring(53);
                txtAnhSP.Text = tenhinh;
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text != string.Empty && txtDVTSP.Text != string.Empty && txtAnhSP.Text != string.Empty)
            {
                if (sp.insertSP(txtMaSP.Text, txtTenSP.Text, txtAnhSP.Text, txtDVTSP.Text, cboMaLoaiSP.SelectedValue.ToString()))
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    txtTenSP.Text = txtDVTSP.Text = txtAnhSP.Text = string.Empty;
                    LoadSP();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công");
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống");
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
            txtAnhSP.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
            txtDVTSP.Text = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
            cboMaLoaiSP.SelectedValue = dgvSanPham.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text != string.Empty && txtDVTSP.Text != string.Empty && txtAnhSP.Text != string.Empty)
            {
                if (sp.updateSP(txtTenSP.Text, txtAnhSP.Text, txtDVTSP.Text, cboMaLoaiSP.SelectedValue.ToString(), txtMaSP.Text))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công");
                    LoadSP();
                    txtTenSP.Text = txtDVTSP.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm không thành công");
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bg.deleteBangGia(dgvSanPham.CurrentRow.Cells[0].Value.ToString()))
            {
                if (sp.deleteSP(dgvSanPham.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                    LoadSP();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm không thành công");
                }
            }
        }

        private void btnThemLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiSP.Text != string.Empty && txtMaLoaiSP.Text != string.Empty)
            {
                if (lsp.InsertLoaiSP(txtMaLoaiSP.Text, txtTenLoaiSP.Text, null))
                {
                    MessageBox.Show("Thêm loại sản phẩm thành công");
                    txtTenLoaiSP.Text = string.Empty;
                    LoadSP();
                }
                else
                    MessageBox.Show("Thêm loại sản phẩm không thành công");

            }
            else
            {
                MessageBox.Show("Không được để trống");
                txtTenLoaiSP.Focus();
            }
        }



        //////Them phiếu nhập hàng

        int index = -1;
        int slm = 0;
        public int kttrungdgv(string masp)
        {
            for (int i = 0; i < dgvCTPN.Rows.Count; i++)
            {
                if (masp == dgvCTPN.Rows[i].Cells[0].Value.ToString())
                {
                    index = i;
                    slm = int.Parse(dgvCTPN.Rows[i].Cells[2].Value.ToString());
                    return 1;
                }
            }
            return 0;
        }
        DataGridViewTextBoxColumn hd1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd5 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd6 = new DataGridViewTextBoxColumn();
        private void setupColumDGV()
        {
            dgvCTPN.Columns.Clear();
            // Column1
            // 
            dgvCTPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            hd1.DataPropertyName = "msp";
            hd1.HeaderText = "Mã Sản Phẩm";
            hd1.Name = "Column1";
            hd1.DisplayIndex = 1;
            //hd1.Width = 100;
            hd1.ReadOnly = true;
            // 
            // Column2
            // 
            hd2.DataPropertyName = "tsp";
            hd2.HeaderText = "Tên Sản Phẩm";
            hd2.Name = "Column2";
            hd2.DisplayIndex = 2;
            // hd2.Width = 250;
            hd2.ReadOnly = true;
            // 
            // Column3
            // 
            hd3.DataPropertyName = "sl";
            hd3.HeaderText = "Số lượng nhập";
            hd3.Name = "Column3";
            hd3.DisplayIndex = 3;
            hd3.ReadOnly = true;
            // 
            // Column4
            // 
            hd4.DataPropertyName = "nsx";
            hd4.HeaderText = "Ngày sản xuất";
            hd4.Name = "Column4";
            hd4.DisplayIndex = 4;
            hd4.ReadOnly = true;
            // hd3.Width = 100;
            // 
            // Column4
            // 
            hd5.DataPropertyName = "hsd";
            hd5.HeaderText = "Hạn sử dụng";
            hd5.Name = "Column5";
            hd5.DisplayIndex = 5;
            hd5.ReadOnly = true;
            //hd4.Width = 100;
            //
            // Column5


            dgvCTPN.Columns.Add(hd1);
            dgvCTPN.Columns.Add(hd2);
            dgvCTPN.Columns.Add(hd3);
            dgvCTPN.Columns.Add(hd4);
            dgvCTPN.Columns.Add(hd5);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP1.Text == string.Empty)
            {
                MessageBox.Show("Mời nhập sản phẩm cần thanh toán!");
                return;
            }
            if (txtSL.Text == string.Empty)
            {
                MessageBox.Show("Mời nhập Số lượng Sản Phẩm!");
                return;
            }

            DonNhapHang dnh = new DonNhapHang();

            if (kttrungdgv(txtMaSP1.Text) == 1)
            {
                list.RemoveAt(index);
                dnh.Msp = txtMaSP1.Text;
                dnh.Tsp = txtTenSP1.Text;
                dnh.Sl = int.Parse(txtSL.Text) + slm;
                dnh.Nsx = DateTime.Parse(dateNSX.Value.ToShortTimeString());
                dnh.Hsd = DateTime.Parse(dateHSD.Value.ToShortDateString());

                list.Add(dnh);
                dgvCTPN.DataSource = null;
                setupColumDGV();
                dgvCTPN.DataSource = list;

                txtMaSP1.Text = txtSL.Text = txtTenSP1.Text = "";
                dateHSD.Text = dateNSX.Text = DateTime.Today.ToShortDateString();

            }
            else
            {
                dnh.Msp = txtMaSP1.Text;
                dnh.Tsp = txtTenSP1.Text;
                dnh.Sl = int.Parse(txtSL.Text);
                dnh.Nsx = DateTime.Parse(dateNSX.Value.ToString());
                dnh.Hsd = DateTime.Parse(dateHSD.Value.ToString());

                list.Add(dnh);
                dgvCTPN.DataSource = null;
                setupColumDGV();
                dgvCTPN.DataSource = list;
                txtMaSP1.Text = txtSL.Text = txtTenSP1.Text = "";
                dateHSD.Text = dateNSX.Text = DateTime.Today.ToShortDateString();
            }
        }

        private void txtMaSP1_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in sp.GetSanPhamTheoMa(txtMaSP1.Text).Rows)
            {
                txtTenSP1.Text = dr["TenSP"].ToString();
            }
            txtSL.Text = "1";
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (pn.InsertPN(lblMaPN1.Text, "Chưa nhập"))
            {
                for (int i = 0; i < dgvCTPN.RowCount; i++)
                {
                    string MaSP = dgvCTPN.Rows[i].Cells[0].Value.ToString();
                    int slnhap = int.Parse(dgvCTPN.Rows[i].Cells[2].Value.ToString());
                    DateTime nsx = DateTime.Parse(dgvCTPN.Rows[i].Cells[3].Value.ToString());
                    DateTime hsd = DateTime.Parse(dgvCTPN.Rows[i].Cells[4].Value.ToString());


                    if (ctpn.InsertCTPN(lblMaPN1.Text, MaSP, slnhap, null, nsx, hsd))
                    {
                        flag = 1;
                    }
                    else
                        flag = 0;

                }
                
            }
            if (flag == 1)
            {
                MessageBox.Show("Tạo phiếu nhập thành công");
                LoadThemPhieuNhap();
                dgvCTPN.DataSource = null;
                setupColumDGV();
            }
            else
            {
                MessageBox.Show("Tạo phiếu nhập không thành công");
                LoadThemPhieuNhap();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if(ctpn.DeleteCTPN(txtTimKiemPN.Text.Trim()))
            {
                if (pn.DeletePN(txtTimKiemPN.Text.Trim()))
                    flag = 1;
                else
                    flag = 0;

            }
            else
            {
                MessageBox.Show("Không thể xóa chi tiết phiếu nhập");
            }
            if(flag == 1)
            {
                MessageBox.Show("Đã xóa phiếu nhập");
                LoadThemPhieuNhap();
            }
            else
            {
                MessageBox.Show("Không thể xóa phiếu nhập");

            }
        }

        private void txtTimKiemPN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiemPN.Text != string.Empty)
                {
                    setupColumDGV();
                    if (pn.GetDataTheoMaPN(txtTimKiemPN.Text.Trim()).Rows.Count != 0)
                    {

                       
                        ctpn.getCTPN(dgvCTPN, txtTimKiemPN.Text.Trim());
                        foreach (DataRow dr in pn.GetDataTheoMaPN(txtTimKiemPN.Text.Trim()).Rows)
                        {
                            lblMaPN1.Text = dr["MaPN"].ToString();
                        }                    }
                    else
                    {
                        lblMaPN1.Text = txtMaSP1.Text = txtTenSP1.Text = txtSL.Text = string.Empty;
                        dgvCTPN.DataSource = cthd.GetChiTietHD(txtTimKiemPN.Text);
                    }

                }
                else
                {
                    //LoadThemPhieuNhap();
                    dgvCTPN.DataSource = ctpn.GetCTPN(txtTimKiemPN.Text);

                }
            }
            catch
            {
                return;
            }

        }

        private void btnDSSP_Click(object sender, EventArgs e)
        {
            frmDanhSachSP frm = new frmDanhSachSP();
            frm.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (txtGiaBanSP.Text != string.Empty)
            {
                if (bg.UpdateGiaBan(float.Parse(txtGiaBanSP.Text), DateTime.Today.ToShortDateString(), cboTenSPChuaCoGia.SelectedValue.ToString()))
                {
                    MessageBox.Show("Cập nhật giá bán thành công");
                    LoadSP();

                }
                else
                    MessageBox.Show("Cập nhật giá bán không thành công");
            }
            else
                MessageBox.Show("Không được để trống");
        }
    }
}

