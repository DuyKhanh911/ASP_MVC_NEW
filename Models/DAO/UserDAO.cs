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
        // Theem moi
        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }
        public void DeleteObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Remove(obj);
        }
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
        public User GetusID(int id)
        {
            return mydb.Users.Where(c => c.ID == id).FirstOrDefault();
        }
        public List<User> GetListUser() {
            return mydb.Users.ToList();
        }
        public IEnumerable<User> ListAll(int page, int pageSize) {
           return mydb.Users.OrderByDescending(c => c.CreatedDate).ToPagedList(page, pageSize);
        }
    }
}
