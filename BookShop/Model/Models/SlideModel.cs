using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Models
{
    public class SlideModel
    {
        public long ID { get; set; }
        public long BookID { get; set; }
        public string Image { get; set; }


        public bool Status { get; set; }
        public string NameBook { get; set; }

    }
}