using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAL_BLL
{
    public class QL_NguoiDung
    {

        public int Check_Config()
        {
            if (Properties.Settings.Default.DB_MobileStoreConn == string.Empty)
                return 1; // Chuỗi cấu hình không phù hợp

            SqlConnection _conn = new SqlConnection(Properties.Settings.Default.DB_MobileStoreConn);

            try
            {
                if (_conn.State == System.Data.ConnectionState.Closed)
                    _conn.Open();
                return 0; // Kết nối thành công. Chuỗi cấu hình hợp lệ!
            }
            catch
            {
                return 2; // Chuỗi cấu hình không phù hợp
            }
        }

        public int Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NguoiDung where TenDangNhap = '" + pUser + "' and MatKhau = '" + pPass + "'", Properties.Settings.Default.DB_MobileStoreConn);

            DataTable dt = new DataTable();
            daUser.Fill(dt);

            if (dt.Rows.Count == 0)
                return 0; // User không tồn tại
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "0")
            {
                return 1; // Không hoạt động
            }
            return 2;// Đăng nhập thành công
        }

        public List<string> LoadServerName()
        {
            List<string> srvname = new List<string> { };
            string servername = "";
            DataTable sqlSource = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow source in sqlSource.Rows)
            {
                string instanceName = source["InstanceName"].ToString();

                if (!string.IsNullOrEmpty(instanceName))
                {
                    servername = source["InstanceName"].ToString() + '\\' + source["ServerName"];
                }
                else
                {
                    servername = source["ServerName"].ToString();
                }
                srvname.Add(servername);
            }
            return srvname;
        }

        public DataTable GetServerName()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            return table;
        }

        //Duyệt all database
        public List<string> GetDatabaseName(string pServerName, string pUser, string pPass)
        {
            List<string> _list = new List<string>();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM sys.databases", "Data Source = " + pServerName + "; Initial Catalog = " + "master" + "; User ID = " + pUser + "; PassWord = " + pPass + "");

                da.Fill(dt);
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    foreach (System.Data.DataColumn col in dt.Columns)
                    {
                        _list.Add(row[col].ToString());
                    }
                }
            }
            catch
            {
                return null;
            }
            return _list;
        }


        //Save cấu hình
        public void ChangeConnectionString(string pServer, string pDatabase, string pUser, string pPass)
        {
            DAL_BLL.Properties.Settings.Default["DB_MobileStoreConn"] = "Data Source=" + pServer + ";Initial Catalog=" + pDatabase + ";User ID=" + pUser + ";Password = " + pPass + "";
            Properties.Settings.Default.Save();
        }

    }
}
