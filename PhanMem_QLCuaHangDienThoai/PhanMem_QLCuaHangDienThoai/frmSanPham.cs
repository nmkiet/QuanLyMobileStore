using DAL;
using System;
using System.Windows.Forms;

namespace PhanMem_QLCuaHangDienThoai
{
    public partial class frmSanPham : Form
    {
        QLCH_DAL Dal = new QLCH_DAL();
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.LoadDataGridSanPham();

            cbThuongHieu.DataSource = Dal.LoadCbnThuongHieu();
            cbThuongHieu.DisplayMember = "TenThuongHieu";
            cbThuongHieu.ValueMember = "MaThuongHieu";

            txtMaSanPham.Enabled = false;
            //txtTenSanPham.Enabled = false;
            //txtDonGiaNhap.Enabled = false;
            //txtDonGiaBan.Enabled = false;
            //txtSoLuongTon.Enabled = false;
            //cbThuongHieu.Enabled = false;
            //txtMoTa.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra rong
            if (string.IsNullOrEmpty(txtTenSanPham.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên sản phẩm! ");
                this.txtTenSanPham.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống đơn gái nhập! ");
                this.txtDonGiaNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống đơn giá bán! ");
                this.txtDonGiaBan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoLuongTon.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống số lượng tồn! ");
                this.txtSoLuongTon.Focus();
                return;
            }

            SANPHAM sp = new SANPHAM();
            sp.TenSP = txtTenSanPham.Text;
            sp.DonGiaNhap = Convert.ToInt32(txtDonGiaNhap.Text);
            sp.DonGiaBan = Convert.ToInt32(txtDonGiaBan.Text);
            sp.SoLuongTon = Convert.ToInt32(txtSoLuongTon.Text);
            sp.MoTa = txtMoTa.Text;
            sp.MaThuongHieu = Convert.ToInt32(cbThuongHieu.SelectedValue.ToString());
            if (Dal.LuuThongTinSanPham(sp) == 1)
            {
                MessageBox.Show("Lưu thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = Dal.LoadDataGridSanPham();

            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            cbThuongHieu.Text = "";
            txtSoLuongTon.Text = "";
            txtMoTa.Text = "";
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SANPHAM sp = new SANPHAM();
                sp.MaSP = Convert.ToInt32(txtMaSanPham.Text);
                string masp = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (Dal.XoaThongTinSanPhamn(Convert.ToInt32(masp)) == 1)
                {
                    MessageBox.Show("Đã xóa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                dataGridView1.DataSource = Dal.LoadDataGridSanPham();
            }
            catch
            {
                MessageBox.Show("Bạn không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            cbThuongHieu.Text = "";
            txtSoLuongTon.Text = "";
            txtMoTa.Text = "";
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaSanPham.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtTenSanPham.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            txtDonGiaNhap.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            txtDonGiaBan.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            txtSoLuongTon.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            txtMoTa.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            cbThuongHieu.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra rong
            if (string.IsNullOrEmpty(txtTenSanPham.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên sản phẩm! ");
                this.txtTenSanPham.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống đơn gái nhập! ");
                this.txtDonGiaNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống đơn giá bán! ");
                this.txtDonGiaBan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoLuongTon.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống số lượng tồn! ");
                this.txtSoLuongTon.Focus();
                return;
            }

            SANPHAM sp = new SANPHAM();
            //sp.TenSP = txtTenSanPham.Text;
            //sp.DonGiaNhap = float.Parse(txtDonGiaNhap.Text);
            //sp.DonGiaBan = float.Parse(txtDonGiaBan.Text);
            //sp.SoLuongTon = Convert.ToInt32(txtSoLuongTon.Text);
            //sp.MoTa = txtMoTa.Text;
            //sp.MaThuongHieu = Convert.ToInt32(cbThuongHieu.SelectedValue.ToString());
            sp.TenSP = txtTenSanPham.Text;
            sp.DonGiaNhap = Convert.ToInt32(txtDonGiaNhap.Text);
            sp.DonGiaBan = Convert.ToInt32(txtDonGiaBan.Text);
            sp.SoLuongTon = Convert.ToInt32(txtSoLuongTon.Text);
            sp.MoTa = txtMoTa.Text;
            sp.MaThuongHieu = Convert.ToInt32(cbThuongHieu.SelectedValue.ToString());
            string masp = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (Dal.SuaThongTinSanPham(Convert.ToInt32(masp), txtTenSanPham.Text, Convert.ToInt32(txtDonGiaNhap.Text), Convert.ToInt32(txtDonGiaBan.Text), Convert.ToInt32(txtSoLuongTon.Text), txtMoTa.Text, Convert.ToInt32(cbThuongHieu.SelectedValue.ToString())) == 1)
            {
                MessageBox.Show("Đã sửa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Sửa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = Dal.LoadDataGridSanPham();

            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            cbThuongHieu.Text = "";
            txtSoLuongTon.Text = "";
            txtMoTa.Text = "";
        }

        private void FrmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("Bạn có chắc muốn đóng ??", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            cbThuongHieu.Text = "";
            txtSoLuongTon.Text = "";
            txtMoTa.Text = "";
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

        private void TxtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
