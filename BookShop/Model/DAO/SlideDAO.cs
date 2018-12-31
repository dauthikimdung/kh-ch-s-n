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
    public class SlideDAO
    {
        BookShopDbContext db = null;

        public SlideDAO()
        {
            db = new BookShopDbContext();
        }

        /*   public List<Slide> ListAll()
           {
               return db.Slides.ToList();
           }
           */
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public Slide FindID(long id)
        {
            return db.Slides.Find(id);
        }
      

        //Phân trang trong admin
        public IEnumerable<SlideModel> listSlidePage(string search, int page, int pagesize)
        {
            
            var slide = (from a in db.Slides
                         join b in db.Books
                         on a.BookID equals b.ID
                         select new SlideModel
                         {
                             ID = a.ID,
                             Image = a.Image,
                             Status = a.Status,
                             NameBook = b.Name


                         });

            if(!string.IsNullOrEmpty(search))
            {

                slide = slide.Where(x => x.NameBook.Contains(search));

            }
            return slide.OrderByDescending(x => x.NameBook).ToPagedList(page, pagesize);
        }

        //Lấy tên sách theo banner
        public List<Book> ListSlide_Book(long BookID)
        {
            return db.Books.Where(x => x.ID == BookID).ToList();
        }

        //Sửa trạng thái Slide
        public bool ChangeStatus(long id)
        {
            var slide = db.Slides.Find(id);//tìm ra id
            slide.Status = !slide.Status;//khi click vào status nó sẽ đổi thành "kích hoạt" or "khóa" tùy thuộc vào trạng thái ban đầu
            db.SaveChanges();
            return slide.Status;
        }

        //Sửa slide
        public bool EditSlide(Slide entity)
        {
            try
            {
                var slide = new Slide();
                slide.Image = entity.Image;
                slide.BookID = entity.BookID;                
                slide.CreatedDate = DateTime.Now;
                slide.Status = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Thêm slide
        public bool AddSlide(Slide entity)
        {
            try
            {
                var slide = new Slide();
                slide.BookID = entity.BookID;
                slide.CreatedDate = DateTime.Now;
                slide.DisplayOrder = 1;
                slide.Image = entity.Image;
                slide.Status = true;
                db.Slides.Add(slide);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xóa slide
        public bool DeleteSlide(long id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
