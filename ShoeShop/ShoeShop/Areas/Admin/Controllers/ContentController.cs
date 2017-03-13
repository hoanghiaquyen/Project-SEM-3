using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            var dao = new Admin_ContentDao();
            var model = dao.ListAllContent();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Content ct)
        {
            if (ModelState.IsValid)
            {
                var model = new Admin_ContentDao();
                var result = model.Update(ct);
                if (result)
                    return RedirectToAction("Index", "Content");
                else
                    ModelState.AddModelError("", "Cập nhật không thành công");
            }

            return View("Index");
        }



        [HttpPost]
        public ActionResult Create(Content ca)
        {
            var dao = new Admin_ContentDao();
            ca.CreatedDate = DateTime.Now;
            ca.ModifiedBy = "Admin";
            ca.Status = true;
            bool id = dao.Insert(ca);
            if (id)
                return RedirectToAction("Index", "Content");
            else
                ModelState.AddModelError("", "Thêm Content không thành công");

            return View("Index");
        }



        public ActionResult Edit(long id)
        {
            var ca = new Admin_ContentDao().ViewDetail(id);
            return View(ca);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new Admin_ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}