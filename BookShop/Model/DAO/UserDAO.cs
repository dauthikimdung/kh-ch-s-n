using Model.EF;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;
namespace Model.DAO
{
    public class UserDAO
    {
        BookShopDbContext db = null;

        public UserDAO()
        {
            db = new BookShopDbContext();
        }

        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }

        public bool Insert(User user)
        {
            try
            {
                user.Status = true;
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckEmail(string email)
        {
         
            return db.Users.Count(x => x.Email == email) > 0;
        }


        public int CheckLogin(string email, string pass)
        {
            if (db.Users.Count(x => x.Email == email) <= 0)
            {
                return -1;
            }
            else if (db.Users.Count(x => x.Password == pass) <= 0)
            {
                return 0;
            }

            return 1;
        }

        public User Find_Email(string email)
        {
            return db.Users.SingleOrDefault(x => x.Email == email);
        }

        public bool Check_Exits_Email(string email)
        {
            using (WebClient webclient = new WebClient())
            {
                string url = "http://verify-email.org/";
                NameValueCollection formdata = new NameValueCollection();
                formdata["check"] = email;
                byte[] responsebyte = webclient.UploadValues(url, "POST", formdata);
                string reponse = Encoding.ASCII.GetString(responsebyte);
                if (reponse.Contains("Result: Ok"))
                    return true;
                return false;
            }
        }

        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.Email == entity.Email);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }
        }

        //Phân trang trong admin
        public IEnumerable<User> listUserPage(string searchString, int page, int pagesize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))// nếu chuỗi tìm kiếm mà khác rỗng
            {
                model = model.Where(x => x.Name.Contains(searchString)); // tìm chuỗi thì dùng contains để tìm gần đúng
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pagesize);
        }

        //Sửa trạng thái người dùng
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);//tìm ra id
            user.Status = !user.Status;//khi click vào status nó sẽ đổi thành "kích hoạt" or "khóa" tùy thuộc vào trạng thái ban đầu
            db.SaveChanges();
            return user.Status;
        }

        //Sửa thông tin người dùng
        public bool EditUser(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.Adress = entity.Adress;
                user.Status = entity.Status;
                user.Password = entity.Password;
                user.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteUser(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Thêm người dùng
        public bool AddUser(User entity)
        {
            try
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Checkemail(string Email)
        {
            return db.Users.Count(x => x.Email == Email) > 0;
        }
    }
}
