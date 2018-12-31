using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ProductViewModel
    {
        public long ID { get; set; }

        
        public string Name { get; set; }

     
        public string Author { get; set; }

        
        public string Released { set; get; }

      
        public string NXB { set; get; }

        public int Buys { set; get; }

      
        public int Weight { set; get; }
       
        public string Form { get; set; }


    
        public int? NumberPage { get; set; }


     
        public DateTime PublishDate { get; set; }

 
        public string code { get; set; }

     
        public string MetaTitle { get; set; }
        
        public string Description { get; set; }

        public string Image { get; set; }

      
        public string Modelmage { get; set; }

     
        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }


     
        public long? CategoryID { get; set; }

      
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

 
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

      
        public string ModifiedBy { get; set; }

     
        public string MetaKeyword { get; set; }

  
        public string MetaDescription { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int ViewCount { get; set; }
    }
}
