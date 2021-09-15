using Models.DAO;
using Models.EF;
using SaleWeb.Common;
using System.Web.Mvc;
using System.Web.Security;
//
using System.ComponentModel.DataAnnotations;


namespace SaleWeb.Areas.Admin.Controllers
{
    public class HomeController : BaseController
   //Ktr đang nhap 
   // public class HomeController : Controller
    {
        UserDAO mydb = new UserDAO();
        OnlineShopDBContext mydb1 = new OnlineShopDBContext();
        // GET: Admin/Home
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;         

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            //  // 5. Trả về các Link được phân trang theo kích thước và số trang.
            // var model = mydb1.Users.OrderByDescending(m => m.ID).ToPagedList(page ?? 1, 5);
            var model = mydb.ListAll(pageNumber, pageSize);
            return View(model);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(User us)
        {
            if (ModelState.IsValid) {
                UserDAO IQ = new UserDAO();
                User use = new User();
                use.UserName = us.UserName;
                use.Password = Encrytor.MD5Hash(us.Password);
                use.Name = us.Name;
                use.Address = us.Address;
                use.Email = us.Email;
                use.Phone = us.Phone;
                use.Status = us.Status;
                IQ.AddObject(use);
                IQ.Save();
                // Thành công chuyển đến trang index
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult delete(int id)
        {
           
            User link = mydb.GetusID(id);
            mydb.DeleteObject(link);
            mydb.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id) {
            var us = mydb.GetusID(id);
            return View(us);
        }
        //Edit
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var IQ = new UserDAO();
                var use = IQ.GetusID(user.ID);

                if (use != null)
                {
                    use.Name = user.Name;
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        use.Password = Encrytor.MD5Hash(user.Password);
                    }
                    else
                    {
                        //var getpass = IQ.getPasss(use.ID, use.Password);
                        use.Password = use.Password;
                    }
                    
                    use.Name = user.Name;
                    use.Address = user.Address;
                    use.Email = user.Email;
                    use.Phone = user.Phone;
                    use.Status = user.Status;
                    IQ.Save();
                    // Thành công chuyển đến trang index
                    return RedirectToAction("Index");
                }
            }
            return View("Edit");
        }
        //LOGOUT
        public ActionResult logout() {
            Session["uslogin"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}