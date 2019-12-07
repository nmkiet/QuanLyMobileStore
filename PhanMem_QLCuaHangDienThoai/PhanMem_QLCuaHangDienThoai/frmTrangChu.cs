using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace PhanMem_QLCuaHangDienThoai
{
    public partial class frmTrangChu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //QL_NguoiDung qlnd;
        
        public frmTrangChu()
        {
            InitializeComponent();
            //qlnd = new QL_NguoiDung();
            
        }

        private Form IsActive(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                    return f;
            }
            return null;
        }


        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(frmBanHang));
            if (form == null)
            {
                frmBanHang f = new frmBanHang();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(frmNhapHang));
            if (form == null)
            {
                frmNhapHang f = new frmNhapHang();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Nha_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(frmNhanVien));
            if (form == null)
            {
                frmNhanVien f = new frmNhanVien();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(frmKhachHang));
            if (form == null)
            {
                frmKhachHang f = new frmKhachHang();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(frmSanPham));
            if (form == null)
            {
                frmSanPham f = new frmSanPham();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void s_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(frmNhaCungCap));
            if (form == null)
            {
                frmNhaCungCap f = new frmNhaCungCap();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void BarButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            this.Hide();
            Frm_DangNhap dangnhap = new Frm_DangNhap();
            dangnhap.ShowDialog();


        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Office 2010 Blue";
        }
    }
}