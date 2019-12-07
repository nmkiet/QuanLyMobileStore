using DAL;
using System;
using System.Windows.Forms;

namespace PhanMem_QLCuaHangDienThoai
{
    public partial class frmNhanVien : Form
    {
        QLCH_DAL Dal = new QLCH_DAL();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.LoadDataGridNhanVien();

            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Focus();

            txtTenNhanVien.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSoDienThoai.Enabled = false;
            dateNamSinh.Enabled = false;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra rong
            if (string.IsNullOrEmpty(txtTenNhanVien.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên nhân viên! ");
                this.txtTenNhanVien.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoDienThoai.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống số điện thoại! ");
                this.txtSoDienThoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống địa chỉ! ");
                this.txtDiaChi.Focus();
                return;
            }

            NHANVIEN nv = new NHANVIEN();
            nv.TenNV = txtTenNhanVien.Text;
            nv.DiaChiNV = txtDiaChi.Text;
            nv.NgaySinh = dateNamSinh.Value.ToString("MM/dd/yyyy");
            nv.SdtNV = txtSoDienThoai.Text;
            if (Dal.LuuThongTinNhanVien(nv) == 1)
            {
                MessageBox.Show("Lưu thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = Dal.LoadDataGridNhanVien();


            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MaNV = Convert.ToInt32(txtMaNhanVien.Text);
                string manv = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (Dal.XoaThongTinNhanVien(Convert.ToInt32(manv)) == 1)
                {
                    MessageBox.Show("Đã xóa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                dataGridView1.DataSource = Dal.LoadDataGridNhanVien();
            }
            catch
            {
                MessageBox.Show("Bạn không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaNhanVien.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtTenNhanVien.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            dateNamSinh.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;

            txtTenNhanVien.Enabled = true;
            txtTenNhanVien.Focus();
            txtDiaChi.Enabled = true;
            txtSoDienThoai.Enabled = true;
            dateNamSinh.Enabled = true;
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra rong
            if (string.IsNullOrEmpty(txtTenNhanVien.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên nhân viên! ");
                this.txtTenNhanVien.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoDienThoai.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống số điện thoại! ");
                this.txtSoDienThoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống địa chỉ! ");
                this.txtDiaChi.Focus();
                return;
            }

            NHANVIEN nv = new NHANVIEN();
            nv.TenNV = txtTenNhanVien.Text;
            nv.DiaChiNV = txtDiaChi.Text;
            nv.NgaySinh = dateNamSinh.Value.ToString("MM/dd/yyyy");
            nv.SdtNV = txtSoDienThoai.Text;
            string manv = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (Dal.SuaThongTinNhanVien(Convert.ToInt32(manv), txtTenNhanVien.Text, txtDiaChi.Text, dateNamSinh.Value.ToString("MM/dd/yyyy"), txtSoDienThoai.Text) == 1)
            {
                MessageBox.Show("Đã sửa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Sửa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = Dal.LoadDataGridNhanVien();

            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void BntThem_Click(object sender, EventArgs e)
        {
            txtTenNhanVien.Enabled = true;
            txtTenNhanVien.Focus();
            txtDiaChi.Enabled = true;
            txtSoDienThoai.Enabled = true;
            dateNamSinh.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Focus();

            txtTenNhanVien.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSoDienThoai.Enabled = false;
            dateNamSinh.Enabled = false;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void FrmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("Bạn có chắc muốn đóng ??", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
