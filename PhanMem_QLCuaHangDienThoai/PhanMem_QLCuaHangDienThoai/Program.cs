using DevExpress.UserSkins;
using System;
using System.Windows.Forms;

namespace PhanMem_QLCuaHangDienThoai
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            Application.Run(new Frm_DangNhap());
        }

        public static frmTrangChu mainForm = null;
        public static Frm_DangNhap DangNhap = null;
    }
}
