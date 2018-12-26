// Đăng nhập
// Author:Nguyễn Phúc Hưng
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DangNhapDAO
    {
        static QUAN_LY_KHACH_SANEntities context = new QUAN_LY_KHACH_SANEntities();
        //Lấy thông tin của người dùng
        public static List<DangNhapDTO> LayThongTinNguoiDung()
        {
            var query = (from t in context.NGUOI_DUNG
                         select new DangNhapDTO
                         {
                             TenDangNhap = t.TenTaiKhoan,
                             MatKhau = t.MatKhau,

                         });
            return query.ToList();
        }
        //Đếm số lượng tài khoản
        public static int DemSoLuongTK()
        {
            int query = (from t in context.NGUOI_DUNG
                         select new DangNhapDTO
                         {

                         }).Count();
            return query;
        }
    }
}
