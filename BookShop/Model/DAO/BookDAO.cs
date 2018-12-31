using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
namespace Model.DAO
{

    public class BookDAO
    {
        BookShopDbContext db = null;

        public BookDAO()
        {
            db = new BookShopDbContext();
        }
        //Lay ra san pham theo danh muc
        public List<Book> ListByCategoryId(long cateID)
        {
            return db.Books.Where(x => x.CategoryID == cateID).ToList();
        }
        public IEnumerable<Book> ListByCategoryId(long cateID, int page, int pageSize)
        {
            return db.Books.Where(x => x.CategoryID == cateID).OrderByDescending(x => x.PublishDate).ToPagedList(page,pageSize);
        }



        //Lấy ra sản phẩm mới phát hành
        public List<Book> ListNewBook(int top)
        {
            return db.Books.Where(x => x.PublishDate < DateTime.Now).OrderByDescending(x => x.PublishDate).Take(top).ToList();
        }
        public IEnumerable<Book> ListNewBook(int page, int pageSize)
        {
            return db.Books.Where(x => x.PublishDate < DateTime.Now).OrderByDescending(x => x.PublishDate).ToPagedList(page,pageSize);
        }

        //Lấy ra sách sắp phát hành
        public List<Book> ListBookFuture(int top)
        {
            return db.Books.Where(x => x.PublishDate > DateTime.Now).OrderBy(x => x.PublishDate).Take(top).ToList();
        }
        public List<Book> ListBookFuture()
        {
            return db.Books.Where(x => x.PublishDate > DateTime.Now).OrderBy(x => x.PublishDate).ToList();
        }
        public IEnumerable<Book> ListBookFuture(int page, int pageSize)
        {
            IEnumerable<Book> model = db.Books;
            return model.Where(x => x.PublishDate > DateTime.Today).OrderByDescending(x => x.PublishDate).ToPagedList(page,pageSize);
        }
        public List<Book> ListNewBook()
        {
            return db.Books.Where(x => x.PublishDate < DateTime.Now).OrderByDescending(x => x.PublishDate).ToList();
        }
        public IEnumerable<Book> ListTopBuys(int page,int pageSize)
        {
            return db.Books.Where(x => x.Status == true).OrderByDescending(x => x.Buys).ToPagedList(page,pageSize);
        }
        public List<Book> ListTopBuys()
        {
            return db.Books.Where(x => x.Status == true).OrderByDescending(x => x.Buys).ToList();
        }
        //Lay ra sach cung tác gia
        public List<Book>ListAuthor(string au)
        {
            return db.Books.Where(x => x.Author == au).OrderByDescending(x => x.Buys).ToList();
        }
   


        public Book ViewDetail(long id)
        {
            return db.Books.Find(id);
        }

        public List<Book> ListViewMax(int top)
        {
            return db.Books.OrderByDescending(x => x.ViewCount).Take(top).ToList();
        }

        public void UpdateView(long id)
        {
            try
            {
                var entity = new Book();
                entity.ID = id;
                var book = db.Books.Find(entity.ID);

                book.ViewCount++;
                entity.ViewCount = book.ViewCount;
                db.SaveChanges();

            }
            catch (Exception ex)
            { }

        }

        //Cập nhất lại số lượt mua của sách sau khi thanh toán thành công
        public void UpdateBuys(long id)
        {
            try
            {
                var entity = new Book();
                entity.ID = id;
                var book = db.Books.Find(entity.ID);
                book.Buys++;//Tăng số lượt mua lên một đơn vị
                entity.Buys = book.Buys;//lưu vào cơ sở dữ liệu
                db.SaveChanges();
            }
            catch (Exception e) { }
        }

        public List<Book> ListCategoryBook(long cate)
        {
            var model = db.Books.Where(x => x.CategoryID == cate).OrderByDescending(x => x.PublishDate).ToList();
            return model;
        }

        public List<Book> ListAll()
        {
            return db.Books.Where(x => x.Status == true).OrderByDescending(x => x.PublishDate < DateTime.Now).ToList();
        }
        
    

        //Lấy ra danh sách sản phẩm có cùng tác giả
        public List<Book> ListAsAuthor(string Author)
        {
            return db.Books.Where(x => x.Author == Author).Take(4).ToList();
        }
       // Lấy ra sách cùng the loai
       public List<Book> ListAsCategory(long ?cateid)
        {
            return db.Books.Where(x => x.CategoryID == cateid).Take(4).ToList();
        }


