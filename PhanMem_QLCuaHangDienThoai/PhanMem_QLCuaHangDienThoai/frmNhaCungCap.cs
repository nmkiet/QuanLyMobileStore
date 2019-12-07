using DAL;
using System;
using System.Windows.Forms;

namespace PhanMem_QLCuaHangDienThoai
{
    public partial class frmNhaCungCap : Form
    {
        QLCH_DAL Dal = new QLCH_DAL(); 
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dal.LoadDataGridNhaCungCap();
            txtMaNhaCungCap.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            //textbox
            txtTenNhaCungCap.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra rong
            if (string.IsNullOrEmpty(txtTenNhaCungCap.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên nhà cung cấp! ");
                this.txtTenNhaCungCap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoDienThoai.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống số điện thoại! ");
                this.txtSoDienThoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống Email! ");
                this.txtEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống địa chỉ! ");
                this.txtDiaChi.Focus();
                return;
            }


            NHACUNGCAP ncc = new NHACUNGCAP();
            ncc.TenNCC = txtTenNhaCungCap.Text;
            ncc.SdtNCC = txtSoDienThoai.Text;
            ncc.Email = txtEmail.Text;
            ncc.DiaChi = txtDiaChi.Text;
            if (Dal.LuuThongTinNCC(ncc) == 1)
            {
                MessageBox.Show("Lưu thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = Dal.LoadDataGridNhaCungCap();

            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtTenNhaCungCap.Focus();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                NHACUNGCAP ncc = new NHACUNGCAP();
                ncc.MaNCC = Convert.ToInt32(txtMaNhaCungCap.Text);
                string mancc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (Dal.XoaThongTinNhaCungCap(Convert.ToInt32(mancc)) == 1)
                {
                    MessageBox.Show("Đã xóa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                dataGridView1.DataSource = Dal.LoadDataGridNhaCungCap();
            }
            catch
            {
                MessageBox.Show("Bạn không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = Dal.LoadDataGridNhaCungCap();

            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtTenNhaCungCap.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            //kiểm tra rỗng
            if (string.IsNullOrEmpty(txtTenNhaCungCap.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tên nhà cung cấp! ");
                this.txtTenNhaCungCap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoDienThoai.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống số điện thoại! ");
                this.txtSoDienThoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống Email! ");
                this.txtEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống địa chỉ! ");
                this.txtDiaChi.Focus();
                return;
            }
            NHACUNGCAP ncc = new NHACUNGCAP();
            ncc.TenNCC = txtTenNhaCungCap.Text;
            ncc.SdtNCC = txtSoDienThoai.Text;
            ncc.Email = txtEmail.Text;
            ncc.DiaChi = txtDiaChi.Text;
            string mancc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (Dal.SuaThongTinNhaCungCap(Convert.ToInt32(mancc), txtTenNhaCungCap.Text, txtSoDienThoai.Text, txtEmail.Text, txtDiaChi.Text) == 1)
            {
                MessageBox.Show("Đã sửa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Sửa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = Dal.LoadDataGridNhaCungCap();

            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtTenNhaCungCap.Focus();
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaNhaCungCap.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtTenNhaCungCap.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtTenNhaCungCap.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
        }

        private void BntThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;

            txtTenNhaCungCap.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;

            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtTenNhaCungCap.Focus();
        }

        private void FrmNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("Bạn có chắc muốn đóng ??", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void TxtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
