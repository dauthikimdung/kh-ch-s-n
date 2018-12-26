//Quản lý các quy định
//Author:Đậu thị Thanh Huyền
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class ThamSoDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();
        
        // Load số lượng khách
        public static List<ThamSoDTO> LoadSoLuongKhach()
        {
            var query = (from ts in context.THAM_SO
                         select new ThamSoDTO
                         {
                             SLKhachToiDa = ts.SoKhachToiDa,
                         });
            return query.ToList();
        }

        //Load phụ thu
        public static List<ThamSoDTO> LoadPhuThu()
        {
            var query = (from ts in context.THAM_SO
                         select new ThamSoDTO
                         {
                             PhuThu = ts.PhuThu,
                         });
            return query.ToList();
        }

        //Cập nhật tham số phụ thu
        public static bool CapNhatTSPhuThu(ThamSoDTO infor)
        {
            SqlParameter phuthu = new SqlParameter("@PhuThu", infor.PhuThu);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSPhuThu @PhuThu", phuthu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Load đơn giá
        public static List<ThamSoDTO> LoadDonGia(string text)
        {
            var query = (from t in context.LOAI_PHONG

                         where t.TenLoaiPhong == text
                         select new ThamSoDTO
                         {
                             DonGia = t.DonGia,
                         });
            return query.ToList();
        }

        //Cập nhật tham số đơn giá
        public static bool CapNhatTSDonGia(ThamSoDTO ts, string t)
        {
            SqlParameter dongia = new SqlParameter("@DonGia", ts.DonGia);
            SqlParameter tenloaiphong = new SqlParameter("@TenLoaiPhong", t);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSDonGia  @TenLoaiPhong ,@DonGia "
                , dongia, tenloaiphong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // lấy thông tin tham số
        public static List<ThamSoDTO> LayThongTinTS()
        {
            var query = (from t in context.THAM_SO
                         select new ThamSoDTO
                         {
                             SLKhachToiDa = t.SoKhachToiDa,
                             HeSo = t.HeSo,
                             PhuThu = t.PhuThu
                         });
            return query.ToList();
        }

        //Cập nhật tham số hệ số
        public static bool CapNhatTSHeSo(ThamSoDTO infor)
        {
            SqlParameter heso = new SqlParameter("@HeSo", infor.HeSo);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSHeSo @HeSo", heso);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Cập nhật số khách tối đa
        public static bool CapNhatTSSoKhachToiDa(ThamSoDTO infor)
        {
            SqlParameter toida = new SqlParameter("@SoKhachToiDa", infor.SLKhachToiDa);
            try
            {
                context.Database.ExecuteSqlCommand("spCapNhatTSSoKhachToiDa @SoKhachToiDa", toida);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //load hệ số
        public static List<ThamSoDTO> LoadHeSo()
        {
            var query = (from ts in context.THAM_SO
                         select new ThamSoDTO
                         {
                             HeSo = ts.HeSo,
                         });
            return query.ToList();
        }
    }
}
