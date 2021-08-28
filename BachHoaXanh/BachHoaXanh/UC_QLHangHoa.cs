using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using LiveCharts.Wpf;
using LiveCharts;

namespace BachHoaXanh
{
    public partial class UC_QLHangHoa : UserControl
    {
        public UC_QLHangHoa()
        {
            InitializeComponent();
        }
        QL_NguoiDung ql = new QL_NguoiDung();

        SanPhamBLL sp = new SanPhamBLL();
        HoaDonBLL hd = new HoaDonBLL();
        ChiTietHDBLL cthd = new ChiTietHDBLL();
        BangGiaBLL bg = new BangGiaBLL();
       PhieuNhapBLL pn = new PhieuNhapBLL();
        ChiTietPNBLL ctpn = new ChiTietPNBLL();
        HSDSanPhamBLL hsdsp = new HSDSanPhamBLL();
        NhanVienBLL nv = new NhanVienBLL();
        LoaiSanPhamBLL lsp = new LoaiSanPhamBLL();
        GetTotalBLL tt = new GetTotalBLL();
        private void UC_QLHangHoa_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = sp.GetSanPham();
            dgvDSHoaDon.DataSource = hd.GetHoaDon();
            dgvDSPN.DataSource = pn.GetPhieuNhap();
            chart2.DataSource = tt.GetData();
        }

        private void dgvDSHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDSHoaDon.RowCount != 0)
                {
                    string mahd = dgvDSHoaDon.CurrentRow.Cells[0].Value.ToString();
                    dgvCTHD.DataSource = cthd.GetChiTietHD(mahd);
                }
                else
                    dgvCTHD.DataSource = null;
            }
            catch
            {
                return;
            }
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            try
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
            catch
            {
                return;
            }

        }

        private void dgvDSPN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSPN.RowCount != 0)
            {
                string mahd = dgvDSPN.CurrentRow.Cells[0].Value.ToString();
                dgvCTPN.DataSource = ctpn.GetCTPN(mahd);
            }
            else
                dgvCTPN.DataSource = null;
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

        
        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiemHD.Text == string.Empty)
                {
                    dgvDSHoaDon.DataSource = hd.GetHoaDon();
                    lblThongKe.Visible = false;

                }
                else
                {
                    dgvDSHoaDon.DataSource = ql.Search(txtTimKiemHD.Text, "HoaDon", "MaHD", "MaNV");
                    int sl = int.Parse(dgvDSHoaDon.RowCount.ToString());

                    int slsp = 0;
                    for (int i = 0; i < dgvCTHD.RowCount; i++)
                    {
                        slsp += int.Parse(dgvCTHD.Rows[i].Cells[2].Value.ToString());
                    }
                    lblThongKe.Visible = true;
                    lblThongKe.Text = "Có " + sl.ToString() + " hóa đơn có sự xuất hiện của " + txtTimKiemHD.Text + " với tổng cộng " + slsp.ToString() + " sản phẩm";
                    //dgvDSHoaDon.DataSource = ql.SearchCT(txtTimKiemHD.Text, "HoaDon", "ChiTietHoaDon", "MaHD", "MaSP");
                }
            }
            catch
            {
                return;
            }
        }

        private void txtTimKiemPN_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
                if (txtTimKiemPN.Text == string.Empty)
                {
                    dgvDSPN.DataSource = pn.GetPhieuNhap();
                    lblThongePN.Visible = false;
                }
                else
                {
                    dgvDSPN.DataSource = ql.Search(txtTimKiemPN.Text, "PhieuNhap", "MaPN", "MaNV");
                    int sl = int.Parse(dgvDSPN.RowCount.ToString());
                    int  kha = 0;
                    for (int i = 0; i < dgvCTPN.RowCount; i++)
                    {
                        kha += int.Parse(dgvCTPN.Rows[i].Cells[2].Value.ToString());
                    }

                lblThongePN.Visible = true;
                lblThongePN.Text = "Hóa đơn có sự xuất hiện của " + txtTimKiemPN.Text + " với tổng cộng " + kha.ToString() + " sản phẩm";

                }

            //}
            //catch
            //{
            //    return;
            //}
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            WordExport word = new WordExport();
            string thangtk = DateTime.Now.Month.ToString();
            string ngay = DateTime.Now.Day.ToString();
            string thang = DateTime.Now.Month.ToString();
            string nam = DateTime.Now.Year.ToString();
            string sohd = hd.HDThang().Rows.Count.ToString();
            float tongtien = 0;
            foreach(DataRow dr in hd.HDThang().Rows)
            {
                tongtien += float.Parse(dr["TongTien"].ToString());
            }
            word.ThongKeDoanhThu(thangtk, ngay, thang, nam, nv.LayTenNV(Form1.TenDN), sohd, tongtien.ToString() ,nv.LayTenNV(Form1.TenDN));

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            chart2.Series["Total"].XValueMember = "Thang";
            chart2.Series["Total"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart2.Series["Total"].YValueMembers = "GiaTri";
            chart2.Series["Total"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
             

        }
    }
}
