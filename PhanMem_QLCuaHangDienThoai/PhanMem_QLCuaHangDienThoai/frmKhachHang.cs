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
    public partial class frmKhachHang : Form
    {
        KhachHangDAL khachhang = new KhachHangDAL();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = khachhang.LoadDataGridKhachHang();
            txtMaKhachHang.Enabled = false;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            ////Kiem tra rong
            //if (string.IsNullOrEmpty(txtTenSanPham.Text.Trim()))
            //{
            //    MessageBox.Show("Không được bỏ trống tên sản phẩm! ");
            //    this.txtTenSanPham.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            //{
            //    MessageBox.Show("Không được bỏ trống đơn gái nhập! ");
            //    this.txtDonGiaNhap.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            //{
            //    MessageBox.Show("Không được bỏ trống đơn giá bán! ");
            //    this.txtDonGiaBan.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtSoLuongTon.Text.Trim()))
            //{
            //    MessageBox.Show("Không được bỏ trống số lượng tồn! ");
            //    this.txtSoLuongTon.Focus();
            //    return;
            //}

            KHACHHANG kh = new KHACHHANG();
            kh.TenKH = txtTenKhachHang.Text;
            kh.SdtKH = txtSoDienThoai.Text;
            kh.DiaChi = txtDiaChi.Text;

            if (khachhang.LuuThongTinKhachHang(kh) == 1)
            {
                MessageBox.Show("Lưu thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = khachhang.LoadDataGridKhachHang();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.TenKH = txtTenKhachHang.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.SdtKH = txtSoDienThoai.Text;
            string makh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (khachhang.SuaThongTinKhachHang(Convert.ToInt32(makh), txtTenKhachHang.Text, txtDiaChi.Text, txtSoDienThoai.Text) == 1)
            {
                MessageBox.Show("Đã sửa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Sửa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            dataGridView1.DataSource = khachhang.LoadDataGridKhachHang();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                KHACHHANG kh = new KHACHHANG();
                kh.MaKH = Convert.ToInt32(txtMaKhachHang.Text);
                string makh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (khachhang.XoaHoaThongTinKhachHnag(Convert.ToInt32(makh)) == 1)
                {
                    MessageBox.Show("Đã xóa thành công rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Chúc bạn may mắn lần sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                dataGridView1.DataSource = khachhang.LoadDataGridKhachHang();
            }
            catch
            {
                MessageBox.Show("Bạn không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("Bạn có chắc muốn đóng ??", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaKhachHang.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtTenKhachHang.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
        }

        private void TxtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
