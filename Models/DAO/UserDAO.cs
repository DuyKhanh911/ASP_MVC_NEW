using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
   public class UserDAO
    {
        OnlineShopDBContext mydb = new OnlineShopDBContext();
        /// <summary>
        /// THÊM MỚI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }
        //XÓA
        public void DeleteObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Remove(obj);
        }
        //LƯU XUỐNG DB
        public void Save() {
            mydb.SaveChanges();
        }
        /// <summary>
        /// KIEM TRA DANG NHAP CÁCH 2
        /// </summary>
        public User Login2(String us, String pass)
        {
           return mydb.Users.Where(c => c.UserName == us && c.Password == pass).FirstOrDefault();
        }
        /// <summary>
        /// KIEM TRA DANG NHAP CÁCH 1
        /// </summary>
        public int Login(string us, string pass) {
            // var result = mydb.Users.Count(c => c.UserName == us && c.Password == pass);
            var result = mydb.Users.SingleOrDefault(c => c.UserName == us);
            if (result == null)
            {
                return -3;
            }
            else {
                if (result.Status == false) {
                    return -1;
                }
                else {
                    if (result.UserName == us && result.Password == pass)
                    {
                        return 1;
                    }
                    else {
                        return -2;
                    }
                }
            }
        }
        public User UserID(string username) {
            return mydb.Users.Where(c => c.UserName == username).FirstOrDefault();
        }
        //tìm user qua ID= nếu ID kiểu int thì dùng hàm find
        public User GetusID(long id)
        {
            return mydb.Users.Find(id);
        }
        /// <summary>
        /// lấy ra danh sách list
        /// </summary>
        /// <returns></returns>
        public List<User> GetListUser() {
            return mydb.Users.ToList();
        }
        //hàm phân trang
        public IEnumerable<User> ListAll(int page, int pageSize) {
           return mydb.Users.OrderByDescending(c => c.ID).ToPagedList(page, pageSize);
        }
        //UPDATE => KHông cần viết vẫn đc , chỉ cẩn gọi id ra ds rồi save lại thôi
        //public bool update(User us)
        //{
        //    try
        //    {
        //        var userid = mydb.Users.Find(us.ID);
        //        userid.Name = us.Name;
        //        userid.Address = us.Address;
        //        userid.Phone = us.Phone;
        //        userid.Status = us.Status;
        //        Save();
        //        return true;

        //    }
        //    catch(Exception ex) {
        //        return false;
        //    }
        //}
        /// <summary>
        /// GET PASS
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public User getPasss(long id, string pass) {
            return mydb.Users.Where(c => c.ID == id && c.Password == pass).FirstOrDefault();
        }
        public bool ChangeStatus(long id) {
            var stus = mydb.Users.Find(id);
            stus.Status = !stus.Status;
            return stus.Status;
        }
    }

}
