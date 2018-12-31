namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name="Tên sách")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Tác giả")]
        public string Author { get; set; }

        [StringLength(50)]
        [Display(Name = "Nhà phát hành")]
        public string Released { set; get; }

        [StringLength(50)]
        [Display(Name = "Nhà xuất bản")]
        public string NXB { set; get; }

        public int Buys { set; get; }

        [Display(Name = "Trọng lượng")]
        public int Weight { set; get; }

        [StringLength(20)]
        [Display(Name = "Hình thức")]
        public string Form { get; set; }


        [Display(Name = "Số trang")]
        public int? NumberPage { get; set; }


        [Display(Name = "Ngày phát hành")]
        public DateTime PublishDate { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Nội dung giới thiệu sách")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh sách")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string Modelmage { get; set; }

        [Display(Name = "Giá bán")]
        public decimal? Price { get; set; }

        [Display(Name = "Giá gốc")]
        public decimal? PromotionPrice { get; set; }


        [Display(Name = "Thể loại sách")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool? Status { get; set; }

        [Display(Name = "Giảm giá đến ngày")]
        public DateTime? TopHot { get; set; }

        public int ViewCount { get; set; }
    }
}
