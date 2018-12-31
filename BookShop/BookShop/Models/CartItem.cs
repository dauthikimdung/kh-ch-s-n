using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class CartItem
    {
        public Book Book { set; get; }
        public int Quantity { set; get; }
    }
}