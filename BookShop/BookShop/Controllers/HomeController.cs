using BookShop.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private const string CartSession = "CartSession";
        // GET: Home
        public ActionResult Index()
        {
            var bookDao = new BookDAO();
            ViewBag.NewBook = bookDao.ListNewBook(10);//lấy ra những sản phẩm mới phát hành
            ViewBag.BookFuture = bookDao.ListBookFuture(5);//Lấy ra sản phẩm sắp phát hành
            ViewBag.BookView = bookDao.ListTopBuys();//Lấy ra sản phẩm bán chạy
                                                      //ViewBag.BookViewLeft = bookDao.ListViewMax(3);//lấy ra 3 thằng đầu
                                                      //hiển thị giỏ        
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);                         //  ViewBag.ViewCategory = new CategoryDAO().ViewImage();

           
        }
        public ActionResult gioithieu()
        {
           
            //  ViewBag.ViewCategory = new CategoryDAO().ViewImage();

            return View();
        }
        public ActionResult Lienhe()
        {

            //  ViewBag.ViewCategory = new CategoryDAO().ViewImage();

            return View();
        }


        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDAO().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult TopMenu()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDAO().GetFooter();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Slides()
        {
          //  var model = new SlideDAO().ListAll();
            ViewBag.slide = new SlideDAO().ListAll();
            ViewBag.Book = new BookDAO().ListAll();
            return PartialView();
        }
      
        //Lấy ra sách mới phát hành
        public ActionResult NewBook(int page=1, int pageSize=4)
        {
            var book = new BookDAO();
           var model = book.ListNewBook(page,pageSize);//lấy ra những sản phẩm mới phát hành
    
         
            return View(model);
        }
        public ActionResult FutureBook(int page=1,int pageSize=4)
        {
            var book = new BookDAO();
            //      ViewBag.FutureBook = book.ListBookFuture();
            var model = book.ListBookFuture(page, pageSize);
            return View(model);
        }
        public ActionResult BookBuys(int page = 1, int pageSize = 4)
        {
            var book = new BookDAO();
            var model = book.ListTopBuys(page,pageSize);
            return View(model);
          
          
        }
        public ActionResult theloai(long cateID ,int page = 1, int pageSize = 4)
        {
            var book = new BookDAO();
            var model = book.ListByCategoryId(cateID, page, pageSize);
            ViewBag.bookcategory = new BookCategoryDAO().ViewDetail(cateID);
            return View(model);




         //   ViewBag.book = new BookDAO().ListByCategoryId(cateID);
        
           // return View();


        }
    }
}