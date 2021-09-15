using Models.DAO;
using Models.EF;
using SaleWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SaleWeb.Areas.Admin.Controllers
{
   // public class HomeController : BaseController
   //Ktr đang nhap 
    public class HomeController : Controller
    {
        UserDAO mydb = new UserDAO();
        OnlineShopDBContext mydb1 = new OnlineShopDBContext();
        // GET: Admin/Home
        public ActionResult Index(int page =1, int pageSize = 4)
        {
            var model = mydb.ListAll(page, pageSize);
           List<User> UsList = mydb.GetListUser();
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
            User us = mydb.GetusID(id);
            return View(us);
        }
        //Edit
        [HttpPost]
        public ActionResult editus(int id)
        {
            if (ModelState.IsValid)
            {
                UserDAO IQ = new UserDAO();
                var use = IQ.GetusID(id);
                User us = new User();

                if (use != null)
                {
                    us.UserName = use.UserName;
                    //use.Password = Encrytor.MD5Hash(useri.Password);
                    //use.Name = useri.Name;
                    //use.Address = useri.Address;
                    //use.Email = useri.Email;
                    //use.Phone = useri.Phone;
                    //use.Status = useri.Status;
                    IQ.Save();
                    // Thành công chuyển đến trang index
                    return RedirectToAction("Index");
                }
            }
            return View("Edit");
        }

    }
}