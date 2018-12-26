//Quản lý dịch vụ
//Author: Đậu Thị Kim Dung
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class DichVuDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();
        
        //Load danh sách các dịch vụ
        public static List<DichVuDTO> LoadDanhSach()
        {
            var query = (from t in context.DICH_VU

                         select new DichVuDTO
                         {
                             MaDichVu = t.MaDichVu,
                             TenDichVu = t.TenDichVu,
                             DonViTinh = t.DonViTinh,
                             DonGia = t.DonGia
                         });
            return query.ToList();
        }
       
        //Thêm dịch vụ
        public static bool ThemDichVu(DichVuDTO infor)
        {
            SqlParameter tendichvu = new SqlParameter("@TenDichVu", infor.TenDichVu);
            SqlParameter donvitinh = new SqlParameter("@DonViTinh", infor.DonViTinh);
            SqlParameter dongia = new SqlParameter("@DonGia", infor.DonGia);

            try
            {
                context.Database.ExecuteSqlCommand("spThemDichVu @TenDichVu, @DonViTinh, @DonGia",
                                    tendichvu, donvitinh, dongia);
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        //lấy đơn giá của dịch vụ
        public static List<DichVuDTO> LayDonGia(int maDichVu)
        {
            var query = (from t in context.DICH_VU
                         where t.MaDichVu == maDichVu
                         select new DichVuDTO
                         {
                             DonGia = t.DonGia
                         });
            return query.ToList();
        }
        
        //Sửa thông tin của dịch vụ
        public static bool SuaThongTinDichVu(DichVuDTO infor)
        {
            SqlParameter madichvu = new SqlParameter("@MaDichVu", infor.MaDichVu);
            SqlParameter tendichvu = new SqlParameter("@TenDichVu", infor.TenDichVu);
            SqlParameter donvitinh = new SqlParameter("@DonViTinh", infor.DonViTinh);
            SqlParameter dongia = new SqlParameter("@DonGia", infor.DonGia);

            try
            {
                context.Database.ExecuteSqlCommand("spSuaThongTinDichVu @MaDichVu, @TenDichVu, @DonViTinh, @DonGia",
                                    madichvu, tendichvu, donvitinh, dongia);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        //Xóa dịch vụ
        public static bool XoaDichVu(DichVuDTO infor)
        {
            SqlParameter madichvu = new SqlParameter("@MaDichVu", infor.MaDichVu);
            try
            {
                context.Database.ExecuteSqlCommand("spXoaDichVu @MaDichVu", madichvu);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
