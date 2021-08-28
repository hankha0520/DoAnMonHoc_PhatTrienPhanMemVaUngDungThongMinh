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
using DAL;

namespace BachHoaXanh
{
    public partial class UC_NghiepVu : UserControl
    {

        List<DonBanHang> list;
        public UC_NghiepVu()
        {
            InitializeComponent();
            LoadNH();
            LoadBH();
            lblTienThoi.Text = string.Empty;
            list = new List<DonBanHang>();
        }
        TongTien tt = new TongTien();
        BangGiaBLL bg = new BangGiaBLL();
        HoaDonBLL hd = new HoaDonBLL();
        ChiTietHDBLL cthd = new ChiTietHDBLL();
        PhieuNhapBLL pn = new PhieuNhapBLL();
        ChiTietPNBLL ctpn = new ChiTietPNBLL();
        NhanVienBLL nv = new NhanVienBLL();
        SanPhamBLL sp = new SanPhamBLL();
        HSDSanPhamBLL hsdsp = new HSDSanPhamBLL();
        BangDoiTraBLL dt = new BangDoiTraBLL();
        ChiTietDoiTraBLL ctdt = new ChiTietDoiTraBLL();

        public void LoadNH()
        {
            dgvPhieuChuaNhap.DataSource = pn.GetDataChuaNhap();
            //if (dgvPhieuChuaNhap.RowCount != 0)

            //    dgvCTPN.DataSource = ctpn.GetCTPN(dgvPhieuChuaNhap.CurrentRow.Cells[0].Value.ToString());

            //else
            //{
            //    txtMaPN.Text = txtTinhTrangNhap.Text = txtTenNV.Text = txtNgayNhap.Text = string.Empty;
            //    txtMaSP.Text = txtTenSP.Text = txtSLNhap.Text = txtNSX.Text = txtHSD.Text = string.Empty;
            //    dgvCTPN.DataSource = null;
            //}
        }

        public void LoadBH()
        {
            timer1.Enabled = true;
            timer1.Start();
            lblNgay.Text = DateTime.Now.ToString();
            lblTenNV1.Text = nv.LayTenNV(Form1.TenDN);
            txtMaSP1.Select();
            lblTongTien.Text = string.Format("{0:0,0}", decimal.Parse(lblTongTien.Text));
            dgvCTHD.DataSource = null;
            setupColumDGV();
            if (hd.LayMaHDMax() == string.Empty)
            {
                lblMaHD.Text = "HD01";
            }
            else
            {
                int hdmax = int.Parse(hd.LayMaHDMax().Trim());
                lblMaHD.Text = "HD0" + (hdmax + 1).ToString();
            }
            btnDoiTra.Enabled = btnDSSP.Enabled = true;
            btnThemMoi.Enabled =  btnXoa.Enabled = btnThanhToan.Enabled = btnCapNhatHD.Enabled = false;
            txtTienNhan.Text = lblTienThoi.Text = "";
            // btnSua.Visible = btnXoa.Visible = false;
            txtMaSP1.Text = txtTenSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = lblTongTien.Text = "";
            nupdownSoLuong.Value = 0;
        }


