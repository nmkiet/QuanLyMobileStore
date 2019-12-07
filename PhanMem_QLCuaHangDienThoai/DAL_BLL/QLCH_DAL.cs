using System.Collections.Generic;
using System.Linq;

namespace DAL_BLL
{
    public class QLCH_DAL
    {
        QLCHDataContext QLCH = new QLCHDataContext();


        public QLCH_DAL()
        {
        }
        // Load data cho datagridview NhaCungCap
        public List<NHACUNGCAP> LoadDataGridNhaCungCap()
        {
            return QLCH.NHACUNGCAPs.Select(t => t).ToList<NHACUNGCAP>();
        }
        //Luu Thong tin nha cung cap 
        public int LuuThongTinNCC(NHACUNGCAP ncc)
        {
            try
            {
                QLCH.NHACUNGCAPs.InsertOnSubmit(ncc);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Xoa thong tin nha cung cap
        public int XoaThongTinNhaCungCap(int mancc)
        {
            NHACUNGCAP mh = QLCH.NHACUNGCAPs.Where(t => t.MaNCC == mancc).FirstOrDefault();
            try
            {
                QLCH.NHACUNGCAPs.DeleteOnSubmit(mh);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //Sua thong tin nha cung cap
        public int SuaThongTinNhaCungCap(int mancc, string tenncc, string dienthoai, string email, string diachi)
        {
            try
            {
                NHACUNGCAP ncc = QLCH.NHACUNGCAPs.Where(t => t.MaNCC == mancc).Single();
                ncc.TenNCC = tenncc;
                ncc.SdtNCC = dienthoai;
                ncc.Email = email;
                ncc.DiaChi = diachi;
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Load DataGridView Nhân Viên
        public List<NHANVIEN> LoadDataGridNhanVien()
        {
            return QLCH.NHANVIENs.Select(t => t).ToList<NHANVIEN>();
        }

        //Luu thông tin nhân viên
        public int LuuThongTinNhanVien(NHANVIEN nv)
        {
            try
            {
                QLCH.NHANVIENs.InsertOnSubmit(nv);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Sửa Thông tin Nhân viên
        public int SuaThongTinNhanVien(int manv, string tennv, string diachi, string ngaysinh, string sodienthoai)
        {
            try
            {
                NHANVIEN nv = QLCH.NHANVIENs.Where(t => t.MaNV == manv).Single();
                nv.TenNV = tennv;
                nv.DiaChiNV = diachi;
                nv.NgaySinh = ngaysinh;
                nv.SdtNV = sodienthoai;
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Xoa thong tin nhan vien
        public int XoaThongTinNhanVien(int manv)
        {
            NHANVIEN nv = QLCH.NHANVIENs.Where(t => t.MaNV == manv).FirstOrDefault();
            try
            {
                QLCH.NHANVIENs.DeleteOnSubmit(nv);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Load combobox Thuong Hiệu
        public List<THUONGHIEU> LoadCbnThuongHieu()
        {
            return QLCH.THUONGHIEUs.Select(t => t).ToList<THUONGHIEU>();
        }

        //Load DataGridView San pham
        public List<SANPHAM> LoadDataGridSanPham()
        {
            return QLCH.SANPHAMs.Select(t => t).ToList<SANPHAM>();
        }

        //Luu thong tin san pham
        public int LuuThongTinSanPham(SANPHAM sp)
        {
            try
            {
                QLCH.SANPHAMs.InsertOnSubmit(sp);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Xoa thong tin san pham
        public int XoaThongTinSanPhamn(int masp)
        {
            SANPHAM sp = QLCH.SANPHAMs.Where(t => t.MaSP == masp).FirstOrDefault();
            try
            {
                QLCH.SANPHAMs.DeleteOnSubmit(sp);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Sua thong tin san pham
        public int SuaThongTinSanPham(int masp, string tensp, int dongianhap, int dongiaban, int soluongton, string mota, int mathuonghieu)
        {
            try
            {
                SANPHAM sp = QLCH.SANPHAMs.Where(t => t.MaSP == masp).Single();
                sp.TenSP = tensp;
                sp.DonGiaNhap = dongianhap;
                sp.DonGiaBan = dongiaban;
                sp.SoLuongTon = soluongton;
                sp.MoTa = mota;
                sp.MaThuongHieu = mathuonghieu;
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
