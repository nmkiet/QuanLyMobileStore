using DAL;
using System;
using System.Windows.Forms;

namespace PhanMem_QLCuaHangDienThoai
{
    public partial class Frm_DangNhap : DevExpress.XtraEditors.XtraForm
    {
        QL_NguoiDung CauHinh = new QL_NguoiDung();
        private bool flag;
        private string nameAccount;//Giữ giá trị tên tài khoản gửi qua frmLogin
        private int numberRole;//Giữ giá trị quyền gửi qua frmLogin
        public string nameDatabase;//Giữ giá trị tên cơ sở dữ liệu gửi qua frmLogin
        public string NameDatabase
        {
            get { return nameDatabase; }
            set { nameDatabase = value; }
        }
        public string NameAccount
        {
            get { return nameAccount; }
            set { nameAccount = value; }
        }
        public int NumberRole
        {
            get { return numberRole; }
            set { numberRole = value; }
        }
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        public Frm_DangNhap()
        {
            InitializeComponent();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lblUsername.Text.ToLower());
                this.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Không được bỏ trống " + lblPassword.Text.ToLower());
                this.txtPassword.Focus();
                return;
            }

            if (CauHinh.Check_Config() == 0)
            {

                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
                //KT_GhiNhoMK();
            }
            if (CauHinh.Check_Config() == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại", "Thông báo");// Xử lý cấu hình
                ProcessConfig();
            }
            if (CauHinh.Check_Config() == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp", "Thông báo");// Xử lý cấu hình
                ProcessConfig();
            }
        }

        public void ProcessConfig()
        {
            frmCauHinh cauhinh = new frmCauHinh();
            cauhinh.ShowDialog();
        }

        //public void KT_GhiNhoMK()
        //{
        //    if (chk_GhiNhoMK.Checked)
        //    {
        //        Properties.Settings.Default.UserName = txtUsername.Text;
        //        Properties.Settings.Default.PassWord = txtPassword.Text;
        //        Properties.Settings.Default.RemeberPass = true;
        //        Properties.Settings.Default.Save();
        //    }
        //    else
        //    {
        //        Properties.Settings.Default.UserName = "";
        //        Properties.Settings.Default.PassWord = "";
        //        Properties.Settings.Default.RemeberPass = false;
        //        Properties.Settings.Default.Save();
        //    }
        //}

        public void ProcessLogin()
        {
            int result = CauHinh.Check_User(txtUsername.Text, txtPassword.Text);
            // Wrong username or pass
            if (result == 0)
            {
                MessageBox.Show("Sai " + lblUsername.Text + " Hoặc " + lblPassword.Text);
                return;
            }
            // Account had been disabled
            else if (result == 1)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            //MessageBox.Show("Đăng nhập thành công", "Thông Báo");
            //flag = true;

            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new frmTrangChu();
            }
            this.Visible = false;
            this.Hide();
            Program.mainForm.ShowDialog();
            this.Show();
        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }
    }
}
