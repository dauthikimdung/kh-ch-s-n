namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        public DateTime? DayOfBirth { get; set; }


        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
     
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string Adress { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}
