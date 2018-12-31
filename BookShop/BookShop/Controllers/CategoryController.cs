using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace BookShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Category()
        {
            //  var model = new CategoryDao().ListAll();
            ViewBag.Category = new CategoryDAO().ListAll();
            ViewBag.BookCategory = new BookCategoryDAO().ListAll();
            //return PartialView(model);
            return PartialView();
        }

    }
}