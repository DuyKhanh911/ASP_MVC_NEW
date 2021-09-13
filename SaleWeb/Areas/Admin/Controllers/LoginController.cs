using Models.DAO;
using SaleWeb.Areas.Admin.Models;
using SaleWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaleWeb.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encrytor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var userIDSession = dao.UserID(model.UserName);
                    var usersession = new UserLogin();
                    usersession.UserName = userIDSession.UserName;
                    usersession.UserID = userIDSession.ID;
                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    //Session["uslogin"] = result;
                    return RedirectToAction("Index", "Home");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tk or mk sai");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "tk bi khoa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "mk khong dung");
                }
                else
                {
                    ModelState.AddModelError("", "dang nhap khong dung");
                }
            }
            return View("Index");
        }
    }
}