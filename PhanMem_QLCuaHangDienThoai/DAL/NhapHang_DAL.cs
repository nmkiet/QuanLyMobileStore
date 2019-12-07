using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;


namespace DAL
{
    public class NhapHang_DAL
    {

        QLCHDataContext QLCH = new QLCHDataContext();

        public NhapHang_DAL()
        {
        }
        //Load ComboBox San Pham
        public List<SANPHAM> LoadCbSanPham()
        {
            return QLCH.SANPHAMs.Select(t => t).ToList<SANPHAM>();
        }


        //Load Thoong tin nha cung caps
        public List<NHACUNGCAP> LoadCbNhaCUngCap()
        {
            return QLCH.NHACUNGCAPs.Select(t => t).ToList<NHACUNGCAP>();
        }

        //Load thong tin nhan vien
        public List<NHANVIEN> LoadCbNhanVien()
        {
            return QLCH.NHANVIENs.Select(t => t).ToList<NHANVIEN>();
        }

        //Luu Thong Tin Hóa Đơn
        public int LuuThongTinHoaDon(HOADONNHAP hdn)
        {
            try
            {
                QLCH.HOADONNHAPs.InsertOnSubmit(hdn);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        // Lay ma Hoa Don 
        public string LayMaHoaDon()
        {
            int max1 = 0;
            int max2 = 0;
            var ma1 = from p in QLCH.HOADONNHAPs
                      select new
                      {
                          p.MaHDN
                      };

            foreach (var i in ma1)
            {
                if (max2 < i.MaHDN)
                {
                    max2 = i.MaHDN;
                }
            }
            if (max1 == max2 || max1 > max2)
                return (max1).ToString();
            return (max2).ToString();
        }

        //Laa thong tin san pham do len cac textbox
        public void LayThongTinSanPham(string masp, TextEdit tensp, TextEdit dongianhap, TextEdit dongiaban, TextEdit mota, TextEdit thuonghieu, TextEdit soluongton)
        {
            var ban = (from p in QLCH.SANPHAMs
                       select new
                       {
                           p.MaSP,
                           p.TenSP,
                           p.DonGiaNhap,
                           p.DonGiaBan,
                           p.MoTa,
                           p.MaThuongHieu,
                           p.SoLuongTon
                       }).ToList();
            foreach (var p in ban)
            {
                if (p.MaSP.ToString().Trim() == masp.ToString())
                {
                    tensp.Text = p.TenSP.Trim();
                    dongianhap.Text = p.DonGiaNhap.ToString().Trim();
                    dongiaban.Text = p.DonGiaBan.ToString().Trim();
                    mota.Text = p.MoTa.ToString().Trim();
                    thuonghieu.Text = p.MaThuongHieu.ToString().Trim();
                    soluongton.Text = p.SoLuongTon.ToString().Trim();
                }
            }
        }
        //Luu Chi tiet don Hang
        public int LuuChiTietNhapHang(CT_HDNHAP ct)
        {
            try
            {
                QLCH.CT_HDNHAPs.InsertOnSubmit(ct);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //public int LuuSanPham(SANPHAM sp)
        //{
        //    try
        //    {
        //        QLCH.SANPHAMs.InsertOnSubmit(sp);
        //        QLCH.SubmitChanges();
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
        //sp.MaSP = Convert.ToInt32(masp);
        //        sp.TenSP = tensp;
        //        sp.DonGiaNhap = Convert.ToInt32(dongianhap);
        //        sp.DonGiaBan = Convert.ToInt32(dongiaban);
        //        sp.SoLuongTon = (Convert.ToInt32(txtSoLuongTon.Text) + (Convert.ToInt32(soluongnhap)));
        //        sp.MoTa = txtMoTa.Text;
        //        sp.MaThuongHieu = Convert.ToInt32(mathuonghieu);
        //Update San Pham 
        public int UpdateSanPham(int masp, int soluong, int dongianhap, int dongiaban)
        {

            try
            {
                SANPHAM sp = QLCH.SANPHAMs.Where(t => t.MaSP == masp).Single();
                sp.SoLuongTon = soluong;
                sp.DonGiaNhap = dongianhap;
                sp.DonGiaBan = dongiaban;
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        // Huy hoa don
        public int XoaHoaDonNhap(int mahdn)
        {
            HOADONNHAP hdn = QLCH.HOADONNHAPs.Where(t => t.MaHDN == mahdn).FirstOrDefault();
            try
            {
                QLCH.HOADONNHAPs.DeleteOnSubmit(hdn);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Update thanh tien trong bang hoa don
        public int UpdateThanhTienHD(int mahdn, int thanhtien)
        {

            try
            {
                HOADONNHAP hd = QLCH.HOADONNHAPs.Where(t => t.MaHDN == mahdn).Single();
                hd.ThanhTienHDN = thanhtien;
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
