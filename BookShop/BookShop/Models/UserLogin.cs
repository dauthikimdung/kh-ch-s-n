using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BookShop.Models
{
    public class UserLogin
    {
       // [Required(ErrorMessage ="Yêu cầu nhập Email")]
        public string email { set; get; }
       // [StringLength(maximumLength:20,MinimumLength =6,ErrorMessage ="Độ dài mật khẩu ít nhất 6 ký tự")]
       // [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string pass { set; get; }
    
       // [Compare("pass",ErrorMessage="Xác nhận mật khẩu không đúng")]
        public string confirmPass { set; get; }
    //    [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string name { set; get; }
        public string phone { set; get; }
        public string adress { set; get; }
        public DateTime? birthday { set; get; }

    }
}