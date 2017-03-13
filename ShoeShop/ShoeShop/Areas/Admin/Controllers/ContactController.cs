using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Admin/Contact
        public ActionResult Index()
        {
            var dao = new Admin_ContactDao();
            var model = dao.ListAllContact();
            return View(model);
        }



        [HttpPost]
        public ActionResult Edit(Contact product)
        {
            if (ModelState.IsValid)
            {
                var model = new Admin_ContactDao();
                var result = model.Update(product);
                if (result)
                    return RedirectToAction("Index", "Contact");
                else
                    ModelState.AddModelError("", "Cập nhật không thành công");
            }

            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            var contact = new Admin_ContactDao().ViewContact(id);
            return View(contact);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new Admin_ContactDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact pd)
        {
            if (ModelState.IsValid)
            {
                var dao = new Admin_ContactDao();
                bool id = dao.Insert(pd);
                if (id)
                    return RedirectToAction("Index", "Contact");
                else
                    ModelState.AddModelError("", "Thêm Liên Hệ không thành công");
            }

            return View("Index");
        }
    }
}
