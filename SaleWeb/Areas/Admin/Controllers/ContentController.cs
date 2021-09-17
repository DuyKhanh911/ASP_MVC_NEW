using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaleWeb.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create() {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult create(Content model) {
            if (ModelState.IsValid) {

            }
            SetViewBag();
            return View();
        }

        public ActionResult edit(long id)
        {
            var dao = new ContentDAO();
            var getID = dao.GetByID(id);
            SetViewBag(getID.CategoryID);
            return View();
        }

        [HttpPost]
        public ActionResult edit(Content model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(model.CategoryID);
            return View();
        }
        // Lấy ra tên thuộc tính của khóa ngoại dạng danh sách
        public void SetViewBag(long? selectId=null) {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.listall(),"ID","Name",selectId);
        }
    }
}