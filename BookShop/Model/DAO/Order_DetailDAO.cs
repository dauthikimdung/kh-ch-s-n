using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Order_DetailDAO
    {
        BookShopDbContext db = null;
        public Order_DetailDAO()
        {
            db = new BookShopDbContext();
        }

        public bool Insert(Order_Detail detail)
        {
            try
            {
                db.Order_Detail.Add(detail);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
            
        }
    }
}
