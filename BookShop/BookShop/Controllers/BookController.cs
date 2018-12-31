using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(long id)
        {
            var book = new BookDAO().ViewDetail(id);
            ViewBag.Book = new BookDAO().ViewDetail(id);
            new BookDAO().UpdateView(book.ID);
            var cate = new BookCategoryDAO().ViewDetail(book.CategoryID.Value);
            ViewBag.CategoryDetail = new CategoryDAO().ViewDetail(cate.ParentID.Value);
            ViewBag.BookDetail = cate;
            ViewBag.AsAuthor = new BookDAO().ListAsAuthor(book.Author);
            ViewBag.AsCategory = new BookDAO().ListAsCategory(book.CategoryID);
            return View();
        }

        //   public PartialViewResult CategoryBook()
        // {
        //   ViewBag.Category = new CategoryDAO().ListAll();
        // ViewBag.BookCategory = new BookCategoryDAO().ListAll();
        //return PartialView();
        //  }
        public ActionResult CategoryBook(long id)
        {
            var category = new BookCategoryDAO().ViewDetail(id);
            ViewBag.Category = category;
            var Categorychild = new BookDAO().ListByCategoryId(id);
            ViewBag.Categorychild = Categorychild;
            return View();
        }
        /*   public ActionResult CategoryParent(long id)
           {
               BookShopDbContext db = new BookShopDbContext();
               var category = new CategoryDAO().ViewDetail(id);
               ViewBag.Category = category;
               List<Book> AllBookOfCategoryParent = new List<Book>();
               var Categorychild = new BookCategoryDAO().ListBookCategory(id);
               ViewBag.Categorychild = Categorychild;

               foreach (var item in Categorychild)

               {
                   var model = (from b in db.Books
                                              join a in Categorychild
                                              on b.CategoryID equals a.ID
                                              select new CategoryParent
                                              {
                                                  ID = b.ID,
                                                  Name = b.Name,
                                                  Author = b.Author,
                                                  Released = b.Author,
                                                  NXB = b.NXB,
                                                  Buys = b.Buys,
                                                  Weight = b.Weight,
                                                  Form = b.Form,
                                                  NumberPage = b.NumberPage,
                                                  PublishDate = b.PublishDate,
                                                  code = b.code,
                                                  MetaTitle = b.MetaTitle,
                                                  Description = b.Description,
                                                  Image = b.Image,
                                                  Modelmage = b.Modelmage,
                                                  Price = b.Price,
                                                  PromotionPrice = b.PromotionPrice,
                                                  Detail = b.Detail,
                                                  CreateDate = b.CreateDate,
                                                  CreateBy = b.CreateBy,
                                                  ModifiedDate = b.ModifiedDate,
                                                  ModifiedBy = b.ModifiedBy,
                                                  MetaKeyword = b.MetaKeyword,
                                                  MetaDescription = b.MetaDescription,
                                                  Status = b.Status,
                                                  TopHot = b.TopHot,
                                                  ViewCount = b.ViewCount,

       }).ToList();   
               }

               return View(model);
           }

               */
     /*   public JsonResult ListName(string q)
        {
            var data = new BookDAO().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        */
        public ActionResult FutureBookDetail(long id)
        {
            var book = new BookDAO().ViewDetail(id);
            ViewBag.Book = new BookDAO().ViewDetail(id);
            new BookDAO().UpdateView(book.ID);
            var cate = new BookCategoryDAO().ViewDetail(book.CategoryID.Value);
            ViewBag.CategoryDetail = new CategoryDAO().ViewDetail(cate.ParentID.Value);
            ViewBag.BookDetail = cate;
            ViewBag.AsAuthor = new BookDAO().ListAsAuthor(book.Author);
            ViewBag.AsCategory = new BookDAO().ListAsCategory(book.CategoryID);
            return View();
        }

        //Sách cùng tác giả
        public ActionResult Author(string au)
        {
            var book = new BookDAO();
            ViewBag.Book = book.ListAuthor(au);
            ViewBag.NameAuthor = au;
            return View();
       
        }
        // sách cũng nhà phát hành
        public ActionResult Release(string re)
        {
            var book = new BookDAO();
            ViewBag.Book = book.Release(re);
            ViewBag.NameRelease = re;
            return View();

        }

      //  Lấy ra tất cả tác giả
     public ActionResult AllAuthor()
        {
            var book = new BookDAO();
        
            ViewBag.allAuthor = book.AllAuthor();//lấy ra tất cả các tác giả

            var Author = book.AllAuthor();
            var listAu = new List<Book>();
            var list = new List<Book>();
            foreach (var item in Author)
            {
                listAu = book.ListAuthor(item);//Lấy ra sách có cùng nhà phát hành
                foreach (var itemRe in listAu)
                {
                    list.Add(itemRe);
                }
            }
            ViewBag.CountAuthor = list;//Lấy ra số lượng sách cho
            return View();
        }

        //Sách cùng nhà phát hành
        /*public ActionResult Release(string re)
        {
            var book = new BookDAO();
            ViewBag.BookViewLeft = book.ListViewMax(3);//lấy ra 3 thằng đầu
            ViewBag.Release = book.Release(re);
            ViewBag.NameRe = re;
            return View();
        }*/

        //Tất cả nhà phát hành
        public ActionResult AllRelease()
        {
            var book = new BookDAO();
            ViewBag.BookViewLeft = book.ListViewMax(3);//lấy ra 3 thằng đầu            
            ViewBag.allRelease = book.allRelease();
            var all = book.allRelease();
            var listRelease = new List<Book>();
            var list = new List<Book>();
            foreach (var item in all)
            {
                listRelease = book.Release(item);//Lấy ra sách có cùng nhà phát hành
                foreach (var itemRe in listRelease)
                {
                    list.Add(itemRe);
                }
            }
            ViewBag.CountBook = list;//Lấy ra số lượng sách cho
            return View();
        }
        
        //Hàm tìm kiếm sách
        public JsonResult ListName(string q)
        {
            var data = new BookDAO().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

          public ActionResult Search(string keyword )
            {
                BookShopDbContext db = new BookShopDbContext();
                var book = new BookDAO();
              //  ViewBag.BookViewLeft = book.ListViewMax(3);//lấy ra 3 thằng đầu
            //    string[] key = keyword.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] key = keyword.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            List<Book> author = new List<Book>();//Tìm theo tác giả
                List<Book> Book_Name = new List<Book>();//Tìm theo tên sách
                List<Book> Release = new List<Book>();//Tìm theo nhà phát hành
                foreach (var item in key)
                {
                    author = (from b in db.Books
                              where b.Author.Contains(item)
                              select b).ToList();

                    Book_Name = (from b in db.Books
                                 where b.Name.Contains(item)
                                 select b).ToList();

                    Release = (from b in db.Books
                               where b.Released.Contains(item)
                               select b).ToList();
                }
                ViewBag.KeyWord = keyword;
                ViewBag.Author = author;
                ViewBag.Name = Book_Name;
                ViewBag.Release = Release;

                return View();
            }
            
   /*     public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new BookDAO().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        */

    }
}