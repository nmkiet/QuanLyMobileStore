using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DAL_BLL
{
    public partial class frmCauHinh : Form
    {
        QL_NguoiDung CauHinh = new QL_NguoiDung();
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void CboServer_DropDown(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            DataTable dt = CauHinh.GetServerName();
            cboServer.Items.Clear();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    cboServer.Items.Add(row[col]);
                }
            }
        }

        private void CboDataBase_DropDown(object sender, EventArgs e)
        {
            if (CheckedBeforSearchNameDB())
            {
                cboDataBase.Items.Clear();
                List<string> _list = CauHinh.GetDatabaseName(cboServer.Text, txtUsername.Text, txtPassword.Text);
                if (_list == null)
                {
                    MessageBox.Show("Thông tin cấu hình chưa chính xác");
                    return;
                }
                foreach (string item in _list)
                {
                    cboDataBase.Items.Add(item);
                }
            }
        }

        private bool CheckedBeforSearchNameDB()
        {
            if (cboServer.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập server name", "Thông Báo");
                cboServer.Focus();
                return false;
            }
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Username", "Thông Báo");
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Password", "Thông Báo");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            CauHinh.ChangeConnectionString(cboServer.Text, cboDataBase.Text, txtUsername.Text, txtPassword.Text);
            this.Close();
        }


    }




}