        private void dgvPhieuChuaNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuChuaNhap.RowCount != 0)
            {
                dgvCTPN.DataSource = ctpn.GetCTPN(dgvPhieuChuaNhap.CurrentRow.Cells[0].Value.ToString());
                txtMaPN.Text = dgvPhieuChuaNhap.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = nv.LayTenNV(Form1.TenDN);
                txtNgayNhap.Text = DateTime.Now.ToShortDateString();
                txtTinhTrangNhap.Text = dgvPhieuChuaNhap.CurrentRow.Cells[3].Value.ToString();

            }
            else
            {
                txtMaPN.Text = txtTinhTrangNhap.Text = txtTenNV.Text = txtNgayNhap.Text = string.Empty;
            }
        }

        private void dgvCTPN_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCTPN.RowCount != 0)
                {
                    txtMaSP.Text = dgvCTPN.CurrentRow.Cells[1].Value.ToString();
                    txtTenSP.Text = sp.layTenSP(txtMaSP.Text);
                    txtSLNhap.Text = dgvCTPN.CurrentRow.Cells[2].Value.ToString();
                    txtNSX.Text = dgvCTPN.CurrentRow.Cells[4].Value.ToString();
                    txtHSD.Text = dgvCTPN.CurrentRow.Cells[5].Value.ToString();

                }
                else
                {
                    txtMaSP.ResetText();
                    txtTenSP.Text = txtSLNhap.Text = txtNSX.Text = txtHSD.Text = string.Empty;
                }
            }
            catch
            {
                return;
            }

        }
       
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            

            if (pn.updatePN(txtMaPN.Text, DateTime.Today.ToString(), Form1.TenDN, "Đã nhập"))
            {

                int flag = 0;
                for (int i = 0; i < dgvCTPN.RowCount; i++)
                {
                    string masp = dgvCTPN.Rows[i].Cells[1].Value.ToString();
                    int sl = int.Parse(dgvCTPN.Rows[i].Cells[2].Value.ToString());
                    DateTime hsd = DateTime.Parse(dgvCTPN.Rows[i].Cells[5].Value.ToString());
                    if (hsdsp.insertHSD(masp, hsd, sl))
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
                    LoadNH();
                    MessageBox.Show("Cập Nhật Thành công");
                }
                else
                {
                    MessageBox.Show("Cập Nhật Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất Bại");
            }
        }
        public static string MaQL = string.Empty;
        public static string MaDoi = string.Empty;
        public static string HSD;


        int index = -1;
        int slm = 0;
        int ttm = 0;
        int dem = 0;

        DataGridViewTextBoxColumn hd1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd5 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn hd6 = new DataGridViewTextBoxColumn();
        private void setupColumDGV()
        {
            dgvCTHD.Columns.Clear();
            // Column1
            // 
            dgvCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            hd3.DataPropertyName = "dvt";
            hd3.HeaderText = "Đơn Vị Tính";
            hd3.Name = "Column3";
            hd3.DisplayIndex = 3;
            hd3.ReadOnly = true;
            // 
            // Column4
            // 
            hd4.DataPropertyName = "sl";
            hd4.HeaderText = "Số Lượng";
            hd4.Name = "Column4";
            hd4.DisplayIndex = 4;
            hd4.ReadOnly = true;
            // hd3.Width = 100;
            // 
            // Column4
            // 
            hd5.DataPropertyName = "gb";
            hd5.HeaderText = "Giá Bán";
            hd5.Name = "Column5";
            hd5.DisplayIndex = 5;
            hd5.ReadOnly = true;
            //hd4.Width = 100;
            //
            // Column5
            // 
            hd6.DataPropertyName = "tt";
            hd6.HeaderText = "Thành Tiền";
            hd6.Name = "Column6";
            hd6.DisplayIndex = 6;
            hd6.ReadOnly = true;
            //hd5.Width = 100;
            //
            dgvCTHD.Columns.Add(hd1);
            dgvCTHD.Columns.Add(hd2);
            dgvCTHD.Columns.Add(hd3);
            dgvCTHD.Columns.Add(hd4);
            dgvCTHD.Columns.Add(hd5);
            dgvCTHD.Columns.Add(hd6);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNgay.Text = DateTime.Now.ToString();
        }
        public int kttrungdgv(string masp)
        {
            for (int i = 0; i < dgvCTHD.Rows.Count; i++)
            {
                if (masp == dgvCTHD.Rows[i].Cells[0].Value.ToString())
                {
                    index = i;
                    slm = int.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString());
                    ttm = int.Parse(dgvCTHD.Rows[i].Cells[5].Value.ToString());
                    return 1;
                }
            }
            return 0;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (txtMaSP1.Text != string.Empty)
                {
                    if (bg.getGiaBanKM(txtMaSP1.Text).Rows.Count != 0)
                    {
                        foreach (DataRow dr in bg.getGiaBanKM(txtMaSP1.Text).Rows)
                        {

                            if (dr["GiaKhuyenMai"].ToString() == string.Empty)
                            {
                                txtGiaBan.Text = string.Format("{0:0,0}", decimal.Parse(dr["GiaBan"].ToString()));
                            }
                            else
                            {
                                txtGiaBan.Text = string.Format("{0:0,0}", decimal.Parse(dr["GiaKhuyenMai"].ToString()));
                            }
                        }

                        foreach (DataRow dr in sp.GetSanPhamTheoMa(txtMaSP1.Text).Rows)
                        {
                            txtTenSP1.Text = dr["TenSP"].ToString();
                            txtDVT1.Text = dr["DVT"].ToString();
                        }
                        nupdownSoLuong.Value = 1;
                    }
                    else
                    {
                        txtTenSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = string.Empty;
                        nupdownSoLuong.Value = 0;
                    }
                }
                else
                {
                    txtTenSP1.Text = txtDVT1.Text = txtGiaBan.Text = string.Empty;

                }
            }
            catch
            {
                return;
            }
        }

        public static int slc = 0;
        public static int slm2 = 0;
        public static string masp = string.Empty;





        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            nupdownSoLuong.Value = 1;
            //txtThanhTien.Text = (int.Parse(txtGiaBan.Text) * int.Parse(nupdownSoLuong.Value.ToString())).ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThanhToan.Enabled = true;
            if (txtMaSP1.Text == string.Empty)
            {
                MessageBox.Show("Mời nhập sản phẩm cần thanh toán!");
                return;
            }
            if (nupdownSoLuong.Value.ToString() == string.Empty)
            {
                MessageBox.Show("Mời nhập Số lượng Sản Phẩm!");
                return;
            }
            DonBanHang dbh = new DonBanHang();

            if (kttrungdgv(txtMaSP1.Text) == 1)
            {
                list.RemoveAt(index);
                dbh.Msp = txtMaSP1.Text;
                dbh.Tsp = txtTenSP1.Text;
                dbh.Dvt = txtDVT1.Text;
                dbh.Sl = int.Parse(nupdownSoLuong.Value.ToString()) + slm;
                dbh.Gb = float.Parse(txtGiaBan.Text);
                dbh.Tt = float.Parse(txtThanhTien.Text) + ttm;
                list.Add(dbh);
                dgvCTHD.DataSource = null;
                setupColumDGV();
                dgvCTHD.DataSource = list;
                lblTongTien.Text = string.Format("{0:0,0}", decimal.Parse(tt.tinhTongTien(dgvCTHD, 5).ToString()));

                txtMaSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = txtTenSP1.Text = "";
                nupdownSoLuong.Value = 0;
            }
            else
            {
                dbh.Msp = txtMaSP1.Text;
                dbh.Tsp = txtTenSP1.Text;
                dbh.Dvt = txtDVT1.Text;
                dbh.Sl = int.Parse(nupdownSoLuong.Value.ToString());
                dbh.Gb = float.Parse(txtGiaBan.Text);
                dbh.Tt = float.Parse(txtThanhTien.Text);
                list.Add(dbh);
                dgvCTHD.DataSource = null;
                setupColumDGV();
                dgvCTHD.DataSource = list;
                lblTongTien.Text = string.Format("{0:0,0}", decimal.Parse(tt.tinhTongTien(dgvCTHD, 5).ToString()));
                txtMaSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = txtTenSP1.Text = "";
                nupdownSoLuong.Value = 0;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            //LoadBH();
            int flag = 0;
            if (hd.insert(lblMaHD.Text, DateTime.Now, float.Parse(lblTongTien.Text), "Đã thanh Toán", Form1.TenDN))
            {
                string mahd = lblMaHD.Text;
                for (int i = 0; i < dgvCTHD.RowCount; i++)
                {
                    string MaSP = dgvCTHD.Rows[i].Cells[0].Value.ToString();
                    int sl = int.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString());
                    float gb = float.Parse(dgvCTHD.Rows[i].Cells[4].Value.ToString());
                    float tt = float.Parse(dgvCTHD.Rows[i].Cells[5].Value.ToString());
                    int slt = 0;
                    slt = sp.LayTongSLT(MaSP);
                    if (cthd.insert(mahd, MaSP, sl, gb, tt))
                    {
                        if (sl == slt)
                        {
                            for (int k = 0; k < hsdsp.GetDataTheoMaSP(MaSP).Rows.Count; k++)
                            {
                                DateTime hsd1 = DateTime.Now;
                                foreach (DataRow dr in hsdsp.timHSDMin(MaSP).Rows)
                                {
                                    hsd1 = DateTime.Parse(dr["HSD"].ToString());
                                    if (hsdsp.updateSL_TinhTrangHH(0, "Hết hàng", MaSP, hsd1.ToString()))
                                    {
                                        flag = 1;
                                    }
                                    else
                                    {
                                        flag = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DateTime hsd1 = DateTime.Now;
                            int sltHSD = 0;
                            foreach (DataRow dr in hsdsp.timHSDMin(MaSP).Rows)
                            {
                                hsd1 = DateTime.Parse(dr["HSD"].ToString());
                                sltHSD = int.Parse(dr["SoLuong"].ToString());
                            }
                            if (hsdsp.updateSL_TinhTrangHH(sltHSD - sl, null, MaSP, hsd1.ToString()))
                            {
                                flag = 1;
                            }
                            else
                            {
                                flag = 0;
                            }

                        }
                    }
                    MaSP = "";
                    sl = 0;
                    gb = 0;
                    tt = 0;
                }
                if (flag == 1)
                {
                    MessageBox.Show("Thanh toán thành công");
                   
                    LoadBH();
                  
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại");
                }
            }
            else
            {
                MessageBox.Show("Thanh toán thất Bại");
            }
        }

        private void btnDoiTra_Click(object sender, EventArgs e)
        {
            btnDoiTra.Enabled = false;
            btnThemMoi.Enabled = btnCapNhatHD.Enabled = btnXoa.Enabled = true;
            txtTimKiemHD.Select();

            lblMaHD.Text = string.Empty;
            dem++;
            if (dem % 2 != 0)
            {
                frmDangNhapQL frm = new frmDangNhapQL();
                frm.ShowDialog();
            }
            if (MaQL != string.Empty)
            {
                if (dem % 2 != 0)
                {
                   
                    txtTimKiemHD.Visible = true;                    
                    lblTenNV1.Text = nv.LayTenNV(MaQL);
                }
                else
                {
                    txtTimKiemHD.Visible = false;
                    LoadBH();
                }
            }
            else
            {
                LoadBH();
                return;
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = btnDoiTra.Enabled = btnCapNhat.Enabled = false;
            btnThem.Enabled = true;
            if (btnThanhToan.Enabled)
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có muốn thanh toán không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                {
                    list.Clear();
                    dgvCTHD.DataSource = null;
                    setupColumDGV();
                   
                    LoadBH();
                    lblTongTien.ResetText();
                }
                else
                {
                    return;
                }
            }
            else
            {
                dgvCTHD.DataSource = null;
                setupColumDGV();
                
                LoadBH();
                lblTongTien.ResetText();

            }
        }

        private void btnDSSP_Click(object sender, EventArgs e)
        {
            frmDanhSachSP frm = new frmDanhSachSP();
            frm.Show();
        }


        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiemHD.Text != string.Empty)
                {
                    setupColumDGV();
                    if (hd.GetDataTheoMaHD(txtTimKiemHD.Text.Trim()).Rows.Count != 0)
                    {

                        btnThanhToan.Enabled = false;
                        
                        cthd.getCTHD(dgvCTHD, txtTimKiemHD.Text.Trim());
                        foreach (DataRow dr in hd.GetDataTheoMaHD(txtTimKiemHD.Text.Trim()).Rows)
                        {
                            lblMaHD.Text = dr["MaHD"].ToString();
                            lblNgay.Text = DateTime.Parse(dr["NgayLap"].ToString()).ToString("dd/MM/yyyy hh:mm");
                            lblTinhTrang.Text = dr["TrinhTrangTT"].ToString();
                        }

                        lblTongTien.Text = string.Format("{0:0,0}", decimal.Parse(tt.tinhTongTien(dgvCTHD, 5).ToString()));
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        lblMaHD.Text = lblTinhTrang.Text = txtMaSP1.Text = txtTenSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = string.Empty;
                        nupdownSoLuong.Value = 0;
                        dgvCTHD.DataSource = cthd.GetChiTietHD(txtTimKiemHD.Text);
                    }
                   
                }
                else
                {
                    LoadBH();
                    dgvCTHD.DataSource = cthd.GetChiTietHD(txtTimKiemHD.Text);

                }
            }
            catch
            {
                return;
            }


        }

        private void nupdownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int slt = sp.LayTongSLT(txtMaSP1.Text);
                int sln = int.Parse(nupdownSoLuong.Value.ToString());
                if (sln > slt)
                {
                    MessageBox.Show("Không đủ hàng rồi ạ!");
                }
                else
                {
                    float gb = float.Parse(txtGiaBan.Text);
                    txtThanhTien.Text = string.Format("{0:0,0}", decimal.Parse((gb * sln).ToString()));
                }
            }
            catch
            {
                return;
            }
        }

        private void dgvCTHD_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCTHD.RowCount != 0)
                {
                    txtMaSP1.Text = dgvCTHD.CurrentRow.Cells[0].Value.ToString();
                    txtTenSP1.Text = dgvCTHD.CurrentRow.Cells[1].Value.ToString();
                    txtDVT1.Text = dgvCTHD.CurrentRow.Cells[2].Value.ToString();
                    nupdownSoLuong.Value = int.Parse(dgvCTHD.CurrentRow.Cells[3].Value.ToString());
                    txtGiaBan.Text = string.Format("{0:0,0}", decimal.Parse(dgvCTHD.CurrentRow.Cells[4].Value.ToString()));
                    txtThanhTien.Text = string.Format("{0:0,0}", decimal.Parse(dgvCTHD.CurrentRow.Cells[5].Value.ToString()));
                    slc = int.Parse(nupdownSoLuong.Value.ToString());
                }
                else
                {
                    lblMaHD.Text = lblTinhTrang.Text = txtMaSP1.Text = txtTenSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = string.Empty;
                    nupdownSoLuong.Value = 0;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnCapNhatHD_Click(object sender, EventArgs e)
        {
            masp = txtMaSP1.Text;
            btnThemMoi.Enabled = btnThem.Enabled = true;
            if (txtTimKiemHD.Text == string.Empty)
            {
                MessageBox.Show("Mời bạn chọn hóa đơn cần tìm!");
                return;
            }
            if (dgvCTHD.SelectedRows == null)
            {
                MessageBox.Show("Mời bạn chọn dòng cần tìm!");
                return;
            }
            int flag = 0;
           
            
            if (cthd.Update(lblMaHD.Text, masp, int.Parse(nupdownSoLuong.Value.ToString()), float.Parse(txtThanhTien.Text)))
            {
                if (hd.UpdateHD(lblMaHD.Text, MaQL, DateTime.Now))
                {
                    slm2 = int.Parse(nupdownSoLuong.Value.ToString());

                    string madoi = "";
                    if (dt.LayMaDoiMax() == string.Empty)
                    {
                        madoi = "DT01";
                    }
                    else
                    {
                        int dmax = int.Parse(dt.LayMaDoiMax());
                        madoi = "DT0" + (dmax + 1).ToString();
                    }
                    if (dt.Insert(madoi, MaQL, lblMaHD.Text, DateTime.Today))
                    {
                        if (ctdt.Insert(madoi, masp, slc - slm2))
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
                    MessageBox.Show("Cập nhật hóa đơn thành công");
                   
                    txtTimKiemHD.Text = string.Empty;
                    setupColumDGV();
                    cthd.getCTHD(dgvCTHD, lblMaHD.Text);
                    lblTongTien.Text = tt.tinhTongTien(dgvCTHD, 5).ToString();
                    txtMaSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = txtTenSP1.Text = "";
                    nupdownSoLuong.Value = 0;
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn thất bại Thất Bại");
                }

            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }            
            
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThemMoi.Enabled = true;
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                if (txtTimKiemHD.Text == string.Empty)
                {
                    MessageBox.Show("Mời bạn chọn hóa đơn cần xóa!");
                    return;
                }
                if (dgvCTHD.SelectedRows == null)
                {
                    MessageBox.Show("Mời bạn chọn dòng cần xóa!");
                    return;
                }
                int flag = 0;

                if (cthd.Delete(lblMaHD.Text, txtMaSP1.Text))
                {
                    if (hd.UpdateHD(lblMaHD.Text, MaQL, DateTime.Now))
                    {
                        string madoi = "";
                        if (dt.LayMaDoiMax() == null)
                        {
                            madoi = "DT01";
                        }
                        else
                        {
                            int dmax = int.Parse(dt.LayMaDoiMax());
                            madoi = "DT0" + (dmax + 1).ToString();
                        }
                        if (dt.Insert(madoi, MaQL, lblMaHD.Text, DateTime.Now))
                        {
                            if (ctdt.Insert(madoi, txtMaSP1.Text, slc - slm2))
                            {
                                flag = 1;
                            }

                            else
                            {
                                flag = 0;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Trả hàng thất bại");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật hóa đơn thất bại");
                    }
                }
                if (flag == 1)
                {
                    MessageBox.Show("Trả hàng thành công");
                    txtTimKiemHD.Text = string.Empty;
                    setupColumDGV();                    
                    cthd.getCTHD(dgvCTHD, lblMaHD.Text);
                    lblTongTien.Text = tt.tinhTongTien(dgvCTHD, 5).ToString();
                    txtMaSP1.Text = txtDVT1.Text = txtGiaBan.Text = txtThanhTien.Text = txtTenSP1.Text = "";
                }
                else
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn thất bại");
                }
            }
            else
            {
                return;
            }
        }

       

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dgvCTPN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            List<ChiTietPhieuNhap> pListCTPN = new List<ChiTietPhieuNhap>();
            // Đổ dữ liệu vào danh sách

            for (int i = 0; i < dgvCTPN.RowCount; i++)
            {
                ChiTietPhieuNhap ii = new ChiTietPhieuNhap();
                ii.MaPN = dgvCTPN.Rows[i].Cells[0].Value.ToString();
                ii.MaSP = dgvCTPN.Rows[i].Cells[1].Value.ToString();
                ii.SoLuongNhap = int.Parse(dgvCTPN.Rows[i].Cells[2].Value.ToString());
                ii.GhiChu = dgvCTPN.Rows[i].Cells[3].Value.ToString();
                ii.NSX = dgvCTPN.Rows[i].Cells[4].Value.ToString();
                ii.HSD = dgvCTPN.Rows[i].Cells[5].Value.ToString();
                pListCTPN.Add(ii);
            }  

            string path = string.Empty;
            excel.ExportKhoa(pListCTPN, ref path, false);
            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thôngtin",
               MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("Không tồn tại");
            }
        }

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTienNhan.Text = string.Format("{0:0,0}", decimal.Parse(txtTienNhan.Text));
                txtTienNhan.SelectionStart = txtTienNhan.Text.Length;
                lblTienThoi.Text = (double.Parse(lblTongTien.Text) - double.Parse(txtTienNhan.Text)).ToString();
                lblTienThoi.Text = string.Format("{0:0,0}", decimal.Parse(lblTienThoi.Text));
            }
            catch
            {
                return;
            }
        }
    }
    
}
