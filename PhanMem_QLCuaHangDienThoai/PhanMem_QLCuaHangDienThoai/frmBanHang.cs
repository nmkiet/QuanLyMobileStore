//using DAL_BLL;
using System;
using System.Windows.Forms;
using DAL;

namespace PhanMem_QLCuaHangDienThoai
{
    public partial class frmBanHang : DevExpress.XtraEditors.XtraForm
    {
        BanHang_DAL banhangdal = new BanHang_DAL();
        //DataTable dtSPChon;
        //DataSet ds;

        //SqlDataAdapter daKH;
        //SqlDataAdapter daHDB;
        //SqlDataAdapter daSP;
        //SqlDataAdapter daCTHDB;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            //Load cbo thuong hieu
            cboThuongHieu.DataSource = banhangdal.LoadThuongHieu();
            cboThuongHieu.DisplayMember = "TenThuongHieu";
            cboThuongHieu.ValueMember = "MaThuongHieu";


            //Load all ds SP
            drvDsSP.DataSource = banhangdal.LoadSanPham();

            //Load cboNV
            cboNV.DataSource = banhangdal.LoadNhanVien();
            cboNV.DisplayMember = "TenNV";
            cboNV.ValueMember = "MaNV";

            //Load cboKH
            cboKH.DataSource = banhangdal.LoadKhachHang();
            cboKH.DisplayMember = "TenKH";
            cboKH.ValueMember = "MaKH";

            //Load drvHoaDon
            drvHoaDon.DataSource = banhangdal.loadHDB();


        }

        private void CboThuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {

            drvDsSP.DataSource = banhangdal.LoadDsSpFromThuongHieu(cboThuongHieu.SelectedValue.ToString());
        }

        private void BtnTaoHoaDon_Click(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = true;
            btnXacNhan.Enabled = true;

            HOADONBAN hdb = new HOADONBAN();
            hdb.MaNV = int.Parse(cboNV.SelectedValue.ToString());
            hdb.MaKH = int.Parse(cboKH.SelectedValue.ToString());
            hdb.NgayLapHDB = DateTime.Parse(dateNgayTao.Text);
            //hdb.GhiChu = txtGhiChu.Text();

            if (txtSdt.Text == "" || dateNgayTao.Text == "")
            {

            }
            else
            {
                if (banhangdal.ThemHD(hdb))
                {
                    drvHoaDon.DataSource = hdb;
                    MessageBox.Show("Thanh cong");
                }
                else
                {
                    MessageBox.Show("That bai");
                }
            }
            txtMaHDB.Text = banhangdal.GetMaHDB();
            drvHoaDon.DataSource = banhangdal.loadHDB();
        }

        private void BtnThemCTHD_Click(object sender, EventArgs e)
        {
            int index = drvDsSP.CurrentRow.Index; //lấy ra chỉ số của row đang đc chọn
            string maChon = drvDsSP.Rows[index].Cells[0].Value.ToString().Trim(); // mã sản phẩm được chọn

        }

        private void DrvDsSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaSP.Text = drvDsSP.Rows[numrow].Cells[0].Value.ToString();
            txtTenSP.Text = drvDsSP.Rows[numrow].Cells[1].Value.ToString();
            txtGiaBan.Text = drvDsSP.Rows[numrow].Cells[3].Value.ToString();
            txtSoLuongTon.Text = drvDsSP.Rows[numrow].Cells[4].Value.ToString();
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            CT_HDBAN ct_hdb = new CT_HDBAN();
            ct_hdb.MaHDB = int.Parse(txtMaHDB.Text);
            ct_hdb.MaSP = int.Parse(txtMaSP.Text);
            ct_hdb.SoLuongBan = int.Parse(txtSoLuong.Text);
            ct_hdb.DonGiaBan = float.Parse(txtGiaBan.Text);
            ct_hdb.TongTien = (int.Parse(txtSoLuong.Text)) * (float.Parse(txtGiaBan.Text));
            if (banhangdal.ThemCT_HDB(ct_hdb))
            {
                drvCTHD.DataSource = ct_hdb;
                MessageBox.Show("Thanh cong");

                CapNhatThanhTien();
            }
            else
            {
                MessageBox.Show("That bai");
            }

            drvCTHD.DataSource = banhangdal.loadCT_HDB(int.Parse(txtMaHDB.Text));



            //int n = drvCTHD.Rows.Add();
            //drvCTHD.Rows[n].Cells[0].Value = int.Parse(txtMaHDB.Text);
            //drvCTHD.Rows[n].Cells[1].Value = int.Parse(cboNV.SelectedValue.ToString());
            //drvCTHD.Rows[n].Cells[2].Value = int.Parse(txtSoLuong.Text);
            ////dataGridView1.Rows[n].Cells[3].Value = cbHangHoa.SelectedValue.ToString();
            //dataGridView1.Rows[n].Cells[3].Value = Convert.ToInt32(cbHangHoa.SelectedValue.ToString());
            //txtSoLuong.Text = "";
        }

        private void CapNhatThanhTien()
        {
            int sc = drvCTHD.Rows.Count;

            float thanhtien = 0;
            if (sc == 0)
            {
                txtThanhTien.Text = "0";
            }
            else
            {
                for (int i = 0; i < sc; i++)
                {
                    //thanhtien = (float.Parse(thanhtien) + float.Parse(drvCTHD.Rows[i].Cells[4].Value.ToString())).ToString();
                    thanhtien += float.Parse(drvCTHD.Rows[i].Cells[4].Value.ToString());

                    txtThanhTien.Text = thanhtien.ToString();
                }
            }
        }

        private void DrvCTHD_DataSourceChanged(object sender, EventArgs e)
        {
            CapNhatThanhTien();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            //int masp = int.Parse(drvCTHD.CurrentRow.Cells[1].Value.ToString());
            ////string masp = drvCTHD.CurrentRow.Cells[1].Value.ToString();
            //CT_HDBAN ct_hdb = new CT_HDBAN();
            //if (banhangdal.XoaCT_HDB(masp))
            //{
            //    drvCTHD.DataSource = ct_hdb;
            //    MessageBox.Show("Thanh cong");

            //    //txtMaMH.Focus();
            //}
            //else
            //{
            //    MessageBox.Show("That bai");
            //}
            //drvCTHD.DataSource = banhangdal.loadCT_HDB(int.Parse(txtMaHDB.Text));  
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {

            SANPHAM sp = new SANPHAM();
            for (int i = 0; i < drvCTHD.Rows.Count; i++)
            {
                string masp = drvCTHD.Rows[i].Cells[1].Value.ToString();
                string soluongban = drvCTHD.Rows[i].Cells[2].Value.ToString();
                int soluongton = Convert.ToInt32(txtSoLuongTon.Text);
                //sp.SoLuongTon = soluongton - (Convert.ToInt32(soluongban));

                if (banhangdal.UpdateSanPham(Convert.ToInt32(masp), (soluongton - (Convert.ToInt32(soluongban)))) == 1)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("That bai");
                }

            }
            drvDsSP.DataSource = banhangdal.LoadSanPham();
        }

        private void BtnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
       
            cboKH.DataSource = banhangdal.LoadKhachHang();
            cboKH.DisplayMember = "TenKH";
            cboKH.ValueMember = "MaKH";
        }
    }
}