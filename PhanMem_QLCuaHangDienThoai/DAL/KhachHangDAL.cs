using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        QLCHDataContext QLCH = new QLCHDataContext();
        public KhachHangDAL()
        { }


        //Load thông tin khách hang
        public List<KHACHHANG> LoadDataGridKhachHang()
        {
            return QLCH.KHACHHANGs.Select(t => t).ToList<KHACHHANG>();
        }
        //Luu thong tin khách hang
        public int LuuThongTinKhachHang(KHACHHANG kh)
        {
            try
            {
                QLCH.KHACHHANGs.InsertOnSubmit(kh);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Xóa Thông tin khách hang
        public int XoaHoaThongTinKhachHnag(int makh)
        {
            KHACHHANG kh = QLCH.KHACHHANGs.Where(t => t.MaKH == makh).FirstOrDefault();
            try
            {
                QLCH.KHACHHANGs.DeleteOnSubmit(kh);
                QLCH.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //Sua thông tin khách hàng
        public int SuaThongTinKhachHang(int makh, string tenkh, string diachi, string sodienthoai)
        {
            try
            {
                KHACHHANG kh = QLCH.KHACHHANGs.Where(t => t.MaKH == makh).Single();
                kh.TenKH = tenkh;
                kh.DiaChi = diachi;
                kh.SdtKH = sodienthoai;
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
