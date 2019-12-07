using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BanHang_DAL
    {
        QLCHDataContext db = new QLCHDataContext();

        public BanHang_DAL() { }

        //load thuong hieu
        public List<THUONGHIEU> LoadThuongHieu()
        {
            return db.THUONGHIEUs.Select(t => t).ToList<THUONGHIEU>();
        }

        //load san pham
        public List<SANPHAM> LoadSanPham()
        {
            return db.SANPHAMs.Select(t => t).ToList<SANPHAM>();
        }

        //load drv Danh sach sp theo Thuong hieu
        public List<SANPHAM> LoadDsSpFromThuongHieu(string pMaThuongHieu)
        {
            return db.SANPHAMs.Where(t => Convert.ToString(t.MaThuongHieu) == pMaThuongHieu).Select(t => t).ToList<SANPHAM>();
        }

        //Load cbo Nhan vien
        public List<NHANVIEN> LoadNhanVien()
        {
            return db.NHANVIENs.Select(t => t).ToList<NHANVIEN>();
        }

        //Load cbo Khach hang
        public List<KHACHHANG> LoadKhachHang()
        {
            return db.KHACHHANGs.Select(t => t).ToList<KHACHHANG>();
        }

        //================Hóa đơn bán=========================
        public List<HOADONBAN> loadHDB()
        {
            return db.HOADONBANs.Select(t => t).ToList<HOADONBAN>();
        }

        public Boolean ThemHD(HOADONBAN hdb)
        {
            try
            {
                db.HOADONBANs.InsertOnSubmit(hdb);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetMaHDB()
        {
            int max1 = 0;
            int max2 = 0;
            var ma1 = from p in db.HOADONBANs
                      select new
                      {
                          p.MaHDB
                      };

            foreach (var i in ma1)
            {
                if (max2 < i.MaHDB)
                {
                    max2 = i.MaHDB;
                }
            }
            if (max1 == max2 || max1 > max2)
                return (max1).ToString();
            return (max2).ToString();
        }

        //===========CT_HoaDonBan =======================
        public List<CT_HDBAN> loadCT_HDB(int pMaHDB)
        {
            return db.CT_HDBANs.Where(t => t.MaHDB == pMaHDB).Select(t => t).ToList<CT_HDBAN>();
        }

        public Boolean ThemCT_HDB(CT_HDBAN ct_hdb)
        {
            try
            {
                db.CT_HDBANs.InsertOnSubmit(ct_hdb);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean XoaCT_HDB(int pMaSP)
        {
            try
            {
                //CT_HDBAN ct_hdb = db.CT_HDBANs.Where(t => Convert.ToString(t.MaSP) == pMaSP).FirstOrDefault();
                CT_HDBAN ct_hdb = db.CT_HDBANs.Where(t => t.MaSP == pMaSP).FirstOrDefault();

                db.CT_HDBANs.DeleteOnSubmit(ct_hdb);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        // Update so luong san pham
        public int UpdateSanPham(int masp, int soluong)
        {
            try
            {
                SANPHAM sp = db.SANPHAMs.Where(t => t.MaSP == masp).Single();
                sp.SoLuongTon = soluong;
                db.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }



    }
}
