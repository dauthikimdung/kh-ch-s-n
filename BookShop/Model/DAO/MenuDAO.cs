using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDAO
    {
        BookShopDbContext db = null;
        public MenuDAO()
        {
            db = new BookShopDbContext();
        }

        //Lấy ra menu chính theo typeID
        //  public List<Menu> ListByGroupID(int groupID)
        //   {
        //  return db.Menus.Where(x => x.TypeID == groupID).OrderBy(x => x.DisplayOrder).ToList();
        //  }
        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }


    }
}