     /*       public List<Book> ListAsAuthor(string author)
        {
            return db.Books.Where(x => x.Author == author).Take(6).ToList();
        }

        //lấy ra sách có cùng thể loại
        public List<Book> ListAsCategory(long? cate)
        {
            return db.Books.Where(x => x.CategoryID == cate).Take(6).ToList();
        }
        */

        //phần danh mục
        public List<Book> CateGory(long CateBookID)
        {
            return db.Books.Where(x => x.CategoryID == CateBookID).OrderByDescending(x => x.PublishDate).ToList();
        }



    /*    public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Books.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Books
                         join b in db.BookCategories
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreateDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }*/


        //Lấy ra nhà phát hành
        public List<Book> Release(string release)
        {
            return db.Books.Where(x => x.Released == release).OrderByDescending(x => x.PublishDate).ToList();
        }

        //Lấy ra tất cả các tác giả
        public List<string> AllAuthor()
        {
            var Au = (from b in db.Books
                      select b.Author).Distinct();
            return Au.ToList();
        }

        //Lấy ra tất cả các nhà phát hành
        public List<string> allRelease()
        {
            var release = (from b in db.Books
                           select b.Released).Distinct();
            return release.ToList();

        }

        //Lấy ra hình thức sách
        public List<string> Form()
        {
            var listForm = new List<string>();
            listForm.Add("Bìa mềm");
            listForm.Add("Bìa cứng");

            return listForm;
        }
        //Tìm kiếm sách
        public List<string> ListName(string search)
        {
     
            var ls = (from x in db.Books
                      where x.Name.Contains(search)
                      select x.Name).ToList();
            var lsAuthor = (from x in db.Books
                            where x.Author.Contains(search)
                            select x.Author).AsEnumerable();
         
            var lsRealed = (from x in db.Books
                            where x.Released.Contains(search)
                            select x.Released).AsEnumerable();
            ls.AddRange(lsAuthor);
            ls.AddRange(lsRealed);
            return ls;



         
        }
        //Phân trang trong admin
        public IEnumerable<Book> listBookPage(string searchString, int page, int pagesize)
        {
            IQueryable<Book> model = db.Books;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.PublishDate < DateTime.Now).ToPagedList(page, pagesize);
        }

        //Xóa trong admin
        public bool DeleteBook(long id)
        {
            try
            {
                var book = db.Books.Find(id);
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Sửa thông tin sách
        public bool EditBook(Book entity)
        {
            try
            {
                var book = db.Books.Find(entity.ID);
                book.Name = entity.Name;
                book.Author = entity.Author;
                book.Released = entity.Released;
                book.NXB = entity.NXB;
                book.Weight = entity.Weight;
                book.Form = entity.Form;
                book.NumberPage = entity.NumberPage;
                book.PublishDate = entity.PublishDate;
                book.MetaTitle = Str_Metatitle(entity.Name);
                book.Description = entity.Description;
                book.Image = entity.Image;
                book.Price = entity.Price;
                book.PromotionPrice = entity.PromotionPrice;
                book.CategoryID = entity.CategoryID;
                book.TopHot = entity.TopHot;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Thêm sách
        public bool addBook(Book entity)
        {
            try
            {
                var book = new Book();
                book.Name = entity.Name;
                book.Author = entity.Author;
                book.Released = entity.Released;
                book.NXB = entity.NXB;
                book.Weight = entity.Weight;
                book.Form = entity.Form;
                book.NumberPage = entity.NumberPage;
                book.PublishDate = entity.PublishDate;
                book.MetaTitle = Str_Metatitle(entity.Name);
                book.Description = entity.Description;
                book.Image = entity.Image;
                book.Price = entity.Price;
                book.PromotionPrice = entity.PromotionPrice;
                book.CategoryID = entity.CategoryID;
                book.CreateDate = DateTime.Now;
                book.TopHot = entity.TopHot;
                book.Status = true;

                db.Books.Add(book);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
                
           
        }

        //Chuyển tên sách thành metatitle
        public string Str_Metatitle(string str)
        {
            string[] VietNamChar = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ:"                
            };
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            string str1 = str.ToLower();
           string[] name = str1.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            string meta = null; 
            //Thêm dấu '-'
           foreach(var item in name)
            {
                meta = meta + item + "-";
            }
            return meta;
        }
    }
}
