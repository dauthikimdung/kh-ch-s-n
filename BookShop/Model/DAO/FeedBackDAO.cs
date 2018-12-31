using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class FeedBackDAO
    {
        BookShopDbContext db = null;

        public FeedBackDAO()
        {
            db = new BookShopDbContext();
        }

        public void Insert(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
        }

    }
}
