using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace PhanMem_QLCuaHangDienThoai
{
    public partial class frmNhapHang : Form
    {
        NhapHang_DAL NhapHangDal = new NhapHang_DAL();
        QLCH_DAL Dal = new QLCH_DAL();
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            txtMaHD.Enabled = false;

            cbSanPham.DataSource = NhapHangDal.LoadCbSanPham();
            cbSanPham.DisplayMember = "TenSP";
            cbSanPham.ValueMember = "MaSP";

            cbNhaCungCap.DataSource = NhapHangDal.LoadCbNhaCUngCap();
            cbNhaCungCap.DisplayMember = "TenNCC";
            cbNhaCungCap.ValueMember = "MaNCC";

            cbMaNhanVien.DataSource = NhapHangDal.LoadCbNhanVien();
            cbMaNhanVien.DisplayMember = "TenNV";
            cbMaNhanVien.ValueMember = "MaNV";

            txtThanhTienNew.Enabled = false;
        }

        private void BtnThemHD_Click(object sender, EventArgs e)
        {
            //Kiem tra rong
            HOADONNHAP hdn = new HOADONNHAP();
            hdn.MaNCC = Convert.ToInt32(cbNhaCungCap.SelectedValue.ToString());
            hdn.MaNV = Convert.ToInt32(cbMaNhanVien.SelectedValue.ToString());
            hdn.NgayLapHDN = DateTime.Parse(dateNgayLap.Value.ToString());
            hdn.ThanhTienHDN = 0;
            hdn.GhiChu = txtGhiChu.Text;
            if (NhapHangDal.LuuThongTinHoaDon(hdn) == 1)
            {
                MessageBox.Show("Lưu thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            txtMaHD.Text = NhapHangDal.LayMaHoaDon();
        }

        private void CbSanPham_TextChanged(object sender, EventArgs e)
        {
            NhapHangDal.LayThongTinSanPham(cbSanPham.SelectedValue.ToString(), txtTenSP, txtDonGiaNhap, txtDonGiaBan, txtMoTa, txtThuongHieu, txtSoLuongTon);
        }

        private void BtnLuuSP_Click(object sender, EventArgs e)
        {
            //Kiểm tra rỗng
            if (string.IsNullOrEmpty(txtTenSP.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên sản phẩm! ");
                this.txtTenSP.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống đơn giá nhập! ");
                this.txtDonGiaNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống đơn giá bán! ");
                this.txtDonGiaBan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống đơn giá nhập! ");
                this.txtDonGiaNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống số lượng! ");
                this.txtSoLuong.Focus();
                return;
            }







            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(cbSanPham.SelectedValue.ToString());
            dataGridView1.Rows[n].Cells[1].Value = cbSanPham.Text;
            dataGridView1.Rows[n].Cells[2].Value = txtMaHD.Text;
            dataGridView1.Rows[n].Cells[3].Value = Convert.ToInt32(txtSoLuong.Text);

            dataGridView1.Rows[n].Cells[4].Value = float.Parse(txtDonGiaNhap.Text);
            dataGridView1.Rows[n].Cells[5].Value = (double.Parse(txtDonGiaNhap.Text)) * (double.Parse(txtSoLuong.Text));
            dataGridView1.Rows[n].Cells[6].Value = float.Parse(txtDonGiaBan.Text);
            dataGridView1.Rows[n].Cells[7].Value = float.Parse(txtThuongHieu.Text);

            txtSoLuong.Text = "";
            txtMoTa.Text = "";
            txtTenSP.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtThuongHieu.Text = "";

            int sc = dataGridView1.Rows.Count;
            double thanhtien = 0;
            for (int j = 0; j < sc; j++)
            {
                thanhtien += double.Parse(dataGridView1.Rows[j].Cells["TongTien"].Value.ToString());
            }
            txtThanhTienNew.Text = thanhtien.ToString();
        }

        private void BtnHuySP_Click(object sender, EventArgs e)
        {
            txtMoTa.Text = "";
            txtTenSP.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtSoLuong.Text = "";
            txtThuongHieu.Text = "";

        }

        private void BtnLuuCTHD_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string masp = dataGridView1.Rows[i].Cells["MaSP"].Value.ToString();
                string tensp = dataGridView1.Rows[i].Cells["TenSP"].Value.ToString();
                string mahdn = dataGridView1.Rows[i].Cells["MaHDN"].Value.ToString();
                string soluongnhap = dataGridView1.Rows[i].Cells["SoLuongNhap"].Value.ToString();
                string dongianhap = dataGridView1.Rows[i].Cells["DonGiaNhap"].Value.ToString();
                string tongtien = dataGridView1.Rows[i].Cells["TongTien"].Value.ToString();
                string dongiaban = dataGridView1.Rows[i].Cells["DonGiaBan"].Value.ToString();
                string mathuonghieu = dataGridView1.Rows[i].Cells["MaThuongHieu"].Value.ToString();

                CT_HDNHAP ct = new CT_HDNHAP();
                //ct.MACHITIET_PD = 1 + i++;
                ct.MaSP = Convert.ToInt32(masp);
                ct.MaHDN = Convert.ToInt32(mahdn);
                ct.SoLuongNhap = Convert.ToInt32(soluongnhap) + 1;
                ct.DonGiaNhap = Convert.ToInt32(dongianhap);
                ct.TongTien = Convert.ToDouble(tongtien);
                NhapHangDal.LuuChiTietNhapHang(ct);
                NhapHangDal.LuuChiTietNhapHang(ct);
                //{
                //    MessageBox.Show("Lưu đơn đặt hàng thành công rồi!");
                //}
                //else
                //{
                //    MessageBox.Show("Lưu đơn đặt hàng thất bại! Chúc bạn may mắn lần sau.");
                //}
                SANPHAM sp = new SANPHAM();

                //sp.MaSP = Convert.ToInt32(masp);
                //sp.TenSP = tensp;
                //sp.DonGiaNhap = float.Parse(dongianhap);
                //sp.DonGiaBan = float.Parse(dongiaban);
                sp.SoLuongTon = (Convert.ToInt32(txtSoLuongTon.Text) + (Convert.ToInt32(soluongnhap)));
                //sp.MoTa = txtMoTa.Text;
                //sp.MaThuongHieu = Convert.ToInt32(mathuonghieu);
                NhapHangDal.UpdateSanPham(Convert.ToInt32(masp), Convert.ToInt32(sp.SoLuongTon), Convert.ToInt32(dongianhap), Convert.ToInt32(dongiaban));
            }
            HOADONNHAP hd = new HOADONNHAP();
            hd.ThanhTienHDN = Convert.ToInt32(txtThanhTienNew.Text);
            NhapHangDal.UpdateThanhTienHD(Convert.ToInt32(txtMaHD.Text), Convert.ToInt32(txtThanhTienNew.Text));
            MessageBox.Show("Nhập hàng thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            cbSanPham.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            cbSanPham.Enabled = false;
        }

        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            cbSanPham.Enabled = true;
            int rowSelected = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Remove(dataGridView1.Rows[rowSelected]);
        }

        private void BtnHuyHD_Click(object sender, EventArgs e)
        {
            try
            {
                HOADONNHAP hdn = new HOADONNHAP();
                hdn.MaHDN = Convert.ToInt32(txtMaHD.Text);
                //int makho = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (NhapHangDal.XoaHoaDonNhap(Convert.ToInt32(txtMaHD.Text)) == 1)
                {
                    MessageBox.Show("Đã hủy hóa đơn thành công rồi!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Hủy hóa đơn thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

            }
            catch
            {
                MessageBox.Show("Bạn không thể hủy!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            txtMaHD.Text = "";
            cbNhaCungCap.Text = "";
            txtGhiChu.Text = "";
            cbMaNhanVien.Text = "";
        }

        private void FrmNhapHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("Bạn có chắc muốn đóng ??", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnThoatHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void BtnThemNCCMoi_Click(object sender, EventArgs e)
        {
            frmNhaCungCap kh = new frmNhaCungCap();
            kh.ShowDialog(); 

            //cbNhaCungCap.DataSource = Dal.loa();
            //cboKH.DisplayMember = "TenKH";
            //cboKH.ValueMember = "MaKH";
        }
    }
}
